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
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace OpenPlzApi.Client.LI
{
    /// <summary>
    /// Client for the Liechtenstein API endpoint of Open PLZ API
    /// </summary>
    public class ApiClientForLiechtenstein : ApiBaseClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApiClientForLiechtenstein"/> class.
        /// </summary>
        /// <param name="httpClient">An <see cref="HttpClient"/> instance</param>
        /// <param name="baseUrl">The base url of the OpenPLZ API</param>
        public ApiClientForLiechtenstein(HttpClient httpClient, string baseUrl)
            : base(httpClient, baseUrl)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiClientForLiechtenstein"/> class.
        /// </summary>
        /// <param name="restClient">An implementation of <see cref="IRestClient"/></param>
        /// <param name="baseUrl">The base url of the OpenPLZ API</param>
        public ApiClientForLiechtenstein(IRestClient restClient, string baseUrl)
            : base(restClient, baseUrl)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiClientForLiechtenstein"/> class.
        /// </summary>
        /// <param name="baseUrl">The base url of the OpenPLZ API</param>
        public ApiClientForLiechtenstein(string baseUrl)
            : base(RestClientFactory.CreateRestClient(), baseUrl)
        {
        }

        /// <summary>
        /// Returns communes (Gemeinden)
        /// </summary>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous operation. The value of the TResult parameter 
        /// contains list of <see cref="Commune"/> instances.</returns>
        public async Task<IReadOnlyList<Commune>> GetCommunesAsync(CancellationToken cancellationToken = default)
        {
            return await GetRestClient().GetListAsync<Commune>(
                CreateUriBuilder()
                    .WithRelativePath("li/Communes")
                    .Uri,
                cancellationToken);
        }

        /// <summary>
        /// Returns localities whose postal code and/or name matches the given patterns.
        /// </summary>
        /// <summary>
        /// Returns all localities whose postal code and/or name matches the given patterns.
        /// </summary>
        /// <param name="postalCode">Postal code pattern</param>
        /// <param name="name">Name pattern</param>
        /// <param name="pageIndex">Page index for paging</param>
        /// <param name="pageSize">Page size for paging</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous operation. The value of the TResult parameter 
        /// contains a paged list of <see cref="Locality"/> instances.</returns>
        public async Task<IReadOnlyPagedCollection<Locality>> GetLocalitiesAsync(string postalCode, string name, int pageIndex = 1, int pageSize = 50, 
            CancellationToken cancellationToken = default)
        {
            return await GetRestClient().GetPageAsync(
                CreateUriBuilder()
                    .WithRelativePath($"li/Localities")
                    .WithParameter("postalCode", postalCode)
                    .WithParameter("name", name)
                    .WithParameter("page", pageIndex)
                    .WithParameter("pageSize", pageSize)
                    .Uri,
                async (ct) => await GetLocalitiesAsync(postalCode, name, pageIndex + 1, pageSize, ct), cancellationToken);
        }

        /// <summary>
        /// Returns streets whose name, postal code and/or name matches the given patterns.
        /// </summary>
        /// <param name="name">Name pattern</param>
        /// <param name="postalCode">Postal code pattern</param>
        /// <param name="locality">Locality pattern</param>
        /// <param name="pageIndex">Page index for paging</param>
        /// <param name="pageSize">Page size for paging</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous operation. The value of the TResult parameter 
        /// contains a paged list of <see cref="Street"/> instances.</returns>
        public async Task<IReadOnlyPagedCollection<Street>> GetStreetsAsync(string name, string postalCode, string locality, int pageIndex = 1, int pageSize = 50, 
            CancellationToken cancellationToken = default)
        {
            return await GetRestClient().GetPageAsync(
                CreateUriBuilder()
                    .WithRelativePath($"li/Streets")
                    .WithParameter("name", name)
                    .WithParameter("postalCode", postalCode)
                    .WithParameter("locality", locality)
                    .WithParameter("page", pageIndex)
                    .WithParameter("pageSize", pageSize)
                    .Uri,
                async (ct) => await GetStreetsAsync(name, postalCode, locality, pageIndex + 1, pageSize, ct), cancellationToken);
        }

        /// <summary>
        /// Performs a full-text search using the street name, postal code and city.
        /// </summary>
        /// <param name="searchTerm">Search term for full text search</param>
        /// <param name="pageIndex">Page index for paging</param>
        /// <param name="pageSize">Page size for paging</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous operation. The value of the TResult parameter 
        /// contains a paged list of <see cref="Street"/> instances.</returns>
        public async Task<IReadOnlyPagedCollection<Street>> PerformFullTextSearchAsync(string searchTerm, int pageIndex = 1, int pageSize = 50, 
            CancellationToken cancellationToken = default)
        {
            return await GetRestClient().GetPageAsync(
                CreateUriBuilder()
                    .WithRelativePath("li/FullTextSearch")
                    .WithParameter("searchTerm", searchTerm)
                    .WithParameter("page", pageIndex)
                    .WithParameter("pageSize", pageSize)
                    .Uri,
                async (ct) => await PerformFullTextSearchAsync(searchTerm, pageIndex + 1, pageSize, ct), cancellationToken);
        }
    }
}
