using UnityEngine;

public class FloatingDialog : MonoBehaviour {
    public Color color;
    public string[] textToDisplay;

    private void Start()
    {
        StartDialog();
    }

    private void StartDialog()
    {
        DialogueManager.instance.StartDialog(new Dialogue(this.gameObject, this.color, this.textToDisplay));
    }
}
