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

    [Header("Shoes")]
    public GameObject Sneakers;

    [Header("Casts")]
    public GameObject LeftArmCast;
    public GameObject LeftArmCastColor;
    public GameObject RightArmCast;
    public GameObject RightArmCastColor;
    public GameObject LeftLegCast;
    public GameObject RightLegCast;


    public void ChangeHairStyle(int style)
    {
        dataToSave.hairStyle = style;

        switch(style)
        {
            case 1:
                SwoopyStyle.SetActive(true);
                JulieStyle.SetActive(false);
                break;
            case 2:
                JulieStyle.SetActive(true);
                SwoopyStyle.SetActive(false);
                break;
            default:
                JulieStyle.SetActive(false);
                SwoopyStyle.SetActive(false);
                break;
        }
    }

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

    public void ChangeSkinTone(int color)
    {
        dataToSave.skinTone = color;

        Color32 colorToSet;

        switch (color)
        {
            case 1:
                colorToSet = new Color32(239, 198, 171, 255);
                break;
            case 2:
                colorToSet = new Color32(199, 153, 123, 255);
                break;
            case 3:
                colorToSet = new Color32(144, 103, 77, 255);
                break;
            case 4:
                colorToSet = new Color32(77, 45, 24, 255);
                break;
            default:
                colorToSet = Color.white;
                break;
        }

        Base.GetComponent<Image>().color = colorToSet;
        HealthyLeftArm.GetComponent<Image>().color = colorToSet;
        HealthyRightArm.GetComponent<Image>().color = colorToSet;
        LeftArmCast.GetComponent<Image>().color = colorToSet;
        RightArmCast.GetComponent<Image>().color = colorToSet;
    }

    public void ChangeShirtColor(int color)
    {
        dataToSave.shirtColor = color;

        Color32 colorToSet;

        switch (color)
        {
            case 1:
                colorToSet = new Color32(213, 68, 58, 255);
                break;
            case 2:
                colorToSet = new Color32(62, 140, 212, 255);
                break;
            case 3:
                colorToSet = new Color32(94, 170, 106, 255);
                break;
            case 4:
                colorToSet = new Color32(181, 181, 181, 255);
                break;
            default:
                colorToSet = Color.white;
                break;
        }

        Shirt.GetComponent<Image>().color = colorToSet;
    }

    public void ChangePantsColor(int color)
    {
        dataToSave.pantsColor = color;

        Color32 colorToSet;

        switch (color)
        {
            case 1:
                colorToSet = new Color32(213, 68, 58, 255);
                break;
            case 2:
                colorToSet = new Color32(62, 140, 212, 255);
                break;
            case 3:
                colorToSet = new Color32(94, 170, 106, 255);
                break;
            case 4:
                colorToSet = new Color32(181, 181, 181, 255);
                break;
            default:
                colorToSet = Color.white;
                break;
        }

        Jeans.GetComponent<Image>().color = colorToSet;
    }

    public void ChangeShoeColor(int color)
    {
        dataToSave.shoeColor = color;

        Color32 colorToSet;

        switch (color)
        {
            case 1:
                colorToSet = new Color32(213, 68, 58, 255);
                break;
            case 2:
                colorToSet = new Color32(62, 140, 212, 255);
                break;
            case 3:
                colorToSet = new Color32(94, 170, 106, 255);
                break;
            case 4:
                colorToSet = new Color32(181, 181, 181, 255);
                break;
            default:
                colorToSet = Color.white;
                break;
        }

        Sneakers.GetComponent<Image>().color = colorToSet;
    }

    public void ChangeCastColor(int color)
    {
        dataToSave.castColor = color;

        Color32 colorToSet;

        switch (color)
        {
            case 1:
                colorToSet = new Color32(213, 68, 58, 255);
                break;
            case 2:
                colorToSet = new Color32(62, 140, 212, 255);
                break;
            case 3:
                colorToSet = new Color32(94, 170, 106, 255);
                break;
            case 4:
                colorToSet = new Color32(181, 181, 181, 255);
                break;
            default:
                colorToSet = Color.white;
                break;
        }

        LeftArmCastColor.GetComponent<Image>().color = colorToSet;
        RightArmCastColor.GetComponent<Image>().color = colorToSet;
        LeftLegCast.GetComponent<Image>().color = colorToSet;
        RightLegCast.GetComponent<Image>().color = colorToSet;
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
