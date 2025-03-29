using UnityEngine;
using UnityEngine.UI;

public class AvatarEditor : MonoBehaviour
{
    public AvatarData dataToSave;

    [Header("Body")]
    public GameObject Base;
    public GameObject HealthyLeftArm;
    public GameObject HealthyRightArm;

    [Header("Hairstyles")]
    public GameObject SwoopyStyle;
    public GameObject JulieStyle;

    [Header("Shirts")]
    public GameObject Shirt;

    [Header("Pants")]
    public GameObject Jeans;

    [Header("Casts")]
    public GameObject LeftArmCast;
    public GameObject LeftArmCastColor;
    public GameObject RightArmCast;
    public GameObject RightArmCastColor;
    public GameObject LeftLegCast;
    public GameObject RightLegCast;

    public void ChangeHairColor(int color)
    {
        dataToSave.hairColor = color;

        Color32 colorToSet;

        switch (color)
        {
            case 1:
                colorToSet = new Color32(109, 71, 46, 255);
                break;
            case 2:
                colorToSet = new Color32(208, 179, 111, 255);
                break;
            case 3:
                colorToSet = Color.black;
                break;
            case 4:
                colorToSet = new Color32(172, 76, 50, 255);
                break;
            default:
                colorToSet = Color.white;
                break;
        }

        JulieStyle.GetComponent<Image>().color = colorToSet;
        SwoopyStyle.GetComponent<Image>().color = colorToSet;
    }

    public void ToggleLeftArmCast()
    {
        bool putCastOn = !LeftArmCast.activeSelf;
        dataToSave.hasCastOnLeftArm = putCastOn;

        LeftArmCast.SetActive(putCastOn);
        LeftArmCastColor.SetActive(putCastOn);
        HealthyLeftArm.SetActive(!putCastOn);
    }

    public void ToggleRightArmCast()
    {
        bool putCastOn = !RightArmCast.activeSelf;
        dataToSave.hasCastOnRightArm = putCastOn;

        RightArmCast.SetActive(putCastOn);
        RightArmCastColor.SetActive(putCastOn);
        HealthyRightArm.SetActive(!putCastOn);
    }

    public void ToggleLeftLegCast()
    {
        bool putCastOn = !LeftLegCast.activeSelf;
        dataToSave.hasCastOnLeftLeg = putCastOn;

        LeftLegCast.SetActive(putCastOn);
    }

    public void ToggleRightLegCast()
    {
        bool putCastOn = !RightLegCast.activeSelf;
        dataToSave.hasCastOnRightLeg = putCastOn;

        RightLegCast.SetActive(putCastOn);
    }
}
