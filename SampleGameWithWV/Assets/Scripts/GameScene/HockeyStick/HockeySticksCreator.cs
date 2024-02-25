using UnityEngine;

public class HockeySticksCreator : MonoBehaviour,IService
{
    [SerializeField] private Vector3 _leftOffset;
    [SerializeField] private Vector3 _rightOffset;

    public void CreateRightStick(Vector3 playerPosition)
    {
        GameObject newHocketStick = ServiceLocator.Current.GetService<PrefabsKeeper>().GetRightHockeyStick();
        newHocketStick.transform.position = playerPosition + _rightOffset;
       
        ServiceLocator.Current.GetService<SoundManagerGameScene>().PlayHockeyStickShotSound();
    }
    public void CreateLeftStick(Vector3 playerPosition)
    {
        GameObject newHocketStick = ServiceLocator.Current.GetService<PrefabsKeeper>().GetLeftHockeyStick();
        newHocketStick.transform.position = playerPosition + _rightOffset;

        ServiceLocator.Current.GetService<SoundManagerGameScene>().PlayHockeyStickShotSound();
    }
}
