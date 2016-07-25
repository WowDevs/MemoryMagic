using System.Text;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedMember.Global

namespace MemoryMagic
{
    public class Lua
    {
        private readonly Hook _wowHook;

        public Lua(Hook wowHook)
        {
            _wowHook = wowHook;
        }

        public void DoString(string command)
        {
            if (!_wowHook.Installed) return;

            // Allocate memory
            var doStringArgCodecave = _wowHook.Memory.AllocateMemory(Encoding.UTF8.GetBytes(command).Length + 1);
            // Write value:
            _wowHook.Memory.WriteBytes(doStringArgCodecave, Encoding.UTF8.GetBytes(command));

            // Write the asm stuff for Lua_DoString
            var asm = new[]
            {
                "mov eax, " + doStringArgCodecave,
                "push 0",
                "push eax",
                "push eax",
                "mov eax, " + ((uint) Offsets.Framescript_ExecuteBuffer + _wowHook.Process.BaseOffset()),
                "call eax",
                "add esp, 0xC",
                "retn"
            };
            // Inject
            _wowHook.InjectAndExecute(asm);
            // Free memory allocated 
            _wowHook.Memory.FreeMemory(doStringArgCodecave);
        }

        public string GetLocalizedText(string localVar)
        {
            if (!_wowHook.Installed) return "WoW Hook not installed";

            var Lua_GetLocalizedText_Space = _wowHook.Memory.AllocateMemory(Encoding.UTF8.GetBytes(localVar).Length + 1);

            _wowHook.Memory.Write(Lua_GetLocalizedText_Space, Encoding.UTF8.GetBytes(localVar));

            var asm = new[]
            {
                "call " + ((uint) Offsets.ClntObjMgrGetActivePlayerObj + + _wowHook.Process.BaseOffset()),
                "mov ecx, eax",
                "push -1",
                "mov edx, " + Lua_GetLocalizedText_Space + "",
                "push edx",
                "call " + ((uint) Offsets.FrameScript__GetLocalizedText + _wowHook.Process.BaseOffset()),
                "retn"
            };

            var sResult = Encoding.UTF8.GetString(_wowHook.InjectAndExecute(asm));

            // Free memory allocated 
            _wowHook.Memory.FreeMemory(Lua_GetLocalizedText_Space);
            return sResult;
        }

        public void SendTextMessage(string message)
        {
            DoString("RunMacroText('/me " + message + "')");
        }

        public void CastSpellByName(string spell)
        {
            DoString($"CastSpellByName('{spell}')");
        }

        public double DebuffRemainingTime(string debuffName)
        {
            var luaStr = $"name, rank, icon, count, debuffType, duration, expirationTime, unitCaster, isStealable, shouldConsolidate, spellId = UnitAura('target','{debuffName}',nil,'HARMFUL')";
            DoString(luaStr);
            var result = GetLocalizedText("expirationTime");

            if (result == "")
                return 0;

            DoString("time = GetTime()");
            var currentTime = GetLocalizedText("time");

            var timeInSeconds = double.Parse(result) - double.Parse(currentTime);

            return timeInSeconds < 0 ? 0 : timeInSeconds;
        }
    }
}