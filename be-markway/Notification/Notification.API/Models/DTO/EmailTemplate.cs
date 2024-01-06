// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

namespace Markway.Notification.API.Models.DTO
{

    public enum EmailTemplate
    {
        ACTIVATION_EMAIL,
        REMINDER_EMAIL,
        QC_EMAIL
    }

    public class EmailTemplates
    {
        public static readonly Dictionary<EmailTemplate, string> Paths = new Dictionary<EmailTemplate, string>()
        {
            {EmailTemplate.ACTIVATION_EMAIL, "Resources/Templates/ActivationEmail.html" },
            {EmailTemplate.REMINDER_EMAIL, "Resources/Templates/ReminderEmail.html" },
            {EmailTemplate.QC_EMAIL, "Resources/Templates/QcEmail.html" }
        };
    }

    public enum EmailType
    {
        AD_DELETE = 1,
        AD_DEACTIVATE = 2,
        AD_UPDATE = 3,
    }

    public class EmailTypeKeys
    {
        public static readonly Dictionary<EmailType, string> Paths = new Dictionary<EmailType, string>()
        {
            {EmailType.AD_DELETE, "Delete ad action" },
            {EmailType.AD_DEACTIVATE, "Deactivate ad action" },
            {EmailType.AD_UPDATE, "Update ad action" }
        };
    }

    public class EmailTemplateKeys
    {
        public static readonly string ACTIVATION_EMAIL_WELCOME = "ACTIVATION_EMAIL_WELCOME";
        public static readonly string ACTIVATION_EMAIL_ACTIVATION_CODE = "ACTIVATION_EMAIL_ACTIVATION_CODE";
        public static readonly string ACTIVATION_EMAIL_USER_FOLLOW_US_ON = "ACTIVATION_EMAIL_USER_FOLLOW_US_ON";
        public static readonly string REMINDER_EMAIL_SUBSCRIPTION_EXPIRATION = "REMINDER_EMAIL_SUBSCRIPTION_EXPIRATION";
        public static readonly string QC_EMAIL_TITLE = "QC_EMAIL_TITLE";
        public static readonly string QC_EMAIL_FAILURE_REASONS = "QC_EMAIL_FAILURE_REASONS";
        public static readonly string QC_EMAIL_AD_ACTION = "QC_EMAIL_AD_ACTION";
        public static readonly string QC_EMAIL_SUMMARY = "QC_EMAIL_SUMMARY";
    }
}
