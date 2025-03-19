using UnityEngine;

// This class contains methods used to navigate through the unity program.
// All methods in the framework are named using the following convention: "GoTo(screen)".
// This file contains a loggedIn boolean, which simulates a user being logged in or out.

public class ScreenHandler : MonoBehaviour
{
    public GameObject startScreen;
    public GameObject homeScreen;
    public GameObject menubar;

    public GameObject diaryScreen;
    public GameObject writeDiaryScreen;
    public GameObject readDiaryScreen;
    public GameObject drawDiaryScreen;

    public GameObject prephaseScreen;
    public GameObject mainphaseScreen;
    public GameObject postphasescreen;

    public GameObject questionScreen;
    public GameObject loginScreen;
    public GameObject registerScreen;
    public GameObject accountScreen;

    public bool loggedIn;
    private bool onHomeScreen;


    void Start()
    {
        GoToStartScreen();
    }

    public void ResetScreens()
    {
        startScreen.SetActive(false);
        homeScreen.SetActive(false);
        menubar.SetActive(false);

        diaryScreen.SetActive(false);
        writeDiaryScreen.SetActive(false);
        readDiaryScreen.SetActive(false);
        drawDiaryScreen.SetActive(false);

        prephaseScreen.SetActive(false);
        mainphaseScreen.SetActive(false);
        postphasescreen.SetActive(false);

        questionScreen.SetActive(false);
        loginScreen.SetActive(false);
        registerScreen.SetActive(false);
        accountScreen.SetActive(false);

        onHomeScreen = false;
    }

    #region MainScenes

    public void GoToStartScreen()
    {
        ResetScreens();
        startScreen.SetActive(true);
    }

    public void GoToHomeScreen()
    {
        if (onHomeScreen)
        {
            GoToStartScreen();
            onHomeScreen = false;
        }
        else
        {
            ResetScreens();
            menubar.SetActive(true);
            homeScreen.SetActive(true);
            onHomeScreen = true;
        }
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

    #region PhaseScreens

    public void GoToPrephaseScreen()
    {
        ResetScreens();
        menubar.SetActive(true);
        prephaseScreen.SetActive(true);
    }

    public void GoToMainphaseScreen()
    {
        ResetScreens();
        menubar.SetActive(true);
        mainphaseScreen.SetActive(true);
    }

    public void GoToPostphaseScreen()
    {
        ResetScreens();
        menubar.SetActive(true);
        postphasescreen.SetActive(true);
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

    #endregion
}
