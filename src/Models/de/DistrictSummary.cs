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
    /// Reduced representation of a German district (Kreis)
    /// </summary>
    public class DistrictSummary
    {
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
