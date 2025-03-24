using System;
using UnityEngine;

[Serializable]
public class Appointment : MonoBehaviour
{
    public string Id;
    public string UserId;
    public DateTime Date;
    public string Reason;
}