using UnityEngine;

public class PrefabsKeeper : MonoBehaviour,IService
{
   [SerializeField] private GameObject _leftHockeyStick;
   [SerializeField] private GameObject _rightHockeyStick;
   [SerializeField] private GameObject _coinsParticle;
    [SerializeField] private GameObject[] _explosionPrefabs;

    public GameObject GetLeftHockeyStick()
    {
        return Instantiate(_leftHockeyStick);
    }

    public GameObject GetRightHockeyStick()
    {
        return Instantiate(_rightHockeyStick);
    }

    public GameObject GetCoinsParticle()
    {
        return Instantiate(_coinsParticle);
    }

    public  GameObject GetExplosionEffect()
    {
        return Instantiate(_explosionPrefabs[Random.Range(0,_explosionPrefabs.Length)]);
    }
}
