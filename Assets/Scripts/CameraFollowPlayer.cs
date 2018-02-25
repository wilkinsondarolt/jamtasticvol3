using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour {
    public float MinX;
    public float MaxX;

    private void Update()
    {
        Camera.main.transform.position = new Vector3(Mathf.Clamp(transform.position.x, MinX, MaxX),
                                                     Camera.main.transform.position.y,
                                                     Camera.main.transform.position.z);
    }
}
