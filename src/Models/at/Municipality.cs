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
    /// Representation of an Austrian municipality (Gemeinde)
    /// </summary>
    public class Municipality
    {
        /// <summary>
        /// Code (Gemeindecode)
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// District (Bezirk)
        /// </summary>
        public DistrictSummary District { get; set; }

        /// <summary>
        /// Federal province (Bunudesland)
        /// </summary>
        public FederalProvinceSummary FederalProvince { get; set; }

        /// <summary>
        /// Key (Gemeindekennziffer)
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// This municipality has multiple postal codes?
        /// </summary>
        public bool MultiplePostalCodes { get; set; }

        /// <summary>
        /// Name (Gemeindename)
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Postal code (Postleitzahl des Gemeindeamtes)
        /// </summary>
        public string PostalCode { get; set; }

        /// <summary>
        /// Status (Gemeindestatus)
        /// </summary>
        public string Status { get; set; }
    }
}
