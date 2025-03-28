using UnityEngine;
using TMPro;
using System;

public class LoadAfterLoginHandler : MonoBehaviour
{
    public ApiConnector apiConnector;
    public LoadHandler loadHandler;
    public ScreenHandler screenHandler;

    public TMP_Text usernameText;
    public TMP_Text birthdateText;
    public TMP_Text pathText;
    public TMP_Text docternameText;

    public async void LoadAfterLoginScreen()
    {
        
        DateTime standardDatetime = new DateTime(1900, 1, 1);

        await apiConnector.ReadChoiceRoute();

        if (apiConnector.currentChoiceRoute.NamePatient == "")
        {
            usernameText.text = "Niet ingesteld";
        }
        else
        {
            usernameText.text = apiConnector.currentChoiceRoute.NamePatient;
        }

        if (apiConnector.currentChoiceRoute.BirthDate == standardDatetime)
        {
            birthdateText.text = "Niet ingesteld";
        }   
        else
        {
            birthdateText.text = apiConnector.currentChoiceRoute.BirthDate.ToString("yyyy/MM/dd");
        }

        if (apiConnector.currentChoiceRoute.Path)
        {
            pathText.text = "b";
        }
        else
        {
            pathText.text = "a";
        }

        if (apiConnector.currentChoiceRoute.NamePatient == "")
        {
            docternameText.text = "Niet ingesteld";
        }
        else
        {
            docternameText.text = apiConnector.currentChoiceRoute.NameDoctor;
        }

        await loadHandler.LoadAppointmentScreen(true);
        screenHandler.GoToAfterLoginScreen();
    }
}
