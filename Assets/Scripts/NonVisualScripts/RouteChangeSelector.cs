using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class RouteChangeSelector : MonoBehaviour
{
    public ApiConnector apiConnector;
    public TMP_Text routeChangeSelectorText;

    public void Start()
    {
        apiConnector.isRouteB = false;
    }

    public void OnRouteButtonClicked()
    {
        apiConnector.isRouteB = !apiConnector.isRouteB;
        if (apiConnector.isRouteB)
        {
            routeChangeSelectorText.text = "Route B";
        }
        else
        {
            routeChangeSelectorText.text = "Route A";
        }
    }
}
