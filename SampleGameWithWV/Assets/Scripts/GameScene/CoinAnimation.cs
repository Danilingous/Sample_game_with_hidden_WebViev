using System.Collections;
using UnityEngine;

public class CoinAnimation : MonoBehaviour
{
    [SerializeField] private GameObject _coinObject;
    [SerializeField] private GameObject _shadowObject;

    private void Start()
    {
        StartCoroutine(CoroutineCoinChangeSize());
    }
    private IEnumerator CoroutineCoinChangeSize()
    {
        float currentSize = 1;
        float changeSizeSteap = 0.01f;
        while (true)
        {
            currentSize += changeSizeSteap;
            _coinObject.transform.localScale = new Vector3(currentSize, currentSize, currentSize);
            _coinObject.transform.localPosition += new Vector3(0, changeSizeSteap, 0);
           // _shadowObject.transform.localScale = new Vector3(currentSize, currentSize, currentSize);
            if (currentSize > 1.2f || currentSize < 1f)
            {
                changeSizeSteap *= -1;
              
            }
            yield return new WaitForSeconds(0.05f);
        }
    }

}
