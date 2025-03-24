using System;
using TMPro;
using UnityEngine;

public class AppointmentInputHandler : MonoBehaviour
{
    public ApiConnector apiConnector;
    public Appointment appointment;

    [SerializeField] TMP_InputField inputDay;
    [SerializeField] TMP_InputField inputMonth;
    [SerializeField] TMP_InputField inputYear;
    [SerializeField] TMP_InputField inputHours;
    [SerializeField] TMP_InputField inputMinutes;
    [SerializeField] TMP_InputField inputReason;

    public void ConfirmCreateAppointmentClicked()
    {
        int day = Convert.ToInt32(inputDay.text);
        int month = Convert.ToInt32(inputMonth.text);
        int year = Convert.ToInt32(inputYear.text);
        int hours = Convert.ToInt32(inputHours.text);
        int minutes = Convert.ToInt32(inputMinutes.text);
        DateTime date = new DateTime(year, month, day, hours, minutes, 0);
        appointment.Date = date.ToString("O");
        appointment.Reason = inputReason.text;

        Debug.Log($"appointment.Date::: {appointment.Date}");

        apiConnector.CreateAppointment(appointment);
        ResetInput();
    }

    public void ResetInput()
    {
        inputDay.text = "";
        inputMonth.text = "";
        inputYear.text = "";
        inputHours.text = "";
        inputMinutes.text = "";
        inputReason.text = "";
        appointment.Date = "";
        appointment.Reason = "";
    }
}
