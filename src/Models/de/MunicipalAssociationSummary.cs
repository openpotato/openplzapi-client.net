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
    /// Reduced representation of a German municipal association (Gemeindeverband)
    /// </summary>
    public class MunicipalAssociationSummary
    {
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
