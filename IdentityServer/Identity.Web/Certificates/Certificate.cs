using System.IO;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace Identity.Web.Certificates
{
    public static class Certificate
    {
        #region Create And Export Certificate
        // Reminder : < How To Make pfx Certificate File >

        // Press Ctrl+R and open Run
        // Type mmc to Run Microsoft Management Console
        // On the menu bar select File> Add/Remove Snap-in
        // Select Certificates And Click <Add>
        // Select Computer account
        // Click Next
        // Select Local computer
        // Click Finish

        // <How To Export Created Certificate>
        // From the top, expand Certificates (Local Computer)
        // Expand the Personal folder
        // Click on the Certificates sub-folder
        // Locate the SSL certificate in the list on the right
        // Right-click on the certificate and select All Tasks > Export.
        // Select "Yes, Export the private key"
        // Click Next
        // In the Export File Format window, ensure the option for "Personal Information Exchange  - PKCS#12 (.pfx)" is selected
        // Select "Include all certificates in the certification path if possible"
        // Click Next 
        #endregion

        public static X509Certificate2 Get()
        {
            var assembly = typeof(Certificate).GetTypeInfo().Assembly;

            var names = assembly.GetManifestResourceNames();

            /***********************************************************************************************
             *  Please note that here we are using a local certificate only for testing purposes. In a 
             *  real environment the certificate should be created and stored in a secure way, which is out
             *  of the scope of this project.
             **********************************************************************************************/
            using (var stream = assembly.GetManifestResourceStream("Identity.Web.Certificates.awronoreids4.pfx"))
            {
                var cer = new X509Certificate2(ReadStream(stream), "Ap@123456");

                return cer;
            }
        }

        private static byte[] ReadStream(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }
    }
}
