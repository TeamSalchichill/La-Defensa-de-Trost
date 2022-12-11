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

    public Button loginButtonInt;
    public Button registerButtonInt;
    public Button invitationButtonInt;

    public TMP_InputField user;
    public TMP_InputField pass;
    public TextMeshProUGUI info;

    public TextMeshProUGUI playerName;

    public Button wiki;

    public void RegisterButton()
    {
        loginButtonInt.interactable = false;
        registerButtonInt.interactable = false;
        invitationButtonInt.interactable = false;

        SoundManager.instance.SoundSelection(3, 0.5f);

        if (pass.text.Length < 6)
        {
            info.text = "La contraseña debe tener al menos 6 caracteres";

            loginButtonInt.interactable = true;
            registerButtonInt.interactable = true;
            invitationButtonInt.interactable = true;
            return;
        }

        if (user.text.Contains("@") || user.text.Contains("."))
        {
            info.text = "El usuario no puede contener \'@\' ni \'.\'";

            loginButtonInt.interactable = true;
            registerButtonInt.interactable = true;
            invitationButtonInt.interactable = true;
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
        loginButtonInt.interactable = true;
        registerButtonInt.interactable = true;
        invitationButtonInt.interactable = true;

        info.text = "Registro completado";
        print("Successful account create!");
        loginScreen.SetActive(false);

        playerName.text = "Preparate para defender Trost " + user.text;

        GameManager.instance.UpdateMaxLevel(0);
        GameManager.instance.UpdateFirstTime();

        DataManger.instance.SaveData(0);
    }

    public void LoginButton()
    {
        loginButtonInt.interactable = false;
        registerButtonInt.interactable = false;
        invitationButtonInt.interactable = false;

        SoundManager.instance.SoundSelection(3, 0.5f);

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
        info.text = "Entrando en Trost...";
        print("Successful login!");
        
        playerName.text = "Preparate para defender Trost " + user.text;

        DataManger.instance.GetData();
        GameManager.instance.UpdateFirstTime();

        Invoke("EnableStart", 5);
    }

    void OnError(PlayFabError error)
    {
        loginButtonInt.interactable = true;
        registerButtonInt.interactable = true;
        invitationButtonInt.interactable = true;

        info.text = error.ErrorMessage;
        print(error.GenerateErrorReport());
    }

    public void PlayInvitation()
    {
        loginButtonInt.interactable = false;
        registerButtonInt.interactable = false;
        invitationButtonInt.interactable = false;

        SoundManager.instance.SoundSelection(3, 0.5f);

        GameManager.instance.UpdateInvitate();
        loginScreen.SetActive(false);
        wiki.interactable = false;
        GameManager.instance.UpdateFirstTime();
    }

    void EnableStart()
    {
        loginScreen.SetActive(false);
    }

    public void OpenKeyBoard()
    {
        TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
    }
}
