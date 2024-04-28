using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using App.cms.Repositories.File;
using Microsoft.AspNetCore.Hosting;

namespace App.cms.FilesHandlers.Zip
{
    public class ZipHandler(IWebHostEnvironment webHostEnvironment, ICmsFilesRepository cmsFilesRepository) : IZipHandler
    {
        public string GenerateZip(List<string> files)
        {
            var directory = webHostEnvironment.WebRootPath + "/GeneratedZips";
            Directory.CreateDirectory(directory);
            var zipFullPath = directory + Guid.NewGuid() + ".zip";

            using (var fileStream = new FileStream(zipFullPath, FileMode.CreateNew))
            {
                using (var archive = new ZipArchive(fileStream, ZipArchiveMode.Create, true))
                {
                    foreach (var file in files)
                    {
                        var fileLink = webHostEnvironment.WebRootPath + file;
                        if (File.Exists(fileLink))
                        {
                            archive.CreateEntryFromFile(fileLink, System.IO.Path.GetFileName(fileLink));
                        }
                    }
                }
            }

            return zipFullPath;
        }
    }
}