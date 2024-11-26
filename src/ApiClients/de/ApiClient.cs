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

namespace OpenPlzApi.Client.DE
{
    /// <summary>
    /// Client for the German API endpoint of Open PLZ API
    /// </summary>
    public class ApiClientForGermany : ApiBaseClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApiClientForGermany"/> class.
        /// </summary>
        /// <param name="httpClient">A <see cref="HttpClient"/> instance</param>
        /// <param name="baseUrl">The base url of the OpenPLZ API</param>
        public ApiClientForGermany(HttpClient httpClient, string baseUrl)
            : base(httpClient, baseUrl)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiClientForGermany"/> class.
        /// </summary>
        /// <param name="restClient">An implementation of <see cref="IRestClient"/></param>
        /// <param name="baseUrl">The base url of the OpenPLZ API</param>
        public ApiClientForGermany(IRestClient restClient, string baseUrl)
            : base(restClient, baseUrl)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiClientForGermany"/> class.
        /// </summary>
        /// <param name="baseUrl">The base url of the OpenPLZ API</param>
        public ApiClientForGermany(string baseUrl)
            : base(RestClientFactory.CreateRestClient(), baseUrl)
        {
        }

        /// <summary>
        /// Returns districts (Kreise) within a federal state (Bundesland).
        /// </summary>
        /// <param name="key">Key of the federal state</param>
        /// <param name="pageIndex">Page index for paging</param>
        /// <param name="pageSize">Page size for paging</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous operation. The value of the TResult parameter 
        /// contains a paged list of <see cref="District"/> instances.</returns>
        public async Task<IReadOnlyPagedCollection<District>> GetDistrictsByFederalStateAsync(string key, int pageIndex = 1, int pageSize = 50, 
            CancellationToken cancellationToken = default)
        {
            return await GetRestClient().GetPageAsync(
                CreateUriBuilder()
                    .WithRelativePath($"de/FederalStates/{key}/Districts")
                    .WithParameter("page", pageIndex)
                    .WithParameter("pageSize", pageSize)
                    .Uri,
                async (ct) => await GetDistrictsByFederalStateAsync(key, pageIndex + 1, pageSize, ct), cancellationToken);
        }

        /// <summary>
        /// Returns districts (Kreise) within a government region (Regierungsbezirk).
        /// </summary>
        /// <param name="key">Key of the government region</param>
        /// <param name="pageIndex">Page index for paging</param>
        /// <param name="pageSize">Page size for paging</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous operation. The value of the TResult parameter 
        /// contains a paged list of <see cref="District"/> instances.</returns>
        public async Task<IReadOnlyPagedCollection<District>> GetDistrictsByGovernmentRegionAsync(string key, int pageIndex = 1, int pageSize = 50, 
            CancellationToken cancellationToken = default)
        {
            return await GetRestClient().GetPageAsync(
                CreateUriBuilder()
                    .WithRelativePath($"de/GovernmentRegions/{key}/Districts")
                    .WithParameter("page", pageIndex)
                    .WithParameter("pageSize", pageSize)
                    .Uri,
                async (ct) => await GetDistrictsByGovernmentRegionAsync(key, pageIndex + 1, pageSize, ct), cancellationToken);
        }

        /// <summary>
        /// Returns federal states (Bundesländer).
        /// </summary>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous operation. The value of the TResult parameter 
        /// contains list of <see cref="FederalState"/> instances.</returns>
        public async Task<IReadOnlyList<FederalState>> GetFederalStatesAsync(CancellationToken cancellationToken = default)
        {
            return await GetRestClient().GetListAsync<FederalState>(
                CreateUriBuilder()
                    .WithRelativePath("de/FederalStates")
                    .Uri,
                cancellationToken);
        }

        /// <summary>
        /// Returns government regions (Regierungsbezirke) within a federal state (Bundesaland).
        /// </summary>
        /// <param name="key">Key of the federal state</param>
        /// <param name="pageIndex">Page index for paging</param>
        /// <param name="pageSize">Page size for paging</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous operation. The value of the TResult parameter 
        /// contains a paged list of <see cref="GovernmentRegion"/> instances.</returns>
        public async Task<IReadOnlyPagedCollection<GovernmentRegion>> GetGovernmentRegionsByFederalStateAsync(string key, int pageIndex = 1, int pageSize = 50, 
            CancellationToken cancellationToken = default)
        {
            return await GetRestClient().GetPageAsync(
                CreateUriBuilder()
                    .WithRelativePath($"de/FederalStates/{key}/GovernmentRegions")
                    .WithParameter("page", pageIndex)
                    .WithParameter("pageSize", pageSize)
                    .Uri,
                async (ct) => await GetGovernmentRegionsByFederalStateAsync(key, pageIndex + 1, pageSize, ct), cancellationToken);
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
                    .WithRelativePath($"de/Localities")
                    .WithParameter("postalCode", postalCode)
                    .WithParameter("name", name)
                    .WithParameter("page", pageIndex)
                    .WithParameter("pageSize", pageSize)
                    .Uri,
                async (ct) => await GetLocalitiesAsync(postalCode, name, pageIndex + 1, pageSize, ct), cancellationToken);
        }

        /// <summary>
        /// Returns municipal associations (Gemeindeverbände) within a district (Kreis).
        /// </summary>
        /// <param name="key">Key of the district</param>
        /// <param name="pageIndex">Page index for paging</param>
        /// <param name="pageSize">Page size for paging</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous operation. The value of the TResult parameter 
        /// contains a paged list of <see cref="MunicipalAssociation"/> instances.</returns>
        public async Task<IReadOnlyPagedCollection<MunicipalAssociation>> GetMunicipalAssociationsByDistrictAsync(string key, int pageIndex = 1, int pageSize = 50, 
            CancellationToken cancellationToken = default)
        {
            return await GetRestClient().GetPageAsync(
                CreateUriBuilder()
                    .WithRelativePath($"de/Districts/{key}/MunicipalAssociations")
                    .WithParameter("page", pageIndex)
                    .WithParameter("pageSize", pageSize)
                    .Uri,
                async (ct) => await GetMunicipalAssociationsByDistrictAsync(key, pageIndex + 1, pageSize, ct), cancellationToken);
        }

        /// <summary>
        /// Returns municipal associations (Gemeindeverbände) within a federal state (Bundesland).
        /// </summary>
        /// <param name="key">Key of the federal state</param>
        /// <param name="pageIndex">Page index for paging</param>
        /// <param name="pageSize">Page size for paging</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous operation. The value of the TResult parameter 
        /// contains a paged list of <see cref="MunicipalAssociation"/> instances.</returns>
        public async Task<IReadOnlyPagedCollection<MunicipalAssociation>> GetMunicipalAssociationsByFederalStateAsync(string key, int pageIndex = 1, int pageSize = 50, 
            CancellationToken cancellationToken = default)
        {
            return await GetRestClient().GetPageAsync(
                CreateUriBuilder()
                    .WithRelativePath($"de/FederalStates/{key}/MunicipalAssociations")
                    .WithParameter("page", pageIndex)
                    .WithParameter("pageSize", pageSize)
                    .Uri,
                async (ct) => await GetMunicipalAssociationsByFederalStateAsync(key, pageIndex + 1, pageSize, ct), cancellationToken);
        }

        /// <summary>
        /// Returns municipal associations (Gemeindeverbünde) within a government region (Regierungsbezirk).
        /// </summary>
        /// <param name="key">Key of the government region</param>
        /// <param name="pageIndex">Page index for paging</param>
        /// <param name="pageSize">Page size for paging</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous operation. The value of the TResult parameter 
        /// contains a paged list of <see cref="MunicipalAssociation"/> instances.</returns>
        public async Task<IReadOnlyPagedCollection<MunicipalAssociation>> GetMunicipalAssociationsByGovernmentRegionAsync(string key, int pageIndex = 1, int pageSize = 50, 
            CancellationToken cancellationToken = default)
        {
            return await GetRestClient().GetPageAsync<MunicipalAssociation>(
                CreateUriBuilder()
                    .WithRelativePath($"de/GovernmentRegions/{key}/MunicipalAssociations")
                    .WithParameter("page", pageIndex)
                    .WithParameter("pageSize", pageSize)
                    .Uri,
                async (ct) => await GetMunicipalAssociationsByGovernmentRegionAsync(key, pageIndex + 1, pageSize, ct), cancellationToken);
        }

        /// <summary>
        /// Returns municipalities (Gemeinden) within a district (Kreis).
        /// </summary>
        /// <param name="key">Key of the district</param>
        /// <param name="pageIndex">Page index for paging</param>
        /// <param name="pageSize">Page size for paging</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous operation. The value of the TResult parameter 
        /// contains a paged list of <see cref="Municipality"/> instances.</returns>
        public async Task<IReadOnlyPagedCollection<Municipality>> GetMunicipalitiesByDistrictAsync(string key, int pageIndex = 1, int pageSize = 50, 
            CancellationToken cancellationToken = default)
        {
            return await GetRestClient().GetPageAsync<Municipality>(
                CreateUriBuilder()
                    .WithRelativePath($"de/Districts/{key}/Municipalities")
                    .WithParameter("page", pageIndex)
                    .WithParameter("pageSize", pageSize)
                    .Uri,
                async (ct) => await GetMunicipalitiesByDistrictAsync(key, pageIndex + 1, pageSize, ct), cancellationToken);
        }
        /// <summary>
        /// Returns municipalities (Gemeinden) within a federal state (Bundesland).
        /// </summary>
        /// <param name="key">Key of the federal state</param>
        /// <param name="pageIndex">Page index for paging</param>
        /// <param name="pageSize">Page size for paging</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous operation. The value of the TResult parameter 
        /// contains a paged list of <see cref="Municipality"/> instances.</returns>
        public async Task<IReadOnlyPagedCollection<Municipality>> GetMunicipalitiesByFederalStateAsync(string key, int pageIndex = 1, int pageSize = 50, 
            CancellationToken cancellationToken = default)
        {
            return await GetRestClient().GetPageAsync<Municipality>(
                CreateUriBuilder()
                    .WithRelativePath($"de/FederalStates/{key}/Municipalities")
                    .WithParameter("page", pageIndex)
                    .WithParameter("pageSize", pageSize)
                    .Uri,
                async (ct) => await GetMunicipalitiesByFederalStateAsync(key, pageIndex + 1, pageSize, ct), cancellationToken);
        }

        /// <summary>
        /// Returns municipalities (Gemeinden) within a government region (Regierungsbezirk).
        /// </summary>
        /// <param name="key">Key of the government region</param>
        /// <param name="pageIndex">Page index for paging</param>
        /// <param name="pageSize">Page size for paging</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous operation. The value of the TResult parameter 
        /// contains a paged list of <see cref="Municipality"/> instances.</returns>
        public async Task<IReadOnlyPagedCollection<Municipality>> GetMunicipalitiesByGovernmentRegionAsync(string key, int pageIndex = 1, int pageSize = 50, 
            CancellationToken cancellationToken = default)
        {
            return await GetRestClient().GetPageAsync<Municipality>(
                CreateUriBuilder()
                    .WithRelativePath($"de/GovernmentRegions/{key}/Municipalities")
                    .WithParameter("page", pageIndex)
                    .WithParameter("pageSize", pageSize)
                    .Uri,
                async (ct) => await GetMunicipalitiesByGovernmentRegionAsync(key, pageIndex + 1, pageSize, ct), cancellationToken);
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
                    .WithRelativePath($"de/Streets")
                    .WithParameter("name", name)
                    .WithParameter("postalCode", postalCode)
                    .WithParameter("locality", locality)
                    .WithParameter("page", pageIndex)
                    .WithParameter("pageSize", pageSize)
                    .Uri,
                async (ct) => await GetStreetsAsync(name, postalCode, locality, pageIndex + 1, pageSize, ct), cancellationToken);
        }

        /// <summary>
        /// Performs a full-text search using the street name, postal code and city and gives back a 
        /// paged list of results.
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
                    .WithRelativePath("de/FullTextSearch")
                    .WithParameter("searchTerm", searchTerm)
                    .WithParameter("page", pageIndex)
                    .WithParameter("pageSize", pageSize)
                    .Uri,
                async (ct) => await PerformFullTextSearchAsync(searchTerm, pageIndex + 1, pageSize, ct), cancellationToken);
        }
    }
}
