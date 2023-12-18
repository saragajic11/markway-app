// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

namespace Markway.Pdfs.API.Models.DTO
{

    public enum PdfTemplate
    {
        GENERATE_PDF,
        OUTPUT_PDF
    }

    public class PdfTemplates
    {
        public static readonly Dictionary<PdfTemplate, string> Paths = new Dictionary<PdfTemplate, string>()
        {
            {PdfTemplate.GENERATE_PDF, "Resources/Templates/generatePdf.html" },
            {PdfTemplate.OUTPUT_PDF, "PdfsOutput.pdf" }
        };
    }

    // public enum EmailType
    // {
    //     AD_DELETE = 1,
    //     AD_DEACTIVATE = 2,
    //     AD_UPDATE = 3,
    // }

    // public class EmailTypeKeys
    // {
    //     public static readonly Dictionary<EmailType, string> Paths = new Dictionary<EmailType, string>()
    //     {
    //         {EmailType.AD_DELETE, "Delete ad action" },
    //         {EmailType.AD_DEACTIVATE, "Deactivate ad action" },
    //         {EmailType.AD_UPDATE, "Update ad action" }
    //     };
    // }

    // public class EmailTemplateKeys
    // {
    //     public static readonly string ACTIVATION_EMAIL_WELCOME = "ACTIVATION_EMAIL_WELCOME";
    //     public static readonly string ACTIVATION_EMAIL_ACTIVATION_CODE = "ACTIVATION_EMAIL_ACTIVATION_CODE";
    //     public static readonly string ACTIVATION_EMAIL_USER_FOLLOW_US_ON = "ACTIVATION_EMAIL_USER_FOLLOW_US_ON";
    //     public static readonly string REMINDER_EMAIL_SUBSCRIPTION_EXPIRATION = "REMINDER_EMAIL_SUBSCRIPTION_EXPIRATION";
    //     public static readonly string QC_EMAIL_TITLE = "QC_EMAIL_TITLE";
    //     public static readonly string QC_EMAIL_FAILURE_REASONS = "QC_EMAIL_FAILURE_REASONS";
    //     public static readonly string QC_EMAIL_AD_ACTION = "QC_EMAIL_AD_ACTION";
    //     public static readonly string QC_EMAIL_SUMMARY = "QC_EMAIL_SUMMARY";
    // }
}
