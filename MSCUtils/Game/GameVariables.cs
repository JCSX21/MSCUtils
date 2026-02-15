using UnityEngine;
using MSCLoader;

namespace MyUniversalUtils.Game
{
    /// <summary>
    /// Simple Game Context class to easily access common GameObjects and Components in both MSC and MWC without having to worry about null checks or caching them yourself.
    /// </summary>
    public static class GameContext
    {
        // Backing Fields

        private static bool _isMSC; // Is MSC Active?

        private static bool _isMWC; // Is MWC Active?

        private static Camera _mainCamera; // Main Camera

        private static GameObject _player; // Player GameObject

        private static Light _sunLight; // Sun Light

        private static GameObject _map; // Map GameObject

        private static GameObject _yard; // Yard GameObject

        // Public Properties

        /// <summary>
        /// Is My Summer Car active?
        /// </summary>
        public static bool IsMSC
        {
            get
            {
                _isMSC = MSCLoader.ModLoader.CurrentGame == MSCLoader.Game.MySummerCar;
                return _isMSC;
            }
        }

        /// <summary>
        /// Is My Winter Car active?
        /// </summary>
        public static bool IsMWC
        {
            get
            {
                _isMWC = MSCLoader.ModLoader.CurrentGame == MSCLoader.Game.MyWinterCar;
                return _isMWC;
            }
        }


        /// <returns>Main Camera</returns>
        public static Camera MainCamera
        {
            get
            {
                if (!_mainCamera)
                {
                    _mainCamera = Camera.main;
                }
                return _mainCamera;
            }
        }

        /// <returns>Player as GameObject</returns>
        public static GameObject Player
        {
            get
            {
                if (!_player)
                {
                    _player = GameObject.Find("PLAYER");
                }
                return _player;
            }
        }

        /// <returns>Sun Light</returns>
        public static Light SunLight
        {
            get
            {
                if (_sunLight == null)
                {
                    Light[] lights = Resources.FindObjectsOfTypeAll<Light>();
                    foreach (Light light in lights)
                    {
                        if (light.name.ToLower().Contains("sun") && light.type == LightType.Directional)
                            _sunLight = light;
                    }
                }
                return _sunLight;
            }
        }

        /// <returns>Map GameObject</returns>
        public static GameObject Map
        {
            get
            {
                if (!_map)
                {
                    _map = GameObject.Find("MAP");
                }
                return _map;
            }
        }

        /// <returns>Yard GameObject</returns>
        public static GameObject Yard
        {
            get
            {
                if (!_yard)
                {
                    _yard = GameObject.Find("YARD");
                }
                return _yard;
            }
        }

        /// <summary>
        /// Get a Spefic Car GameObject by a Provided Enum.
        /// </summary>
        /// <param name="car">Car you want to be returned</param>
        /// <returns>Given Car as GameObject</returns>
        public static GameObject GetCar(MSCCars car)
        {
            switch (car)
            {
                case MSCCars.Satsuma:
                    return FindCar("SATSUMA(557kg, 248)");
                case MSCCars.Ferndale:
                    return FindCar("FERNDALE(1630kg)");
                case MSCCars.Hayosiko:
                    return FindCar("HAYOSIKO(1500kg, 250)");
                case MSCCars.EDM:
                    return FindCar("NPC_CARS/KUSKI");
                case MSCCars.Bus:
                    return FindCar("NPC_CARS/BusSpawnRykipohja/BUS");
                case MSCCars.Traffic:
                    return FindCar("TRAFFIC");
                case MSCCars.Kekmet:
                    return FindCar("KEKMET(350-400psi)");
                case MSCCars.ArvoAlgotson:
                    return FindCar("COMBINE(350-400psi)");
                case MSCCars.Ruscko:
                    return FindCar("RCO_RUSCKO12(270)");
                case MSCCars.Ricochet:
                    return FindCar("NPC_CARS/Amikset/KYLAJANI");
                case MSCCars.Svoboda:
                    return FindCar("NPC_CARS/Amikset/AMIS2");
                default:
                    ModConsole.LogError($"Car '{car}' not recognized.");
                    return null;
            }
        }

        /// <summary>
        /// Get a Spefic Car GameObject by a Provided Enum.
        /// </summary>
        /// <param name="car">Car you want to be returned</param>
        /// <returns>Given Car as GameObject</returns>
        public static GameObject GetCar(MWCCars car)
        {
            switch (car)
            {
                case MWCCars.Rivett:
                    return FindCar("RIVETT(350-400psi)");
                case MWCCars.Bachglotz:
                    return FindCar("BACHGLOTZ(1905kg)");
                case MWCCars.Sorbett:
                    return FindCar("SORBET(190-200psi)");
                case MWCCars.EDM:
                    return FindCar("NPC_CARS/EDM");
                case MWCCars.Bus:
                    return FindCar("NPC_CARS/BusSpawnRykipohja/BUS");
                case MWCCars.Traffic:
                    return FindCar("TRAFFIC");
                case MWCCars.Kekmet:
                    return FindCar("KEKMET(350-400psi)");
                case MWCCars.AmisCar:
                    return FindCar("NPC_CARS/Marinade");
                case MWCCars.Taxi:
                    return FindCar("JOBS/TAXIJOB/MACHTWAGEN");
                default:
                    ModConsole.LogError($"Car '{car}' not recognized.");
                    return null;
            }
        }


        private static GameObject FindCar(string carPath)
        {
            GameObject car = GameObject.Find(carPath);
            if (car == null)
            {
                ModConsole.LogError($"Car '{carPath}' not found in the scene. This only happens if its a Car that is set active Dynamically.");
                return null;
            }
            return car;
        }
    }
}
