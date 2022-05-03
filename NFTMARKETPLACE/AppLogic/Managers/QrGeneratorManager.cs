using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IronBarCode;
using QRCoder;

namespace AppLogic.Managers
{
    public class QrGeneratorManager : BaseManager
    {
        public QRCode genQR(string info)
        { 
            QRCoder.QRCodeGenerator QG = new QRCoder.QRCodeGenerator();
            var data = QG.CreateQrCode(info, QRCoder.QRCodeGenerator.ECCLevel.H);
            var code = new QRCoder.QRCode(data);
            return code;
        }

        public void CreateQR(string info)
        {
            GeneratedBarcode MyBarCode = IronBarCode.BarcodeWriter.CreateBarcode(info, BarcodeWriterEncoding.QRCode);
            string dir = @"c:\imgs";

            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            MyBarCode.SaveAsPng(@"c:\imgs\QR.png");

        }


    }
}
