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
    /// Representation of a German municipality (Gemeinde)
    /// </summary>
    public class Municipality
    {
        /// <summary>
        /// Association (Gemeindeverbund)
        /// </summary>
        public MunicipalAssociationSummary Association { get; set; }

        /// <summary>
        /// District (Kreis)
        /// </summary>
        public DistrictSummary District { get; set; }

        /// <summary>
        /// Federal state (Bundesland)
        /// </summary>
        public FederalStateSummary FederalState { get; set; }

        /// <summary>
        /// Government region (Regierungsbezirk)
        /// </summary>
        public GovernmentRegionSummary GovernmentRegion { get; set; }

        /// <summary>
        /// Regional key (Regionalschlüssel)
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Multiple postal codes available? 
        /// </summary>
        public bool MultiplePostalCodes { get; set; }

        /// <summary>
        /// Name (Gemeindename)
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Postal code of the administrative headquarters (Verwaltungssitz), 
        /// if there are multiple postal codes available
        /// </summary>
        public string PostalCode { get; set; }

        /// <summary>
        /// Type (Kennzeichen)
        /// </summary>
        public string Type { get; set; }
    }
}
