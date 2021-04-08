using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace rupture
{
    class Program
    {
        const string PanelLocation = "https://rupture-panel.com/";

        static void Main(string[] args)
        {
            Logger.Log("Rupture Started");
            OS.Load();

            Logger.Log("Found OS information: {0}", OS.OperatingSystem);

            Http.Get(PanelLocation);
            

            // to do: main logic + server side

        }
    }
}
