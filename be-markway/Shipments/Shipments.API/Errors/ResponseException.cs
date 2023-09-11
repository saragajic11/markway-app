// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using System.Net;

namespace Markway.Shipments.API.Errors
{
    public class HttpResponseException : Exception
    {
        public HttpStatusCode StatusCode
        {
            get;
        }

        public ErrorResponse ErrorResponse
        {
            get;
        }

        public HttpResponseException(HttpStatusCode _statusCode, ErrorResponse _errorResponse)
        {
            StatusCode = _statusCode;
            ErrorResponse = _errorResponse;
        }
    }
}

