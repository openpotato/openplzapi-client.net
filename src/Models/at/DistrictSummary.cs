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
    /// Reduced representation of an Austrian district (Bezirk)
    /// </summary>
    public class DistrictSummary
    {
        /// <summary>
        /// Code (Bezirkskodierung)
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Key (Bezirkskennziffer)
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Name (Bezirksname)
        /// </summary>
        public string Name { get; set; }
    }
}
