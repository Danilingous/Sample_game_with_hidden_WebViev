using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour,IService
{
    private readonly float _startTimmeDelay = 2;
    private readonly float _solveTime = 10;
    private readonly float _shortSolveTime = 3;

    private void Awake()
    {
        Time.timeScale = 1;
    }
    private void Start()
    {
        ServiceLocator.Current.GetService<TimerController>().StartWorkCountDown(_startTimmeDelay, StartGameplay);
    }
    private void StartGameplay()
    {
        ServiceLocator.Current.GetService<GameSwipesDetecter>().StartDetecteSwipes();
        ServiceLocator.Current.GetService<GameSceneUIManager>().ClothCanvasTimer();
        ServiceLocator.Current.GetService<ObjectsCreator>().CreateLine();
        ServiceLocator.Current.GetService<PauseButtonController>().ActivateButton();
        ServiceLocator.Current.GetService<PointsCounter>().StartAddPoint();

    }

    public void ClickButtonPause()
    {
        Time.timeScale = 0;
        ServiceLocator.Current.GetService<PauseButtonController>().DeactivateButton();
        ServiceLocator.Current.GetService<GameSwipesDetecter>().StopDetecteSwipes();
        ServiceLocator.Current.GetService<GameSceneUIManager>().OpenCanvasPause();
    }

    public void ClickButtonContinueGame()
    {
        ServiceLocator.Current.GetService<PauseButtonController>().ActivateButton();
        ServiceLocator.Current.GetService<GameSceneUIManager>().ClothCanvasPause();
        ServiceLocator.Current.GetService<GameSwipesDetecter>().StartDetecteSwipes();
        Time.timeScale = 1;
    }

    public void ClickButtonTutorial()
    {
        SceneManager.LoadScene(StringCommomValues.TutorialSceneName);
    }
    public void PuckAndHockeyCollisionBehavior()
    {
        StartCoroutine(CoroutinePuckAndHockeyCollisionBehavior());
    }

    private IEnumerator CoroutinePuckAndHockeyCollisionBehavior()
    {
        HockeyStick[] sticks = FindObjectsOfType<HockeyStick>();
        for (int i = 0; i < sticks.Length; i++) Destroy(sticks[i].gameObject);
        Time.timeScale = 0; 
        ServiceLocator.Current.GetService<GameSwipesDetecter>().StopDetecteSwipes();
        yield return new WaitForSecondsRealtime(0.5f);
        float timeToSolve = 0;
        if (ServiceLocator.Current.GetService<CoinsManager>().CoinsCount > ServiceLocator.Current.GetService<BuyBackManager>().BuyBackCost)
        {
            timeToSolve = _solveTime;
        }
        else timeToSolve = _shortSolveTime;
        ServiceLocator.Current.GetService<GameSceneUIManager>().OpenCanvasTimer(timeToSolve, ReloadGame);
        ServiceLocator.Current.GetService<GameSceneUIManager>().OpenCanvasBuyBack();
    }

    public void ReloadGame()
    {
        ServiceLocator.Current.GetService<PointsCounter>().TrySaveReord();
        SceneManager.LoadScene(StringCommomValues.GameSceneName);
    }

    public void BackToMenuScene()
    {
        ServiceLocator.Current.GetService<PointsCounter>().TrySaveReord();
        SceneManager.LoadScene(StringCommomValues.MenuSceneName);
    }

    public void ContinueGameAfterBuyBack()
    {
        ServiceLocator.Current.GetService<TimerController>().StopCountDown();
        ServiceLocator.Current.GetService<BuyBackManager>().IncreaseCost();
        ServiceLocator.Current.GetService<GameSceneUIManager>().ClothCanvasTimer();
        ServiceLocator.Current.GetService<GameSceneUIManager>().ClothCanvasBuyBack();
        ServiceLocator.Current.GetService<PauseButtonController>().ActivateButton();
        ServiceLocator.Current.GetService<GameSwipesDetecter>().StartDetecteSwipes();
        Destroy(FindObjectOfType<CrashEfect>().gameObject);

        HockeyPlayerCollision[] hockyePlayers = FindObjectsOfType<HockeyPlayerCollision>();
        for(int i=0; i< hockyePlayers.Length;i++)
        {
            GameObject explosionEffecct = ServiceLocator.Current.GetService<PrefabsKeeper>().GetExplosionEffect();
            explosionEffecct.transform.localScale = hockyePlayers[i].transform.localScale;
            explosionEffecct.transform.position = hockyePlayers[i].transform.position;
            Destroy(hockyePlayers[i].gameObject);
        }
        Time.timeScale = 1;
    }

}
