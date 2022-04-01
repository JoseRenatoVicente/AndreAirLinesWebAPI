using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace AndreAirLines.Client
{
    public static class ReadJson
    {
        public static List<Entity>? getData<Entity>(string pathFile)
        {
            if (File.Exists(pathFile))
                return JsonConvert.DeserializeObject<List<Entity>>(
                    new StreamReader(pathFile).ReadToEnd());

            return null;
        }
    }
}
