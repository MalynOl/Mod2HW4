using System.Text;
namespace HomeWork8
{
    public class FileService : IFileService
    {
        private readonly IConfigService _configService;
        private readonly INotificationService _notificationService;

        public FileService(IConfigService config, INotificationService notification)
        {
            _configService = config;
            _notificationService = notification;
        }

        public void WriteToFile(string str)
        {
            string path = _configService.GetDirectoryName();

            CheckCountFiles(path);

            string fileFullName = @$"{path}\{DateTime.Now:HH.mm.ss dd.MM.yyyy}.txt";
            try
            {
                using (StreamWriter sw = File.CreateText(fileFullName))
                {
                    sw.WriteLine(str);
                }
            }
            catch (Exception e)
            {
                _notificationService.WriteText(e.Message);
            }
        }

        public void CheckCountFiles(string directoryName)
        {
            var directory = new DirectoryInfo(directoryName);
            if (directory.Exists)
            {
                try
                {
                    FileInfo[] files = directory.GetFiles();
                    DateTime[] creationTimeMas = new DateTime[files.Length];

                    if (files.Length > 3)
                    {
                        for (int i = 0; i < files.Length; i++)
                        {
                            creationTimeMas[i] = files[i].CreationTime;
                        }

                        Array.Sort(creationTimeMas, files);

                        files[0].Delete();
                    }
                }
                catch (Exception ex)
                {
                    _notificationService.WriteText(ex.Message);
                }
            }
            else
            {
                directory.Create();
            }
        }
    }
}
