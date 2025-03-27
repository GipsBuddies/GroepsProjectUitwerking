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
    public bool isRouteB = false;

    public List<Appointment> appointments = new List<Appointment>();

    [Header("Dependencies")]
    public UserApiClient userApiClient;
    public AppointmentApiClient appointmentApiClient;
    public ChoiceRouteApiClient choiceRouteApiClient;

    [HideInInspector]
    public ChoiceRoute currentChoiceRoute;


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

                await ReadChoiceRoute();

                screenHandler.GoToAfterLoginScreen();
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
                appointments.Clear();
                foreach (var item in dataResponse.Data)
                {
                    Appointment a = new Appointment();
                    a.Date = item.Date;
                    a.Reason = item.Reason;
                    // eventueel extra velden kopiëren
                    appointments.Add(a);
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
                screenHandler.LoadAppointmentScreen();
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
    public async void DeleteAppointment(string appointmentId)
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

#region ChoiceRoute

[ContextMenu("ChoiceRoute/Read")]
public async Task ReadChoiceRoute()
{
    IWebRequestReponse webRequestResponse = await choiceRouteApiClient.ReadChoiceRoute();

    switch (webRequestResponse)
    {
        case WebRequestData<ChoiceRoute> dataResponse:
            currentChoiceRoute = dataResponse.Data;
            Debug.Log("Read ChoiceRoute succesvol");

            if (dataResponse.Data != null)
            {
                Debug.Log("Data is geen null dus choiseroute is al aangemaakt");  
                break;
            }
            else if (dataResponse.Data == null)
            {
                Debug.Log("Data is null dus choiseroute moet nog aangemaakt worden en gaat nu gebeuren.");
                ChoiceRoute choiceRoute = new ChoiceRoute();
                choiceRoute.Path = false;
                choiceRoute.Begining = false;
                choiceRoute.Middel = false;
                choiceRoute.Finish = false;
                choiceRoute.NamePatient = "";
                choiceRoute.BirthDate = new DateTime(2015, 1, 1);
                choiceRoute.NameDoctor = "";
                CreateChoiceRoute(choiceRoute);
                break;
            }

            break;
        case WebRequestError errorResponse:
            Debug.Log("Fout bij het ophalen van ChoiceRoute: " + errorResponse.ErrorMessage);
            break;
        default:
            throw new NotImplementedException("No implementation for webRequestResponse of class: " + webRequestResponse.GetType());
    }
}

[ContextMenu("ChoiceRoute/Create")]
public async void CreateChoiceRoute(ChoiceRoute newChoiceRoute)
{
    IWebRequestReponse webRequestResponse = await choiceRouteApiClient.CreateChoiceRoute(newChoiceRoute);

    switch (webRequestResponse)
    {
        case WebRequestData<ChoiceRoute> dataResponse:
            currentChoiceRoute = dataResponse.Data;
            Debug.Log("ChoiceRoute succesvol aangemaakt");
            break;
        case WebRequestError errorResponse:
            Debug.Log("Fout bij het aanmaken van ChoiceRoute: " + errorResponse.ErrorMessage);
            break;
        default:
            throw new NotImplementedException("No implementation for webRequestResponse of class: " + webRequestResponse.GetType());
    }
}

[ContextMenu("ChoiceRoute/Update")]
public async void UpdateChoiceRoute(ChoiceRoute updatedChoiceRoute)
{
    if (updatedChoiceRoute == null)
    {
        Debug.LogWarning("UpdateChoiceRoute: Geen geldig ChoiceRoute object opgegeven.");
        return;
    }

    IWebRequestReponse webRequestResponse = await choiceRouteApiClient.UpdateChoiceRouteForCurrentUser(updatedChoiceRoute);

    switch (webRequestResponse)
    {
        case WebRequestData<ChoiceRoute> dataResponse:
            currentChoiceRoute = dataResponse.Data;
            Debug.Log("ChoiceRoute succesvol bijgewerkt");
            break;
        case WebRequestError errorResponse:
            Debug.Log("Fout bij het bijwerken van ChoiceRoute: " + errorResponse.ErrorMessage);
            break;
        default:
            throw new NotImplementedException("No implementation for webRequestResponse of class: " + webRequestResponse.GetType());
    }
}

#endregion


}