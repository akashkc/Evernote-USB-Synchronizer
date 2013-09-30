using System;

namespace EvernoteUSBSyncLib.Models
{

    public class Item
    {
        /// <summary>
        /// Gets or Sets FileName
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Gets or sets Location
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets Size
        /// </summary>
        public long Size { get; set; }

        /// <summary>
        /// Gets or sets CreationDate
        /// </summary>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Gets or sets LastModifiedTime
        /// </summary>
        public DateTime LastModifiedDate { get; set; }

    }
}
