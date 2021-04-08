using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;

namespace rupture
{
    internal static class OS
    {
        public static string OperatingSystem { get;  set; }

        public static void Load()
        {
            List<Exception> exceptions = new List<Exception>();
            try
            {

                OperatingSystem = GetOperatingSystem();
            } catch (Exception e )
            {
                exceptions.Add(e);
            }
            finally
            {
                foreach(Exception e in exceptions )
                {
                    Logger.Log(e.StackTrace);
                }
            }
        }

        private static string GetOperatingSystem()
        {
            object name = (from x in new ManagementObjectSearcher("SELECT Caption FROM Win32_OperatingSystem").Get().Cast<ManagementObject>()
                        select x.GetPropertyValue("Caption")).FirstOrDefault();
            return ( name != null ? name.ToString() : "Unknown").Trim() + " " +  (Environment.Is64BitOperatingSystem ? "64-bit" : "32-bit");
        }
    }
}
