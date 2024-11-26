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
    /// Representation of a German locality (Ort oder Stadt)
    /// </summary>
    public class Locality
    {
        /// <summary>
        /// Reference to district (Kreis)
        /// </summary>
        public DistrictSummary District { get; set; }

        /// <summary>
        /// Reference to federal state (Bundesland)
        /// </summary>
        public FederalStateSummary FederalState { get; set; }

        /// <summary>
        /// Reference to municipality
        /// </summary>
        public MunicipalitySummary Municipality { get; set; }

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
