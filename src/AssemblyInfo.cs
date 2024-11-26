#region OpenPLZ API .NET Client - Copyright (c) STÜBER SYSTEMS GmbH
/*    
 *    OpenPLZ API .NET Client
 *    
 *    Copyright (c) STÜBER SYSTEMS GmbH
 *
 *    Licensed under the MIT License, Version 2.0. 
 */
#endregion

using System.Reflection;

namespace OpenPlzApi.Client
{
    /// <summary>
    /// Helper class to extract assambly infos
    /// </summary>
    public static class AssemblyInfo
    {
        public static string GetAgentName()
        {
            return Assembly.GetExecutingAssembly().GetName().Name;
        }

        public static string GetVersion()
        {
            return Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }
    }
}