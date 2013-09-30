using System.Collections.Generic;
using System.IO;
using System.Linq;
using EvernoteUSBSyncLib.Models;

namespace EvernoteUSBSyncLib.Utils
{
    public static class ItemConverter
    {
        public static List<Item> ConvertFileToItemList(this FileInfo[] files)
        {
            return files.Select(x => new Item
                {
                    FileName = x.Name,
                    Location = x.FullName,
                    Size = x.Length,
                    CreationDate = x.CreationTime,
                    LastModifiedDate = x.LastWriteTime
                }).ToList();
        }
    }
}
