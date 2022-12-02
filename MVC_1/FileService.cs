namespace MVC_1
{
    public class FileService : BackgroundService
    {
       
        IWebHostEnvironment hostEnvironment;

        public FileService(IWebHostEnvironment hostEnvironment)
        {
            this.hostEnvironment = hostEnvironment;
        }

       
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            string PngPath = Path.Combine(hostEnvironment.WebRootPath, "PNGFiles");
            string JPEGPath = Path.Combine(hostEnvironment.WebRootPath, "JPEGFiles");
            
            Directory.CreateDirectory(PngPath);
            Directory.CreateDirectory(PngPath);

            // string[] fileExtension = null;
            string[] filePaths = Directory.GetFiles(Path.Combine(hostEnvironment.WebRootPath, "ReceivedFiles"));
            
            foreach(var item in filePaths)
            {
                string fileName = Path.GetFileName(item);
                string fileExtension = Path.GetExtension(item);

                if(fileExtension == ".png")
                {
                    string saveToPath = Path.Combine(PngPath, fileName);

                    using (FileStream stream = new FileStream(saveToPath, FileMode.Create))
                    {
                        
                        IFormFile file;
                       file.CopyToAsync(stream);
                    }

                }
            }

        }
    }
}
