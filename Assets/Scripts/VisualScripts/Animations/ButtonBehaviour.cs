using DG.Tweening;
using UnityEngine;

public class ButtonBehaviour : MonoBehaviour
{
    public Transform ButtonToAnimate;
    public Transform IconToAnimate;

    public GameObject RegularImage;
    public GameObject AltImage;

    public float AnimationDuration;
    public float RegularButtonSize;
    public float NewButtonSize;
    public float NewIconSize;
    public float MaxTilt;

    private void OnDisable()
    {
        if(ButtonToAnimate != null)
        {
            ButtonToAnimate.localScale = Vector3.one;

            if(AltImage != null )
            {
                DeactivateAltImage();
            }

            if(IconToAnimate != null )
            {
                IconToAnimate.localScale = Vector3.one;
            }

            ButtonToAnimate.Rotate(Vector3.zero);
        }
    }

    /// <summary>
    /// Laat de knop geleidelijk groeien of krimpen.
    /// 
    /// Gebruikt variabelen:
    /// - ButtonToAnimate: De knop die moet groeien of krimpen
    /// - NewButtonSize: Formaat dat de knop gaat worden
    /// - AnimationDuration: Hoe lang het duurt voordat de knop van formaat is veranderd
    /// 
    /// (Als hier iets misgaat, controleer dan of de schaal van het object X=1, Y=1 is.)
    /// </summary>
    public void ChangeButtonSize()
    {
        ButtonToAnimate.DOScaleX(NewButtonSize, AnimationDuration);
        ButtonToAnimate.DOScaleY(NewButtonSize, AnimationDuration);
    }

    /// <summary>
    /// Maakt de knop geleidelijk weer de normale grootte.
    /// 
    /// Gebruikt variabelen:
    /// - ButtonToAnimate: De knop die moet groeien of krimpen
    /// - AnimationDuration: Hoe lang het duurt voordat de knop van formaat is veranderd
    /// 
    /// (Als hier iets misgaat, controleer dan of de schaal van het object X=1, Y=1 is.)
    /// </summary>
    public void MakeButtonShrinkBack()
    {
        ButtonToAnimate.DOScaleX(RegularButtonSize, AnimationDuration);
        ButtonToAnimate.DOScaleY(RegularButtonSize, AnimationDuration);
    }

    /// <summary>
    /// Zet "AltImage" aan en "RegularImage" uit.
    /// 
    /// Gebruikt variabelen:
    /// - RegularImage: Een afbeelding die actief is en moet verdwijnen
    /// - AltImage: Een afbeelding die NIET actief is en moet verschijnen
    /// 
    /// (Voorbeeld: Wanneer je met je muis over een blauwe knop gaat, wordt die knop boller.
    /// De normale knop is een RegularImage en de bolle knop is een AltImage.)
    /// </summary>
    public void ActivateAltImage()
    {
        RegularImage.gameObject.SetActive(false);
        AltImage.gameObject.SetActive(true);
    }

    /// <summary>
    /// Doet het tegenovergestelde van "ActivateAltImage()."
    /// 
    /// Gebruikt variabelen:
    /// - RegularImage: Een afbeelding die door ActivateAltImage() inactief is gemaakt en weer moet verschijnen
    /// - AltImage: Een afbeelding die door ActivateAltImage() actief is en weer moet verdwijnen
    /// </summary>
    public void DeactivateAltImage()
    {
        RegularImage.gameObject.SetActive(true);
        AltImage.gameObject.SetActive(false);
    }

    /// <summary>
    /// Deze methode zorgt ervoor dat het icoontje op de button relatief sterker vergroot wordt dan de rest van de button.
    /// </summary>
    public void GrowIcon()
    {
        IconToAnimate.DOScaleX(NewIconSize, 0);
        IconToAnimate.DOScaleY(NewIconSize, 0);
    }

    public void ShrinkIconBack()
    {
        IconToAnimate.DOScaleX(1, 0);
        IconToAnimate.DOScaleY(1, 0);
    }

    public void TiltRandomly()
    {
        ButtonToAnimate.DORotate(new Vector3 {z = Random.Range(-MaxTilt, MaxTilt)}, AnimationDuration);
    }

    public void TiltBack()
    {
        ButtonToAnimate.DORotate(new Vector3 {z = 0}, AnimationDuration);
    }
}
