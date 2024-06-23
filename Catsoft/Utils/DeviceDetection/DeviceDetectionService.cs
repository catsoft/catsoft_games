using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Http;

namespace App.Utils.DeviceDetection
{
    public class DeviceDetectionService : IDeviceDetectionService
    {
        public bool IsMobileDevice(HttpContext context)
        {
            var userAgent = context.Request.Headers["User-Agent"].ToString();

            // A simple regex pattern to detect mobile User-Agent
            var mobilePattern = new Regex(@"Android|iPhone|iPad|iPod|BlackBerry|Opera Mini|IEMobile|WPDesktop", RegexOptions.IgnoreCase);

            return mobilePattern.IsMatch(userAgent);
        }
    }
}