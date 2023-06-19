using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LogicManager : MonoBehaviour
{
    [SerializeField]
    // ! Mode selector
    public TMP_Dropdown mode_selector;
    List<string> mode_options = new List<string> { "Lorenz Butterfly", "LSystem", "Bifurcation Diagram" };

    // ! Lorenz Butterfly
    public bool mode_A_toggle = false;
    public TextMeshProUGUI mode_A_text_initX;
    public TextMeshProUGUI mode_A_text_initY;
    public TextMeshProUGUI mode_A_text_initZ;
    public TextMeshProUGUI mode_A_text_traceTime;
    public TMP_InputField mode_A_inputField_initX;
    public TMP_InputField mode_A_inputField_initY;
    public TMP_InputField mode_A_inputField_initZ;
    public TMP_InputField mode_A_inputField_traceTime;
    public GameObject mode_A_sphere;
    public Tracer mode_A_sphere_tracer;
    public Button mode_A_button_reset;

    // ! LSystem
    public TextMeshProUGUI mode_B_text_task;
    public TextMeshProUGUI mode_B_text_lineWidth;
    public TextMeshProUGUI mode_B_text_w;
    public TextMeshProUGUI mode_B_text_newf;
    public TextMeshProUGUI mode_B_text_newb;
    public TextMeshProUGUI mode_B_text_angleInt;
    public TextMeshProUGUI mode_B_text_angleInc;
    public TextMeshProUGUI mode_B_text_scaler;
    public TextMeshProUGUI mode_B_text_scaleFactor;
    public TextMeshProUGUI mode_B_text_segmentLength;
    public TextMeshProUGUI mode_B_text_currentIndex;
    public TextMeshProUGUI mode_B_text_wFull;
    public TMP_InputField mode_B_inputField_task;
    public TMP_InputField mode_B_inputField_lineWidth;
    public TMP_InputField mode_B_inputField_w;
    public TMP_InputField mode_B_inputField_newf;
    public TMP_InputField mode_B_inputField_newb;
    public TMP_InputField mode_B_inputField_angleInt;
    public TMP_InputField mode_B_inputField_angleInc;
    public TMP_InputField mode_B_inputField_scaler;
    public TMP_InputField mode_B_inputField_scaleFactor;
    public TMP_InputField mode_B_inputField_segmentLength;
    public TMP_InputField mode_B_inputField_currentIndex;
    public TMP_InputField mode_B_inputField_wFull;

    // ! Bifurcation Diagram

    // Start is called before the first frame update
    void Start()
    {
        // ! Mode selector
        mode_selector.options.Clear();
        mode_selector.AddOptions(mode_options);
        mode_selector.value = 0;
        ModeALogic();
        mode_selector.onValueChanged.AddListener(delegate { DropdownValueChanged(mode_selector); });
        // ! Lorenz Butterfly
        mode_A_button_reset.onClick.AddListener(delegate { ModeAReset(); });
        mode_A_inputField_initX.text = "0.01";
        mode_A_inputField_initY.text = "0.01";
        mode_A_inputField_initZ.text = "0.01";
        mode_A_inputField_traceTime.text = "10";
    }

    // Update is called once per frame
    void Update()
    {

    }

    void DropdownValueChanged(TMP_Dropdown change)
    {
        // 1. Spawn UI elements for the selected mode
        // 2. Spawn drawing function
        if (change.value == 0)
        {
            ModeALogic();
        }
        else if (change.value == 1)
        {
            ModeBLogic();
        }
        else if (change.value == 2)
        {
            ModeCLogic();
        }
    }

    void ModeALogic()
    {
        // ! Lorenz Butterfly
        // Debug.Log("Lorenz Butterfly");
        // * Disable UI elements for other modes
        mode_B_text_task.gameObject.SetActive(false);
        mode_B_text_lineWidth.gameObject.SetActive(false);
        mode_B_text_w.gameObject.SetActive(false);
        mode_B_text_newf.gameObject.SetActive(false);
        mode_B_text_newb.gameObject.SetActive(false);
        mode_B_text_angleInt.gameObject.SetActive(false);
        mode_B_text_angleInc.gameObject.SetActive(false);
        mode_B_text_scaler.gameObject.SetActive(false);
        mode_B_text_scaleFactor.gameObject.SetActive(false);
        mode_B_text_segmentLength.gameObject.SetActive(false);
        mode_B_text_currentIndex.gameObject.SetActive(false);
        mode_B_text_wFull.gameObject.SetActive(false);
        mode_B_inputField_task.gameObject.SetActive(false);
        mode_B_inputField_lineWidth.gameObject.SetActive(false);
        mode_B_inputField_w.gameObject.SetActive(false);
        mode_B_inputField_newf.gameObject.SetActive(false);
        mode_B_inputField_newb.gameObject.SetActive(false);
        mode_B_inputField_angleInt.gameObject.SetActive(false);
        mode_B_inputField_angleInc.gameObject.SetActive(false);
        mode_B_inputField_scaler.gameObject.SetActive(false);
        mode_B_inputField_scaleFactor.gameObject.SetActive(false);
        mode_B_inputField_segmentLength.gameObject.SetActive(false);
        mode_B_inputField_currentIndex.gameObject.SetActive(false);
        mode_B_inputField_wFull.gameObject.SetActive(false);
        // * Enable UI elements for this mode
        mode_A_text_initX.gameObject.SetActive(true);
        mode_A_text_initY.gameObject.SetActive(true);
        mode_A_text_initZ.gameObject.SetActive(true);
        mode_A_text_traceTime.gameObject.SetActive(true);
        mode_A_inputField_initX.gameObject.SetActive(true);
        mode_A_inputField_initY.gameObject.SetActive(true);
        mode_A_inputField_initZ.gameObject.SetActive(true);
        mode_A_inputField_traceTime.gameObject.SetActive(true);
        mode_A_sphere.gameObject.SetActive(true);
        mode_A_toggle = true;
        mode_A_button_reset.gameObject.SetActive(true);
        // * Run drawing function
        mode_A_sphere.GetComponent<Tracer>().update = mode_A_toggle;
    }

    void ModeBLogic()
    {
        // ! LSystem
        // Debug.Log("LSystem");
        // * Disable UI elements for other modes
        mode_A_text_initX.gameObject.SetActive(false);
        mode_A_text_initY.gameObject.SetActive(false);
        mode_A_text_initZ.gameObject.SetActive(false);
        mode_A_text_traceTime.gameObject.SetActive(false);
        mode_A_inputField_initX.gameObject.SetActive(false);
        mode_A_inputField_initY.gameObject.SetActive(false);
        mode_A_inputField_initZ.gameObject.SetActive(false);
        mode_A_inputField_traceTime.gameObject.SetActive(false);
        mode_A_sphere.gameObject.SetActive(false);
        mode_A_toggle = false;
        mode_A_button_reset.gameObject.SetActive(false);
        // * Enable UI elements for this mode
        mode_B_text_task.gameObject.SetActive(true);
        mode_B_text_lineWidth.gameObject.SetActive(true);
        mode_B_text_w.gameObject.SetActive(true);
        mode_B_text_newf.gameObject.SetActive(true);
        mode_B_text_newb.gameObject.SetActive(true);
        mode_B_text_angleInt.gameObject.SetActive(true);
        mode_B_text_angleInc.gameObject.SetActive(true);
        mode_B_text_scaler.gameObject.SetActive(true);
        mode_B_text_scaleFactor.gameObject.SetActive(true);
        mode_B_text_segmentLength.gameObject.SetActive(true);
        mode_B_text_currentIndex.gameObject.SetActive(true);
        mode_B_text_wFull.gameObject.SetActive(true);
        mode_B_inputField_task.gameObject.SetActive(true);
        mode_B_inputField_task.gameObject.SetActive(true);
        mode_B_inputField_lineWidth.gameObject.SetActive(true);
        mode_B_inputField_w.gameObject.SetActive(true);
        mode_B_inputField_newf.gameObject.SetActive(true);
        mode_B_inputField_newb.gameObject.SetActive(true);
        mode_B_inputField_angleInt.gameObject.SetActive(true);
        mode_B_inputField_angleInc.gameObject.SetActive(true);
        mode_B_inputField_scaler.gameObject.SetActive(true);
        mode_B_inputField_scaleFactor.gameObject.SetActive(true);
        mode_B_inputField_segmentLength.gameObject.SetActive(true);
        mode_B_inputField_currentIndex.gameObject.SetActive(true);
        mode_B_inputField_wFull.gameObject.SetActive(true);
        // * Run drawing function
        DrawLSystem();
    }

    void ModeCLogic()
    {
        // ! Bifurcation Diagram
        // Debug.Log("Bifurcation Diagram");
        // * Disable UI elements for other modes
        mode_A_text_initX.gameObject.SetActive(false);
        mode_A_text_initY.gameObject.SetActive(false);
        mode_A_text_initZ.gameObject.SetActive(false);
        mode_A_text_traceTime.gameObject.SetActive(false);
        mode_A_inputField_initX.gameObject.SetActive(false);
        mode_A_inputField_initY.gameObject.SetActive(false);
        mode_A_inputField_initZ.gameObject.SetActive(false);
        mode_A_inputField_traceTime.gameObject.SetActive(false);
        mode_A_sphere.gameObject.SetActive(false);
        mode_A_toggle = false;
        mode_A_button_reset.gameObject.SetActive(false);
        mode_B_text_task.gameObject.SetActive(false);
        mode_B_text_lineWidth.gameObject.SetActive(false);
        mode_B_text_w.gameObject.SetActive(false);
        mode_B_text_newf.gameObject.SetActive(false);
        mode_B_text_newb.gameObject.SetActive(false);
        mode_B_text_angleInt.gameObject.SetActive(false);
        mode_B_text_angleInc.gameObject.SetActive(false);
        mode_B_text_scaler.gameObject.SetActive(false);
        mode_B_text_scaleFactor.gameObject.SetActive(false);
        mode_B_text_segmentLength.gameObject.SetActive(false);
        mode_B_text_currentIndex.gameObject.SetActive(false);
        mode_B_text_wFull.gameObject.SetActive(false);
        mode_B_inputField_task.gameObject.SetActive(false);
        mode_B_inputField_task.gameObject.SetActive(false);
        mode_B_inputField_lineWidth.gameObject.SetActive(false);
        mode_B_inputField_w.gameObject.SetActive(false);
        mode_B_inputField_newf.gameObject.SetActive(false);
        mode_B_inputField_newb.gameObject.SetActive(false);
        mode_B_inputField_angleInt.gameObject.SetActive(false);
        mode_B_inputField_angleInc.gameObject.SetActive(false);
        mode_B_inputField_scaler.gameObject.SetActive(false);
        mode_B_inputField_scaleFactor.gameObject.SetActive(false);
        mode_B_inputField_segmentLength.gameObject.SetActive(false);
        mode_B_inputField_currentIndex.gameObject.SetActive(false);
        mode_B_inputField_wFull.gameObject.SetActive(false);
        // * Enable UI elements for this mode
        // * Run drawing function
        DrawBifurcationDiagram();
    }

    void ModeAReset()
    {
        // mode_A_sphere.GetComponent<TrailRenderer>().emitting = false;
        mode_A_sphere.GetComponent<TrailRenderer>().Clear();
        var x = double.Parse(mode_A_inputField_initX.text);
        var y = double.Parse(mode_A_inputField_initY.text);
        var z = double.Parse(mode_A_inputField_initZ.text);
        // mode_A_sphere.GetComponent<Tracer>().x = new double[3] { 0.01, 0, 0 };
        mode_A_sphere.GetComponent<Tracer>().x = new double[3] { x, y, z };
        mode_A_sphere.GetComponent<TrailRenderer>().time = float.Parse(mode_A_inputField_traceTime.text);
        // mode_A_sphere.GetComponent<TrailRenderer>().emitting = true;
    }

    void DrawLSystem()
    {

    }

    void DrawBifurcationDiagram()
    {

    }
}
