using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ApiConnector : MonoBehaviour
{
    public ScreenHandler screenHandler;
    public LoadHandler loadHandler;

    public List<Appointment> appointments;

    [Header("Dependencies")]
    public UserApiClient userApiClient;
    public AppointmentApiClient appointmentApiClient;

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

    #region Appoinment

    [ContextMenu("Appointment/Read all")]
    public async Task ReadAppointments()
    {
        IWebRequestReponse webRequestResponse = await appointmentApiClient.ReadAppointments();

        switch (webRequestResponse)
        {
            case WebRequestData<List<Appointment>> dataResponse:
                List<Appointment> appointments = dataResponse.Data;
                appointments.Clear();
                
                foreach (var appointment in appointments)
                {
                    Debug.Log($"Afspraak: {appointment.Reason}");
                }

                loadHandler.ContinueLoadingAppointmentScreen();

                // TODO: Handle succes scenario.
                break;
            case WebRequestError errorResponse:
                string errorMessage = errorResponse.ErrorMessage;
                Debug.Log("Read appointments error: " + errorMessage);
                // TODO: Handle error scenario. Show the errormessage to the user.
                break;
            default:
                throw new NotImplementedException("No implementation for webRequestResponse of class: " + webRequestResponse.GetType());
        }
    }

    [ContextMenu("Appointment/Create")]
    public async void CreateAppointment(Appointment appointment)
    {
        IWebRequestReponse webRequestResponse = await appointmentApiClient.CreateAppointment(appointment);

        switch (webRequestResponse)
        {
            case WebRequestData<Appointment> dataResponse:
                Debug.Log("Created appointment");
                break;
            case WebRequestError errorResponse:
                string errorMessage = errorResponse.ErrorMessage;
                Debug.Log("Create appointment error: " + errorMessage);
                // TODO: Handle error scenario. Show the errormessage to the user.
                break;
            default:
                throw new NotImplementedException("No implementation for webRequestResponse of class: " + webRequestResponse.GetType());
        }
    }

    [ContextMenu("Appointment/Delete")]
    public async void DeleteEnvironment2D(string appointmentId)
    {
        IWebRequestReponse webRequestResponse = await appointmentApiClient.DeleteAppointment(appointmentId);

        switch (webRequestResponse)
        {
            case WebRequestData<string> dataResponse:
                string responseData = dataResponse.Data;

                Debug.Log("Deletion confimed");
                // TODO: Handle succes scenario.
                break;
            case WebRequestError errorResponse:
                string errorMessage = errorResponse.ErrorMessage;
                Debug.Log("Delete appointment error: " + errorMessage);
                // TODO: Handle error scenario. Show the errormessage to the user.
                break;
            default:
                throw new NotImplementedException("No implementation for webRequestResponse of class: " + webRequestResponse.GetType());
        }
    }

    #endregion

}