#region OpenPLZ API .NET Client - Copyright (c) STÜBER SYSTEMS GmbH
/*    
 *    OpenPLZ API .NET Client
 *    
 *    Copyright (c) STÜBER SYSTEMS GmbH
 *
 *    Licensed under the MIT License, Version 2.0. 
 */
#endregion

namespace OpenPlzApi.Client.CH
{
    /// <summary>
    /// Representation of a Swiss commune (Gemeinde)
    /// </summary>
    public class Commune
    {
        /// <summary>
        /// Canton (Kanton)
        /// </summary>
        public CantonSummary Canton { get; set; }

        /// <summary>
        /// District (Bezirk)
        /// </summary>
        public DistrictSummary District { get; set; }

        /// <summary>
        /// Key (Gemeindenummer)
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Name (Amtlicher Gemeindename)
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Short name (Gemeindename, kurz)
        /// </summary>
        public string ShortName { get; set; }
    }
}
