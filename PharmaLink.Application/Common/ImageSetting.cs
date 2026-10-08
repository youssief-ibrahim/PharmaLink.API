using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaLink.Application.Common
{
    public static class ImageSetting
    {
        public static readonly List<string> AllowedExtensions = new()
        {
        ".jpg", ".jpeg", ".png"
         };

        public const long MaxSize = 5 * 1024 * 1024; // 5MB
    }
}
