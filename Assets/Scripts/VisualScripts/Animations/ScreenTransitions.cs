using System.Collections;
using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

public class ScreenTransitions : MonoBehaviour
{
    //public Transform ScreenToFadeOut;
    public Transform TransitionCircle;
    public Transform TransitionSquare;
    public GameObject TransitionCircleAsObject;

    public GameObject PageToClose;
    public GameObject PageToOpen;

    public Vector3 PositionForCircleToCloseInOn;
    public Vector3 StandardPosition = Vector3.zero;

    //public Vector3 RightAboveScreen;
    //public float ShrunkenScale;
    //public float GrownScale;

    public float MaxTransitionObjectSize;
    public float AnimationDuration;

    //public void SwingOut()
    //{
    //    Tween moveScreen = ScreenToFadeOut.DOLocalMove(RightAboveScreen, AnimationDuration);
    //    Tween scaleSceneX = ScreenToFadeOut.DOScaleX(ShrunkenScale, AnimationDuration);
    //    Tween scaleSceneY = ScreenToFadeOut.DOScaleY(ShrunkenScale, AnimationDuration);

    //    moveScreen.SetEase(Ease.InSine);

    //    moveScreen.Play();
    //    scaleSceneX.Play();
    //    scaleSceneY.Play();

    //    RemoveObjectOnceAnimationFinishes(RightAboveScreen);
    //}

    public void UseCircleTransition()
    {
        TransitionCircleAsObject.SetActive(true);
        Tween transitionCircleScaleX = TransitionCircle.DOScaleX(1, AnimationDuration);
        Tween transitionCircleScaleY = TransitionCircle.DOScaleY(1, AnimationDuration);
        Tween transitionSquareScaleX = TransitionSquare.DOScaleX(2300, AnimationDuration);
        Tween transitionSquareScaleY = TransitionSquare.DOScaleY(2300, AnimationDuration);
        Tween transitionCircleMove = TransitionCircle.DOLocalMove(PositionForCircleToCloseInOn, AnimationDuration);

        transitionCircleScaleX.SetEase(Ease.OutSine);
        transitionCircleScaleY.SetEase(Ease.OutSine);
        transitionSquareScaleX.SetEase(Ease.OutSine);
        transitionSquareScaleY.SetEase(Ease.OutSine);
        transitionCircleMove.SetEase(Ease.OutSine);

        transitionCircleScaleX.Play();
        transitionCircleScaleY.Play();
        transitionSquareScaleX.Play();
        transitionSquareScaleY.Play();
        transitionCircleMove.Play();

        StartWaitingForCircleAnimation(true);
    }

    private void OpenCircleAgain()
    {
        Tween transitionCircleScaleX = TransitionCircle.DOScaleX(2300, AnimationDuration);
        Tween transitionCircleScaleY = TransitionCircle.DOScaleY(2300, AnimationDuration);
        Tween transitionSquareScaleX = TransitionSquare.DOScaleX(1, AnimationDuration);
        Tween transitionSquareScaleY = TransitionSquare.DOScaleY(1, AnimationDuration);
        Tween transitionCircleMove = TransitionCircle.DOLocalMove(StandardPosition, AnimationDuration);

        transitionCircleScaleX.SetEase(Ease.InSine);
        transitionCircleScaleY.SetEase(Ease.InSine);
        transitionSquareScaleX.SetEase(Ease.InSine);
        transitionSquareScaleY.SetEase(Ease.InSine);
        transitionCircleMove.SetEase(Ease.InSine);

        transitionCircleScaleX.Play();
        transitionCircleScaleY.Play();
        transitionSquareScaleX.Play();
        transitionSquareScaleY.Play();
        transitionCircleMove.Play();

        StartWaitingForCircleAnimation(false);
    }

    //public void RemoveObjectOnceAnimationFinishes(Vector3 endPosition)
    //{
    //    StartCoroutine(Waiting(endPosition));
    //}

    private void StartWaitingForCircleAnimation(bool closing)
    {
        if(closing)
        {
            StartCoroutine(WaitForCircleToClose());
        }
        else
        {
            StartCoroutine(WaitForCircleToOpen());
        }
    }
    
    private IEnumerator WaitForCircleToClose()
    {
        Debug.Log("Started Waiting To Close");
        while (TransitionCircle.localScale.x > 2)
        {
            yield return null;
        }

        Debug.Log("Finished Waiting To Close");

        PageToClose.SetActive(false);
        PageToOpen.SetActive(true);

        OpenCircleAgain();
    }

    private IEnumerator WaitForCircleToOpen()
    {
        Debug.Log("Started Waiting To Open");
        while (TransitionCircle.localScale.x < 2290)
        {
            yield return null;
        }

        Debug.Log("Finished Waiting To Open");

        TransitionCircleAsObject.SetActive(false);
    }
}
