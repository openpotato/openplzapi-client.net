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
    /// Reduced representation of an Austrian municipality (Gemeinde)
    /// </summary>
    public class MunicipalitySummary
    {
        /// <summary>
        /// Code (Gemeindecode)
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Key (Gemeindekennziffer)
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Name (Gemeindename)
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Status (Gemeindestatus)
        /// </summary>
        public string Status { get; set; }
    }
}
