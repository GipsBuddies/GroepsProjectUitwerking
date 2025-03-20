using System.Collections;
using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

public class ScreenTransitions : MonoBehaviour
{
    public Transform ScreenToFadeOut;
    public Transform TransitionCircle;
    public GameObject ObjectToRemoveAfterFadeOut;

    public GameObject DialogueScreen;
    public GameObject TransitionCircleAgain;

    public Vector3 RightAboveScreen;
    public float ShrunkenScale;
    public float GrownScale;

    public float AnimationDuration;

    public void SwingOut()
    {
        Tween moveScreen = ScreenToFadeOut.DOLocalMove(RightAboveScreen, AnimationDuration);
        Tween scaleSceneX = ScreenToFadeOut.DOScaleX(ShrunkenScale, AnimationDuration);
        Tween scaleSceneY = ScreenToFadeOut.DOScaleY(ShrunkenScale, AnimationDuration);

        moveScreen.SetEase(Ease.InSine);

        moveScreen.Play();
        scaleSceneX.Play();
        scaleSceneY.Play();

        RemoveObjectOnceAnimationFinishes(RightAboveScreen);
    }

    public void UseCircleTransition(bool closing)
    {
        if(closing)
        {
            TransitionCircleAgain.SetActive(true);
            TransitionCircle.DOScaleX(0, AnimationDuration);
            TransitionCircle.DOScaleY(0, AnimationDuration);
        }
    }

    public void RemoveObjectOnceAnimationFinishes(Vector3 endPosition)
    {
        StartCoroutine(Waiting(endPosition));
    }
    
    private IEnumerator Waiting(Vector3 endPosition)
    {
        Debug.Log("Started Waiting");
        while (ScreenToFadeOut.position.y < endPosition.y - 100)
        {
            yield return null;
        }

        Debug.Log("Finished Waiting");

        ObjectToRemoveAfterFadeOut.SetActive(false);
    }
}
