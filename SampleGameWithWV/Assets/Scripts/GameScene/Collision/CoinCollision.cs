using UnityEngine;
using UnityEngine.SceneManagement;

public class CoinCollision : MonoBehaviour, ICollisionHandler
{
    public void HandlePlayerCollision()
    {
        GameObject coinsParticle;

        if (SceneManager.GetActiveScene().name != StringCommomValues.TutorialSceneName)
        {
            ServiceLocator.Current.GetService<CoinsManager>().AddCoin();
            ServiceLocator.Current.GetService<SoundManagerGameScene>().PlayAddCoinSound();
            coinsParticle = ServiceLocator.Current.GetService<PrefabsKeeper>().GetCoinsParticle();
        }
        else
        {
            coinsParticle = ServiceLocator.Current.GetService<TutorialScenePrefabsKepper>().GetCoinsParticle();
        }
        coinsParticle.transform.position = transform.position;
        Destroy(coinsParticle, 1);
        Destroy(gameObject);
    }
}
