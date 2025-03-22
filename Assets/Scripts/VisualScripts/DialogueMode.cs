using System;
using DG.Tweening;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static JsonDialogueReader;

public class DialogueMode : MonoBehaviour
{
    public GameObject DialogueScreen;
    public JsonDialogueReader DialogueReader;
    public ScreenTransitions LeaveDialogueMode;

    public Transform DialogueBox;
    public TMP_Text DialogueBoxLine1;
    public TMP_Text DialogueBoxLine2;
    public TMP_Text DialogueBoxLine3;
    public Transform Character;
    public GameObject NextButton;
    public GameObject ButtonPrefab;
    public Transform ButtonParent;

    public Vector3 DialogueBoxPosition;
    public float DialogueBoxMoveDuration;
    public Vector3 CharacterPosition;
    public float CharacterMoveDuration;

    public float FirstButtonX;
    public float FirstButtonY;
    public float ButtonSpacing;
    public float ButtonAnimationDuration;
    public float TimeBetweenButtonsAppearing;

    private DialogueSeries _activeDialogueSeries;
    private int _activeDialogueScreenNumber;
    private DialogueScreen _activeDialogueScreen;

    private void Start()
    {
        SetDialogueSeries("opening");

        MoveCharacterInFromLeft();
        MoveDialogueBoxInFromBelow();
    }

    private void MoveCharacterInFromLeft()
    {
        Tween moveCharacterIntoPosition = Character.DOLocalMove(CharacterPosition, CharacterMoveDuration);
        moveCharacterIntoPosition.SetEase(Ease.OutSine);
        moveCharacterIntoPosition.Play();
    }

    private void MoveDialogueBoxInFromBelow()
    {
        Tween moveDialogueBoxIntoPosition = DialogueBox.DOLocalMove(DialogueBoxPosition, DialogueBoxMoveDuration);
        moveDialogueBoxIntoPosition.SetEase(Ease.OutBack);
        moveDialogueBoxIntoPosition.Play();
    }

    public void SetDialogueSeries(string nameOfSeries)
    {
        NextButton.SetActive(false);
        RemoveButtons();
        ClearDialogueBox();
        _activeDialogueSeries = Array.Find(DialogueReader.DialogueList.dialogue, p => p.seriesName == nameOfSeries);
        _activeDialogueScreenNumber = 0;
        _activeDialogueScreen = _activeDialogueSeries.dialogueScreens[_activeDialogueScreenNumber];
        
        Debug.Log($"Current Screen number: {_activeDialogueScreenNumber + 1}/{_activeDialogueSeries.dialogueScreens.Length}");

        SetDialogueBoxText();
        MakeButtonsAppear();
    }

    public void ClearDialogueBox()
    {
        DialogueBoxLine1.SetText("");
        DialogueBoxLine2.SetText("");
        DialogueBoxLine3.SetText("");
    }

    public void SetDialogueBoxText()
    {
        DialogueBoxLine1.SetText(_activeDialogueScreen.characterLine1);
        DialogueBoxLine2.SetText(_activeDialogueScreen.characterLine2);
        DialogueBoxLine3.SetText(_activeDialogueScreen.characterLine3);
    }

    public void MakeButtonsAppear()
    {
        if(_activeDialogueScreen.dialogueOptions != null)
        {
            for (int buttonIndex = 0; buttonIndex < _activeDialogueScreen.dialogueOptions.Length; buttonIndex++)
            {
                string currentText = _activeDialogueScreen.dialogueOptions[buttonIndex].text;
                string currentTakesYouTo = _activeDialogueScreen.dialogueOptions[buttonIndex].takesYouTo;

                GameObject button = (GameObject)Instantiate(ButtonPrefab, new Vector3{x = FirstButtonX, y = FirstButtonY - (buttonIndex * ButtonSpacing), z = 0}, Quaternion.identity, ButtonParent);
                button.GetComponentInChildren<TMP_Text>().text = currentText;
                button.GetComponent<Button>().onClick.AddListener(() => { SetDialogueSeries(currentTakesYouTo); });

                Tween buttonScaleX = button.transform.DOScaleX(1, ButtonAnimationDuration);
                Tween buttonScaleY = button.transform.DOScaleY(1, ButtonAnimationDuration);

                buttonScaleX.SetEase(Ease.OutBack);
                buttonScaleY.SetEase(Ease.OutBack);

                buttonScaleX.Play();
                buttonScaleY.Play();
            }
        }
        else
        {
            NextButton.SetActive(true);
        }
    }

    public void NextDialogueScreen()
    {
        NextButton.SetActive(false);
        RemoveButtons();
        _activeDialogueScreenNumber++;

        Debug.Log($"Current Screen number: {_activeDialogueScreenNumber + 1}/{_activeDialogueSeries.dialogueScreens.Length}");

        if (_activeDialogueSeries.dialogueScreens.Length > _activeDialogueScreenNumber)
        {
            _activeDialogueScreen = _activeDialogueSeries.dialogueScreens[_activeDialogueScreenNumber];

            ClearDialogueBox();
            SetDialogueBoxText();
            MakeButtonsAppear();
        }
        else
        {
            LeaveDialogueMode.UseCircleTransition("circle");
        }
    }

    public void RemoveButtons()
    {
        foreach (Transform child in ButtonParent)
        {
            Destroy(child.gameObject);
        }
    }
}
