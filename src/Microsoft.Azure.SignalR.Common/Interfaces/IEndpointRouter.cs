﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;

namespace Microsoft.Azure.SignalR
{
    /// <summary>
    /// TODO: expose
    /// </summary>
    internal interface IEndpointRouter
    {
        /// <summary>
        /// TODO: add HttpContext for Core and HostContext for AspNet one?
        /// </summary>
        /// <param name="primaryEndpoints"></param>
        /// <returns></returns>
        ServiceEndpoint GetNegotiateEndpoint(IReadOnlyList<ServiceEndpoint> primaryEndpoints);

        IReadOnlyList<ServiceEndpoint> GetEndpointsForBroadcast(IReadOnlyList<ServiceEndpoint> availableEnpoints);

        IReadOnlyList<ServiceEndpoint> GetEndpointsForUser(string userId, IReadOnlyList<ServiceEndpoint> availableEnpoints);

        IReadOnlyList<ServiceEndpoint> GetEndpointsForUsers(IReadOnlyList<string> userList, IReadOnlyList<ServiceEndpoint> availableEnpoints);

        IReadOnlyList<ServiceEndpoint> GetEndpointsForGroup(string groupName, IReadOnlyList<ServiceEndpoint> availableEnpoints);

        IReadOnlyList<ServiceEndpoint> GetEndpointsForGroups(IReadOnlyList<string> groupList, IReadOnlyList<ServiceEndpoint> availableEnpoints);

        IReadOnlyList<ServiceEndpoint> GetEndpointsForConnection(string connectionId, IReadOnlyList<ServiceEndpoint> availableEnpoints);
    }
}
