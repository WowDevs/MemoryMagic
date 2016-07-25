using System;

namespace MemoryMagic
{
    public static class Offsets
    {
        // http://www.ownedcore.com/forums/world-of-warcraft/world-of-warcraft-bots-programs/wow-memory-editing/563526-wow-7-0-3-22293-release-info-dump-thread.html

        public static IntPtr Framescript_ExecuteBuffer = new IntPtr(0xA6739);       
        public static IntPtr ClntObjMgrGetActivePlayerObj = new IntPtr(0x81722);      
        public static IntPtr GameState = new IntPtr(0xE55A49);                      
        public static IntPtr FrameScript__GetLocalizedText = new IntPtr(0x30095B);  
        public static IntPtr PlayerNameOffset = new IntPtr(0xF34E20);               
    }
}