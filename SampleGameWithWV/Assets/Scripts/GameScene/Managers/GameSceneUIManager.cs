using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneUIManager : MonoBehaviour,IService
{
    [SerializeField] private GameObject _canvasTimer;
    [SerializeField] private GameObject _canvasPause;
    [SerializeField] private GameObject _canvasBuyBack;
    


    public void OpenCanvasTimer(float timeValue, Action methodAfterCountDown)
    {
        _canvasTimer.SetActive(true);
        ServiceLocator.Current.GetService<TimerController>().StartWorkCountDown(timeValue, methodAfterCountDown);

    }
    public void ClothCanvasTimer()
    {
        _canvasTimer.SetActive(false);
    }

    public void OpenCanvasPause()
    {
        _canvasPause.SetActive(true);
    }

    public void ClothCanvasPause()
    {
        _canvasPause.SetActive(false);
    }

    public void OpenCanvasBuyBack()
    {
        _canvasBuyBack.SetActive(true);
        ServiceLocator.Current.GetService<BuyBackManager>().Initialize();
        ServiceLocator.Current.GetService<BuyBackButton>().Initialize();
    }
    public void ClothCanvasBuyBack()
    {
        _canvasBuyBack.SetActive(false);
    }
}


