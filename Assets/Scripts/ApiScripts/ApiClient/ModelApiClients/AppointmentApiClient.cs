using System;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class AppointmentApiClient : MonoBehaviour
{
    public WebClient webClient;

    public async Awaitable<IWebRequestReponse> ReadAppointments()
    {
        string route = "/appointments";

        IWebRequestReponse webRequestResponse = await webClient.SendGetRequest(route);
        return ParseEnvironment2DListResponse(webRequestResponse);
    }

    public async Awaitable<IWebRequestReponse> CreateAppointment(Appointment appointment)
    {
        string route = "/appointments";
        string data = JsonUtility.ToJson(appointment);

        IWebRequestReponse webRequestResponse = await webClient.SendPostRequest(route, data);
        return ParseEnvironment2DResponse(webRequestResponse);
    }

    public async Awaitable<IWebRequestReponse> DeleteAppointment(string appointmentId)
    {
        string route = "/appointments/" + appointmentId;
        return await webClient.SendDeleteRequest(route);
    }

    private IWebRequestReponse ParseEnvironment2DResponse(IWebRequestReponse webRequestResponse)
    {
        switch (webRequestResponse)
        {
            case WebRequestData<string> data:
                Debug.Log("Response data raw: " + data.Data);
                Appointment appointment = JsonUtility.FromJson<Appointment>(data.Data);
                WebRequestData<Appointment> parsedWebRequestData = new WebRequestData<Appointment>(appointment);
                return parsedWebRequestData;
            default:
                return webRequestResponse;
        }
    }

    private IWebRequestReponse ParseEnvironment2DListResponse(IWebRequestReponse webRequestResponse)
    {
        switch (webRequestResponse)
        {
            case WebRequestData<string> data:
                Debug.Log("Response data raw: " + data.Data);
                List<Appointment> appointments = JsonHelper.ParseJsonArray<Appointment>(data.Data);
                WebRequestData<List<Appointment>> parsedWebRequestData = new WebRequestData<List<Appointment>>(appointments);
                return parsedWebRequestData;
            default:
                return webRequestResponse;
        }
    }

}

