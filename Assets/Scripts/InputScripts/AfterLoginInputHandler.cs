using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;

public class AfterLoginInputHandler : MonoBehaviour
{
    public ApiConnector apiConnector;

    [SerializeField] TMP_InputField inputText;

    public TextMeshProUGUI buttontext;

    private bool routestatus = false;

    private int option;

    public void NameButtonClicked()
    {
        option = 1;
    }

    public void BirthDateButtonClicked()
    {
        option = 2;
    }

    public void RouteButtonClicked()
    {
        option = 3;
    }

    public void NameDocterButton()
    {
        option = 4;
    }

    public void ConfirmButtonClicked()
    {
        ChoiceRoute choiceRoute = new ChoiceRoute();

        switch (option)
        {
            case 1:
                Debug.Log($"ROUET 1 naam zou nu veranderd moeten worden naar {inputText.text}");
                choiceRoute.Id = apiConnector.currentChoiceRoute.Id;
                choiceRoute.UserId = apiConnector.currentChoiceRoute.UserId;
                choiceRoute.Path = apiConnector.currentChoiceRoute.Path;
                choiceRoute.Begining = apiConnector.currentChoiceRoute.Begining;
                choiceRoute.Middel = apiConnector.currentChoiceRoute.Middel;
                choiceRoute.Finish = apiConnector.currentChoiceRoute.Finish;
                choiceRoute.NamePatient = inputText.text;
                choiceRoute.BirthDate = apiConnector.currentChoiceRoute.BirthDate;
                choiceRoute.NameDoctor = apiConnector.currentChoiceRoute.NameDoctor;
                apiConnector.UpdateChoiceRoute(choiceRoute);
                break;
            case 2:
                break;
            case 3:
                Debug.Log($"ROUTE 3 code zou nu uitgevoerd worden om iets te sturen naar de db met route {buttontext.text}");
                break;
            case 4:
                break;
        }
    }

    public void ChangeRouteStatus()
    {
        routestatus = !routestatus;
        if (routestatus)
        {
            inputText.text = "b";
            buttontext.text = "b";
        }
        else if (!routestatus)
        {
            inputText.text = "a";
            buttontext.text = "a";
        }
    }
}
