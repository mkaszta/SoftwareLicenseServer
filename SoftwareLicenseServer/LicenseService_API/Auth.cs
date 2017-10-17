using System;
using System.Runtime.Serialization;

namespace LicenseService_API
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
