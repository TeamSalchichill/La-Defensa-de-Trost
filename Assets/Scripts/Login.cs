using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;
using TMPro;

public class Login : MonoBehaviour
{
    public GameObject loginScreen;

    public TMP_InputField user;
    public TMP_InputField pass;
    public TextMeshProUGUI info;

    public TextMeshProUGUI playerName;

    public void RegisterButton()
    {
        if (pass.text.Length < 6)
        {
            info.text = "Password too short!";
            return;
        }

        if (user.text.Contains("@") || user.text.Contains("."))
        {
            info.text = "No puede contener @ ni .";
            return;
        }

        string userGmail = user.text + "@gmail.com";

        var request = new RegisterPlayFabUserRequest
        {
            Email = userGmail,
            Password = pass.text,
            RequireBothUsernameAndEmail = false
        };
        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnError);
    }
    void OnRegisterSuccess(RegisterPlayFabUserResult result)
    {
        info.text = "registered and logged in!";
        loginScreen.SetActive(false);

        playerName.text = "Preparate para defender Trost " + user.text;

        GameManager.instance.UpdateMaxLevel(1);
        GameManager.instance.UpdateFirstTime();
    }

    public void LoginButton()
    {
        string userGmail = user.text + "@gmail.com";

        var request = new LoginWithEmailAddressRequest
        {
            Email = userGmail,
            Password = pass.text
        };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnError);
    }
    void OnLoginSuccess(LoginResult result)
    {
        info.text = "Logged in!";
        print("Successful login/account create!");
        loginScreen.SetActive(false);

        playerName.text = "Preparate para defender Trost " + user.text;

        DataManger.instance.GetData();
        GameManager.instance.UpdateFirstTime();
    }

    void OnError(PlayFabError error)
    {
        info.text = error.ErrorMessage;
        print(error.GenerateErrorReport());
    }
}
