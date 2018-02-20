using UnityEngine;
using UnityEngine.UI;

public class FloatingDialog : MonoBehaviour {
    public Text nameLabel;
    public float xDisp;
    public float yDisp;

    void Update ()
    {
        Vector3 wantedPos = Camera.main.WorldToViewportPoint(this.gameObject.transform.position);
        nameLabel.transform.position = new Vector3(wantedPos.x * Screen.width + xDisp, 
                                                   wantedPos.y * Screen.height + yDisp, 
                                                   40);
    }
}
