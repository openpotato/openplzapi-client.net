#region OpenPLZ API .NET Client - Copyright (c) STÜBER SYSTEMS GmbH
/*    
 *    OpenPLZ API .NET Client
 *    
 *    Copyright (c) STÜBER SYSTEMS GmbH
 *
 *    Licensed under the MIT License, Version 2.0. 
 */
#endregion

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace OpenPlzApi.Client
{
    /// <summary>
    /// A typed HTTP client interface.
    /// </summary>
    public interface IRestClient
    {
        /// <summary>
        /// Requests an API endpoint and returns back a list of elements.
        /// </summary>
        /// <typeparam name="T">The type of the element to be returned</typeparam>
        /// <param name="requestUrl">The request url</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous operation. The value of the TResult parameter 
        /// contains the list of elements.</returns>
        Task<IReadOnlyList<T>> GetListAsync<T>(Uri requestUrl, CancellationToken cancellationToken) where T : class;

        /// <summary>
        /// Requests an API endpoint and returns back a page of elements.
        /// </summary>
        /// <typeparam name="T">The type of the element to be returned</typeparam>
        /// <param name="requestUrl">The request url</param>
        /// <param name="nextPage">A delegate for the getting the next page.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous operation. The value of the TResult parameter 
        /// contains the page of elements.</returns>
        Task<IReadOnlyPagedCollection<T>> GetPageAsync<T>(Uri requestUrl, Func<CancellationToken, Task<IReadOnlyPagedCollection<T>>> nextPage, CancellationToken cancellationToken) where T : class;
    }
}
