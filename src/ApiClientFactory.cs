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
using System.Net.Http;

namespace OpenPlzApi.Client
{
    /// <summary>
    /// An API client factory for all supported API clients (German, Austrian, Swiss or Liechtenstein)
    /// </summary>
    public static class ApiClientFactory
    {
        /// <summary>
        /// The offical base url of the OoenPLZ API
        /// </summary>
        public const string OPlzApiBaseUrl = "https://openplzapi.org";

        /// <summary>
        /// Returns a new instance of a <see cref=‘ApiBaseClient’ /> derived API client
        /// </summary>
        /// <typeparam name="T">API client type</typeparam>
        /// <param name="baseUrl">The base url of the OoenPLZ API</param>
        /// <returns>Returns a new <see cref=‘ApiBaseClient’ /> derived API client</returns>
        public static T CreateClient<T>(string baseUrl = OPlzApiBaseUrl) where T : ApiBaseClient
        {
            return (T)Activator.CreateInstance(typeof(T), [baseUrl]);
        }

        /// <summary>
        /// Returns a new instance of a <see cref=‘ApiBaseClient’ /> derived API client
        /// </summary>
        /// <typeparam name="T">API client type</typeparam>
        /// <param name="httpClient">A <see cref="HttpClient"/> instance</param>
        /// <param name="baseUrl">The base url of the OoenPLZ API</param>
        /// <returns>Returns a new <see cref=‘ApiBaseClient’ /> derived API client</returns>
        public static T CreateClient<T>(HttpClient httpClient, string baseUrl = OPlzApiBaseUrl) where T : ApiBaseClient
        {
            return (T)Activator.CreateInstance(typeof(T), [httpClient, baseUrl]);
        }
    }
}
