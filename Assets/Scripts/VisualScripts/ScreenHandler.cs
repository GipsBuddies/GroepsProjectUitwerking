using System.Threading.Tasks;
using NUnit.Framework;
using UnityEngine;

// This class contains methods used to navigate through the unity program.
// All methods in the framework are named using the following convention: "GoTo(screen)".
// This file contains a loggedIn boolean, which simulates a user being logged in or out.

public class ScreenHandler : MonoBehaviour
{
    public LoadHandler loadHandler;
    public ApiConnector apiConnector;

    public GameObject startScreen;
    public GameObject homeScreenRouteA;
    public GameObject homeScreenRouteB;
    public GameObject menubar;

    public GameObject diaryScreen;
    public GameObject writeDiaryScreen;
    public GameObject readDiaryScreen;
    public GameObject drawDiaryScreen;

    public GameObject prephaseScreenRouteA;
    public GameObject mainphaseScreenRouteA;
    public GameObject postphasescreenRouteA;

    public GameObject prephaseScreenRouteB;
    public GameObject mainphaseScreenRouteB;
    public GameObject postphasescreenRouteB;

    public GameObject questionScreen;
    public GameObject loginScreen;
    public GameObject afterLoginScreen;
    public GameObject registerScreen;
    public GameObject accountScreen;
    public GameObject appointmentScreen;

    public bool loggedIn;
    public bool followsRouteB;

    void Start()
    {
        GoToStartScreen();
        loggedIn = false;
    }

    public void ResetScreens()
    {
        startScreen.SetActive(false);
        homeScreenRouteA.SetActive(false);
        homeScreenRouteB.SetActive(false);
        menubar.SetActive(false);

        diaryScreen.SetActive(false);
        writeDiaryScreen.SetActive(false);
        readDiaryScreen.SetActive(false);
        drawDiaryScreen.SetActive(false);

        prephaseScreenRouteA.SetActive(false);
        mainphaseScreenRouteA.SetActive(false);
        postphasescreenRouteA.SetActive(false);

        prephaseScreenRouteB.SetActive(false);
        mainphaseScreenRouteB.SetActive(false);
        postphasescreenRouteB.SetActive(false);

        questionScreen.SetActive(false);
        loginScreen.SetActive(false);
        afterLoginScreen.SetActive(false);
        registerScreen.SetActive(false);
        accountScreen.SetActive(false);
        appointmentScreen.SetActive(false);
    }

    #region MainScenes

    public void GoToStartScreen()
    {
        ResetScreens();
        startScreen.SetActive(true);
    }

    public async void GoToHomeScreen()
    {
        if (loggedIn)
        {
            await apiConnector.ReadChoiceRoute();

            if (apiConnector.currentChoiceRoute.Path)
            {
                ApiGoToHomeScreenB();
            }
            else
            {
                ApiGoToHomeScreenA();
            }
        }
        else
        {
            ResetScreens();
            menubar.SetActive(true);
            homeScreenRouteA.SetActive(true);
        }
    }

    public void ApiGoToHomeScreenA()
    {
        ResetScreens();
        menubar.SetActive(true);
        homeScreenRouteA.SetActive(true);
    }

    public void ApiGoToHomeScreenB()
    {
        ResetScreens();
        menubar.SetActive(true);
        homeScreenRouteB.SetActive(true);
    }

    #endregion

    #region DiaryScreens

    public void GoToDiaryScreen()
    {
        if (loggedIn)
        {
            ResetScreens();
            menubar.SetActive(true);
            diaryScreen.SetActive(true);
            writeDiaryScreen.SetActive(true);
        }
        else
        {
            GoToLoginScreen();
        }
    }

    public void GoToReadDiaryScreen()
    {
        if (loggedIn)
        {
            ResetScreens();
            menubar.SetActive(true);
            diaryScreen.SetActive(true);
            readDiaryScreen.SetActive(true);
        }
        else
        {
            GoToLoginScreen();
        }
    }

    public void GoToDrawDiaryScreen()
    {
        if (loggedIn)
        {
            ResetScreens();
            menubar.SetActive(true);
            diaryScreen.SetActive(true);
            drawDiaryScreen.SetActive(true);
        }
        else
        {
            GoToLoginScreen();
        }
    }

    #endregion

    #region PhaseScreensRouteA

    public void GoToPrephaseScreenRouteA()
    {
        ResetScreens();
        menubar.SetActive(true);
        prephaseScreenRouteA.SetActive(true);
    }

    public void GoToMainphaseScreenRouteA()
    {
        ResetScreens();
        menubar.SetActive(true);
        mainphaseScreenRouteA.SetActive(true);
    }

    public void GoToPostphaseScreenRouteA()
    {
        ResetScreens();
        menubar.SetActive(true);
        postphasescreenRouteA.SetActive(true);
    }

    #endregion

    #region PhaseScreensRouteB

    public void GoToPrephaseScreenRouteB()
    {
        ResetScreens();
        menubar.SetActive(true);
        prephaseScreenRouteB.SetActive(true);
    }

    public void GoToMainphaseScreenRouteB()
    {
        ResetScreens();
        menubar.SetActive(true);
        mainphaseScreenRouteB.SetActive(true);
    }

    public void GoToPostphaseScreenRouteB()
    {
        ResetScreens();
        menubar.SetActive(true);
        postphasescreenRouteB.SetActive(true);
    }

    #endregion

    #region OtherScreens

    public void GoToQuestionScreen()
    {
        ResetScreens();
        menubar.SetActive(true);
        questionScreen.SetActive(true);
    }

    public void GoToLoginScreen()
    {
        ResetScreens();
        menubar.SetActive(true);
        loginScreen.SetActive(true);
    }

    public void GoToAfterLoginScreen()
    {
        if (loggedIn)
        {
            ResetScreens();
            menubar.SetActive(true);
            afterLoginScreen.SetActive(true);
        }
        else
        {
            GoToLoginScreen();  
        }
        
    }

    public void GoToRegisterScreen()
    {
        ResetScreens();
        menubar.SetActive(true);
        registerScreen.SetActive(true);
    }

    public void GoToAccountScreen()
    {
        if (loggedIn)
        {
            ResetScreens();
            menubar.SetActive(true);
            accountScreen.SetActive(true);
        }
        else
        {
            GoToLoginScreen();
        }
    }

    public async void LoadAppointmentScreen()
    {
        if (loggedIn)
        {
            await loadHandler.LoadAppointmentScreen(false);
        }
        else
        {
            GoToLoginScreen();
        }
    }

    public void GoToAppointmentScreen()
    {
        ResetScreens();
        menubar.SetActive(true);
        appointmentScreen.SetActive(true);
    }

    #endregion
}
