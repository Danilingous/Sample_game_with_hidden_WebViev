using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackSoundManagerr : MonoBehaviour
{
    private static BackSoundManagerr Inctance;

    private void Awake()
    {
        if (Inctance == null)
        {
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
            Inctance = this;
        }
        else Destroy(gameObject);
    }

}
