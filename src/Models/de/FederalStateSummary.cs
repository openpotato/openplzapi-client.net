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
    /// Reduced representation of a German federal state (Bundesland)
    /// </summary>
    public class FederalStateSummary 
    {
        /// <summary>
        /// Regional key (Regionalschlüssel)
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Name (Bundeslandname)
        /// </summary>
        public string Name { get; set; }
    }
}
