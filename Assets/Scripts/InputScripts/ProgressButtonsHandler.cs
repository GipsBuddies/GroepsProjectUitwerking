using UnityEngine;
using UnityEngine.UI;

public class ProgressButtonsHandler : MonoBehaviour
{
    public ApiConnector apiConnector;
    public ScreenHandler screenHandler;
    public void PrephaseButtonClicked()
    {
        apiConnector.currentChoiceRoute.Begining = !apiConnector.currentChoiceRoute.Begining;
        PushChangeToDataBase();
    }

    public void MainPhaseButtonClicked()
    {
        apiConnector.currentChoiceRoute.Middel = !apiConnector.currentChoiceRoute.Middel;
        PushChangeToDataBase();
    }

    public void PostPhaseButtonClicked()
    {
        apiConnector.currentChoiceRoute.Finish = !apiConnector.currentChoiceRoute.Finish;
        PushChangeToDataBase();
    }

    public async void PushChangeToDataBase()
    {
        ChoiceRoute choiceRoute = new ChoiceRoute();

        choiceRoute.UserId = apiConnector.currentChoiceRoute.UserId;
        choiceRoute.Path = apiConnector.currentChoiceRoute.Path;

        choiceRoute.Begining = apiConnector.currentChoiceRoute.Begining;
        choiceRoute.Middel = apiConnector.currentChoiceRoute.Middel;
        choiceRoute.Finish = apiConnector.currentChoiceRoute.Finish;

        choiceRoute.NamePatient = apiConnector.currentChoiceRoute.NamePatient;
        choiceRoute.BirthDate = apiConnector.currentChoiceRoute.BirthDate;
        choiceRoute.NameDoctor = apiConnector.currentChoiceRoute.NameDoctor;

        await apiConnector.UpdateChoiceRoute(choiceRoute);
        screenHandler.GoToHomeScreen();
    }
}
