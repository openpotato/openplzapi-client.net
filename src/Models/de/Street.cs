#region OpenPLZ API .NET Client - Copyright (c) STÜBER SYSTEMS GmbH
/*    
 *    OpenPLZ API .NET Client
 *    
 *    Copyright (c) STÜBER SYSTEMS GmbH
 *
 *    Licensed under the MIT License, Version 2.0. 
 */
#endregion

namespace OpenPlzApi.Client.DE
{
    /// <summary>
    /// Representation of a German street (Straße)
    /// </summary>
    public class Street
    {
        /// <summary>
        /// Borough (Stadtbezirk)
        /// </summary>
        public string Borough { get; set; }

        /// <summary>
        /// District (Kreis)
        /// </summary>
        public DistrictSummary District { get; set; }

        /// <summary>
        /// Federal state (Bundesland)
        /// </summary>
        public FederalStateSummary FederalState { get; set; }

        /// <summary>
        /// Locality (Ortsname)
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

        /// <summary>
        /// Suburb (Stadtteil)
        /// </summary>
        public string Suburb { get; set; }
    }
}
