using System;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;

namespace SoftwareLicenseServer.WebService.BL
{
    [Serializable]
    [DataContract]
    public class AuthRequest
    {
        [DataMember]
        public string AppKey { get; set; }

        [DataMember]
        public string AppName { get; set; }

        [DataMember]
        public string AppVersion { get; set; }

        [DataMember]        
        public string OwnersName { get; set; }

        [DataMember]        
        public string OwnersNIP
        {
            get { return this._ownersNIP; }
            set { this._ownersNIP = this.GetDigitsOnly(value); }
        }

        private string _ownersNIP;                

        public AuthRequest()
        {
            _ownersNIP = "";            
        } 

        private string GetDigitsOnly(string sourceString)
        {
            string resultString = "";

            Regex regexObj = new Regex(@"[^\d]");
            resultString = regexObj.Replace(sourceString, "");

            return resultString;
        }
    }
}