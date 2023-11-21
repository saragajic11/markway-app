// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Markway.Pdfs.API.Models;
using Markway.Pdfs.API.Repository.Core;

namespace Markway.Pdfs.API.Repository
{
    public class ExampleEntityRepository : BaseRepository<ExampleEntity>, IExampleEntityRepository
    {
        public ExampleEntityRepository(PdfsContext context)
            : base(context) { }
    }
}
