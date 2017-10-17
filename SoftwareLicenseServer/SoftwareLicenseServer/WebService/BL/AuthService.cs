using SoftwareLicenseServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using static SoftwareLicenseServer.Models.LicensingModels;
using CipherAPI;
using System.IO;
using System.Web;

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

        public AuthResponse GetAuthorization(AuthRequest request)
        {
            AuthResponse response = new AuthResponse();
            Licenses license = new Licenses();
            int errorCounter = 0;

            try
            {
                license = this._lstLicenses.Where(l => AES.Decrypt(l.Lic_Key, "test") == AES.Decrypt(request.AppKey, "test")).FirstOrDefault();

                if (license != null)
                {
                    if (license.Lic_ActivationStatus != 1)
                    {
                        errorCounter += 1;
                        response.Details.Add(string.Format("License hasn't been activated yet. "));
                    }

                    if (license.Lic_ExpirationDate < DateTime.Today)
                    {
                        errorCounter += 1;
                        response.Details.Add(string.Format("License has expired on {0}. ", license.Lic_ExpirationDate.ToShortDateString()));
                    }

                    if (license.Contractors.Ctr_NIP != request.OwnersNIP)
                    {
                        errorCounter += 1;
                        response.Details.Add(string.Format("Provided NIP number is invalid for this license. "));
                    }

                    if (license.Apps.App_Acronym != request.AppName)
                    {
                        errorCounter += 1;
                        response.Details.Add(string.Format("The license key is not intended to this application."));
                    }
                    else
                    {
                        if (license.Apps.App_Version != request.AppVersion)
                        {
                            errorCounter += 1;
                            response.Details.Add(string.Format("The license key is not intended to this version of {0}.", request.AppName));                            
                        }
                    }
                }
                else
                {
                    errorCounter += 1;
                    response.Details.Add(string.Format("Provided key is invalid (license not found)."));
                }

                if (errorCounter == 0)
                {
                    response.IsAuthorized = true;
                    response.ExpirationDate = license.Lic_ExpirationDate;
                    response.Details.Add("Authorization successful.");
                }
                else
                {
                    response.IsAuthorized = false;
                }                
            }
            catch (Exception ex)
            {
                response.Details.Add(string.Format("There was an error getting authorization: {0}", ex.Message));                
            }

            return response;
        }

        public byte[] DownloadFile(string fileName)
        {
            string relativePath = HttpContext.Current.Server.MapPath("~/");

            FileStream fs = File.Open(string.Format("{0}/WebService/TestFiles/{1}", relativePath, fileName), FileMode.Open, FileAccess.Read);

            byte[] bytes = new byte[fs.Length];

            fs.Read(bytes, 0, (int)fs.Length);
            fs.Close();

            return bytes;
        }
    }
}