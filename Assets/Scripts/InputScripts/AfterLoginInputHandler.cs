using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;

public class AfterLoginInputHandler : MonoBehaviour
{
    [SerializeField] TMP_InputField inputText;

    private int option;

    public void NameButtonClicked()
    {
        option = 1;
    }

    public void BirthDateButtonClicked()
    {
        option = 2;
    }

    public void RouteButtonClicked()
    {
        option = 3;
    }

    public void NameDocterButton()
    {
        option = 4;
    }

    public void ConfirmButtonClicked()
    {
        switch(option)
        {
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
        }
    }
}
