using System.IdentityModel.Selectors;
using System.ServiceModel;

namespace SoftwareLicenseServer.WebService.BL
{
    public class WSAuthenticator : UserNamePasswordValidator
    {
        public override void Validate(string userName, string password)
        {
            if (userName != "mkaszta" && password != "pass")
            {
                throw new FaultException("Invalid user and/or password");
            }
        }
    }
}