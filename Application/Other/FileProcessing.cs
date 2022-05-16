using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Application.Other
{
    public static class FileProcessing
    {
        public static string SaveFile(IFormFile file)
        {
            var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "File", fileName);
            using var stream = new FileStream(filePath, FileMode.Create);
            file.CopyTo(stream);
            return fileName;
        }

        public static void RemoveFile(string fileName)
        {

            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "File", fileName);
            if (File.Exists(path))
            {
                File.Delete(path);
            }

        }
    }
}
