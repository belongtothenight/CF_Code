using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public Color black = Color.black;
    public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        cam.clearFlags = CameraClearFlags.SolidColor;
        cam.backgroundColor = black;
        cam.orthographicSize = 7.1f;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
