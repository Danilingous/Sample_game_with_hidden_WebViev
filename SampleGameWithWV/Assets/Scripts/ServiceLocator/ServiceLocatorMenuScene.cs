using UnityEngine;

public class ServiceLocatorMenuScene : MonoBehaviour
{
    [SerializeField] private CoinsManager _coinsManager;
    [SerializeField] private CanvasAnimationMaster _canvasAnimationMaster;
    [SerializeField] private MenuSceneMaster _menuSceneMaster;
    [SerializeField] private UIMasterMenuScene _uiMasterMenuScene;
    [SerializeField] private SoundManagerMenuScene _soundManagerMenuScene;
    [SerializeField] private SoundModeButton _soundModeButton;
    [SerializeField] private RecordsManager _recordsManager;

    private void Awake()
    {
        ServiceLocator.Initialize();
        MakeServices();
    }

    private void MakeServices()
    {
        ServiceLocator.Current.RegisterService(_coinsManager);
        ServiceLocator.Current.RegisterService(_canvasAnimationMaster);
        ServiceLocator.Current.RegisterService(_menuSceneMaster);
        ServiceLocator.Current.RegisterService(_uiMasterMenuScene);
        ServiceLocator.Current.RegisterService(_soundManagerMenuScene);
        ServiceLocator.Current.RegisterService(_soundModeButton);
        ServiceLocator.Current.RegisterService(_recordsManager);
    }
}
