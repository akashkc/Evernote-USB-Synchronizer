using System;

namespace EvernoteUSBSyncLib.CustomExceptions
{
    class EvernoteLocalDatabaseFolderNotFoundException : Exception
    {
        public EvernoteLocalDatabaseFolderNotFoundException() : base("Evernote Local Database Folder Not Found")
        {
            
        }
    }
}
