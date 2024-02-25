using UnityEngine;

public class UIManagerTutorialScene : MonoBehaviour,IService
{
    [SerializeField] private GameObject _canvasManageSwipes;
    [SerializeField] private GameObject _canvasCollectCoins;
    [SerializeField] private GameObject _canvasDodge;
    [SerializeField] private GameObject _canvasLuck;

    public void ClothCanvasManagerSwipe()
    {
        _canvasManageSwipes.SetActive(false);
    }

    public void OpenCanvasCollectCoins()
    {
        _canvasCollectCoins.SetActive(true);
    }

    public void ClothCanvasCollectCoins()
    {
        _canvasCollectCoins.SetActive(true);
    }

    public void OpenCanvasDodge()
    {
        _canvasDodge.SetActive(true);
    }

    public void ClothCanvasDodge()
    {
        _canvasDodge.SetActive(false);
    }

    public void OpenCanvasLuck()
    {
        _canvasLuck.SetActive(true);
    }
}
