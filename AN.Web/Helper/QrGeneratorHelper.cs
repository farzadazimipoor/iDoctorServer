using QRCoder;
using System;
using System.Drawing;
using System.IO;

namespace AN.Web.Helper
{
    public class QrGeneratorHelper
    {
        public static Bitmap QrBarcodeGenerator(string plaintext)
        {
            if (string.IsNullOrEmpty(plaintext)) throw new ArgumentNullException(nameof(plaintext));

            try
            {
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(plaintext, QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);
                Bitmap qrCodeImage = qrCode.GetGraphic(20);
                return qrCodeImage;
            }
            catch
            {
                throw new Exception("Error While GenerateQrCode");
            }
        }

        public static byte[] BitmapToByteArray(Bitmap bitmap)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
        }
    }
}