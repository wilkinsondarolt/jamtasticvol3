using UnityEngine;

public class FloatingDialog : MonoBehaviour
{
    public Color color;
    public string[] textToDisplay;

    public void StartDialog()
    {
        if (!DialogueManager.instance.Busy)
            DialogueManager.instance.StartDialog(new Dialogue(this.gameObject, this.color, this.textToDisplay));
    }    
}