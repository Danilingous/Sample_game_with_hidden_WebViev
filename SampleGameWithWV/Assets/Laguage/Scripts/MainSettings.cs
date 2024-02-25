#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "MainSettings", menuName = "Translator/MainSettings", order = 0)]
public class MainSettings : ScriptableObject
{
    public bool _processing = false;
    public bool _complete = false;
    public bool SafeMode;

    public string StartLanguage;
    public bool[] SelectedLanguages = Array.Empty<bool>();
    
    public List<Scene> Scenes = new List<Scene>();

    public async void Translate()
    {
        _complete = false;
        _processing = true;
        var allTexts = FindObjectsOfType<TextTranslator>(true);
        foreach (var text in allTexts)
        {
            if (SafeMode)
            {
                await Task.Delay(10);
            }
            TranslateText(text, text.GetText(), SelectedLanguages, StartLanguage);
        }

        _processing = false;
        _complete = true;

        ClearStrings();
    }

    private void TranslateText(TextTranslator textComponent, string text, bool[] languages, string startLanguage)
    {
        if (string.IsNullOrEmpty(text))
        {
            Debug.Log("Null");
            return;
        }

        List<string> lang = new List<string>();

        for (int i = 0; i < languages.Length; i++)
        {
            if (languages[i])
            {
                lang.Add(Language.Languages[i]);
            }
        }
        
        if (lang.Count == 0)
        {
            Debug.Log("Nothing");
            return;
        }
        
        textComponent.Translates = new TranslateData[lang.Count + 1];
        textComponent.Translates[0] = new TranslateData
        {
            Language = startLanguage,
            Text = text
        };

        for (int i = 0; i < lang.Count-1; i++)
        {
            textComponent.Translates[i+1].Text = Translator.Translate(textComponent.Translates[0].Text, startLanguage, lang[i]);
            textComponent.Translates[i+1].Language = lang[i];
        }
        textComponent.Translates[lang.Count].Text = Translator.Translate(textComponent.Translates[0].Text, startLanguage, lang[lang.Count-1]);
        textComponent.Translates[lang.Count].Language = lang[lang.Count-1];
    }
    
    private async void ClearStrings()
    {
        await Task.Delay(2000);
        _processing = false;
        _complete = false;
    }

    public void OpenAllScenes()
    {
        for (int i = 0; i < UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings; i++)
        {
            var path = SceneUtility.GetScenePathByBuildIndex(i);
            Scenes.Add(EditorSceneManager.OpenScene(path, OpenSceneMode.Additive));
        }
    }

    public void CloseScenes()
    {
        foreach (var scene in Scenes)
        {
            EditorSceneManager.SaveScene(scene);
            EditorSceneManager.CloseScene(scene, true);
        }
        Scenes.Clear();
    }

    public void AddComponentToAllTexts()
    {
        var allTexts = FindObjectsOfType<Text>(true);
        foreach (var text in allTexts)
        {
            if (text.TryGetComponent(out TextTranslator findedText))
            {
                continue;
            }

            bool flag = false;
            
            foreach (var num in _numberChars)
            {
                if (text.text.Contains(num))
                {
                    flag = true;
                    break;
                }
            }

            if (!flag)
            {
                text.AddComponent<TextTranslator>();
            }
        }
    }

    private char[] _numberChars = new char[]
    {
        '0',
        '1',
        '2',
        '3',
        '4',
        '5',
        '6',
        '7',
        '8',
        '9'
    };
}

#endif