using System;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class ChoiceRouteApiClient : MonoBehaviour
{
    public WebClient webClient;

    private const string Route = "/ChoiceRoute";

    public async Awaitable<IWebRequestReponse> ReadChoiceRoute()
    {
        IWebRequestReponse response = await webClient.SendGetRequest(Route);
        return ParseChoiceRouteResponse(response);
    }

    public async Awaitable<IWebRequestReponse> CreateChoiceRoute(ChoiceRouteCreateModel choiceRoute)
    {
        string data = JsonConvert.SerializeObject(choiceRoute, new JsonSerializerSettings
        {
            DateFormatString = "yyyy-MM-ddTHH:mm:ss"
        });

        IWebRequestReponse response = await webClient.SendPostRequest(Route, data);
        return ParseChoiceRouteResponse(response);
    }

    public async Awaitable<IWebRequestReponse> UpdateChoiceRouteForCurrentUser(ChoiceRoute updatedChoiceRoute)
    {
        // Als jouw backend de ID afleidt van de token, dan hoeft deze route geen querystring meer
        string route = "/ChoiceRoute";
        string data = JsonConvert.SerializeObject(updatedChoiceRoute);
        IWebRequestReponse response = await webClient.SendPutRequest(route, data);
        return ParseChoiceRouteResponse(response);
    }


    private IWebRequestReponse ParseChoiceRouteResponse(IWebRequestReponse webRequestResponse)
    {
        switch (webRequestResponse)
        {
            case WebRequestData<string> data:
                Debug.Log("Response data raw: " + data.Data);
                ChoiceRoute parsed = JsonConvert.DeserializeObject<ChoiceRoute>(data.Data);
                return new WebRequestData<ChoiceRoute>(parsed);
            default:
                return webRequestResponse;
        }
    }
}
