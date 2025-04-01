using UnityEngine;
using System.Collections;

public class Countdown : MonoBehaviour
{
    public float targetTime = 60.0f;
    public PopupBehavior Popup;
    public bool TimerHasEnded = false;

    private void Update()
    {
        if (targetTime <= 0.0f)
        {
            if(!TimerHasEnded)
            {
                Popup.PopupAppear();
            }
            TimerHasEnded = true;
        }
        else
        {
            targetTime -= Time.deltaTime;
        }

    }
}
