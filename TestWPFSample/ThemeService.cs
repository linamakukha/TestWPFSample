using System;
using System.Linq;
using System.Windows;

namespace TestWPFSample
{
    public static class ThemeService
    {
        public static void ApplyTheme(string themeName)
        {
            var themePath = themeName switch
            {
                "Light" => "Resources/Themes/LightTheme.xaml",
                "Dark" => "Resources/Themes/DarkTheme.xaml",
                "Pastel" => "Resources/Themes/PastelTheme.xaml",
                _ => "Resources/Themes/LightTheme.xaml"
            };

            var dictionaries = Application.Current.Resources.MergedDictionaries;

            var currentTheme = dictionaries.FirstOrDefault(dictionary =>
                dictionary.Source != null &&
                dictionary.Source.OriginalString.Contains("Resources/Themes/"));

            if (currentTheme != null)
            {
                dictionaries.Remove(currentTheme);
            }

            dictionaries.Insert(0, new ResourceDictionary
            {
                Source = new Uri(themePath, UriKind.Relative)
            });
        }
    }
}