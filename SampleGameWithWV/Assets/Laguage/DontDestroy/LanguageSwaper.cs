using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageSwaper : MonoBehaviour
{
    private void Awake()
    {
        if (PlayerPrefs.HasKey("PPLanguage"))
        {
            Language.SwitchLanguage(PlayerPrefs.GetString("PPLanguage"));
        }
    }
    public void SwitchLanguageBttonsClick(string language)
    {
        Language.SwitchLanguage(language);

    }
}
