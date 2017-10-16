using System;
using System.Runtime.Serialization;

namespace SoftwareLicenseServer.WebService.BL
{
    [Serializable]
    [DataContract]
    public class Auth
    {
        [DataMember]
        public bool IsAuthorized { get; set; }

        [DataMember]
        public DateTime ExpirationDate { get; set; }

        public Auth()
        {
            IsAuthorized = false;
        }
    }
}