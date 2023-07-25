// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Napokon.Customers.API.Models
{
    public class Entity
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id
        {
            get; set;
        }

        public DateTime DateCreated
        {
            get; set;
        }

        public DateTime DateUpdated
        {
            get; set;
        }

        public bool Deleted
        {
            get; set;
        }
    }
}

