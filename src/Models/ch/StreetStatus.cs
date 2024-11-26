#region OpenPLZ API .NET Client - Copyright (c) STÜBER SYSTEMS GmbH
/*    
 *    OpenPLZ API .NET Client
 *    
 *    Copyright (c) STÜBER SYSTEMS GmbH
 *
 *    Licensed under the MIT License, Version 2.0. 
 */
#endregion

using System.Text.Json.Serialization;

namespace OpenPlzApi.Client.CH
{
    /// <summary>
    /// Street status (Straßenstatus)
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum StreetStatus
    {
        /// <summary>
        /// No status available
        /// </summary>
        None,
        
        /// <summary>
        /// Planned street
        /// </summary>
        Planned = 1,

        /// <summary>
        /// Real street
        /// </summary>
        Real = 2,

        /// <summary>
        /// Outdated street
        /// </summary>
        Outdated = 3
    }
}
