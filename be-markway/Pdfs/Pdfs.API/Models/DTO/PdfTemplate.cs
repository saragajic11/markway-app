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

    // public class PdfTypeKeys
    // {
    //     public static readonly Dictionary<EmailType, string> Paths = new Dictionary<EmailType, string>()
    //     {
    //         {EmailType.AD_DELETE, "Delete ad action" },
    //         {EmailType.AD_DEACTIVATE, "Deactivate ad action" },
    //         {EmailType.AD_UPDATE, "Update ad action" }
    //     };
    // }

    public class PdfTemplateKeys
    {
        public static readonly string MARKWAY_SHIPMENT_ID = "MARKWAY_SHIPMENT_ID";
        public static readonly string MARKWAY_SHIPMENT_CARRIER = "MARKWAY_SHIPMENT_CARRIER";
        public static readonly string MARKWAY_SHIPMENT_LICENCE_PLATE = "MARKWAY_SHIPMENT_LICENCE_PLATE";
        public static readonly string MARKWAY_SHIPMENT_VEHICLE_TYPE = "MARKWAY_SHIPMENT_VEHICLE_TYPE";
        public static readonly string MARKWAY_SHIPMENT_MERCH = "MARKWAY_SHIPMENT_MERCH";
        public static readonly string MARKWAY_SHIPMENT_AMOUNT = "MARKWAY_SHIPMENT_AMOUNT";
        public static readonly string MARKWAY_LOAD_ON_LOCATION = "MARKWAY_LOAD_ON_LOCATION";
        public static readonly string MARKWAY_LOAD_OFF_LOCATION = "MARKWAY_LOAD_OFF_LOCATION";
        public static readonly string MARKWAY_LOAD_ON_DATE = "MARKWAY_LOAD_ON_DATE";
        public static readonly string MARKWAY_LOAD_OFF_DATE = "MARKWAY_LOAD_OFF_DATE";
        public static readonly string MARKWAY_EXPORT_CUSTOMS = "MARKWAY_EXPORT_CUSTOMS";
        public static readonly string MARKWAY_IMPORT_CUSTOMS = "MARKWAY_IMPORT_CUSTOMS";
        public static readonly string MARKWAY_SHIPMENT_NOTES = "MARKWAY_SHIPMENT_NOTES";
        // public static readonly string MARKWAY_SHIPMENT_ID = "MARKWAY_SHIPMENT_ID";
        // public static readonly string MARKWAY_SHIPMENT_ID = "MARKWAY_SHIPMENT_ID";

    }
}
