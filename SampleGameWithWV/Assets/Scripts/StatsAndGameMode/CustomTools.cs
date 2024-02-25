using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomTools : MonoBehaviour
{
    private AndroidJavaClass _unity;
    private AndroidJavaObject _activity;

    private static AndroidJavaObject _pluginInstance;

    private void Awake()
    {
        InitializePlugin("com.example.custom.Plugin");
    }

    private void InitializePlugin(string pluginName)
    {
        _unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        _activity = _unity.GetStatic<AndroidJavaObject>("currentActivity");
        _pluginInstance = new AndroidJavaObject(pluginName);

        _pluginInstance.CallStatic("RecieveUnityActivity", _activity);
    }

    public static bool IsUSBConnected()
    {
        try
        {
            return _pluginInstance.Call<bool>("IsUSBConnected");
        }
        catch (System.Exception ex)
        {
            throw new System.Exception(ex.Message);
        }
    }

    public static void Toast(string msg)
    {
        try
        {
            _pluginInstance.Call("Toast", msg);
        }
        catch (System.Exception ex)
        {
            throw new System.Exception(ex.Message);
        }
    }
}
