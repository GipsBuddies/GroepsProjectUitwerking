using UnityEngine;
using DG.Tweening;
using TMPro;

public class PopupBehavior : MonoBehaviour
{
    public GameObject PopupScreen;
    public GameObject PopupWindow;
    public GameObject Darkening;
    public TMP_Text Message;
    public float AppearDuration;
    public float WindowScale;
    public float ReappearTime;

    public Countdown PopupTimer;
    private string _randomReminder;

    public void PopupAppear()
    {
        PopupScreen.SetActive(true);

        SetRandomReminder();
        Message.SetText(_randomReminder);

        Tween windowGrowX = PopupWindow.transform.DOScaleX(WindowScale, AppearDuration);
        Tween windowGrowY = PopupWindow.transform.DOScaleY(WindowScale, AppearDuration);

        windowGrowX.SetEase(Ease.OutBack);
        windowGrowY.SetEase(Ease.OutBack);

        windowGrowX.Play();
        windowGrowY.Play();
    }

    public void PopupClose()
    {
        PopupTimer.targetTime = ReappearTime;
        PopupTimer.TimerHasEnded = false;
        PopupScreen.SetActive(false);
        PopupWindow.transform.localScale = Vector3.zero;
    }

    private void SetRandomReminder()
    {
        string[] reminders = { "Vergeet niet genoeg te drinken!", "Vergeet niet genoeg te eten!", "Wees voorzichtig met je gebroken ledemaat!", "Vergeet niet je medicijnen in te nemen als je die hebt!", "Probeer 's nachts genoeg te slapen!" };

        _randomReminder = reminders[Random.Range(0, reminders.Length)];
    }
}
