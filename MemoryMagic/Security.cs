namespace MemoryMagic
{
    public static class Security
    {
        public static string UserEmail => ConfigFile.ReadValue("MemoryMagic", "UserEmail");
        public static string UserPassword => ConfigFile.ReadValue("MemoryMagic", "UserPassword");
    }
}
