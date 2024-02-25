using UnityEngine;

public class UIMasterMenuScene : MonoBehaviour, IService
{
    [SerializeField] private GameObject _canvasFirstOpen;
    [SerializeField] private GameObject _canvasTerms;
    [SerializeField] private GameObject _canvasPrivacy;
    [SerializeField] private GameObject _canvasLanguage;

    [SerializeField] private GameObject _backImageCanvasMenu;
    [SerializeField] private GameObject _backImageCanvasSettings;
    [SerializeField] private GameObject _backImageCanvasRecords;

    public void OpenCanvasFirstOpen()
    {
        _canvasFirstOpen.SetActive(true);
    }
    public void ClothCanvasFirstOpen()
    {
        _canvasFirstOpen.SetActive(false);
    }

    public void OpenSettingsCanvas()
    {
        ServiceLocator.Current.GetService<CanvasAnimationMaster>().ReplaceCanvases(_backImageCanvasMenu, _backImageCanvasSettings);
    }

    public void ClothSettingsCanvas()
    {
        ServiceLocator.Current.GetService<CanvasAnimationMaster>().ReplaceCanvases(_backImageCanvasSettings, _backImageCanvasMenu);
    }

    public void OpenRecordsCanvas()
    {
        ServiceLocator.Current.GetService<CanvasAnimationMaster>().ReplaceCanvases(_backImageCanvasMenu, _backImageCanvasRecords);
    }
    public void ClothRecordsCanvas()
    {
        ServiceLocator.Current.GetService<CanvasAnimationMaster>().ReplaceCanvases(_backImageCanvasRecords, _backImageCanvasMenu);
    }

    public void RegisterHandler()
    {
        Debug.Log(this.GetType().Name + " registred");
    }


    public void OpenCanvasTerms()
    {
        _canvasTerms.SetActive(true);
    }
    public  void ClothCanvasTerms()
    {
        _canvasTerms.SetActive(false);
    }

    public void OpenCanvasPrivacy()
    {
        _canvasPrivacy.SetActive(true);
    }
    public void ClothCanvasPrivacy()
    {
        _canvasPrivacy.SetActive(false);
    }

    public void OpenCanvasLanguage()
    {
        _canvasLanguage.SetActive(true);
    }
    public void ClothCanvasLanguage()
    {
        _canvasLanguage.SetActive(false);
    }
}
