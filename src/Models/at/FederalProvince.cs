﻿#region OpenPLZ API .NET Client - Copyright (c) STÜBER SYSTEMS GmbH
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
    /// Representation of an Austrian federal province (Bundesland)
    /// </summary>
    public class FederalProvince
    {
        /// <summary>
        /// Key (Bundeslandkennziffer)
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Name (Bundeslandname)
        /// </summary>
        public string Name { get; set; }
    }
}
