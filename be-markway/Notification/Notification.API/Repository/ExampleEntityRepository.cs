// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Markway.Notification.API.Models;
using Markway.Notification.API.Repository.Core;

namespace Markway.Notification.API.Repository
{
    public class ExampleEntityRepository : BaseRepository<ExampleEntity>, IExampleEntityRepository
    {
        public ExampleEntityRepository(NotificationContext context)
            : base(context) { }
    }
}
