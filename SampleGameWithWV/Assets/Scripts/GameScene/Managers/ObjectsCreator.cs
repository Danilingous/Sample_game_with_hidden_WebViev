using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsCreator : MonoBehaviour,IService
{
    [SerializeField] private GameObject[] _objectsLines;

    public void CreateLine()
    {
        Destroy(Instantiate(_objectsLines[Random.Range(0, _objectsLines.Length)]), 10);
    }

    
}
