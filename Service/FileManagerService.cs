using System;
using System.Configuration;
using System.Drawing;
using System.IO;
using Omu.Drawing;
using Omu.ProDinner.Core.Service;

namespace Omu.ProDinner.Service
{
    public class FileManagerService : IFileManagerService
    {
        private readonly string mealsPath = @ConfigurationManager.AppSettings["storagePath"] + "/meals/";
        private readonly string tempPath;

        public FileManagerService()
        {
            tempPath = mealsPath + "temp/";
        }

        public void MakeImages(string filename, int x, int y, int w, int h)
        {
            using (var image = Image.FromFile(tempPath + filename))
            {
                var img = Imager.Crop(image, new Rectangle(x, y, w, h));
                var resized = Imager.Resize(img, 200, 150, true);
                var small = Imager.Resize(img, 100, 75, true);
                var mini = Imager.Resize(img, 45, 34, true);
                Imager.SaveJpeg(mealsPath + filename, resized);
                Imager.SaveJpeg(mealsPath + "s" + filename, small);
                Imager.SaveJpeg(mealsPath + "m" + filename, mini);
            }
        }

        public string SaveJpeg(Stream inputStream, out int w, out int h)
        {
            var g = Guid.NewGuid() + ".jpg";
            var filePath = tempPath + g;
            using (var image = Image.FromStream(inputStream))
            {
                var resized = Imager.Resize(image, 640, 480, true);
                Imager.SaveJpeg(filePath, resized);

                w = resized.Width;
                h = resized.Height;
                return g;
            }
        }
    }
}