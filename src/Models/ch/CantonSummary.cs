#region OpenPLZ API .NET Client - Copyright (c) STÜBER SYSTEMS GmbH
/*    
 *    OpenPLZ API .NET Client
 *    
 *    Copyright (c) STÜBER SYSTEMS GmbH
 *
 *    Licensed under the MIT License, Version 2.0. 
 */
#endregion

namespace OpenPlzApi.Client.CH
{
    /// <summary>
    /// Reduced representation of a Swiss canton (Kanton)
    /// </summary>
    public class CantonSummary
    {
        /// <summary>
        /// Key (Bfs-Nummer des Kantons)
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Name (Kantonsname)
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Short name (Kantonskürzel)
        /// </summary>
        public string ShortName { get; set;  }
    }
}
