using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneMaster : MonoBehaviour, IService
{
    public bool IsAvalicbleClickButtons { get; private set; } = true;

    public void LetClickUIButtons() => IsAvalicbleClickButtons = true;
    public void ForbidClickUIButtons() => IsAvalicbleClickButtons = false;

    private void Awake()
    {
        Time.timeScale = 1;
    }
    private void Start()
    {
        if(!PlayerPrefs.HasKey(StringCommomValues.PPFirstOpenGame))
        {
            ServiceLocator.Current.GetService<UIMasterMenuScene>().OpenCanvasFirstOpen();
        }
    }
    private bool CheckAvaliableClickButtons()
    {
        if(IsAvalicbleClickButtons)
        {
            ServiceLocator.Current.GetService<SoundManagerMenuScene>().PlayClickSound();
            return true;
        }
        return false;
    }
    #region MethodsForButtons

    public void ClickStartButton()
    {
        if (CheckAvaliableClickButtons())
        {
            if (PlayerPrefs.HasKey(StringCommomValues.PPFirstOpenGameScene))
            {
                SceneManager.LoadScene(StringCommomValues.GameSceneName);
            }
            else
            {
                PlayerPrefs.SetInt(StringCommomValues.PPFirstOpenGameScene, 1);
                PlayerPrefs.Save();
                SceneManager.LoadScene(StringCommomValues.TutorialSceneName);
            }
        }
    }

    public void ClickSettingsButton()
    {
        if (CheckAvaliableClickButtons())
            ServiceLocator.Current.GetService<UIMasterMenuScene>().OpenSettingsCanvas();
    }
    public void ClickBackButtonToMenuFromSettings()
    {
        if (CheckAvaliableClickButtons())
            ServiceLocator.Current.GetService<UIMasterMenuScene>().ClothSettingsCanvas();
    }

    public void ClickRecordsButton()
    {
        if (CheckAvaliableClickButtons())
            ServiceLocator.Current.GetService<UIMasterMenuScene>().OpenRecordsCanvas();
    }
    public void ClickBackButtonToMenuFromREcords()
    {
        if (CheckAvaliableClickButtons())
            ServiceLocator.Current.GetService<UIMasterMenuScene>().ClothRecordsCanvas();
    }

    public void ClickButtonClothCanvasFirstOpen()
    {
        PlayerPrefs.SetInt(StringCommomValues.PPFirstOpenGame, 1);
        PlayerPrefs.Save();
        ServiceLocator.Current.GetService<UIMasterMenuScene>().ClothCanvasFirstOpen();
    }

    public void ClickButtonTerms()
    {
        if (CheckAvaliableClickButtons())
            ServiceLocator.Current.GetService<UIMasterMenuScene>().OpenCanvasTerms();
    }
    public void ClickButtonPrivacy()
    {
        if (CheckAvaliableClickButtons())
            ServiceLocator.Current.GetService<UIMasterMenuScene>().OpenCanvasPrivacy();
    }

    public void ClickWriteUs()
    {
        if (CheckAvaliableClickButtons())
            Application.OpenURL("mailto:"+"");
    }

    public void ClickRateUs()
    {
        if (CheckAvaliableClickButtons())
            Application.OpenURL("market://details?id=" + Application.identifier);
    }

    public void ClickSoundButton()
    {
        if (CheckAvaliableClickButtons())
            ServiceLocator.Current.GetService<SoundModeButton>().CLick();
    }
    public void ClickLanguageButton()
    {
        if (CheckAvaliableClickButtons())
            ServiceLocator.Current.GetService<UIMasterMenuScene>().OpenCanvasLanguage();
    }
    #endregion

    public void RegisterHandler()
    {
        Debug.Log(this.GetType().Name + " registred");
    }
}
