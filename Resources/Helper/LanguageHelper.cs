﻿using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Threading;
using System.Windows;

namespace Resources.Helper
{
    public static class LanguageHelper
    {
        // Change Application Culture
        public static void SelectCulture(string culture)
        {
            if (String.IsNullOrEmpty(culture))
                return;

            ResourceDictionary dict = new ResourceDictionary();
            dict.Source = new Uri($"pack://application:,,,/Resources;component/Languages/{culture}.xaml");
            if (culture != null)
            {
                foreach (var v in Application.Current.Resources.MergedDictionaries)
                {
                    if (v.Source?.ToString() == dict.Source?.ToString())
                    {
                        Application.Current.Resources.MergedDictionaries.Remove(v);
                        break;
                    }

                }

                Application.Current.Resources.MergedDictionaries.Add(dict);
            }

            //Inform the threads of the new culture.     
            Thread.CurrentThread.CurrentCulture = new CultureInfo(culture);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
        }

        // Add Current Languages to Combobox
        public static void AddLanguages(ObservableCollection<string> langCollection, string folder)
        {
            string path = $"{folder}";
            foreach (var i in Application.Current.Resources.MergedDictionaries)
            {

                if (i.Source != null && path.Length < i.Source.ToString().Length && i.Source.AbsoluteUri.StartsWith("pack://application:,,,/Resources;component/Languages"))
                {
                    string langXaml = i.Source.ToString().Substring(path.Length+1);
                    string lang = langXaml.Remove(langXaml.LastIndexOf("."));
                    langCollection.Add(lang);
                }
            }
        }
    }
}
