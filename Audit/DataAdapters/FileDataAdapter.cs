using System;
using System.IO;
using Newtonsoft.Json;

namespace Audit.DataAdapters
{
    public class FileDataAdapter : AuditDataAdapter
    {

        private string _filenamePrefix = string.Empty;
        private string _directoryPath = string.Empty;
       
        /// <summary>
        /// Gets or sets the Filename prefix that will be used.
        /// </summary>
        public string FilenamePrefix
        {
            get => _filenamePrefix;
            set => _filenamePrefix = value;
        }
        
        /// <summary>
        /// Gets or sets the Directory path to store the output files (default is current directory).
        /// </summary>
        public string DirectoryPath
        {
            get => _directoryPath;
            set => _directoryPath = value;
        }

        public override object InsertEvent(IAuditEvent auditEvent)
        {
            var fullPath = GetFilePath(auditEvent);
            var json = JsonConvert.SerializeObject(auditEvent, new JsonSerializerSettings() { Formatting = Formatting.Indented });
            File.WriteAllText(fullPath, json);
            return fullPath;
        }


        private string GetFilePath(IAuditEvent auditEvent)
        {
            string fileName = _filenamePrefix;

            fileName += $"{DateTime.Now:yyyyMMddHHmmss}.json";

            var directory = _directoryPath ?? string.Empty;

            if (directory.Length > 0)
            {
                Directory.CreateDirectory(directory);
            }
            return Path.Combine(directory, fileName);
        }
    }
}
