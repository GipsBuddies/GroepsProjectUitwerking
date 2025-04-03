using UnityEngine;
using TMPro;
using System;

public class LoadStandardAppointmentDate : MonoBehaviour
{
    public TMP_InputField currentDay;
    public TMP_InputField currentMonth;
    public TMP_InputField currentYear;
    public TMP_InputField currentHour;
    public TMP_InputField currentMinute;

    public void OnEnable()
    {
        DateTime currentTime = DateTime.Now;
        currentDay.text = Convert.ToString(currentTime.Day);
        currentMonth.text = Convert.ToString(currentTime.Month);
        currentYear.text = Convert.ToString(currentTime.Year);
        currentHour.text = Convert.ToString(currentTime.Hour);
        currentMinute.text = Convert.ToString(currentTime.Minute);
    }
}
