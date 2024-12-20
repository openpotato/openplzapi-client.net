﻿#region OpenPLZ API .NET Client - Copyright (c) STÜBER SYSTEMS GmbH
/*    
 *    OpenPLZ API .NET Client
 *    
 *    Copyright (c) STÜBER SYSTEMS GmbH
 *
 *    Licensed under the MIT License, Version 2.0. 
 */
#endregion

namespace OpenPlzApi.Client.LI
{
    /// <summary>
    /// Reduced representation of a Liechtenstein commune (Gemeinde)
    /// </summary>
    public class CommuneSummary
    {
        /// <summary>
        /// Key (Gemeindenummer)
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Name (Amtlicher Gemeindename)
        /// </summary>
        public string Name { get; set; }
    }
}
