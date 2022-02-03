using Newtonsoft.Json;

namespace HomeWork8
{
    internal class ConfigService : IConfigService
    {
        public string GetDirectoryName()
        {
            Directory nameDirectory = new Directory();
            try
            {
                string pathFileConfig = @"C:\Users\User\source\repos\MalynOl\Mod2HW4\HomeWork8\Config\ConfigFolder.json";
                var configFileText = File.ReadAllText(pathFileConfig);
                nameDirectory = JsonConvert.DeserializeObject<Directory>(configFileText);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return nameDirectory.FolderName;
        }
    }
}
