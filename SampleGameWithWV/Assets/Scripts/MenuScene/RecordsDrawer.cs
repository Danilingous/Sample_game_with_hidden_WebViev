using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecordsDrawer : MonoBehaviour
{
    private int[] _recordsValue;
    [SerializeField] private Text[] _textRecords;
    private void Start()
    {
        DrawRecords();
    }

    private void DrawRecords()
    {
        ServiceLocator.Current.GetService<RecordsManager>().GetRecords(out _recordsValue);
        for(int i=0;i<_recordsValue.Length;i++)
        {
            _textRecords[i].text = (i + 1).ToString() + ". " + _recordsValue[i].ToString();
        }
    }
}
