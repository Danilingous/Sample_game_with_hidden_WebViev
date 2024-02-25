using UnityEngine;
using UnityEngine.UI;

public class BuyBackManager : MonoBehaviour,IService
{
    [SerializeField] private Text _textBuyBackCost;
    public int BuyBackCost { get; private set; } = 10;

    public void Initialize()
    {
        _textBuyBackCost.text = BuyBackCost.ToString();
    }

    public void IncreaseCost()
    {
        BuyBackCost *= 2;
    }
}
