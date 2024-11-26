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
    /// Representation of a German district (Kreis)
    /// </summary>
    public class District
    {
        /// <summary>
        /// Administrative headquarters (Sitz der Kreisverwaltung)
        /// </summary>
        public string AdministrativeHeadquarters { get; set; }

        /// <summary>
        /// Reference to federal state (Bundesland)
        /// </summary>
        public FederalStateSummary FederalState { get; set; }

        /// <summary>
        /// Reference to government region (Regierungsbezirk)
        /// </summary>
        public GovernmentRegionSummary GovernmentRegion { get; set; }

        /// <summary>
        /// Regional key (Regionalschlüssel)
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Name (Kreisname)
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Type (Kennzeichen)
        /// </summary>
        public string Type { get; set; }
    }
}
