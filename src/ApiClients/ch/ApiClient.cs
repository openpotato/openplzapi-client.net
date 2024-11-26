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

namespace OpenPlzApi.Client.CH
{
    /// <summary>
    /// Client for the Swiss API endpoint of Open PLZ API
    /// </summary>
    public class ApiClientForSwitzerland : ApiBaseClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApiClientForSwitzerland"/> class.
        /// </summary>
        /// <param name="httpClient">A <see cref="HttpClient"/> instance</param>
        /// <param name="baseUrl">The base url of the OpenPLZ API</param>
        public ApiClientForSwitzerland(HttpClient httpClient, string baseUrl)
            : base(httpClient, baseUrl)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiClientForSwitzerland"/> class.
        /// </summary>
        /// <param name="restClient">An implementation of <see cref="IRestClient"/></param>
        /// <param name="baseUrl">The base url of the OpenPLZ API</param>
        public ApiClientForSwitzerland(IRestClient restClient, string baseUrl)
            : base(restClient, baseUrl)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiClientForSwitzerland"/> class.
        /// </summary>
        /// <param name="baseUrl">The base url of the OpenPLZ API</param>
        public ApiClientForSwitzerland(string baseUrl)
            : base(RestClientFactory.CreateRestClient(), baseUrl)
        {
        }

        /// <summary>
        /// Returns all cantons (Kantone).
        /// </summary>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous operation. The value of the TResult parameter 
        /// contains list of <see cref="Canton"/> instances.</returns>
        public async Task<IReadOnlyList<Canton>> GetCantonsAsync(CancellationToken cancellationToken = default)
        {
            return await GetRestClient().GetListAsync<Canton>(
                CreateUriBuilder()
                    .WithRelativePath("ch/Cantons")
                    .Uri,
                cancellationToken);
        }

        /// <summary>
        /// Returns communes (Gemeinden) within a canton (Kanton).
        /// </summary>
        /// <param name="key">Key of the caton</param>
        /// <param name="pageIndex">Page index for paging</param>
        /// <param name="pageSize">Page size for paging</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous operation. The value of the TResult parameter 
        /// contains a paged list of <see cref="Commune"/> instances.</returns>
        public async Task<IReadOnlyPagedCollection<Commune>> GetCommunesByCantonAsync(string key, int pageIndex = 1, int pageSize = 50, 
            CancellationToken cancellationToken = default)
        {
            return await GetRestClient().GetPageAsync<Commune>(
                CreateUriBuilder()
                    .WithRelativePath($"ch/Cantons/{key}/Communes")
                    .WithParameter("page", pageIndex)
                    .WithParameter("pageSize", pageSize)
                    .Uri,
                async (ct) => await GetCommunesByCantonAsync(key, pageIndex + 1, pageSize, ct), cancellationToken);
        }

        /// <summary>
        /// Returns communes (Gemeinden) within a district (Bezirk).
        /// </summary>
        /// <param name="key">Key of the district</param>
        /// <param name="pageIndex">Page index for paging</param>
        /// <param name="pageSize">Page size for paging</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous operation. The value of the TResult parameter 
        /// contains a paged list of <see cref="Commune"/> instances.</returns>
        public async Task<IReadOnlyPagedCollection<Commune>> GetCommunesByDistrictAsync(string key, int pageIndex = 1, int pageSize = 50, 
            CancellationToken cancellationToken = default)
        {
            return await GetRestClient().GetPageAsync<Commune>(
                CreateUriBuilder()
                    .WithRelativePath($"ch/Districts/{key}/Communes")
                    .WithParameter("page", pageIndex)
                    .WithParameter("pageSize", pageSize)
                    .Uri,
                async (ct) => await GetCommunesByDistrictAsync(key, pageIndex + 1, pageSize, ct), cancellationToken);
        }

        /// <summary>
        /// Returns districts (Bezirke) within a canton (Kanton).
        /// </summary>
        /// <param name="key">Key of the canton</param>
        /// <param name="pageIndex">Page index for paging</param>
        /// <param name="pageSize">Page size for paging</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous operation. The value of the TResult parameter 
        /// contains a paged list of <see cref="District"/> instances.</returns>
        public async Task<IReadOnlyPagedCollection<District>> GetDistrictsByCantonAsync(string key, int pageIndex = 1, int pageSize = 50, 
            CancellationToken cancellationToken = default)
        {
            return await GetRestClient().GetPageAsync<District>(
                CreateUriBuilder()
                    .WithRelativePath($"ch/Cantons/{key}/Districts")
                    .WithParameter("page", pageIndex)
                    .WithParameter("pageSize", pageSize)
                    .Uri,
                async (ct) => await GetDistrictsByCantonAsync(key, pageIndex + 1, pageSize, ct), cancellationToken);
        }

        /// <summary>
        /// Returns localities whose postal code and/or name matches the given patterns.
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
            return await GetRestClient().GetPageAsync<Locality>(
                CreateUriBuilder()
                    .WithRelativePath($"ch/Localities")
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
            return await GetRestClient().GetPageAsync<Street>(
                CreateUriBuilder()
                    .WithRelativePath($"ch/Streets")
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
            return await GetRestClient().GetPageAsync<Street>(
                CreateUriBuilder()
                    .WithRelativePath("ch/FullTextSearch")
                    .WithParameter("searchTerm", searchTerm)
                    .WithParameter("page", pageIndex)
                    .WithParameter("pageSize", pageSize)
                    .Uri,
                async (ct) => await PerformFullTextSearchAsync(searchTerm, pageIndex + 1, pageSize, ct), cancellationToken);
        }
    }
}
