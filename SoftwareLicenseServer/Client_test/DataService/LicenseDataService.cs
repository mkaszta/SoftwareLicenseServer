using Client_test.ServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client_test.DataService
{
    class LicenseDataService
    {
        private LicenseServiceClient _client;

        public LicenseDataService()
        {
            this._client = new LicenseServiceClient();
        }

        public AuthResponse GetAuth(AuthRequest authRequest)
        {
            return this._client.GetAuthorization(authRequest);
        }

        public byte[] DownloadFile(string fileName)
        {
            return this._client.DownloadFile(fileName);
        }
    }
}
