// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Microsoft.AspNetCore.Mvc;

namespace Markway.Shipments.API.Controllers
{
    public class BaseController<TEntity> : ControllerBase where TEntity : class
    {
        public BaseController()
        {
        }
    }
}

