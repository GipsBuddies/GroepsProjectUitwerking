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
    public float ClosingDuration;
    public float OpeningDuration;

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

    #region ClosingTransitions

    public void UseCircleTransition(string openingTransition)
    {
        TransitionCircleAsObject.SetActive(true);
        Tween circleScaleX = TransitionCircle.DOScaleX(1, ClosingDuration);
        Tween circleScaleY = TransitionCircle.DOScaleY(1, ClosingDuration);
        Tween squareScaleX = TransitionSquare.DOScaleX(2300, ClosingDuration);
        Tween squareScaleY = TransitionSquare.DOScaleY(2300, ClosingDuration);
        Tween circleMove = TransitionCircle.DOLocalMove(PositionForCircleToCloseInOn, ClosingDuration);

        circleScaleX.SetEase(Ease.OutSine);
        circleScaleY.SetEase(Ease.OutSine);
        squareScaleX.SetEase(Ease.OutSine);
        squareScaleY.SetEase(Ease.OutSine);
        circleMove.SetEase(Ease.OutSine);

        circleScaleX.Play();
        circleScaleY.Play();
        squareScaleX.Play();
        squareScaleY.Play();
        circleMove.Play();

        StartWaitingForClosingAnimation("circle", openingTransition);
    }

    #endregion

    #region WaitingToClose

    private void StartWaitingForClosingAnimation(string closingTransition, string openingTransition)
    {
        switch(closingTransition)
        {
            case "circle":
                StartCoroutine(WaitForCircleToClose(openingTransition));
                break;
            default:
                StartCoroutine(WaitForCircleToClose(openingTransition));
                Debug.Log("Did not recognize closing transition, defaulting to circle");
                break;
        }
    }
    private IEnumerator WaitForCircleToClose(string openingTransition)
    {
        Debug.Log("Started Waiting To Close");
        while (TransitionCircle.localScale.x > 1)
        {
            yield return null;
        }

        Debug.Log("Finished Waiting To Close");

        switch(openingTransition)
        {
            case "circle":
                OpenCircleAgain();
                break;
            default:
                OpenCircleAgain();
                Debug.Log("Did not recognize opening transition, defaulting to circle");
                break;
        }
    }

    #endregion

    #region OpeningTransitions

    private void OpenCircleAgain()
    {
        Tween circleScaleX = TransitionCircle.DOScaleX(2300, OpeningDuration);
        Tween circleScaleY = TransitionCircle.DOScaleY(2300, OpeningDuration);
        Tween squareScaleX = TransitionSquare.DOScaleX(1, OpeningDuration);
        Tween squareScaleY = TransitionSquare.DOScaleY(1, OpeningDuration);
        Tween circleMove = TransitionCircle.DOLocalMove(StandardPosition, OpeningDuration);

        circleScaleX.SetEase(Ease.InSine);
        circleScaleY.SetEase(Ease.InSine);
        squareScaleX.SetEase(Ease.InSine);
        squareScaleY.SetEase(Ease.InSine);
        circleMove.SetEase(Ease.InSine);

        circleScaleX.Play();
        circleScaleY.Play();
        squareScaleX.Play();
        squareScaleY.Play();
        circleMove.Play();

        StartWaitingForOpeningAnimation("circle");
    }

    //public void RemoveObjectOnceAnimationFinishes(Vector3 endPosition)
    //{
    //    StartCoroutine(Waiting(endPosition));
    //}

    #endregion

    #region WaitingToOpen

    private void StartWaitingForOpeningAnimation(string openingTransition)
    {
        PageToClose.SetActive(false);
        PageToOpen.SetActive(true);

        switch (openingTransition)
        {
            case "circle":
                StartCoroutine(WaitForCircleToOpen());
                break;
            default:
                Debug.Log("Mistake in Opening Animation");
                break;
        }
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

    #endregion
}
