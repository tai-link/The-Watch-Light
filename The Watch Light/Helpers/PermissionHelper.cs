using Microsoft.Maui.ApplicationModel;

namespace The_Watch_Light.Helpers
{
    class PermissionHelper : Permissions.BasePermission
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

        // This method checks if current status of the permission.
        public override Task<PermissionStatus> CheckStatusAsync()
        {
            throw new System.NotImplementedException();
        }

        // This method is optional and a PermissionException is often thrown if a permission is not declared.
        public override void EnsureDeclared()
        {
            throw new System.NotImplementedException();
        }

        // Requests the user to accept or deny a permission.
        public override Task<PermissionStatus> RequestAsync()
        {
            throw new System.NotImplementedException();
        }

        // Indicates that the requestor should prompt the user as to why the app requires the permission, because the
        // user has previously denied this permission.
        public override bool ShouldShowRationale()
        {
            throw new NotImplementedException();
        }
    }
}
