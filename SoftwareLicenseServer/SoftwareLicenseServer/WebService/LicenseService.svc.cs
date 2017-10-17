﻿using SoftwareLicenseServer.WebService.BL;
using System.Collections.Generic;
using static SoftwareLicenseServer.Models.LicensingModels;
using System;

namespace SoftwareLicenseServer.WebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "LicenseService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select LicenseService.svc or LicenseService.svc.cs at the Solution Explorer and start debugging.
    public class LicenseService : ILicenseService
    {
        private AuthService _authService;

        public LicenseService()
        {
            _authService = new AuthService();
        }

        public byte[] DownloadFile(string fileName)
        {
            return this._authService.DownloadFile(fileName);
        }

        public AuthResponse GetAuthorization(AuthRequest authRequest)
        {
            return this._authService.GetAuthorization(authRequest);
        }        
    }
}
