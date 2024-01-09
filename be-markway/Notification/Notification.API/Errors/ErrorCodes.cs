// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

namespace Markway.Notification.API.Errors
{

    public enum ErrorCode
    {
        SERVICE_ABBREVIATION_0001
    }

    public class Errors
    {
        public static readonly Dictionary<ErrorCode, string> Descriptions = new Dictionary<ErrorCode, string>()
        {
            { ErrorCode.SERVICE_ABBREVIATION_0001, "Error description" }
        };
    }
}

