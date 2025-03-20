using DG.Tweening;
using UnityEngine;

public class DialogueModeOpening : MonoBehaviour
{
    public GameObject DialogueScreen;

    public Transform DialogueBox;
    public Transform Character;

    public Vector3 DialogueBoxPosition;
    public float DialogueBoxMoveDuration;
    public Vector3 CharacterPosition;
    public float CharacterMoveDuration;

    private void Start()
    {
        Tween moveDialogueBoxIntoPosition = DialogueBox.DOLocalMove(DialogueBoxPosition,DialogueBoxMoveDuration);
        moveDialogueBoxIntoPosition.SetEase(Ease.OutBack);
        moveDialogueBoxIntoPosition.Play();

        Tween moveCharacterIntoPosition = Character.DOLocalMove(CharacterPosition, CharacterMoveDuration);
        moveCharacterIntoPosition.SetEase(Ease.OutSine);
        moveCharacterIntoPosition.Play();
    }
}
