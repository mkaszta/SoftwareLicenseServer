﻿using SoftwareLicenseServer.WebService.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using static SoftwareLicenseServer.Models.LicensingModels;

namespace SoftwareLicenseServer.WebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ILicenseService" in both code and config file together.
    [ServiceContract]
    public interface ILicenseService
    {
        [OperationContract]
        AuthResponse GetAuthorization(AuthRequest authRequest);

        [OperationContract]
        byte[] DownloadLicense(AuthRequest authRequest);
    }
}
