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
    /// Representation of a German municipal association (Gemeindeverband)
    /// </summary>
    public class MunicipalAssociation
    {
        /// <summary>
        /// Administrative headquarters (Verwaltungssitz des Gemeindeverbandes)
        /// </summary>
        public string AdministrativeHeadquarters { get; set; }

        /// <summary>
        /// District (Kreis)
        /// </summary>
        public DistrictSummary District { get; set; }

        /// <summary>
        /// Federal state (Bundesland)
        /// </summary>
        public FederalStateSummary FederalState { get; set; }

        /// <summary>
        /// Regional key (Regionalschlüssel)
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Name (Name des Gemeindeverbandes)
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Type (Kennzeichen des Gemeindeverbandes)
        /// </summary>
        public string Type { get; set; }
    }
}
