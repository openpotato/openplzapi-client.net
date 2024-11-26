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
    /// Representation of a Liechtenstein locality (Ort oder Stadt)
    /// </summary>
    public class Locality
    {
        /// <summary>
        /// Commune (Gemeinde)
        /// </summary>
        public CommuneSummary Commune { get; set; }

        /// <summary>
        /// Name (Ortsname)
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Postal code (Postleitzahl)
        /// </summary>
        public string PostalCode { get; set; }
    }
}
