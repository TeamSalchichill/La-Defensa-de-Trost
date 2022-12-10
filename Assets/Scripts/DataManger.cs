using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;
using TMPro;

public class DataManger : MonoBehaviour
{
    public static DataManger instance;

    void Awake()
    {
        instance = this;
    }

    public void GetData()
    {
        PlayFabClientAPI.GetUserData(new GetUserDataRequest(), OnDataRecieved, OnError);
    }
    void OnDataRecieved(GetUserDataResult result)
    {
        print("Recieved user data!");
        if (result.Data != null && result.Data.ContainsKey("LevelMax"))
        {
            GameManager.instance.UpdateMaxLevel(int.Parse(result.Data["LevelMax"].Value));
        }
    }
    public void SaveData(int levelMax)
    {
        var request = new UpdateUserDataRequest
        {
            Data = new Dictionary<string, string>
            {
                {"LevelMax", (levelMax).ToString()}
            }
        };

        GameManager.instance.UpdateMaxLevel(levelMax);

        PlayFabClientAPI.UpdateUserData(request, OnDataSend, OnError);
    }
    void OnDataSend(UpdateUserDataResult result)
    {
        print("Successful user data send!");
    }

    void OnError(PlayFabError error)
    {
        print(error.GenerateErrorReport());
    }
}
