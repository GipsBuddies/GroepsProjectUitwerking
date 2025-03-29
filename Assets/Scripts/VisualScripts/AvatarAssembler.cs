using UnityEngine;
using UnityEngine.UI;

public class AvatarAssembler : MonoBehaviour
{
    public AvatarData dataToUse;

    [Header("Body")]
    public GameObject Base;
    public GameObject HealthyLeftArm;
    public GameObject HealthyRightArm;

    [Header("Expressions")]
    public GameObject HappyFace;
    public GameObject SurprisedFace;

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

    private void OnEnable()
    {
        SetHairStyle(dataToUse.hairStyle);
        SetHairColor(dataToUse.hairColor);
        SetSkinTone(dataToUse.skinTone);
        SetShirtColor(dataToUse.shirtColor);
        SetPantsColor(dataToUse.pantsColor);
        SetShoeColor(dataToUse.shoeColor);
        SetCastColor(dataToUse.castColor);
        PutOnCorrectCasts(dataToUse.hasCastOnLeftArm, dataToUse.hasCastOnRightArm, dataToUse.hasCastOnLeftLeg, dataToUse.hasCastOnRightLeg);
    }

    public void SetHairStyle(int style)
    {
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

    public void SetHairColor(int color)
    {
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

    public void SetSkinTone(int color)
    {
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

    public void SetShirtColor(int color)
    {
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

    public void SetPantsColor(int color)
    {
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

    public void SetShoeColor(int color)
    {
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

    public void SetCastColor(int color)
    {
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

    private void PutOnCorrectCasts(bool leftArm, bool rightArm, bool leftLeg, bool rightLeg)
    {
        LeftArmCast.SetActive(leftArm);
        LeftArmCastColor.SetActive(leftArm);
        HealthyLeftArm.SetActive(!leftArm);

        RightArmCast.SetActive(rightArm);
        RightArmCastColor.SetActive(rightArm);
        HealthyRightArm.SetActive(!rightArm);

        LeftLegCast.SetActive(leftLeg);
        RightLegCast.SetActive(rightLeg);
    }
}
