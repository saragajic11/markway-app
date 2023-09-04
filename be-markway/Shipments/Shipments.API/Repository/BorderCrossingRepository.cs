// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Markway.Shipments.API.Models;
using Markway.Shipments.API.Repository.Core;

namespace Markway.Shipments.API.Repository
{
    public class BorderCrossingRepository : BaseRepository<BorderCrossing>, IBorderCrossingRepository
    {
        public BorderCrossingRepository(ShipmentsContext context)
            : base(context) { }
    }
}
