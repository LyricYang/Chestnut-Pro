namespace Chestnut_Pro.Service
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    /// File Utils
    /// </summary>
    public class FileUtils
    {
        /// <summary>
        /// Read JSON File
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static dynamic ReadJsonFile(string path)
        {
            using (var streamReader = File.OpenText(path))
            {
                var json = streamReader.ReadToEnd();
                dynamic data = JsonConvert.DeserializeObject(json);
                return data;
            }
        }


        /// <summary>
        /// Get file content
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static IEnumerable<string> GetFileContent(string path)
        {
            using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                using (var sr = new StreamReader(fs))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        yield return line;
                    }
                }
            }
        }

        /// <summary>
        /// Write content to file
        /// </summary>
        /// <param name="folder"></param>
        /// <param name="file"></param>
        /// <param name="content"></param>
        public static void WriteTextToFile(string folder, string file, List<string> content)
        {
            if (Directory.Exists(folder))
            {
                File.WriteAllLines(folder + file, content);
            }
        }
    }
}