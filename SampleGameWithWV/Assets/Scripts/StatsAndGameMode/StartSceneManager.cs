using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneManager 
{
    public static void LoadGameScene()
    {
        SceneManager.LoadScene(StringCommomValues.MenuSceneName);
    }

    public static void LoadBonusScene()
    {
        SceneManager.LoadScene(StringCommomValues.BonusSceneName);
    }
}
