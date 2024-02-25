using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsCounter : MonoBehaviour,IService
{
    [SerializeField] private Text _textPointsVallue;
    public int PointsValue { get; private set; } = 0;
    private int _addScoreValue=3;

    public void StartAddPoint()
    {
        StartCoroutine(CoroutineAddPoints());
        StartCoroutine(CoroutineIncreasseStep());
    }

    private IEnumerator CoroutineAddPoints()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.1f);
            PointsValue += _addScoreValue;
            DrawPointsValue();
        }
    }

    private IEnumerator CoroutineIncreasseStep()
    {
        while(true)
        {
            yield return new WaitForSeconds(3);
            _addScoreValue++;
        }
    }

    private void DrawPointsValue()
    {
        _textPointsVallue.text = PointsValue.ToString();
    }

    public void TrySaveReord()
    {
        StopAllCoroutines();
        ServiceLocator.Current.GetService<RecordsManager>().TrySaveNewRecord(PointsValue);
    }
}
