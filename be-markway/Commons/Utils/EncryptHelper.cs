// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using System.Security.Cryptography;
using System.Text;

namespace Napokon.Commons.Utils
{
    public class EncryptHelper
    {
        public static string SymmetricEncrypt(string plainText)
        {
            MD5 md5Hash = MD5.Create();

            var sourceBytes = Encoding.UTF8.GetBytes(plainText);

            var hashBytes = md5Hash.ComputeHash(sourceBytes);

            var hash = BitConverter.ToString(hashBytes).Replace("-", string.Empty);

            return hash;
        }
    }
}

