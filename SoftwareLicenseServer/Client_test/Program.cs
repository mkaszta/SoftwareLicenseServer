using CipherAPI;
using Client_test.DataService;
using Client_test.ServiceReference;
using System.Reflection;
using System.IO;

namespace Client_test
{
    class Program
    {
        static void Main(string[] args)
        {
            string appKey = "asdasdasd";
            string appKeyEncrypted = AES.Encrypt(appKey, "test");

            LicenseDataService dataService = new LicenseDataService();
            AuthResponse response = new AuthResponse();

            AuthRequest authRequest = new AuthRequest();
            authRequest = new AuthRequest()
            {
                AppKey = AES.Encrypt(appKey, "test"),
                OwnersName = "",
                OwnersNIP = "",
                AppName = Assembly.GetExecutingAssembly().GetName().Name,
                AppVersion = string.Format("{0}.{1}", Assembly.GetExecutingAssembly().GetName().Version.Major.ToString(),
                                Assembly.GetExecutingAssembly().GetName().Version.Minor.ToString())
            };


            //response = dataService.GetAuth(authRequest);
            
            byte[] bytes = dataService.DownloadFile("01_10_2017.pdf");
            FileStream fs = new FileStream(@"c:\Users\michal.kaszta\Downloads\downloaded.pdf", FileMode.Create);

            fs.Write(bytes, 0, bytes.Length);
            fs.Close();            
        }
    }
}
