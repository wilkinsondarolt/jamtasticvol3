using UnityEngine;
using System.Collections.Generic;

public class FloatingDialog : MonoBehaviour
{
    public List<Conversation> conversationList;

    public void StartDialog()
    {
        if (conversationList.Count == 0)
            return;

        if (!DialogueManager.instance.Busy)
        {
            Conversation conversation = conversationList[0];
            foreach (Dialogue dialogue in conversation.dialogueList)
            {
                DialogueManager.instance.AddDialog(new Dialogue(dialogue.person, dialogue.text));
            }

            if (conversationList.Count > 1)
                conversationList.RemoveAt(0);
        }            
    }    
}