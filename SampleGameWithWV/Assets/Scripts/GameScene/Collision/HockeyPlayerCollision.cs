using UnityEngine;
using UnityEngine.SceneManagement;

public class HockeyPlayerCollision : MonoBehaviour, ICollisionHandler
{
    public void HandlePlayerCollision()
    {
        if (SceneManager.GetActiveScene().name != StringCommomValues.TutorialSceneName)
        {
            ServiceLocator.Current.GetService<SoundManagerGameScene>().PlayHockeyStickShotSound();
            GameObject _collisionEffect = ServiceLocator.Current.GetService<PrefabsKeeper>().GetExplosionEffect();
            _collisionEffect.transform.position = ServiceLocator.Current.GetService<PlayerMove>().gameObject.transform.position + new Vector3(0, 1, 0);
            ServiceLocator.Current.GetService<GameSceneManager>().PuckAndHockeyCollisionBehavior();
        }
    }
}
