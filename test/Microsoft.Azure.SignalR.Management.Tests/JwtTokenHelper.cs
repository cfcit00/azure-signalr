﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using Microsoft.Azure.SignalR.TestUtility;

namespace Microsoft.Azure.SignalR.Management.Tests
{
    internal static class JwtTokenHelper
    {
        public static string GenerateExpectedAccessToken(JwtSecurityToken token, string audience, string accessKey, IEnumerable<Claim> customClaims = null)
        {
            var requestId = token.Claims.FirstOrDefault(claim => claim.Type == Constants.ClaimType.Id)?.Value;

            var userClaimType = JwtSecurityTokenHandler.DefaultOutboundClaimTypeMap[ClaimTypes.NameIdentifier];
            var userId = token.Claims.FirstOrDefault(claim => claim.Type == userClaimType)?.Value;

            var claims = new Claim[] { new Claim(ClaimTypes.NameIdentifier, userId) };
            if(customClaims != null) claims = claims.Concat(customClaims).ToArray();

            var tokenString = JwtTokenUtility.GenerateJwtBearer(audience, claims, token.ValidTo,
                token.ValidFrom,
                token.ValidFrom,
                accessKey,
                requestId);

            return tokenString;
        }
    }
}