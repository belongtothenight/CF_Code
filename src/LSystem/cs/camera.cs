using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public Camera cam;
    public Color black = Color.black;
    // public float camSize = 6.1f; // this setting is duplicated with default size in the camera component
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        cam.clearFlags = CameraClearFlags.SolidColor;
        cam.backgroundColor = black;
        cam.orthographicSize = 1f;
        // cam.rect = new Rect(0, 0, 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
