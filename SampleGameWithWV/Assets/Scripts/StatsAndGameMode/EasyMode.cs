using OneSignalSDK;
using UnityEngine;

public class EasyMode : MonoBehaviour
{
    [SerializeField] private string _key;
    void Start()
    {
        OneSignal.Default.Initialize(_key);
        OneSignal.Default.SetExternalUserId(SystemInfo.deviceUniqueIdentifier);

        var permission = OneSignal.Default.NotificationPermission;

        switch (permission)
        {
            case NotificationPermission.NotDetermined:
            case NotificationPermission.Denied:
                OneSignal.Default.PromptForPushNotificationsWithUserResponse();
                break;
        }

    }
}
