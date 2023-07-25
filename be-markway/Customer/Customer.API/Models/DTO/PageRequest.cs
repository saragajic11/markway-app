// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using System.ComponentModel.DataAnnotations;

namespace Napokon.Customer.API.Models.DTO
{
    public enum Sort
    {
        ASC,
        DESC
    }

    public record PageRequest
    {
        [Required(ErrorMessage = "Page is mandatory")]
        public int Page { get; init; } = 0;

        [Required(ErrorMessage = "Per Page is mandatory")]
        public int PerPage { get; set; } = 20;

        [Required(ErrorMessage = "Sort is mandatory")]
        public Sort? Sort { get; init; } = DTO.Sort.ASC;

    }
}

