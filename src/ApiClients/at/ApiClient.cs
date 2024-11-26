﻿#region OpenPLZ API .NET Client - Copyright (c) STÜBER SYSTEMS GmbH
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

namespace OpenPlzApi.Client.AT
{
    /// <summary>
    /// Client for the Autrian API endpoint of the OpenPLZ API
    /// </summary>
    public class ApiClientForAustria : ApiBaseClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApiClientForAustria"/> class.
        /// </summary>
        /// <param name="httpClient">A <see cref="HttpClient"/> instance</param>
        /// <param name="baseUrl">The base url of the OpenPLZ API</param>
        public ApiClientForAustria(HttpClient httpClient, string baseUrl)
            : base(httpClient, baseUrl)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiClientForAustria"/> class.
        /// </summary>
        /// <param name="restClient">An implementation of <see cref="IRestClient"/></param>
        /// <param name="baseUrl">The base url of the OpenPLZ API</param>
        public ApiClientForAustria(IRestClient restClient, string baseUrl)
            : base(restClient, baseUrl)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiClientForAustria"/> class.
        /// </summary>
        /// <param name="baseUrl">The base url of the OpenPLZ API</param>
        public ApiClientForAustria(string baseUrl)
            : base(RestClientFactory.CreateRestClient(), baseUrl)
        {
        }

        /// <summary>
        /// Returns districts (Bezirke) within a federal province (Bundesland).
        /// </summary>
        /// <param name="key">Key of the federal province</param>
        /// <param name="pageIndex">Page index for paging</param>
        /// <param name="pageSize">Page size for paging</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous operation. The value of the TResult parameter 
        /// contains a paged collection of <see cref="District"/> instances.</returns>
        public async Task<IReadOnlyPagedCollection<District>> GetDistrictsByFederalProvinceAsync(string key, int pageIndex = 1, int pageSize = 50,
            CancellationToken cancellationToken = default)
        {
            return await GetRestClient().GetPageAsync<District>(
                CreateUriBuilder()
                    .WithRelativePath($"at/FederalProvinces/{key}/Districts")
                    .WithParameter("page", pageIndex)
                    .WithParameter("pageSize", pageSize)
                    .Uri,
                async (ct) => await GetDistrictsByFederalProvinceAsync(key, pageIndex + 1, pageSize, ct), cancellationToken);
        }

        /// <summary>
        /// Returns federal provinces (Bundesländer).
        /// </summary>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous operation. The value of the TResult parameter 
        /// contains a list of <see cref="FederalProvince"/> instances.</returns>
        public async Task<IReadOnlyList<FederalProvince>> GetFederalProvincesAsync(CancellationToken cancellationToken = default)
        {
            return await GetRestClient().GetListAsync<FederalProvince>(
                CreateUriBuilder()
                    .WithRelativePath("at/FederalProvinces")
                    .Uri, 
                cancellationToken);
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
        /// contains a paged collection of <see cref="Locality"/> instances.</returns>
        public async Task<IReadOnlyPagedCollection<Locality>> GetLocalitiesAsync(string postalCode, string name, int pageIndex = 1, int pageSize = 50,
            CancellationToken cancellationToken = default)
        {
            return await GetRestClient().GetPageAsync<Locality>(
                CreateUriBuilder()
                    .WithRelativePath($"at/Localities")
                    .WithParameter("postalCode", postalCode)
                    .WithParameter("name", name)
                    .WithParameter("page", pageIndex)
                    .WithParameter("pageSize", pageSize)
                    .Uri,
                async (ct) => await GetLocalitiesAsync(postalCode, name, pageIndex + 1, pageSize, ct), cancellationToken);
        }

        /// <summary>
        /// Returns municipalities (Gemeinden) within a district (Bezirk).
        /// </summary>
        /// <param name="key">Key of the district</param>
        /// <param name="pageIndex">Page index for paging</param>
        /// <param name="pageSize">Page size for paging</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous operation. The value of the TResult parameter 
        /// contains a paged collection of <see cref="Municipality"/> instances.</returns>
        public async Task<IReadOnlyPagedCollection<Municipality>> GetMunicipalitiesByDistrictAsync(string key, int pageIndex = 1, int pageSize = 50,
            CancellationToken cancellationToken = default)
        {
            return await GetRestClient().GetPageAsync<Municipality>(
                CreateUriBuilder()
                    .WithRelativePath($"at/Districts/{key}/Municipalities")
                    .WithParameter("page", pageIndex)
                    .WithParameter("pageSize", pageSize)
                    .Uri,
                async (ct) => await GetMunicipalitiesByDistrictAsync(key, pageIndex + 1, pageSize, ct), cancellationToken);
        }

        /// <summary>
        /// Returns municipalities (Gemeinden) within a federal province (Bundesland).
        /// </summary>
        /// <param name="key">Key of the federal province</param>
        /// <param name="pageIndex">Page index for paging</param>
        /// <param name="pageSize">Page size for paging</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous operation. The value of the TResult parameter 
        /// contains a paged collection of <see cref="Municipality"/> instances.</returns>
        public async Task<IReadOnlyPagedCollection<Municipality>> GetMunicipalitiesByFederalProvinceAsync(string key, int pageIndex = 1, int pageSize = 50,
            CancellationToken cancellationToken = default)
        {
            return await GetRestClient().GetPageAsync<Municipality>(
                CreateUriBuilder()
                    .WithRelativePath($"at/FederalProvinces/{key}/Municipalities")
                    .WithParameter("page", pageIndex)
                    .WithParameter("pageSize", pageSize)
                    .Uri,
                async (ct) => await GetMunicipalitiesByFederalProvinceAsync(key, pageIndex + 1, pageSize, ct), cancellationToken);
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
        /// contains a paged collection of <see cref="Street"/> instances.</returns>
        public async Task<IReadOnlyPagedCollection<Street>> GetStreetsAsync(string name, string postalCode, string locality, int pageIndex = 1, int pageSize = 50,
            CancellationToken cancellationToken = default)
        {
            return await GetRestClient().GetPageAsync<Street>(
                CreateUriBuilder()
                    .WithRelativePath($"at/Streets")
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
        /// contains a paged collection of <see cref="Street"/> instances.</returns>
        public async Task<IReadOnlyPagedCollection<Street>> PerformFullTextSearchAsync(string searchTerm, int pageIndex = 1, int pageSize = 50, 
            CancellationToken cancellationToken = default)
        {
            return await GetRestClient().GetPageAsync<Street>(
                CreateUriBuilder()
                    .WithRelativePath("at/FullTextSearch")
                    .WithParameter("searchTerm", searchTerm)
                    .WithParameter("page", pageIndex)
                    .WithParameter("pageSize", pageSize)
                    .Uri,
                async (ct) => await PerformFullTextSearchAsync(searchTerm, pageIndex + 1, pageSize, ct), cancellationToken);
        }
    }
}