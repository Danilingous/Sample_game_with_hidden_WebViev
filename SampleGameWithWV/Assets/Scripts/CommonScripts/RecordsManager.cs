using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordsManager : MonoBehaviour,IService
{

    private int[] _records = new int[3];

    private void Awake()
    {
        InitIalize();
    }

    private void InitIalize()
    {
        for(int i=0;i<_records.Length;i++)
        {
            if(PlayerPrefs.HasKey(StringCommomValues.PPRecords+i.ToString()))
            {
                _records[i] = PlayerPrefs.GetInt(StringCommomValues.PPRecords + i.ToString());
            }
            else
            {
                PlayerPrefs.SetInt(StringCommomValues.PPRecords + i.ToString(), 0);
                _records[i] = 0;
            }
            PlayerPrefs.Save();
        }
    }

    public void GetRecords(out int[]array)
    {
        array = new int[_records.Length];
        for(int i=0;i<_records.Length;i++)
        {
            array[i] = _records[i];
        }
    }
    public void TrySaveNewRecord(int value)
    {
        if(value>_records[0])
        {
            _records[2] = _records[1];
            _records[1] = _records[0];
            _records[0] = value;
        }
        else if(value>_records[1])
        {
            _records[2] = _records[1];
            _records[1] = value;
        }
        else if(value > _records[2])
        {
            _records[2] = value;
        }
        SaveRecords();
    }
    private void SaveRecords()
    {
        for(int i=0;i< _records.Length; i++)
        {
            PlayerPrefs.SetInt(StringCommomValues.PPRecords + i.ToString(), _records[i]);
        }
        PlayerPrefs.Save();
    }
}


