using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Watch_Light.Services
{
    internal class LocationService : IGeolocation
    {


        public async Task<Location> GetLastKnownLocationAsync()
        {
            return await Geolocation.Default.GetLastKnownLocationAsync();
        }

        public async Task<Location> GetLocationAsync(GeolocationRequest request, CancellationToken cancelToken)
        {
            return await Geolocation.Default.GetLocationAsync(request, cancelToken);
        }

        public async Task<Location> GetCurrentLocationAsync(CancellationToken cancelToken)
        {
            GeolocationRequest request = new GeolocationRequest(GeolocationAccuracy.Best, TimeSpan.FromSeconds(10));

            return await GetLocationAsync(request, cancelToken);
        }

    }
}
