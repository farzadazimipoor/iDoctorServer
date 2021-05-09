using System.Collections.Generic;

namespace Shared.Settings
{
    public class AppSettings
    {
        public IdentityServer IdentityServer { get; set; }
        public Jwt Jwt { get; set; }
        public GoogleReCaptcha GoogleReCaptcha { get; set; }
        public AwroNoreSettings AwroNoreSettings { get; set; }
    }

    public class IdentityServer
    {
        public string Authority { get; set; }
    }

    public class Jwt
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }

    public class GoogleReCaptcha
    {
        public string SecretKey { get; set; }
        public string SiteKey { get; set; }
    }

    public class AwroNoreSettings
    {
        public ApplicationConfig App { get; set; }
        public ConsultancyDisclamer ConsultancyDisclamer { get; set; }
        public ChatScreenMention ChatScreenMention { get; set; }
        public ConsultantChatScreenMention ConsultantChatScreenMention { get; set; }
        public ContactDefaultStatus ContactDefaultStatus { get; set; }
        public ConsultantDefaultStatus ConsultantDefaultStatus { get; set; }
        public List<string> RequestAppointmentAgents { get; set; }
        public KurtenameSmsOptions KurtenameSmsOptions { get; set; }
        public string ApplicationName { get; set; }
        public string Version { get; set; }
    }

    public class ApplicationConfig
    {
        public AppDashboardActionConfig Kurdish { get; set; }
        public AppDashboardActionConfig Arabic { get; set; }
        public AppDashboardActionConfig English { get; set; }
    }

    public class AppDashboardActionConfig
    {
        public bool ShowDashboardAction { get; set; }
        public string DashboardActionTitle { get; set; }
        public string DashboardActionUrl { get; set; }
    }

    public class ConsultancyDisclamer
    {
        public string Disclamer { get; set; }
        public string DisclamerKu { get; set; }
        public string DisclamerAr { get; set; }
    }

    public class ChatScreenMention
    {
        public string Mention { get; set; }
        public string MentionKu { get; set; }
        public string MentionAr { get; set; }
    }

    public class ConsultantChatScreenMention
    {
        public string Mention { get; set; }
        public string MentionKu { get; set; }
        public string MentionAr { get; set; }
    }

    public class ContactDefaultStatus
    {
        public string Status { get; set; }
        public string StatusKu { get; set; }
        public string StatusAr { get; set; }
    }

    public class ConsultantDefaultStatus
    {
        public string Status { get; set; }
        public string StatusKu { get; set; }
        public string StatusAr { get; set; }
    }

    public class KurtenameSmsOptions
    {
        public string BaseUrl { get; set; }
        public string ApiKey { get; set; }
        public string SourceAddress { get; set; }
        public bool Unicode { get; set; }
    }
}
