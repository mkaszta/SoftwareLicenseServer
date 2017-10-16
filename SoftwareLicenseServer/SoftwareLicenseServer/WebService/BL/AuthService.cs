using SoftwareLicenseServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static SoftwareLicenseServer.Models.LicensingModels;
using CipherAPI;

namespace SoftwareLicenseServer.WebService.BL
{
    public class AuthService
    {
        private ApplicationDbContext _dbContext;
        private IList<Licenses> _lstLicenses { get; set; }

        public AuthService()
        {
            this._dbContext = new ApplicationDbContext();
            this._lstLicenses = _dbContext.Licenses.ToList();
        }

        public Auth GetLicense(string appKey)
        {
            Auth auth = new Auth();
            Licenses license = new Licenses();

            license = this._lstLicenses.Where(l => l.Lic_Key == AES.Decrypt(appKey, "test")).FirstOrDefault();

            if (license != null)
            {
                if (license.Lic_ActivationStatus == 1 && license.Lic_ExpirationDate <= DateTime.Today)
                {
                    auth.IsAuthorized = true;
                }

                auth.ExpirationDate = license.Lic_ExpirationDate;
            }

            return auth;
        }

        public IList<Licenses> GetAllLicenses()
        {
            return this._lstLicenses;
        }
    }
}