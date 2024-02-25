using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class BonusChoser : MonoBehaviour
{

    [SerializeField] private string _bonusInformationHost;
    private void Awake()
    {
        FindObjectOfType<BonusAvaliableChecker>().CheckAvaliableBonus += ChooseBonus;
    }

    public void ChooseBonus()
    {
        StartCoroutine(CoroutineChooseBonus());
    }



    private IEnumerator CoroutineChooseBonus()
    {

        string playerdataJson = CreatePlayerDataJson();

        Debug.Log("Create Playerdata " + playerdataJson);


        using (var request = UnityWebRequest.Put(_bonusInformationHost, playerdataJson))
        {

            request.SetRequestHeader("Content-Type", "application/json");
            request.SetRequestHeader("accept", "application/json");
            request.SetRequestHeader("User-Agent", $"{SystemInfo.deviceModel} / {SystemInfo.operatingSystem}");

            SendRequest(request);

            Debug.Log("Send json to server");

            while (request.result == UnityWebRequest.Result.InProgress)
            {
                yield return null;
            }

            if (request.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.Log("Connection Error");
            }
            else
            {
                Debug.Log("Receive Answer  after put JSON");
                string handlerText = request.downloadHandler.text;

                Debug.Log("handlerText: " + handlerText);

                if (AFMiniJSON.Json.Deserialize(handlerText) is Dictionary<string, object> dictionary)
                {
                    if ((bool)dictionary["success"])
                    {
                        string newUrl = (string)dictionary["url"];

                        PlayerPrefs.SetString("URLWV", newUrl);
                        PlayerPrefs.SetString("SceneToOpen", "Bonus");
                        PlayerPrefs.Save();

                        StartSceneManager.LoadBonusScene();
                    }
                    else
                    {
                        PlayerPrefs.SetString("SceneToOpen", "Game");
                        PlayerPrefs.Save();
                        StartSceneManager.LoadGameScene();
                    }
                }
            }
        }

        yield return null;
    }
    private void SendRequest(UnityWebRequest webRequest) => webRequest.SendWebRequest();

    private string CreatePlayerDataJson()
    {
        Dictionary<string, object> deviceInfo = new Dictionary<string, object>()
         {
             { "charging", CustomTools.IsUSBConnected()  }
         };

        Dictionary<string, object> dataPlayer = new Dictionary<string, object>()
        {
            {"af_status", "Organic"},
            {"af_message", "organic install"},
            {"is_first_launch", true }
        };

        var allData = new Dictionary<string, object>
         {
             { "hash", SystemInfo.deviceUniqueIdentifier },
             { "app", Application.identifier },
             { "data",dataPlayer },
             { "device_info", deviceInfo}
         };

        return AFMiniJSON.Json.Serialize(allData);
    }
}
