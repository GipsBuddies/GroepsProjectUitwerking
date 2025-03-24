using UnityEngine;

public class LoadHandler : MonoBehaviour
{
    public ApiConnector apiConnector;
    public async void LoadAppointmentScreen()
    {
        await apiConnector.ReadAppointments();
    }
}
