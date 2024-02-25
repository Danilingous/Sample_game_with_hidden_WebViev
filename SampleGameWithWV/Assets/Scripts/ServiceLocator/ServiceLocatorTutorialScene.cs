using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceLocatorTutorialScene : MonoBehaviour
{
    [SerializeField] private TutorialSceneManager _tutorialSceneManager;
    [SerializeField] private UIManagerTutorialScene _uiManagerTutorialScene;
    [SerializeField] private PlayerMove _playerMove;
    [SerializeField] private TutorialScenePrefabsKepper _tutorialScenePrefabsKepper;
    private void Awake()
    {
        ServiceLocator.Initialize();
        RegisterServices();
    }

    private void RegisterServices()
    {
        ServiceLocator.Current.RegisterService(_tutorialSceneManager);
        ServiceLocator.Current.RegisterService(_uiManagerTutorialScene);
        ServiceLocator.Current.RegisterService(_playerMove);
        ServiceLocator.Current.RegisterService(_tutorialScenePrefabsKepper);
    }
       
}
