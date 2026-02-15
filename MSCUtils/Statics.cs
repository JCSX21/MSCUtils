using MSCLoader;
using System.Linq;
using System.Reflection;

namespace MyUniversalUtils
{
    internal class Statics
    {
        private static Mod cachedMod;

        internal static Mod CurrentMod
        {
            get
            {
                var callingAssembly = Assembly.GetCallingAssembly();

                var currentMod = MSCLoader.ModLoader.LoadedMods
                    .FirstOrDefault(m => m.GetType().Assembly == callingAssembly);

                if (currentMod == null)
                {
                    ModConsole.Error("SaveLoadExtensions: Could not determine calling Mod.");
                    return null;
                }

                if (cachedMod != currentMod)
                {
                    cachedMod = currentMod;
                }

                return cachedMod;
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
