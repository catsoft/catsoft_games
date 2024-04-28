using System;
using System.Collections.Generic;

namespace App.cms.FilesHandlers
{
    public interface IZipHandler
    {
        public string GenerateZip(List<string> files);
    }
}