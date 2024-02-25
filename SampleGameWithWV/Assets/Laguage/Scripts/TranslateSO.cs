using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "TranslateSO", menuName = "Translator/TranslateSO", order = 1)]
public class TranslateSO : ScriptableObject
{
    public string LanguageToTranslate;
    public string TextToTranslate;
    
    public bool[] SelectedLanguages = Array.Empty<bool>();
    public TranslateData[] Translates = Array.Empty<TranslateData>();

    public void Translate()
    {
        if (string.IsNullOrEmpty(TextToTranslate))
        {
            Debug.Log("Null");
            return;
        }
        
        List<string> lang = new List<string>();

        for (int i = 0; i < SelectedLanguages.Length; i++)
        {
            if (SelectedLanguages[i])
            {
                lang.Add(Language.Languages[i]);
            }
        }
        
        if (lang.Count == 0)
        {
            Debug.Log("Nothing");
            return;
        }

        Translates = new TranslateData[lang.Count];

        for (int i = 0; i < lang.Count-1; i++)
        {
            Translates[i].Text = Translator.Translate(TextToTranslate, LanguageToTranslate, lang[i]);
            Translates[i].Language = lang[i];
        }
        Translates[lang.Count-1].Text = Translator.Translate(TextToTranslate, LanguageToTranslate, lang[lang.Count-1]);
        Translates[lang.Count-1].Language = lang[lang.Count-1];
    }
}