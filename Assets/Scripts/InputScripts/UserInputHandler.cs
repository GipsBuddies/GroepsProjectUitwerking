using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class UserInputHandler : MonoBehaviour
{
    public ApiConnector apiConnector;
    public User user;

    [SerializeField] TMP_InputField usernameLoginInputField;
    [SerializeField] TMP_InputField passwordLoginInputField;

    [SerializeField] TMP_InputField usernameRegisterInputField;
    [SerializeField] TMP_InputField passwordRegisterInputField;

    public void LoginButtonClick()
    {
        user.email = usernameLoginInputField.text;
        user.password = passwordLoginInputField.text;
        apiConnector.Login(user);
        ResetInput();
    }

    public void RegisterButtonClick()
    {
        user.email = usernameRegisterInputField.text;
        user.password = passwordRegisterInputField.text;
        apiConnector.Register(user);
        ResetInput();
    }

    public void ResetInput()
    {
        usernameLoginInputField.text = "";
        passwordLoginInputField.text = "";
        usernameRegisterInputField.text = "";
        passwordRegisterInputField.text = "";
        user.email = "";
        user.password = "";
    }
}
