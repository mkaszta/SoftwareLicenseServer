using CipherAPI;
using Client_CONNECTOR.DataService;
using Client_CONNECTOR.ServiceReference;
using System.Reflection;
using System.IO;

namespace Client_CONNECTOR
{
    class Program
    {
        static void Main(string[] args)
        {
            string appKey = "asdasdasd";
            string appKeyEncrypted = AES_Helper.Encrypt(appKey, "test");

            LicenseDataService dataService = new LicenseDataService();
            AuthResponse response = new AuthResponse();

            AuthRequest authRequest = new AuthRequest();
            authRequest = new AuthRequest()
            {
                AppKey = AES_Helper.Encrypt(appKey, "test"),
                OwnersName = "",
                OwnersNIP = "6422966998",
                AppName = "Client_test", //Assembly.GetExecutingAssembly().GetName().Name,
                AppVersion = "1.0" //string.Format("{0}.{1}", Assembly.GetExecutingAssembly().GetName().Version.Major.ToString(),
                                //Assembly.GetExecutingAssembly().GetName().Version.Minor.ToString())
            };


            //response = dataService.GetAuth(authRequest);
            
            byte[] bytes = dataService.DownloadLicense(authRequest);

            if (bytes != null)
            {
                FileStream fs = new FileStream(@"c:\Users\michal.kaszta\Downloads\cert.xml", FileMode.Create);

                fs.Write(bytes, 0, bytes.Length);
                fs.Close();
            }            
        }
    }
}
