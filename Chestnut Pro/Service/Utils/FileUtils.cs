namespace Chestnut_Pro.Service
{
    using Newtonsoft.Json;
    using System.IO;

    public class FileUtils
    {
        public static dynamic ReadJsonFile(string path)
        {
            using (var streamReader = File.OpenText(path))
            {
                var json = streamReader.ReadToEnd();
                dynamic data = JsonConvert.DeserializeObject(json);
                return data;
            }
        }
    }
}