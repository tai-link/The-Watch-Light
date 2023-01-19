using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Watch_Light.Services
{
    internal class LocationService : IGeolocation
    {
        public Task<Location> GetLastKnownLocationAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Location> GetLocationAsync(GeolocationRequest request, CancellationToken cancelToken)
        {
            throw new NotImplementedException();
        }
    }
}
