using UnityEngine;
using UnityEngine.UI;

public class BuyBackButton : MonoBehaviour,IService
{
    [SerializeField] private Button _button;
    [SerializeField] GameObject _forwardImage;

    public void Click()
    {
        if(ServiceLocator.Current.GetService<CoinsManager>().TrySpendCoins(ServiceLocator.Current.GetService<BuyBackManager>().BuyBackCost))
            ServiceLocator.Current.GetService<GameSceneManager>().ContinueGameAfterBuyBack();
    }

    public  void  Initialize()
    {
        if(ServiceLocator.Current.GetService<CoinsManager>().CoinsCount<ServiceLocator.Current.GetService<BuyBackManager>().BuyBackCost)
        {
            _button.enabled = false;
            _forwardImage.SetActive(true);
        }
    }
}
