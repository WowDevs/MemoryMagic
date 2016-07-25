namespace MemoryMagic
{
    public static class LuaStrings
    {
        public static string LoginLuaFormat =
            "if (WoWAccountSelectDialog and WoWAccountSelectDialog:IsShown()) then " +
            "for i = 0, GetNumGameAccounts() do " +
            "if GetGameAccountInfo(i) == '{2}' then " +
            "WoWAccountSelect_SelectAccount(i) " +
            "end " +
            "end " +
            "elseif (AccountLoginUI and AccountLoginUI:IsVisible()) then " +
            "DefaultServerLogin('{0}', '{1}') " +
            "AccountLoginUI:Hide() " +
            "elseif (RealmList and RealmList:IsVisible()) then " +
            "for i = 1, select('#',GetRealmCategories()) do " +
            "for j = 1, GetNumRealms(i) do " +
            "if GetRealmInfo(i, j) == '{3}' then " +
            "RealmList:Hide() " +
            "ChangeRealm(i, j) " +
            "end " +
            "end " +
            "end " +
            "elseif (CharacterSelectUI and CharacterSelectUI:IsVisible()) then " +
            "if GetServerName() ~= '{3}' and (not RealmList or not RealmList:IsVisible()) then " +
            "RequestRealmList(1) " +
            "else " +
            "for i = 0,GetNumCharacters() do " +
            "if (GetCharacterInfo(i) == '{4}') then " +
            "CharacterSelect_SelectCharacter(i) " +
            "EnterWorld() " +
            "end " +
            "end " +
            "end " +
            "end ";
    }
}