using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ApiConnector : MonoBehaviour
{
    public ScreenHandler screenHandler;

    [Header("Dependencies")]
    public UserApiClient userApiClient;

    #region Login

    [ContextMenu("User/Register")]
    public async void Register(User user)
    {
        IWebRequestReponse webRequestResponse = await userApiClient.Register(user);

        switch (webRequestResponse)
        {
            case WebRequestData<string> dataResponse:
                Debug.Log("Register succes");
                screenHandler.GoToLoginScreen();
                break;
            case WebRequestError errorResponse:
                Debug.Log($"Error: {errorResponse}");
                //error
                break;
            default:
                throw new NotImplementedException("No implementation for webRequestResponse of class: " + webRequestResponse.GetType());
        }
    }

    [ContextMenu("User/Login")]
    public async void Login(User user)
    {
        IWebRequestReponse webRequestResponse = await userApiClient.Login(user);

        switch (webRequestResponse)
        {
            case WebRequestData<string> dataResponse:
                Debug.Log("login succes");
                screenHandler.loggedIn = true;
                screenHandler.GoToHomeScreen();
                break;
            case WebRequestError errorResponse:
                Debug.Log($"Eror: {errorResponse}");
                //error
                break;
            default:
                throw new NotImplementedException("No implementation for webRequestResponse of class: " + webRequestResponse.GetType());
        }
    }

    [ContextMenu("User/Logout")]
    public async void Logout()
    {
        IWebRequestReponse webRequestResponse = await userApiClient.Logout();

        switch (webRequestResponse)
        {
            case WebRequestData<string> dataResponse:
                Debug.Log("Logout succes");
                screenHandler.GoToStartScreen();
                screenHandler.loggedIn = false;
                break;
            case WebRequestError errorResponse:
                Debug.Log($"Error: {errorResponse}");
                //error
                break;
            default:
                throw new NotImplementedException("No implementation for webRequestResponse of class: " + webRequestResponse.GetType());
        }
    }

    #endregion

}