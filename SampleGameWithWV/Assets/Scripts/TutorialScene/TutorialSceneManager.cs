using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

public class TutorialSceneManager : MonoBehaviour,IService
{
    private void Awake()
    {
        Time.timeScale = 1;
    }
    private  void Start()
    {
        TutorialBehaviourAcync();
    }

    private async void TutorialBehaviourAcync()
    {
        await FirstActAcync();
        await SecondActAcync();
        await ThirdActAcync();
        await FourthActAcync();
        OpengameScene();
    }

    private async Task FirstActAcync()
    {
        await Task.Delay(500);
        ServiceLocator.Current.GetService<TutorialScenePrefabsKepper>().GetleftSwipeObject();
        await Task.Delay(1200);
        ServiceLocator.Current.GetService<TutorialScenePrefabsKepper>().GetRightSwipeObject();
    }
    private async Task SecondActAcync()
    {
        await Task.Delay(500);
        ServiceLocator.Current.GetService<TutorialScenePrefabsKepper>().GetCoinsObject();
        await Task.Delay(500);
        ServiceLocator.Current.GetService<UIManagerTutorialScene>().ClothCanvasManagerSwipe();
        ServiceLocator.Current.GetService<UIManagerTutorialScene>().OpenCanvasCollectCoins();
        await Task.Delay(500);
        ServiceLocator.Current.GetService<TutorialScenePrefabsKepper>().GetleftSwipeObject();

    }

    private async  Task ThirdActAcync()
    {
        await Task.Delay(1500);
        ServiceLocator.Current.GetService<TutorialScenePrefabsKepper>().GetHockeyPlayerObject();
        ServiceLocator.Current.GetService<UIManagerTutorialScene>().ClothCanvasCollectCoins();
        ServiceLocator.Current.GetService<UIManagerTutorialScene>().OpenCanvasDodge();
        await Task.Delay(900);
        ServiceLocator.Current.GetService<TutorialScenePrefabsKepper>().GetRightSwipeObject();
        await Task.Delay(900);
        ServiceLocator.Current.GetService<TutorialScenePrefabsKepper>().GetRightSwipeObject();
        await Task.Delay(2000);
    }

    private async Task FourthActAcync()
    {
        ServiceLocator.Current.GetService<TutorialScenePrefabsKepper>().GetleftSwipeObject();
        ServiceLocator.Current.GetService<UIManagerTutorialScene>().ClothCanvasDodge();
        ServiceLocator.Current.GetService<UIManagerTutorialScene>().OpenCanvasLuck();
        await Task.Delay(2000);
    }

    private void  OpengameScene()
    {
        SceneManager.LoadScene(StringCommomValues.GameSceneName);
    }
         
}
