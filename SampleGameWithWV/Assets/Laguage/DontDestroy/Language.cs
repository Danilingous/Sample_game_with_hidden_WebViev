using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class Language
{
    public static Action<string> OnChangeLanguage;

    private static string _activeLanguage = "English";
    
    public static string[] Languages =
    {
        "Russian", 
        "English", 
        "French",
        "German", 
        "Spanish", 
        "Italian",
        "Hindi",
        "Portuguese", 
        "Arabic", 
        "Bengali", 
        "Turkish", 
        "Kazakh"
    };
    
    public static Dictionary<string, string> NamesToCode = new Dictionary<string, string>()
    {
        { "Auto", "auto"},
        { "Russian", "ru"},
        { "English", "en"},
        { "French", "fr"},
        { "German", "de"},
        { "Spanish", "es"},
        { "Italian", "it"},
        { "Hindi", "hi"},
        { "Portuguese", "pt"},
        { "Arabic", "ar"},
        { "Bengali", "bn"},
        { "Turkish", "tr"},
        { "Kazakh", "kk"}
    };
    
    /// <summary>
    ///   <para>Russian, English, French, German, Spanish, Italian, Hindi, Portuguese, Arabic, Bengali, Turkish, Kazakh</para>
    /// </summary>
    public static void SwitchLanguage(string newLanguage)
    {
        if (Languages.Contains(newLanguage))
        {
            _activeLanguage = newLanguage;
            OnChangeLanguage?.Invoke(_activeLanguage);
            PlayerPrefs.SetString("PPLanguage", newLanguage);
            PlayerPrefs.Save();
        }
        else
        {
            Debug.LogError("Unknown language");
        }
    }
    
    public static string GetLanguage()
    {
        return _activeLanguage;
    }
}