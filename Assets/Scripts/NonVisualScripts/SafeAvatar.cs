using UnityEngine;

public class SafeAvatar : MonoBehaviour
{
    public ApiConnector apiConnector;

    public AvatarData avatarData;
    public async void SafeButtonClicked()
    {
        await apiConnector.ReadChoiceRoute();

        ChoiceRoute choiceRoute = new ChoiceRoute();

        choiceRoute.UserId = apiConnector.currentChoiceRoute.UserId;
        choiceRoute.Path = apiConnector.currentChoiceRoute.Path;
        choiceRoute.Begining = apiConnector.currentChoiceRoute.Begining;
        choiceRoute.Middel = apiConnector.currentChoiceRoute.Middel;
        choiceRoute.Finish = apiConnector.currentChoiceRoute.Finish;
        choiceRoute.NamePatient = apiConnector.currentChoiceRoute.NamePatient;
        choiceRoute.BirthDate = apiConnector.currentChoiceRoute.BirthDate;
        choiceRoute.NameDoctor = apiConnector.currentChoiceRoute.NameDoctor;



        choiceRoute.CharacterType = avatarData.characterType;
        choiceRoute.SkinTone = avatarData.skinTone;
        choiceRoute.HairStyle = avatarData.hairStyle;
        choiceRoute.ShirtColor = avatarData.hairColor;
        choiceRoute.PantsColor = avatarData.pantsColor;
        choiceRoute.ShoeColor = avatarData.shoeColor;
        choiceRoute.CastColor = avatarData.castColor;
        choiceRoute.HasCastOnLeftArm = avatarData.hasCastOnLeftArm;
        choiceRoute.HasCastOnRightArm = avatarData.hasCastOnRightArm;
        choiceRoute.HasCastOnLeftLeg = avatarData.hasCastOnLeftLeg;
        choiceRoute.HasCastOnRightLeg = avatarData.hasCastOnRightLeg;

        await apiConnector.UpdateChoiceRoute(choiceRoute);
        Debug.Log("OPGESLAGEN");
        Debug.Log("OPGESLAGEN");
        Debug.Log("OPGESLAGEN");
    }
}
