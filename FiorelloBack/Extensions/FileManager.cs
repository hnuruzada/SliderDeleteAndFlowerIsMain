using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace FiorelloBack.Extensions
{
    public static class FileManager
    {
        public static bool IsImage(this IFormFile file)
        {
            return file.ContentType.Contains("image/");
        }
        public static bool IsSizeOkay(this IFormFile file, int mb)
        {
            return file.Length / 1024 / 1024 <= mb;
        }

        public static string SaveImg(this IFormFile file, string root, string folder)
        {
            string rootPath = Path.Combine(root, folder);
            string fileName = Guid.NewGuid().ToString() + file.FileName;
            string fullPath = Path.Combine(rootPath, fileName);
            using (FileStream fileStream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
            return fileName;
        }
    }
}
