using DTO_POJOS;
using System;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using AppLogic;

namespace AppLogic.Managers
{

    public class SmsManager
    {
        
        public static void SendSms(string number)
        {
            Sms sms = new Sms();
            sms.Token = OtpManager.GenerateOtp();
            sms.AccountSid = "AC2dcb13dbd71118d1a6d60bc59ac27228";
            sms.AuthToken = "dfdd6bfa5331bb7bd4da0aaa3456a405";
            sms.Phone = "+506"+number;
            sms.Message = "Grupo NetQuality, Check your account please! ";
            sms.ServicePath = "MG4990c8952ad39c6007998cb19ae1dc71";
            TwilioClient.Init(sms.AccountSid, sms.AuthToken);

            var messageOptions = new CreateMessageOptions(new PhoneNumber(sms.Phone));
            messageOptions.MessagingServiceSid = sms.ServicePath;
            messageOptions.Body = sms.Message + sms.Token;

            var message = MessageResource.Create(messageOptions);
            
        }

        public static void SendSmsParamOtp(string number, int opt)
        {
            Sms sms = new Sms();
            sms.Token = opt;
            sms.AccountSid = "AC2dcb13dbd71118d1a6d60bc59ac27228";
            sms.AuthToken = "dfdd6bfa5331bb7bd4da0aaa3456a405";
            sms.Phone = "+506" + number;
            sms.Message = "Grupo NetQuality, Check your account please! ";
            sms.ServicePath = "MG4990c8952ad39c6007998cb19ae1dc71";
            TwilioClient.Init(sms.AccountSid, sms.AuthToken);

            var messageOptions = new CreateMessageOptions(new PhoneNumber(sms.Phone));
            messageOptions.MessagingServiceSid = sms.ServicePath;
            messageOptions.Body = sms.Message + sms.Token;

            var message = MessageResource.Create(messageOptions);

        }

        public static void SendDymanicSms(Validation _validation)
        {
            Sms sms = new Sms();
            sms.Token = _validation.Otp;
            sms.AccountSid = "AC2dcb13dbd71118d1a6d60bc59ac27228";
            sms.AuthToken = "dfdd6bfa5331bb7bd4da0aaa3456a405";
            sms.Phone = "+506" + _validation.PhoneTo;
            sms.Message = _validation.Msj+" ";
            sms.ServicePath = "MG4990c8952ad39c6007998cb19ae1dc71";
            TwilioClient.Init(sms.AccountSid, sms.AuthToken);

            var messageOptions = new CreateMessageOptions(new PhoneNumber(sms.Phone));
            messageOptions.MessagingServiceSid = sms.ServicePath;
            messageOptions.Body = sms.Message + sms.Token;

            var message = MessageResource.Create(messageOptions);

        }

        public static void SendMainSms(Validation _validation)
        {
            Sms sms = new Sms();
            sms.AccountSid = "AC2dcb13dbd71118d1a6d60bc59ac27228";
            sms.AuthToken = "dfdd6bfa5331bb7bd4da0aaa3456a405";
            sms.Phone = "+506" + _validation.PhoneTo;
            sms.Message = _validation.Msj + " ";
            sms.ServicePath = "MG4990c8952ad39c6007998cb19ae1dc71";
            TwilioClient.Init(sms.AccountSid, sms.AuthToken);

            var messageOptions = new CreateMessageOptions(new PhoneNumber(sms.Phone));
            messageOptions.MessagingServiceSid = sms.ServicePath;
            messageOptions.Body = sms.Message;

            var message = MessageResource.Create(messageOptions);

        }

    }
}
