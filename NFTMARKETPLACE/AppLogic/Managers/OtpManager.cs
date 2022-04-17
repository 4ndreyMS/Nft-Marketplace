using DataAccess.Crud;
using DTO_POJOS;
using System;

namespace AppLogic.Managers
{
    public class OtpManager
    {
        public OtpCrudFactory otpFactory;
        

        public OtpManager()
        {
            otpFactory = new OtpCrudFactory(); 
        }
        public static int GenerateOtp()
        {
            Otp otp = new Otp();
            Random random = new Random();
            otp.NumMin = 111111;
            otp.NumMax = 999999;

            otp.Code = random.Next(otp.NumMin, otp.NumMax);

            return otp.Code;
        }

        public void UpdateOtp(Otp otp)
        {
            otpFactory.Update(otp);
        }
    }
}
