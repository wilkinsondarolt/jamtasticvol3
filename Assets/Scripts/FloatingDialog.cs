using UnityEngine;

public class FloatingDialog : MonoBehaviour
{
    public Color color;
    public Dialogue[] conversation;

    public void StartDialog()
    {
        if (!DialogueManager.instance.Busy)
        {
            foreach (Dialogue dialogue in conversation)
            {
                DialogueManager.instance.AddDialog(new Dialogue(dialogue.person, dialogue.color, dialogue.text));
            }
        }            
    }    
}