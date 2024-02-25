using System;
using UnityEngine;


public class BonusAvaliableChecker : MonoBehaviour
{
    public event Action CheckAvaliableBonus = () => Debug.Log("Start checking the availability of the bonus");

    private void Awake()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            StartSceneManager.LoadGameScene();
        }
    }
    void Start()
    {
        var sceneToOpen = PlayerPrefs.GetString("SceneToOpen");
        if (sceneToOpen == "Game")
        {
            StartSceneManager.LoadGameScene();
        }
        else if (sceneToOpen == "Bonus")
        {
            Screen.orientation = ScreenOrientation.AutoRotation;
            StartSceneManager.LoadBonusScene();
        }
        else
        {
            CheckAvaliableBonus.Invoke();
        }
    }
}
