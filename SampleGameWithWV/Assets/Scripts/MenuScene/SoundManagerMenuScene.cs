using UnityEngine;

public class SoundManagerMenuScene : MonoBehaviour,IService
{
    [SerializeField] private AudioSource _clickSound;

    public void PlayClickSound()
    {
        _clickSound.Play();
    }
    public void RegisterHandler()
    {
        Debug.Log(this.GetType().Name + " registred");
    }

}
