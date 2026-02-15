using MSCLoader;
using System;

namespace MyUniversalUtils.ModLoaderExtensions
{
    /// <summary>
    /// Extension for some more convenient Settings creation, such as creating dropdowns directly from Enums and adding spacing between Settings.
    /// </summary>
    public static class SettingsExtensions
    {
        /// <summary>
        /// Adds a single empty line in the settings menu for spacing.
        /// </summary>
        public static void Space()
        {
            Settings.AddText("");
        }

        /// <summary>
        /// Adds multiple empty lines in the settings menu for spacing.
        /// </summary>
        /// <param name="spacing">Number of empty lines to insert.</param>
        public static void Space(int spacing)
        {
            for (int i = 0; i < spacing; i++)
            {
                Space();
            }
        }

        /// <summary>
        /// Creates a dropdown in the settings menu using the names of an enum type.
        /// </summary>
        /// <param name="settingID">The unique ID of the setting.</param>
        /// <param name="name">The display name of the dropdown.</param>
        /// <param name="enumType">The enum type to populate the dropdown options.</param>
        /// <returns>The created SettingsDropDownList.</returns>
        public static SettingsDropDownList CreateDropdownWithEnum(string settingID, string name, Type enumType)
        {
            string[] options = Enum.GetNames(enumType);
            return Settings.AddDropDownList(settingID, name, options);
        }

        /// <summary>
        /// Creates a dropdown in the settings menu using the names of an enum type with a default selected index.
        /// </summary>
        /// <param name="settingID">The unique ID of the setting.</param>
        /// <param name="name">The display name of the dropdown.</param>
        /// <param name="enumType">The enum type to populate the dropdown options.</param>
        /// <param name="defaultSelected">The index of the initially selected option.</param>
        /// <returns>The created SettingsDropDownList.</returns>
        public static SettingsDropDownList CreateDropdownWithEnum(string settingID, string name, Type enumType, int defaultSelected = 0)
        {
            string[] options = Enum.GetNames(enumType);
            return Settings.AddDropDownList(settingID, name, options, defaultSelected);
        }

        /// <summary>
        /// Creates a dropdown in the settings menu with a default selected index and an optional action for selection changes.
        /// </summary>
        /// <param name="settingID">The unique ID of the setting.</param>
        /// <param name="name">The display name of the dropdown.</param>
        /// <param name="enumType">The enum type to populate the dropdown options.</param>
        /// <param name="defaultSelected">The index of the initially selected option.</param>
        /// <param name="OnSelectionChanged">Optional callback invoked when the selection changes.</param>
        /// <returns>The created SettingsDropDownList.</returns>
        public static SettingsDropDownList CreateDropdownWithEnum(string settingID, string name, Type enumType, int defaultSelected = 0, Action OnSelectionChanged = null)
        {
            if (OnSelectionChanged == null)
                ModConsole.LogWarning($"No OnSelectionChanged action provided for dropdown '{settingID}'. This may be intentional, but if not, consider providing an action to handle selection changes.");
            
            string[] options = Enum.GetNames(enumType);
            return Settings.AddDropDownList(settingID, name, options, defaultSelected, OnSelectionChanged);
        }

        /// <summary>
        /// Creates a dropdown in the settings menu with a default selected index, optional selection change callback, and visibility control.
        /// </summary>
        /// <param name="settingID">The unique ID of the setting.</param>
        /// <param name="name">The display name of the dropdown.</param>
        /// <param name="enumType">The enum type to populate the dropdown options.</param>
        /// <param name="defaultSelected">The index of the initially selected option.</param>
        /// <param name="OnSelectionChanged">Optional callback invoked when the selection changes.</param>
        /// <param name="visibleByDefault">Whether the dropdown should be visible by default.</param>
        /// <returns>The created SettingsDropDownList.</returns>
        public static SettingsDropDownList CreateDropdownWithEnum(string settingID, string name, Type enumType, int defaultSelected = 0, Action OnSelectionChanged = null, bool visibleByDefault = true)
        {
            if (OnSelectionChanged == null)
                ModConsole.LogWarning($"No OnSelectionChanged action provided for dropdown '{settingID}'. This may be intentional, but if not, consider providing an action to handle selection changes.");

            string[] options = Enum.GetNames(enumType);
            return Settings.AddDropDownList(settingID, name, options, defaultSelected, OnSelectionChanged, visibleByDefault);
        }
    }
}
