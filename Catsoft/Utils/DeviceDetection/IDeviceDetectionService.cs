using Microsoft.AspNetCore.Http;

namespace App.Utils.DeviceDetection
{
    public interface IDeviceDetectionService
    {
        bool IsMobileDevice(HttpContext context);
    }
}