using UnityEngine;
using TMPro;
using UnityEngine.UI;
using JetBrains.Annotations;
using System;
using Unity.VisualScripting;
using System.Collections.Generic;

public class LoadHandler : MonoBehaviour
{
    public ApiConnector apiConnector;
    public ScreenHandler screenHandler;

    private List<DateTime> datesOnCalendar = new List<DateTime>();

    public TMP_Text date1;
    public TMP_Text date2;
    public TMP_Text date3;
    public TMP_Text date4;
    public TMP_Text date5;
    public TMP_Text date6;
    public TMP_Text date7;
    public TMP_Text date8;
    public TMP_Text date9;
    public TMP_Text date10;
    public TMP_Text date11;
    public TMP_Text date12;
    public TMP_Text date13;
    public TMP_Text date14;
    public TMP_Text date15;
    public TMP_Text date16;
    public TMP_Text date17;
    public TMP_Text date18;
    public TMP_Text date19;
    public TMP_Text date20;
    public TMP_Text date21;
    public TMP_Text date22;
    public TMP_Text date23;
    public TMP_Text date24;
    public TMP_Text date25;

    public async void LoadAppointmentScreen()
    {
        await apiConnector.ReadAppointments();
    }

    public void ContinueLoadingAppointmentScreen()
    {
        LoadDateTextsOnCalendar();

        foreach (Appointment appointment in apiConnector.appointments)
        {
            foreach (DateTime date in datesOnCalendar)
            {
                if (appointment.Date == Convert.ToString(date))
                {
                    Debug.Log("JE MOEILIJKE STUKJE CODE WERKT!");
                }
            }
        }

        screenHandler.GoToAppointmentScreen();
    }

    public void LoadDateTextsOnCalendar()
    {
        DateTime today = DateTime.Today;
        DateTime dateX;

        for (int date = 1; date <= 25; date++)
        {
            dateX = today.AddDays(date);
            datesOnCalendar.Add(dateX);
            switch (date)
            {
                case 1:
                    date1.text = dateX.ToString("MM/dd");
                    break;
                case 2:
                    date2.text = dateX.ToString("MM/dd");
                    break;
                case 3:
                    date3.text = dateX.ToString("MM/dd");
                    break;
                case 4:
                    date4.text = dateX.ToString("MM/dd");
                    break;
                case 5:
                    date5.text = dateX.ToString("MM/dd");
                    break;
                case 6:
                    date6.text = dateX.ToString("MM/dd");
                    break;
                case 7:
                    date7.text = dateX.ToString("MM/dd");
                    break;
                case 8:
                    date8.text = dateX.ToString("MM/dd");
                    break;
                case 9:
                    date9.text = dateX.ToString("MM/dd");
                    break;
                case 10:
                    date10.text = dateX.ToString("MM/dd");
                    break;
                case 11:
                    date11.text = dateX.ToString("MM/dd");
                    break;
                case 12:
                    date12.text = dateX.ToString("MM/dd");
                    break;
                case 13:
                    date13.text = dateX.ToString("MM/dd");
                    break;
                case 14:
                    date14.text = dateX.ToString("MM/dd");
                    break;
                case 15:
                    date15.text = dateX.ToString("MM/dd");
                    break;
                case 16:
                    date16.text = dateX.ToString("MM/dd");
                    break;
                case 17:
                    date17.text = dateX.ToString("MM/dd");
                    break;
                case 18:
                    date18.text = dateX.ToString("MM/dd");
                    break;
                case 19:
                    date19.text = dateX.ToString("MM/dd");
                    break;
                case 20:
                    date20.text = dateX.ToString("MM/dd");
                    break;
                case 21:
                    date21.text = dateX.ToString("MM/dd");
                    break;
                case 22:
                    date22.text = dateX.ToString("MM/dd");
                    break;
                case 23:
                    date23.text = dateX.ToString("MM/dd");
                    break;
                case 24:
                    date24.text = dateX.ToString("MM/dd");
                    break;
                case 25:
                    date25.text = dateX.ToString("MM/dd");
                    break;
                default:
                    Debug.Log("Error in date switchcase");
                    break;
            }
        }
    }
}
