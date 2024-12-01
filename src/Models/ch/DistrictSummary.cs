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
    /// Reduced representation of a Swiss district (Bezirk)
    /// </summary>
    public class DistrictSummary
    {
        /// <summary>
        /// Key (Bfs-Nummer des Bezirks)
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Name (Bezirksname)
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Short name (Bezirksname, kurz)
        /// </summary>
        public string ShortName { get; set; }
    }
}
