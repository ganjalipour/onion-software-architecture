using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Consulting.Common.Utility.Extentions
{
   public static class DirectoryExtentions
    {
        public static void DeleteDirectories (this DirectoryInfo directory)
        {
            foreach(var dir in directory.GetDirectories())
            {
                dir.Delete(true); 
            }
        }

        public static void DeleteFiles(this DirectoryInfo directory)
        {
            foreach (var file in directory.GetFiles())
            {
                file.Delete();
            }
        }


        


    }
}
