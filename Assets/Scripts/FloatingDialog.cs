using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FloatingDialog : MonoBehaviour {
    private Text textDialog;
    public Image baloonDialog;
    
    public float xDisp;
    public float yDisp;
    public string[] textToDisplay;

    private void Start()
    {
        textDialog = baloonDialog.GetComponentInChildren<Text>();
        StopAllCoroutines();
        StartCoroutine(DisplayDialog());
    }

    IEnumerator DisplayDialog()
    {      
        foreach (string Sentence in this.textToDisplay)
        {
            textDialog.text = "";
            foreach (char Letter in Sentence)
            {
                textDialog.text += Letter;
                yield return null;
            }
            yield return new WaitForSeconds(1.0f);
        }
        yield return new WaitForSeconds(0.5f);
        DisableDialogBaloon();
    }

    void Update ()
    {
        Vector3 wantedPos = Camera.main.WorldToViewportPoint(this.gameObject.transform.position);
        baloonDialog.transform.position = new Vector3(wantedPos.x * Screen.width + xDisp, 
                                                      wantedPos.y * Screen.height + yDisp, 
                                                      40);
    }

    void DisableDialogBaloon()
    {
        baloonDialog.gameObject.SetActive(false);
        
    }
}
