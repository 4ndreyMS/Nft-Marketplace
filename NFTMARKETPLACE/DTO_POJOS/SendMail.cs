namespace DTO_POJOS
{
    public class SendMail
    {
        public string ApiKey { get; set; }

        public string EmailTitle { get; set; }

        public string Group { get; set; }
        public string MailFrom { get; set; }

        public string MailTo { get; set; }

        public string MailContent { get; set; }

        public int Token { get; set; }

        public string HtmlContent { get; set; }

    }
}
