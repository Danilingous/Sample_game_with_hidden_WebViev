using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TextTranslator : MonoBehaviour
{
    public bool Upper;
    public bool FirstUpper;
    public TranslateData[] Translates = Array.Empty<TranslateData>();
    
    private Text _textComponent;

    public string GetText()
    {
        _textComponent = GetComponent<Text>();
        return _textComponent.text;
    }

    private void Awake()
    {
        Language.OnChangeLanguage += ChangeLanguage;
        _textComponent = GetComponent<Text>();
        
        if (Upper)
        {
            UpperCase();
        }
        else if (FirstUpper)
        {
            FirstUpperCase();
        }
        
        ChangeLanguage(Language.GetLanguage());
    }

    private void OnDestroy()
    {
        Language.OnChangeLanguage -= ChangeLanguage;
    }

    private void ChangeLanguage(string language)
    {
        if (Translates.Length == 0)
        {
            return;
        }
        foreach (var translate in Translates)
        {
            if (translate.Language == language)
            {
                _textComponent.text = translate.Text;
                return;
            }
        }
        _textComponent.text = Translates[0].Text;
    }

    private void UpperCase()
    {
        for (int i = 0; i < Translates.Length; i++)
        {
            Translates[i].Text = Translates[i].Text.ToUpper();
        }
    }

    private void FirstUpperCase()
    {
        for (int i = 0; i < Translates.Length; i++)
        {
            var text = Translates[i].Text[0].ToString().ToUpper() + Translates[i].Text.Substring(1).ToLower();
            Translates[i].Text = text;
        }
    }
}

[Serializable]
public struct TranslateData
{
    public string Language;
    public string Text;
}