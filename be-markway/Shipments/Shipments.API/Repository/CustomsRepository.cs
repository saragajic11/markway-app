// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Markway.Shipments.API.Models;
using Markway.Shipments.API.Repository.Core;

namespace Markway.Shipments.API.Repository
{
    public class CustomsRepository : BaseRepository<Customs>, ICustomsRepository
    {
        public CustomsRepository(ShipmentsContext context)
            : base(context) { }
    }
}
