
using UnityEngine;

public class ServiceLocatorGameScene : MonoBehaviour
{
    [SerializeField] private CoinsManager _coinsManager;
    [SerializeField] private GameSwipesDetecter _gameSwipesDetecter;
    [SerializeField] private PlayerMove _playerMove;
    [SerializeField] private HockeySticksCreator _hockeySticksCreator;
    [SerializeField] private SoundManagerGameScene _soundManagerGameScene;
    [SerializeField] private ForwardSpeedController _forwardSpeedController;
    [SerializeField] private PrefabsKeeper _prefabsKeeper;
    [SerializeField] private ObjectsCreator _objectsCreator;
    [SerializeField] private GameSceneManager _gameSceneManager;
    [SerializeField] private GameSceneUIManager _gameSceneUIManager;
    [SerializeField] private TimerController _timerController;
    [SerializeField] private PauseButtonController _pauseButtonController;
    [SerializeField] private BuyBackButton _buyBackButton;
    [SerializeField] private BuyBackManager _buyBackManager;
    [SerializeField] private RecordsManager _recordsManager;
    [SerializeField] private PointsCounter _pointsCounter;

    private void Awake()
    {
        ServiceLocator.Initialize();
        RegisterServices();
    }

    private void RegisterServices()
    {
        ServiceLocator.Current.RegisterService(_coinsManager);
        ServiceLocator.Current.RegisterService(_gameSwipesDetecter);
        ServiceLocator.Current.RegisterService(_playerMove);
        ServiceLocator.Current.RegisterService(_hockeySticksCreator);
        ServiceLocator.Current.RegisterService(_soundManagerGameScene);
        ServiceLocator.Current.RegisterService(_forwardSpeedController);
        ServiceLocator.Current.RegisterService(_prefabsKeeper);
        ServiceLocator.Current.RegisterService(_objectsCreator);
        ServiceLocator.Current.RegisterService(_gameSceneManager);
        ServiceLocator.Current.RegisterService(_gameSceneUIManager);
        ServiceLocator.Current.RegisterService(_timerController);
        ServiceLocator.Current.RegisterService(_pauseButtonController);
        ServiceLocator.Current.RegisterService(_buyBackButton);
        ServiceLocator.Current.RegisterService(_buyBackManager);
        ServiceLocator.Current.RegisterService(_recordsManager);
        ServiceLocator.Current.RegisterService(_pointsCounter);
    }
}
