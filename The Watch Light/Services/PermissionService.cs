using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Watch_Light.Services
{
    internal class PermissionService
    {
        public async Task<PermissionStatus> CheckAndRequestLocationPermission()
        {
            PermissionStatus status = await Permissions.CheckStatusAsync<Permissions.LocationAlways>();

            if (status == PermissionStatus.Granted)
                return status;

            if (status == PermissionStatus.Denied && DeviceInfo.Platform == DevicePlatform.iOS)
            {
                if (status != PermissionStatus.Granted)
                    await Shell.Current.DisplayAlert("Permission required",
                        "Location permission is required. Please turn it on in settings. ", "OK");
                // Prompt the user to turn on in settings
                // On iOS once a permission has been denied it may not be requested again from the application
                return status;
            }

            if (Permissions.ShouldShowRationale<Permissions.LocationAlways>())
            {
                await Shell.Current.DisplayAlert("Permission required",
                       "Location permission is required to find you.", "OK");
            }

            status = await Permissions.RequestAsync<Permissions.LocationAlways>();

            return status;
        }
    }
}
