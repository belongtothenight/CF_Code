using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class camera : MonoBehaviour
{
    public Camera cam;
    public Color black = Color.black;
    public float base_move_speed = 100.0f;
    public int sensitivity = 200;
    private Vector3 camRotation;
    // public float camSize = 6.1f; // this setting is duplicated with default size in the camera component
    private bool isRotating = true;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        // cam.clearFlags = CameraClearFlags.SolidColor;
        // cam.backgroundColor = black;
        cam.orthographicSize = 1f;
        // cam.rect = new Rect(0, 0, 1f, 1f);
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        // * On/Off Rotation
        if (Input.GetKeyDown(KeyCode.R))
        {
            isRotating = !isRotating;
            Cursor.visible = !Cursor.visible;
        }
        // * Rotation
        if (isRotating)
        {
            transform.Rotate(Vector3.up * sensitivity * Time.deltaTime * Input.GetAxis("Mouse X"));
            camRotation.x -= Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
            camRotation.y += Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
            cam.transform.localEulerAngles = camRotation;
        }
        // * Movement
        if (Input.GetKey(KeyCode.W))
        {
            // Front
            // cam.transform.position += new Vector3(0, 0, base_move_speed * Time.deltaTime);
            cam.transform.position += cam.transform.forward * base_move_speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            // Back
            // cam.transform.position += new Vector3(0, 0, -base_move_speed * Time.deltaTime);
            cam.transform.position += -cam.transform.forward * base_move_speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            // Left
            // cam.transform.position += new Vector3(-base_move_speed * Time.deltaTime, 0, 0);
            cam.transform.position += -cam.transform.right * base_move_speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            // Right
            // cam.transform.position += new Vector3(base_move_speed * Time.deltaTime, 0, 0);
            cam.transform.position += cam.transform.right * base_move_speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            // Up
            cam.transform.position += new Vector3(0, base_move_speed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            // Down
            cam.transform.position += new Vector3(0, -base_move_speed * Time.deltaTime, 0);
        }
        base_move_speed += Input.mouseScrollDelta.y * 10;
        // * Exit
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
