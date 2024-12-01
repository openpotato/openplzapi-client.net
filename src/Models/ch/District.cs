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
    /// Representation of a Swiss district (Bezirk)
    /// </summary>
    public class District
    {
        /// <summary>
        /// Canton (Kanton)
        /// </summary>
        public CantonSummary Canton { get; set; }

        /// <summary>
        /// Historical code (Historisierte Nummer des Bezirks)
        /// </summary>
        public string HistoricalCode { get; set; }

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
