using UnityEngine;
using TMPro;
using System;

public class LoadAfterLoginHandler : MonoBehaviour
{
    public ApiConnector apiConnector;
    public LoadHandler loadHandler;
    public ScreenHandler screenHandler;
    public AvatarData avatarData;

    public TMP_Text usernameText;
    public TMP_Text birthdateText;
    public TMP_Text pathText;
    public TMP_Text docternameText;

    public async void LoadAfterLoginScreen()
    {
        
        DateTime standardDatetime = new DateTime(1900, 1, 1);

        await apiConnector.ReadChoiceRoute();

        avatarData.characterType = apiConnector.currentChoiceRoute.CharacterType;
        avatarData.skinTone = apiConnector.currentChoiceRoute.SkinTone;
        avatarData.hairStyle = apiConnector.currentChoiceRoute.HairStyle;
        avatarData.hairColor = apiConnector.currentChoiceRoute.HairColor;
        avatarData.shirtColor = apiConnector.currentChoiceRoute.ShirtColor;
        avatarData.pantsColor = apiConnector.currentChoiceRoute.PantsColor;
        avatarData.shoeColor = apiConnector.currentChoiceRoute.ShoeColor;
        avatarData.castColor = apiConnector.currentChoiceRoute.CastColor;
        avatarData.hasCastOnLeftArm = apiConnector.currentChoiceRoute.HasCastOnLeftArm;
        avatarData.hasCastOnRightArm = apiConnector.currentChoiceRoute.HasCastOnRightArm;
        avatarData.hasCastOnLeftLeg = apiConnector.currentChoiceRoute.HasCastOnLeftLeg;
        avatarData.hasCastOnRightLeg = apiConnector.currentChoiceRoute.HasCastOnRightLeg;

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
