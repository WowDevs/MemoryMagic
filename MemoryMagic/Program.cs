using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace MemoryMagic
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            //Environment.CurrentDirectory = EmbeddedDllClass.dirName;
            //EmbeddedDllClass.ExtractEmbeddedDlls("fasmdll_managed.dll", Properties.Resources.fasmdll_managed);
            //EmbeddedDllClass.LoadDll("fasmdll_managed.dll");

            //AppDomain.CurrentDomain.AssemblyResolve += (sender, args) =>
            //{
            //    var thisAssembly = Assembly.GetExecutingAssembly();

            //    if (args.Name.Contains("fasmdll"))
            //        return null;

            //    //Get the Name of the AssemblyFile
            //    var name = args.Name.Substring(0, args.Name.IndexOf(',')) + ".dll";
                
            //    //Load form Embedded Resources - This Function is not called if the Assembly is in the Application Folder
            //    var resources = thisAssembly.GetManifestResourceNames().Where(s => s.EndsWith(name));
            //    var enumerable = resources as IList<string> ?? resources.ToList();
            //    if (!enumerable.Any()) return null;

            //    var resourceName = enumerable.First();
            //    using (var stream = thisAssembly.GetManifestResourceStream(resourceName))
            //    {
            //        if (stream == null) return null;
            //        var block = new byte[stream.Length];
            //        stream.Read(block, 0, block.Length);
            //        return Assembly.Load(block);
            //    }
            //};

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());
        }
    }
}