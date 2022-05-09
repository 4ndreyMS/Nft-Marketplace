using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_POJOS;

namespace AppLogic.Managers
{
    public class SendValidationsManager: BaseManager
    {
        private OtpManager otpManager;

        private QrGeneratorManager qrManager;

        public SendValidationsManager()
        {
            otpManager = new OtpManager();
        }

        public int sendBothValidations(Validation obj)
        {
            obj.Otp= OtpManager.GenerateOtp();
            var sendMail = SendMailManager.SendDynamicMail(obj);
            SmsManager.SendDymanicSms(obj);
            return obj.Otp;
        }

        public void sendSmsMail(Validation obj)
        {
            var sendMail = SendMailManager.SendSmsMail(obj);
            SmsManager.SendMainSms(obj);
        }

        public string sendQrNFT(Validation obj)
        {
            qrManager = new QrGeneratorManager();

            var sendMail = SendMailManager.SendDynamicQR(obj);
            return "QR send";
        }


        public string GenQR(string obj)
        {
            qrManager = new QrGeneratorManager();
            qrManager.CreateQR(obj);
            return "Qr created";
        }

    }
}
