#region OpenPLZ API .NET Client - Copyright (c) STÜBER SYSTEMS GmbH
/*    
 *    OpenPLZ API .NET Client
 *    
 *    Copyright (c) STÜBER SYSTEMS GmbH
 *
 *    Licensed under the MIT License, Version 2.0. 
 */
#endregion

namespace OpenPlzApi.Client.LI
{
    /// <summary>
    /// Representation of a Liechtenstein street (Straße)
    /// </summary>
    public class Street
    {
        /// <summary>
        /// Commune (Gemeinde)
        /// </summary>
        public CommuneSummary Commune { get; set; }

        /// <summary>
        /// Key (Straßenschlüssel)
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Locality (Ortsname)
        /// </summary>
        public string Locality { get; set; }

        /// <summary>
        /// Name (Straßenname)
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Postal code (Postleitzahl)
        /// </summary>
        public string PostalCode { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        public StreetStatus Status { get; set; }
    }
}
