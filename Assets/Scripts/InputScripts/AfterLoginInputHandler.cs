using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;
using System;

public class AfterLoginInputHandler : MonoBehaviour
{
    public ApiConnector apiConnector;
    public LoadAfterLoginHandler loadAfterLoginHandler;
    public AvatarData avatarData;

    //naam veranderen
    [SerializeField] TMP_InputField inputText;

    //geboorte datum veranderen
    [SerializeField] TMP_InputField yearInput;
    [SerializeField] TMP_InputField monthInput;
    [SerializeField] TMP_InputField dayInput;

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

    public async void ConfirmButtonClicked()
    {
        await apiConnector.ReadChoiceRoute();

        ChoiceRoute choiceRoute = new ChoiceRoute();

        //choiceRoute.Id = apiConnector.currentChoiceRoute.Id;
        choiceRoute.UserId = apiConnector.currentChoiceRoute.UserId;

        choiceRoute.Path = apiConnector.currentChoiceRoute.Path;
        choiceRoute.Begining = apiConnector.currentChoiceRoute.Begining;
        choiceRoute.Middel = apiConnector.currentChoiceRoute.Middel;
        choiceRoute.Finish = apiConnector.currentChoiceRoute.Finish;
        choiceRoute.NamePatient = apiConnector.currentChoiceRoute.NamePatient;
        choiceRoute.BirthDate = apiConnector.currentChoiceRoute.BirthDate;
        choiceRoute.NameDoctor = apiConnector.currentChoiceRoute.NameDoctor;

        //avatardata:
        choiceRoute.CharacterType = avatarData.characterType;
        choiceRoute.SkinTone = avatarData.skinTone;
        choiceRoute.HairStyle = avatarData.hairStyle;
        choiceRoute.HairColor = avatarData.hairColor;
        choiceRoute.ShirtColor = avatarData.shirtColor;
        choiceRoute.PantsColor = avatarData.pantsColor;
        choiceRoute.ShoeColor = avatarData.shoeColor;
        choiceRoute.CastColor = avatarData.castColor;
        choiceRoute.HasCastOnLeftArm = avatarData.hasCastOnLeftArm;
        choiceRoute.HasCastOnRightArm = avatarData.hasCastOnRightArm;
        choiceRoute.HasCastOnLeftLeg = avatarData.hasCastOnLeftLeg;
        choiceRoute.HasCastOnRightLeg = avatarData.hasCastOnRightLeg;

        switch (option)
        {
            case 1:
                Debug.Log($"ROUET 1 naam zou nu veranderd moeten worden naar {inputText.text}");
                choiceRoute.NamePatient = inputText.text;
                break;
            case 2:
                DateTime birthday = new DateTime(Convert.ToInt32(yearInput.text), Convert.ToInt32(monthInput.text), Convert.ToInt32(dayInput.text));
                Debug.Log($"Birthday should be changed to {Convert.ToString(birthday)}");
                choiceRoute.BirthDate = birthday;
                break;
            case 3:
                Debug.Log($"ROUTE 3 code zou nu uitgevoerd worden om iets te sturen naar de db met route {buttontext.text}");
                choiceRoute.Path = routestatus;
                break;
            case 4:
                choiceRoute.NameDoctor = inputText.text;
                break;
        }
        ClearInputs();
        await apiConnector.UpdateChoiceRoute(choiceRoute);
        loadAfterLoginHandler.LoadAfterLoginScreen();
    }

    public void ChangeRouteStatus()
    {
        routestatus = !routestatus;
        if (routestatus)
        {
            routestatus = true;
            inputText.text = "B";
            buttontext.text = "B";
        }
        else if (!routestatus)
        {
            routestatus = false;
            inputText.text = "A";
            buttontext.text = "A";
        }
    }

    public void ClearInputs()
    {
        inputText.text = "";
        yearInput.text = "";
        monthInput.text = "";
        dayInput.text = "";
    }
}
