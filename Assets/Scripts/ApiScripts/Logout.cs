using UnityEngine;

public class Logout : MonoBehaviour
{
    public ApiConnector apiConnector;
    public User user;

    public void LogoutButtonClicked()
    {
        user.email = apiConnector.userApiClient.
        apiConnector.Logout(user);
    }
}
