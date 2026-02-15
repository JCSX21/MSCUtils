using MSCLoader;
using System.Linq;
using System.Reflection;
using System;

namespace MyUniversalUtils.ModLoaderExtensions
{
    /// <summary>
    /// Extension class that doesnt need you to define a Mod or Type in SaveLoad.WriteValue<T>(Mod, string, T) and SaveLoad.ReadValue<T>(Mod, string) calls.
    /// </summary>
    public static class SaveLoadExtensions
    {
        /// <summary>
        /// Saves a value for the calling mod using the given key. 
        /// The value's type is automatically detected and used in SaveLoad.WriteValue&lt;T&gt;.
        /// </summary>
        /// <param name="key">The save key.</param>
        /// <param name="value">The value to save.</param>
        public static void WriteValue(string key, object value)
        {
            var mod = Statics.CurrentMod;
            if (mod == null) return;

            if (value == null)
            {
                ModConsole.Error("SaveLoadExtensions: value cannot be null");
                return;
            }

            Type valueType = value.GetType();

            // SaveLoad.WriteValue<T>(Mod, string, T)
            MethodInfo genericMethod = typeof(SaveLoad).GetMethods(BindingFlags.Public | BindingFlags.Static).FirstOrDefault(m => m.Name == "WriteValue" && m.IsGenericMethodDefinition && m.GetParameters().Length == 3);

            if (genericMethod == null)
            {
                ModConsole.Error("SaveLoadExtensions: Could not find generic WriteValue method");
                return;
            }

            MethodInfo constructed = genericMethod.MakeGenericMethod(valueType);

            // Aufruf: SaveLoad.WriteValue<T>(mod, key, value)
            constructed.Invoke(null, new object[] { mod, key, value });
        }

        /// <summary>
        /// Reads a value of a specified type for the calling mod using the given key.
        /// Returns null if the key does not exist.
        /// </summary>
        /// <param name="key">The save key.</param>
        /// <returns>The value if it exists; otherwise null.</returns>
        public static T ReadValue<T>(string key)
        {
            var mod = Statics.CurrentMod;
            if (mod == null) return default(T);

            if (!SaveLoad.ValueExists(mod, key))
            {
                return default(T);
            }

            MethodInfo genericMethod = typeof(SaveLoad)
                .GetMethods(BindingFlags.Public | BindingFlags.Static)
                .FirstOrDefault(m => m.Name == "ReadValue" && m.IsGenericMethodDefinition && m.GetParameters().Length == 2);

            if (genericMethod == null)
            {
                ModConsole.Error("SaveLoadExtensions: Could not find generic ReadValue method");
                return default(T);
            }

            MethodInfo constructed = genericMethod.MakeGenericMethod(typeof(T));
            return (T)constructed.Invoke(null, new object[] { mod, key });
        }

        /// <summary>
        /// Saves multiple key-value pairs for the calling mod.
        /// The number of keys must match the number of values.
        /// </summary>
        /// <param name="saveKeys">Array of keys.</param>
        /// <param name="values">Array of values.</param>
        public static void WriteValues(string[] saveKeys, object[] values)
        {
            if (saveKeys.Length != values.Length)
            {
                ModConsole.Error("SaveLoadExtensions: Number of save keys must match number of values");
                return;
            }

            for (int i = 0; i < saveKeys.Length; i++)
                WriteValue(saveKeys[i], values[i]);
        }

        /// <summary>
        /// Reads multiple values of the same type.
        /// Returns null for any key that does not exist.
        /// </summary>
        /// <param name="keys">Array of save keys.</param>
        /// <param name="types">Array of corresponding types to read.</param>
        /// <returns>Array of read values.</returns>
        public static T[] ReadValues<T>(params string[] keys)
        {
            T[] results = new T[keys.Length];
            for (int i = 0; i < keys.Length; i++)
            {
                results[i] = ReadValue<T>(keys[i]);
            }
            return results;
        }

    }
}
