using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EvernoteUSBSyncLib.Constants
{ 

	/// <summary>
	/// Constant value for Evernote folder location
	/// </summary>
    public class EvernoteFolderLocation
    {
        public static string LocalAppLocation
        {
            get
            {
                return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"Evernote\Evernote\Databases");
            }
        }
        public static string DesktopAppLocation
        {
            get
            {
                return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), DatabaseFolderName);
            }
        }

        public static string DatabaseFolderName
        {
            get { return "Databases"; }
        }
    }
}
