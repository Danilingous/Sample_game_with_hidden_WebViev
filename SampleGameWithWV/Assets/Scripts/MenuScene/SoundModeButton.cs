using UnityEngine;
using UnityEngine.UI;

public class SoundModeButton : MonoBehaviour,IService
{
    [SerializeField] private Image _imageCurrentSoundMode;
    [SerializeField] private Sprite _spriteSoundOn;
    [SerializeField] private Sprite _spriteSoundOff;
    private void Start()
    {
        InitializeButton();
    }

    private void InitializeButton()
    {
        if(PlayerPrefs.HasKey(StringCommomValues.PPSoundMode))
        {
            if(PlayerPrefs.GetInt(StringCommomValues.PPSoundMode)==1)
            {
                _imageCurrentSoundMode.sprite = _spriteSoundOn;
                AudioListener.volume = 1;
            }
            else
            {
                _imageCurrentSoundMode.sprite = _spriteSoundOff;
                AudioListener.volume = 0;
            }
        }
        else
        {
            AudioListener.volume = 1;
            PlayerPrefs.SetInt(StringCommomValues.PPSoundMode, 1);
            PlayerPrefs.Save();
        }
    }

    public void CLick()
    {
        if(AudioListener.volume == 1)
        {
            AudioListener.volume = 0;
            _imageCurrentSoundMode.sprite = _spriteSoundOff;
        }
        else
        {
            AudioListener.volume = 1;
            _imageCurrentSoundMode.sprite = _spriteSoundOn;
        }
        PlayerPrefs.SetInt(StringCommomValues.PPSoundMode, (int)AudioListener.volume);
        PlayerPrefs.Save();
    }
}
