using System;
using System.Collections.Generic;
using UnityEngine;

public class JsonDialogueReader : MonoBehaviour
{
    public TextAsset DialogueJson;

    public AllDialogue DialogueList = new AllDialogue();

    [Serializable]
    public class AllDialogue
    {
        public DialogueSeries[] dialogue;
    }

    [Serializable]
    public class DialogueSeries
    {
        public string seriesName;
        public DialogueScreen[] dialogueScreens;
    }

    [Serializable]
    public class DialogueScreen
    {
        public string characterLine1;
        public string characterLine2;
        public string characterLine3;

        public string characterEmotion;

        public DialogueOption[] dialogueOptions;
        public string externalLink;
    }

    [Serializable]
    public class DialogueOption
    {
        public string text;
        public string iconName;
        public string takesYouTo;
    }

    private void Start()
    {
        DialogueList = JsonUtility.FromJson<AllDialogue>(DialogueJson.text);
    }
}
