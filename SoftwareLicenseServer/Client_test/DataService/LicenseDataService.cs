using Client_CONNECTOR.ServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client_CONNECTOR.DataService
{
    class LicenseDataService
    {
        private LicenseServiceClient _client;

        public LicenseDataService()
        {
            this._client = new LicenseServiceClient();
        }

        public AuthResponse GetAuthorization(AuthRequest authRequest)
        {
            return this._client.GetAuthorization(authRequest);
        }

        public byte[] DownloadLicense(AuthRequest authRequest)
        {
            return this._client.DownloadLicense(authRequest);
        }
    }
}
