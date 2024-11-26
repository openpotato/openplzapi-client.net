#region OpenPLZ API .NET Client - Copyright (c) STÜBER SYSTEMS GmbH
/*    
 *    OpenPLZ API .NET Client
 *    
 *    Copyright (c) STÜBER SYSTEMS GmbH
 *
 *    Licensed under the MIT License, Version 2.0. 
 */
#endregion

namespace OpenPlzApi.Client.AT
{
    /// <summary>
    /// Representation of an Austrian street (Straße)
    /// </summary>
    public class Street
    {
        /// <summary>
        /// District (Bezirk)
        /// </summary>
        public DistrictSummary District { get; set; }

        /// <summary>
        /// Federal province (Bunudesland)
        /// </summary>
        public FederalProvinceSummary FederalProvince { get; set; }

        /// <summary>
        /// Key (Straßenkennziffer)
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Locality (Ortschaftsname)
        /// </summary>
        public string Locality { get; set; }

        /// <summary>
        /// Municipality (Gemeinde)
        /// </summary>
        public MunicipalitySummary Municipality { get; set; }

        /// <summary>
        /// Name (Straßenname)
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Postal code (Postleitzahl)
        /// </summary>
        public string PostalCode { get; set; }
    }
}
