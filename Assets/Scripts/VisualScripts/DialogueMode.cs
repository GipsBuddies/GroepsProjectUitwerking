using System;
using DG.Tweening;
using TMPro;
//using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static JsonDialogueReader;

public class DialogueMode : MonoBehaviour
{
    [Header("General")]
    public GameObject DialogueScreen;
    public JsonDialogueReader DialogueReader;
    public ScreenTransitionsImproved LeaveDialogueMode;
    public SeriesToStartWith SeriesToStart;

    [Header("Character")]
    public Transform Character;
    public GameObject CharacterNeutral;
    public GameObject CharacterCheerful;
    public GameObject CharacterThinking;
    public float CharacterSquishIntensity;
    public float CharacterSquishDuration;
    public float CharacterUnsquishDuration;
    public Vector3 CharacterPosition;
    public float CharacterMoveDuration;

    [Header("Dialogue Box")]
    public Transform DialogueBox;
    public TMP_Text DialogueBoxLine1;
    public TMP_Text DialogueBoxLine2;
    public TMP_Text DialogueBoxLine3;
    public Vector3 DialogueBoxPosition;
    public float DialogueBoxMoveDuration;

    [Header("Dialogue Option Buttons")]
    public GameObject ButtonPrefab;
    public Transform ButtonParent;
    public float FirstButtonX;
    public float FirstButtonY;
    public float ButtonSpacing;
    public float ButtonAnimationDuration;
    public float TimeBetweenButtonsAppearing;

    [Header("Next Screen Button")]
    public GameObject NextButton;

    [Header("Web Link Utility")]
    public Transform WebLinkObject;
    public TMP_Text WebLinkTitle;
    public Vector3 WebLinkObjectPosition;
    public float WebLinkObjectAppearDuration;
    public float WebLinkObjectDisappearDuration;

    // Private Fields
    private DialogueSeries _activeDialogueSeries;
    private DialogueScreen _activeDialogueScreen;
    private int _activeDialogueScreenNumber;
    private string _activeWebLink;
    private string _activeWebLinkTitle;

    private void OnEnable()
    {
        SetDialogueSeries(SeriesToStart.SeriesName);

        MoveCharacterInFromLeft();
        MoveDialogueBoxInFromBelow();
    }

    private void OnDisable()
    {
        Character.SetPositionAndRotation(new Vector3 { x = -440, y = 540 }, Quaternion.identity);
        DialogueBox.SetPositionAndRotation(new Vector3 { x = 960, y = -340 }, Quaternion.identity);
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
        
        Debug.Log($"Current Screen: {_activeDialogueSeries.seriesName}({_activeDialogueScreenNumber + 1}/{_activeDialogueSeries.dialogueScreens.Length})");

        SetDialogueBoxText();
        MakeButtonsAppear();
        SetCharacterEmotion();
        MakeCharacterBounce();
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
            float firstButtonYForManyButtons = _activeDialogueScreen.dialogueOptions.Length > 2 ? FirstButtonY + 150 : FirstButtonY;
            float smartButtonSpacing = _activeDialogueScreen.dialogueOptions.Length > 3 ? ButtonSpacing * (Mathf.Pow((float)0.8, _activeDialogueScreen.dialogueOptions.Length)) : ButtonSpacing;

            for (int buttonIndex = 0; buttonIndex < _activeDialogueScreen.dialogueOptions.Length; buttonIndex++)
            {
                string currentText = _activeDialogueScreen.dialogueOptions[buttonIndex].text;
                string currentTakesYouTo = _activeDialogueScreen.dialogueOptions[buttonIndex].takesYouTo;

                GameObject button = (GameObject)Instantiate(ButtonPrefab, new Vector3{x = FirstButtonX, y = firstButtonYForManyButtons - (buttonIndex * smartButtonSpacing), z = 0}, Quaternion.identity, ButtonParent);
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

        if(_activeDialogueScreen.externalLink != null)
        {
            MakeLinkButtonAppear();
        }
    }

    public void NextDialogueScreen()
    {
        NextButton.SetActive(false);
        RemoveButtons();
        _activeDialogueScreenNumber++;

        if (_activeDialogueSeries.dialogueScreens.Length > _activeDialogueScreenNumber)
        {
            Debug.Log($"Current Screen: {_activeDialogueSeries.seriesName}({_activeDialogueScreenNumber + 1}/{_activeDialogueSeries.dialogueScreens.Length})");
            
            _activeDialogueScreen = _activeDialogueSeries.dialogueScreens[_activeDialogueScreenNumber];

            ClearDialogueBox();
            SetDialogueBoxText();
            MakeButtonsAppear();
            SetCharacterEmotion();
            MakeCharacterBounce();
        }
        else
        {
            LeaveDialogueMode.CloseCircleOpenCircle();
        }
    }

    public void RemoveButtons()
    {
        foreach (Transform child in ButtonParent)
        {
            Destroy(child.gameObject);
        }

        MakeLinkButtonDisappear();
    }

    public void SetCharacterEmotion()
    {
        foreach (Transform emotion in Character)
        {
            emotion.gameObject.SetActive(false);
        }

        switch (_activeDialogueScreen.characterEmotion)
        {
            case "neutral":
                CharacterNeutral.SetActive(true);
                break;
            case "cheerful":
                CharacterCheerful.SetActive(true);
                break;
            case "thinking":
                CharacterThinking.SetActive(true);
                break;
            default:
                CharacterNeutral.SetActive(true);
                Debug.Log($"Did not recognize the emotion called '{_activeDialogueScreen.characterEmotion}', defaulted to neutral.");
                break;
        }
    }

    public void MakeLinkButtonAppear()
    {
        _activeWebLink = _activeDialogueScreen.externalLink;

        
        if(_activeDialogueScreen.externalLinkName != null )
        {
            _activeWebLinkTitle = _activeDialogueScreen.externalLinkName;
            WebLinkTitle.SetText(_activeWebLinkTitle);
        }
        else
        {
            WebLinkTitle.SetText(_activeWebLink);
        }

        Tween webLinkObjectAppear = WebLinkObject.DOLocalMove(WebLinkObjectPosition, WebLinkObjectAppearDuration);
        webLinkObjectAppear.SetEase(Ease.OutBounce);
        webLinkObjectAppear.Play();
    }

    public void MakeLinkButtonDisappear()
    {
        Tween webLinkObjectDisappear = WebLinkObject.DOLocalMove(new Vector3 { y = -600}, WebLinkObjectDisappearDuration);
        webLinkObjectDisappear.SetEase(Ease.InBack);
        webLinkObjectDisappear.Play();
    }

    public void GoToCurrentLink()
    {
        Application.OpenURL(_activeWebLink);
    }

    public void MakeCharacterBounce()
    {
        Sequence _wholeBounce = DOTween.Sequence();

        Tween squish = Character.DOScaleY(CharacterSquishIntensity, CharacterSquishDuration);
        Tween moveDown = Character.DOLocalMoveY(500 * CharacterSquishIntensity - 500, CharacterSquishDuration);
        Tween unSquish = Character.DOScaleY(1, CharacterUnsquishDuration);
        Tween moveUp = Character.DOLocalMoveY(0, CharacterUnsquishDuration);

        squish.SetEase(Ease.InSine);
        moveDown.SetEase(Ease.InSine);
        unSquish.SetEase(Ease.OutBack);
        moveUp.SetEase(Ease.OutBack);

        _wholeBounce.Insert(0, squish);
        _wholeBounce.Insert(0, moveDown);
        _wholeBounce.Insert(CharacterSquishDuration, unSquish);
        _wholeBounce.Insert(CharacterSquishDuration, moveUp);

        _wholeBounce.Play();
    }
}
