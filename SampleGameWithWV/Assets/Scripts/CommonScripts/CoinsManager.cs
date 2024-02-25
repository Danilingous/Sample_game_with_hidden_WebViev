using UnityEngine;

public class CoinsManager : MonoBehaviour,IService
{
    private CoinsCountDrawer[] _coinsCountDrawers;
    public int CoinsCount { get; private set; } = 0;
    [SerializeField] private int _startCoinsCount = 30;

    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        _coinsCountDrawers = FindObjectsOfType<CoinsCountDrawer>();
        if (PlayerPrefs.HasKey(StringCommomValues.PPCoinsCount))
        {
            CoinsCount = PlayerPrefs.GetInt(StringCommomValues.PPCoinsCount);
        }
        else
        {
            CoinsCount = _startCoinsCount;
            SaveCoinsCount();
        }
        DrawCoinsCount();
    }

    private void SaveCoinsCount()
    {
        PlayerPrefs.SetInt(StringCommomValues.PPCoinsCount, CoinsCount);
        PlayerPrefs.Save();
    }

    private void DrawCoinsCount()
    {
        for(int i=0;i< _coinsCountDrawers.Length;i++)
        {
            _coinsCountDrawers[i].DrawCoinsCount(CoinsCount);
        }
    }

    public void RegisterHandler()
    {
        Debug.Log(this.GetType().Name + " registred");
    }

    public void AddCoin()
    {
        CoinsCount++;
        SaveCoinsCount();
        DrawCoinsCount();
    }

    public bool TrySpendCoins(int count)
    {
        if(CoinsCount>=count)
        {
            CoinsCount -= count;
            SaveCoinsCount();
            DrawCoinsCount();
            return true;
        }
        return false;
    }

}
