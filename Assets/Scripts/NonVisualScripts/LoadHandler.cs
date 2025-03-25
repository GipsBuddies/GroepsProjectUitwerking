using UnityEngine;
using TMPro;
using UnityEngine.UI;
using JetBrains.Annotations;
using System;
using Unity.VisualScripting;
using System.Collections.Generic;
using UnityEditor.PackageManager.Requests;

public class LoadHandler : MonoBehaviour
{
    public ApiConnector apiConnector;
    public ScreenHandler screenHandler;

    private List<DateTime> datesOnCalendar = new List<DateTime>();
    private bool IsNewestAppointmentToday;
    private bool IsAppointmentWithinMonth;

    public TMP_Text dateNextAppointment;

    [Header("Today")]
    public GameObject todayAppointmentButton;
    public TMP_Text todayTitle;
    public TMP_Text todayTime;

    [Header("Date1")]
    public TMP_Text date1;
    public GameObject dateAppointment1;
    public TMP_Text dateTitle1;
    public TMP_Text dateTime1;

    [Header("Date2")]
    public TMP_Text date2;
    public GameObject dateAppointment2;
    public TMP_Text dateTitle2;
    public TMP_Text dateTime2;

    [Header("Date3")]
    public TMP_Text date3;
    public GameObject dateAppointment3;
    public TMP_Text dateTitle3;
    public TMP_Text dateTime3;

    [Header("Date4")]
    public TMP_Text date4;
    public GameObject dateAppointment4;
    public TMP_Text dateTitle4;
    public TMP_Text dateTime4;

    [Header("Date5")]
    public TMP_Text date5;
    public GameObject dateAppointment5;
    public TMP_Text dateTitle5;
    public TMP_Text dateTime5;

    [Header("Date6")]
    public TMP_Text date6;
    public GameObject dateAppointment6;
    public TMP_Text dateTitle6;
    public TMP_Text dateTime6;

    [Header("Date7")]
    public TMP_Text date7;
    public GameObject dateAppointment7;
    public TMP_Text dateTitle7;
    public TMP_Text dateTime7;

    [Header("Date8")]
    public TMP_Text date8;
    public GameObject dateAppointment8;
    public TMP_Text dateTitle8;
    public TMP_Text dateTime8;

    [Header("Date9")]
    public TMP_Text date9;
    public GameObject dateAppointment9;
    public TMP_Text dateTitle9;
    public TMP_Text dateTime9;

    [Header("Date10")]
    public TMP_Text date10;
    public GameObject dateAppointment10;
    public TMP_Text dateTitle10;
    public TMP_Text dateTime10;

    [Header("Date11")]
    public TMP_Text date11;
    public GameObject dateAppointment11;
    public TMP_Text dateTitle11;
    public TMP_Text dateTime11;

    [Header("Date12")]
    public TMP_Text date12;
    public GameObject dateAppointment12;
    public TMP_Text dateTitle12;
    public TMP_Text dateTime12;

    [Header("Date13")]
    public TMP_Text date13;
    public GameObject dateAppointment13;
    public TMP_Text dateTitle13;
    public TMP_Text dateTime13;

    [Header("Date14")]
    public TMP_Text date14;
    public GameObject dateAppointment14;
    public TMP_Text dateTitle14;
    public TMP_Text dateTime14;

    [Header("Date15")]
    public TMP_Text date15;
    public GameObject dateAppointment15;
    public TMP_Text dateTitle15;
    public TMP_Text dateTime15;

    [Header("Date16")]
    public TMP_Text date16;
    public GameObject dateAppointment16;
    public TMP_Text dateTitle16;
    public TMP_Text dateTime16;

    [Header("Date17")]
    public TMP_Text date17;
    public GameObject dateAppointment17;
    public TMP_Text dateTitle17;
    public TMP_Text dateTime17;

    [Header("Date18")]
    public TMP_Text date18;
    public GameObject dateAppointment18;
    public TMP_Text dateTitle18;
    public TMP_Text dateTime18;

    [Header("Date19")]
    public TMP_Text date19;
    public GameObject dateAppointment19;
    public TMP_Text dateTitle19;
    public TMP_Text dateTime19;

    [Header("Date20")]
    public TMP_Text date20;
    public GameObject dateAppointment20;
    public TMP_Text dateTitle20;
    public TMP_Text dateTime20;

    [Header("Date21")]
    public TMP_Text date21;
    public GameObject dateAppointment21;
    public TMP_Text dateTitle21;
    public TMP_Text dateTime21;

    [Header("Date22")]
    public TMP_Text date22;
    public GameObject dateAppointment22;
    public TMP_Text dateTitle22;
    public TMP_Text dateTime22;

    [Header("Date23")]
    public TMP_Text date23;
    public GameObject dateAppointment23;
    public TMP_Text dateTitle23;
    public TMP_Text dateTime23;

    [Header("Date24")]
    public TMP_Text date24;
    public GameObject dateAppointment24;
    public TMP_Text dateTitle24;
    public TMP_Text dateTime24;

    [Header("Date25")]
    public TMP_Text date25;
    public GameObject dateAppointment25;
    public TMP_Text dateTitle25;
    public TMP_Text dateTime25;

    public async void LoadAppointmentScreen()
    {
        await apiConnector.ReadAppointments();
    }

    public void ContinueLoadingAppointmentScreen()
    {
        ResetSetAppointments();
        LoadDateTextsOnCalendar();
        Debug.Log($"AANTAL AFSPRAKEN OP ACCOUNT:{apiConnector.appointments.Count}");
    
        if (apiConnector.appointments.Count > 0)
        {
            DateTime closestTimeToToday = apiConnector.appointments[0].Date;
        }
    
        DateTime today = DateTime.Today;
        foreach (Appointment appointment in apiConnector.appointments)
        {
            IsAppointmentWithinMonth = false;

            Debug.Log($"AAN HET TESTEN OF {appointment.Date.Date} == {DateTime.Today.Date}");
            if (appointment.Date.Date == DateTime.Today.Date)
            {
                TimeSpan differenceInTimeToday = appointment.Date - DateTime.Now;
                todayAppointmentButton.SetActive(true);
                todayTitle.text = appointment.Reason;
                todayTime.text = appointment.Date.TimeOfDay.ToString(@"hh\:mm");
                dateNextAppointment.text = $"Uw volgende afspraak is over {differenceInTimeToday.Days} dagen en {differenceInTimeToday.Hours} uur.";
                IsNewestAppointmentToday = true;
            }

            DateTime appointmentDate = appointment.Date;
            foreach (DateTime dateOnCalendar in datesOnCalendar)
            {
                if (appointmentDate.Date == dateOnCalendar.Date)
                {
                    IsAppointmentWithinMonth = true;

                    if (appointment.Date < today)
                    {
                        //is de datum voor voor vandaag
                    }
                    else
                    {
                        if (appointment.Date.TimeOfDay < today.TimeOfDay)
                        {
                            //vandaag maar afspraak is geweest
                        }
                        else if (!IsNewestAppointmentToday)
                        {
                            TimeSpan differenceInTime = appointment.Date - DateTime.Now;
                            dateNextAppointment.text = $"Uw volgende afspraak is over {differenceInTime.Days} dagen en {differenceInTime.Hours} uur.";
                        }
                    }

                    string dateMonthDay = appointmentDate.Date.ToString("MM/dd");
                    string time = appointment.Date.ToString("HH:mm");

                    if (dateMonthDay == date1.text)
                    {
                        dateAppointment1.SetActive(true);
                        dateTitle1.text = appointment.Reason;
                        dateTime1.text = time;
                    }
                    else if (dateMonthDay == date2.text)
                    {
                        dateAppointment2.SetActive(true);
                        dateTitle2.text = appointment.Reason;
                        dateTime2.text = time;
                    }
                    else if (dateMonthDay == date3.text)
                    {
                        dateAppointment3.SetActive(true);
                        dateTitle3.text = appointment.Reason;
                        dateTime3.text = time;
                    }
                    else if (dateMonthDay == date4.text)
                    {
                        dateAppointment4.SetActive(true);
                        dateTitle4.text = appointment.Reason;
                        dateTime4.text = time;
                    }
                    else if (dateMonthDay == date5.text)
                    {
                        dateAppointment5.SetActive(true);
                        dateTitle5.text = appointment.Reason;
                        dateTime5.text = time;
                    }
                    else if (dateMonthDay == date6.text)
                    {
                        dateAppointment6.SetActive(true);
                        dateTitle6.text = appointment.Reason;
                        dateTime6.text = time;
                    }
                    else if (dateMonthDay == date7.text)
                    {
                        dateAppointment7.SetActive(true);
                        dateTitle7.text = appointment.Reason;
                        dateTime7.text = time;
                    }
                    else if (dateMonthDay == date8.text)
                    {
                        dateAppointment8.SetActive(true);
                        dateTitle8.text = appointment.Reason;
                        dateTime8.text = time;
                    }
                    else if (dateMonthDay == date9.text)
                    {
                        dateAppointment9.SetActive(true);
                        dateTitle9.text = appointment.Reason;
                        dateTime9.text = time;
                    }
                    else if (dateMonthDay == date10.text)
                    {
                        dateAppointment10.SetActive(true);
                        dateTitle10.text = appointment.Reason;
                        dateTime10.text = time;
                    }
                    else if (dateMonthDay == date11.text)
                    {
                        dateAppointment11.SetActive(true);
                        dateTitle11.text = appointment.Reason;
                        dateTime11.text = time;
                    }
                    else if (dateMonthDay == date12.text)
                    {
                        dateAppointment12.SetActive(true);
                        dateTitle12.text = appointment.Reason;
                        dateTime12.text = time;
                    }
                    else if (dateMonthDay == date13.text)
                    {
                        dateAppointment13.SetActive(true);
                        dateTitle13.text = appointment.Reason;
                        dateTime13.text = time;
                    }
                    else if (dateMonthDay == date14.text)
                    {
                        dateAppointment14.SetActive(true);
                        dateTitle14.text = appointment.Reason;
                        dateTime14.text = time;
                    }
                    else if (dateMonthDay == date15.text)
                    {
                        dateAppointment15.SetActive(true);
                        dateTitle15.text = appointment.Reason;
                        dateTime15.text = time;
                    }
                    else if (dateMonthDay == date16.text)
                    {
                        dateAppointment16.SetActive(true);
                        dateTitle16.text = appointment.Reason;
                        dateTime16.text = time;
                    }
                    else if (dateMonthDay == date17.text)
                    {
                        dateAppointment17.SetActive(true);
                        dateTitle17.text = appointment.Reason;
                        dateTime17.text = time;
                    }
                    else if (dateMonthDay == date18.text)
                    {
                        dateAppointment18.SetActive(true);
                        dateTitle18.text = appointment.Reason;
                        dateTime18.text = time;
                    }
                    else if (dateMonthDay == date19.text)
                    {
                        dateAppointment19.SetActive(true);
                        dateTitle19.text = appointment.Reason;
                        dateTime19.text = time;
                    }
                    else if (dateMonthDay == date20.text)
                    {
                        dateAppointment20.SetActive(true);
                        dateTitle20.text = appointment.Reason;
                        dateTime20.text = time;
                    }
                    else if (dateMonthDay == date21.text)
                    {
                        dateAppointment21.SetActive(true);
                        dateTitle21.text = appointment.Reason;
                        dateTime21.text = time;
                    }
                    else if (dateMonthDay == date22.text)
                    {
                        dateAppointment22.SetActive(true);
                        dateTitle22.text = appointment.Reason;
                        dateTime22.text = time;
                    }
                    else if (dateMonthDay == date23.text)
                    {
                        dateAppointment23.SetActive(true);
                        dateTitle23.text = appointment.Reason;
                        dateTime23.text = time;
                    }
                    else if (dateMonthDay == date24.text)
                    {
                        dateAppointment24.SetActive(true);
                        dateTitle24.text = appointment.Reason;
                        dateTime24.text = time;
                    }
                    else if (dateMonthDay == date25.text)
                    {
                        dateAppointment25.SetActive(true);
                        dateTitle25.text = appointment.Reason;
                        dateTime25.text = time;
                    }
                }
                else
                {
                    //Debug.Log($"{appointmentDate.Date} != {dateOnCalendar.Date}");
                }
            }

            //doesn't directly work getting error 405 method not found, non priority feature
            if (!IsAppointmentWithinMonth)
            {
                //apiConnector.DeleteAppointment(appointment.Id);
            }
        }
        Debug.Log("HIJ IS DOOR DE 2 foreach heen gegaan");
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

    public void ResetSetAppointments()
    {
        IsNewestAppointmentToday = false;
        IsAppointmentWithinMonth = false;

        todayAppointmentButton.SetActive(false);
        
        dateAppointment1.SetActive(false);
        dateAppointment2.SetActive(false);
        dateAppointment3.SetActive(false);
        dateAppointment4.SetActive(false);
        dateAppointment5.SetActive(false);
        dateAppointment6.SetActive(false);
        dateAppointment7.SetActive(false);
        dateAppointment8.SetActive(false);
        dateAppointment9.SetActive(false);
        dateAppointment10.SetActive(false);
        dateAppointment11.SetActive(false);
        dateAppointment12.SetActive(false);
        dateAppointment13.SetActive(false);
        dateAppointment14.SetActive(false);
        dateAppointment15.SetActive(false);
        dateAppointment16.SetActive(false);
        dateAppointment17.SetActive(false);
        dateAppointment18.SetActive(false);
        dateAppointment19.SetActive(false);
        dateAppointment20.SetActive(false);
        dateAppointment21.SetActive(false);
        dateAppointment22.SetActive(false);
        dateAppointment23.SetActive(false);
        dateAppointment24.SetActive(false);
        dateAppointment25.SetActive(false);
    }
}
