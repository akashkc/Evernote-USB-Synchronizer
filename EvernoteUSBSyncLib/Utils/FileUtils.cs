using System.IO;
using EvernoteUSBSyncLib.Constants;

namespace EvernoteUSBSyncLib.Utils
{
    public static class FileUtils
    {
        /// <summary>
        /// Checks whether source file is most updated than target file or not.
        /// </summary>
        /// <param name="sourceFile"></param>
        /// <param name="targetFile"></param>
        /// <returns></returns>
        public static bool IsEvernoteTargetFileMostUpdated(string sourceFile, string targetFile)
        {
            // Checks whether file is evernote main file which has extension exb
            if (File.Exists(targetFile) && targetFile.EndsWith(Evernote.Database.MainFile))
            {
                // if the source modified time is less than target filename, 
                // throw UpdatedFileAlreadyExist
                if (File.GetCreationTime(targetFile) > File.GetCreationTime(sourceFile))
                    return true;
            }
            return false;
        }
    }
}
