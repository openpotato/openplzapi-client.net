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
    /// Representation of a German government region (Regierungsbezirk)
    /// </summary>
    public class GovernmentRegion
    {
        /// <summary>
        /// Administrative headquarters (Verwaltungssitz des Regierungsbezirks)
        /// </summary>
        public string AdministrativeHeadquarters { get; set; }

        /// <summary>
        /// Federal state (Bundesland)
        /// </summary>
        public FederalStateSummary FederalState { get; set; }

        /// <summary>
        /// Regional key (Regionalschlüssel)
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Name (Bezirksname)
        /// </summary>
        public string Name { get; set; }
    }
}
