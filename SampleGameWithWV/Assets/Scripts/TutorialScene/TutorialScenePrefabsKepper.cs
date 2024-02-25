using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScenePrefabsKepper : MonoBehaviour,IService
{
    [SerializeField] private GameObject _leftSwipePrefag;
    [SerializeField] private GameObject _rightSwipePrefag;
    [SerializeField] private GameObject _coinsObject;
    [SerializeField] private GameObject _hockeyPlayerObject;
    [SerializeField] private GameObject _coinsParticle;

    public  GameObject GetleftSwipeObject()
    {
        return Instantiate(_leftSwipePrefag);
    }
    public GameObject GetRightSwipeObject()
    {
        return Instantiate(_rightSwipePrefag);
    }

    public GameObject GetCoinsObject()
    {
        return Instantiate(_coinsObject);
    }

    public GameObject GetHockeyPlayerObject()
    {
        return Instantiate(_hockeyPlayerObject);
    }

    public GameObject GetCoinsParticle()
    {
        return Instantiate(_coinsParticle);
    }
}
