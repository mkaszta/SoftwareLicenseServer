using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SoftwareLicenseServer.WebService.BL
{
    [Serializable]
    [DataContract]
    public class AuthResponse
    {
        [DataMember]
        public bool IsAuthorized { get; set; }

        [DataMember]
        public DateTime ExpirationDate { get; set; }

        [DataMember]
        public List<string> Details { get; set; }

        public AuthResponse()
        {
            this.IsAuthorized = false;
            this.Details = new List<string>();           
        }
    }
}