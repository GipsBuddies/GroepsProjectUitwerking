using System.Collections;
using System.Threading.Tasks;
using DG.Tweening;
//using Unity.VisualScripting;
using UnityEngine;

public class ScreenTransitionsImproved : MonoBehaviour
{
    public Transform TransitionCircle;
    public Transform TransitionSquare;
    public GameObject TransitionCircleAsObject;

    public GameObject pageToClose;
    public GameObject pageToOpen;
    public float closingDuration;
    public float openingDuration;
    public Vector3 positionToCloseInOn;
    public Vector3 positionToOpenFrom;

    public void CloseCircleOpenCircle()
    {
        CloseCircle(pageToClose, pageToOpen, positionToCloseInOn, closingDuration, positionToOpenFrom, openingDuration, "circle");
    }

    public void CloseCircleOpenCircle_CloseOnMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.x -= 960;
        mousePosition.y -= 540;

        CloseCircle(pageToClose, pageToOpen, mousePosition, closingDuration, positionToOpenFrom, openingDuration, "circle");
    }

    #region ClosingTransitions

    private void CloseCircle(GameObject pageToClose, GameObject pageToOpen, Vector3 positionToCloseInOn, float closingDuration, Vector3 positionToOpenFrom, float openingDuration, string outAnimation)
    {
        TransitionCircleAsObject.SetActive(true);

        Sequence sequence = DOTween.Sequence();

        Tween circleScaleX = TransitionCircle.DOScaleX(1, closingDuration);
        Tween circleScaleY = TransitionCircle.DOScaleY(1, closingDuration);
        Tween squareScaleX = TransitionSquare.DOScaleX(2300, closingDuration);
        Tween squareScaleY = TransitionSquare.DOScaleY(2300, closingDuration);
        Tween circleMove = TransitionCircle.DOLocalMove(positionToCloseInOn, closingDuration);

        circleScaleX.SetEase(Ease.OutSine);
        circleScaleY.SetEase(Ease.OutSine);
        squareScaleX.SetEase(Ease.OutSine);
        squareScaleY.SetEase(Ease.OutSine);
        circleMove.SetEase(Ease.OutQuad);

        sequence.Insert(0, circleScaleX);
        sequence.Insert(0, circleScaleY);
        sequence.Insert(0, squareScaleX);
        sequence.Insert(0, squareScaleY);
        sequence.Insert(0, circleMove);

        switch (outAnimation)
        {
            case "circle":
                sequence.onComplete = InitiateOpenCircle;
                break;
            default:
                sequence.onComplete = InitiateOpenCircle;
                Debug.Log($"Didn't recognize outAnimation {outAnimation}.");
                break;

        }
        
        sequence.Play();

        void InitiateOpenCircle()
        {
            OpenCircle(pageToClose, pageToOpen, positionToOpenFrom, openingDuration);
        }
    }

    #endregion

    #region OpeningTransitions

    private void OpenCircle(GameObject pageToClose, GameObject pageToOpen, Vector3 positionToOpenFrom, float openingDuration)
    {
        SwitchPages(pageToClose, pageToOpen);
        TransitionCircle.DOLocalMove(positionToOpenFrom, 0);

        Sequence sequence = DOTween.Sequence();

        Tween circleScaleX = TransitionCircle.DOScaleX(2300, openingDuration);
        Tween circleScaleY = TransitionCircle.DOScaleY(2300, openingDuration);
        Tween squareScaleX = TransitionSquare.DOScaleX(1, openingDuration);
        Tween squareScaleY = TransitionSquare.DOScaleY(1, openingDuration);
        Tween circleMove = TransitionCircle.DOLocalMove(Vector3.zero, openingDuration);

        circleScaleX.SetEase(Ease.InSine);
        circleScaleY.SetEase(Ease.InSine);
        squareScaleX.SetEase(Ease.InSine);
        squareScaleY.SetEase(Ease.InSine);
        circleMove.SetEase(Ease.InQuad);

        sequence.Insert(0, circleScaleX);
        sequence.Insert(0, circleScaleY);
        sequence.Insert(0, squareScaleX);
        sequence.Insert(0, squareScaleY);
        sequence.Insert(0, circleMove);

        sequence.onComplete = DeactivateTransitionCircle;

        sequence.Play();

        void DeactivateTransitionCircle()
        {
            TransitionCircleAsObject.SetActive(false);
        }
    }

    #endregion

    #region General

    private void SwitchPages(GameObject pageToClose, GameObject pageToOpen)
    {
        pageToClose.SetActive(false);
        pageToOpen.SetActive(true);
    }

    #endregion
}
