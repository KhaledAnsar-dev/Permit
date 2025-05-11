using System;
using System.Diagnostics;
using System.Reflection;
using System.Configuration;

namespace DVLD_Data
{
    internal class clsDataAccessSettings
    {

        public static void ErrorLog(string message , string methodName ,string SourceName = "Permit")
        {

            if (!EventLog.SourceExists(SourceName))
            {
                EventLog.CreateEventSource(SourceName, "Application");
            }

            string fullMessage = $"Error in {methodName}: {message}";
            EventLog.WriteEntry(SourceName, fullMessage, EventLogEntryType.Error);
        }

        private static string DBConnectionString()
        {
            string CS = ConfigurationManager.ConnectionStrings["PermitDB"].ConnectionString;
            return CS;
        }
        public static string ConnectionString
        {

            get
            {
                //return "Server=.;Database=Permit;User Id=SA;Password=Razan2024";
                return DBConnectionString();
            }
        }

    }
}
