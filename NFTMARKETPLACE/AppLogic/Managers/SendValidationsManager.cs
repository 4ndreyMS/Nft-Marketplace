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

    }
}
