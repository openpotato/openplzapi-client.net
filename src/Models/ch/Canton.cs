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
    /// Representation of a Swiss canton (Kanton)
    /// </summary>
    public class Canton
    {
        /// <summary>
        /// Code (Kantonskürzel)
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Key (Kantonsnummer)
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Name (Kantonsname)
        /// </summary>
        public string Name { get; set; }
    }
}
