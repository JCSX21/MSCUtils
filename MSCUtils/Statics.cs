using MSCLoader;
using MyUniversalUtils.ModLoaderExtensions;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MyUniversalUtils
{
    internal class Statics
    {
        private static Dictionary<Assembly, Mod> modCache = new Dictionary<Assembly, Mod>();

        internal static Mod CurrentMod
        {
            get
            {
                // Gehe den Stack durch bis zur ersten Assembly außerhalb von SaveLoadExtensions
                var stackTrace = new System.Diagnostics.StackTrace();
                Assembly callingAssembly = null;

                foreach (var frame in stackTrace.GetFrames())
                {
                    var method = frame.GetMethod();
                    if (method == null || method.DeclaringType == null) continue;

                    var assembly = method.DeclaringType.Assembly;

                    // Überspringe eigene Assembly
                    if (assembly != typeof(SaveLoadExtensions).Assembly)
                    {
                        callingAssembly = assembly;
                        break;
                    }
                }

                if (callingAssembly == null)
                {
                    ModConsole.Error("SaveLoadExtensions: Could not determine calling Assembly.");
                    return null;
                }

                // Cache-Lookup
                if (modCache.ContainsKey(callingAssembly))
                {
                    return modCache[callingAssembly];
                }

                // Mod finden
                var currentMod = MSCLoader.ModLoader.LoadedMods
                    .FirstOrDefault(m => m.GetType().Assembly == callingAssembly);

                if (currentMod == null)
                {
                    ModConsole.Error("SaveLoadExtensions: Could not find Mod for Assembly: " + callingAssembly.FullName);
                    return null;
                }

                // Cache speichern
                modCache[callingAssembly] = currentMod;
                return currentMod;
            }
        }
    }
    public enum MSCCars
    {
        Satsuma,
        Ferndale,
        Hayosiko,
        EDM,
        Bus,
        Traffic,
        Kekmet,
        ArvoAlgotson,
        Ruscko,
        Ricochet,
        Svoboda
    }

    public enum MWCCars
    {
        Rivett,
        Bachglotz,
        Sorbett,
        EDM,
        Bus,
        Traffic,
        Kekmet,
        AmisCar,
        Taxi
    }
}
