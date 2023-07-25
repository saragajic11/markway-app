// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using System.Text.Json.Serialization;

namespace Napokon.Customer.API.Errors
{
    public class ErrorResponse
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ErrorCode ErrorCode
        {
            get; set;
        }

        public string ErrorDescription
        {
            get; set;
        }

        public ErrorResponse(ErrorCode _errorCode)
        {
            ErrorCode = _errorCode;
            ErrorDescription = Errors.Descriptions.GetValueOrDefault(_errorCode);
        }
    }
}

