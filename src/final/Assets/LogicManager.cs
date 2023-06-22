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
    public GameObject mode_A_sphere;
    public TextMeshProUGUI mode_A_text_initX;
    public TextMeshProUGUI mode_A_text_initY;
    public TextMeshProUGUI mode_A_text_initZ;
    public TextMeshProUGUI mode_A_text_traceTime;
    public TMP_InputField mode_A_inputField_initX;
    public TMP_InputField mode_A_inputField_initY;
    public TMP_InputField mode_A_inputField_initZ;
    public TMP_InputField mode_A_inputField_traceTime;
    public Button mode_A_button_reset;

    // ! LSystem
    public bool mode_B_toggle = false;
    public GameObject mode_B_empty;
    public TextMeshProUGUI mode_B_text_lineWidth;
    public TextMeshProUGUI mode_B_text_level;
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
    public TMP_InputField mode_B_inputField_lineWidth;
    public TMP_InputField mode_B_inputField_level;
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
    public Button mode_B_button_reset;

    // ! Bifurcation Diagram
    public bool mode_C_toggle = false;
    public GameObject mode_C_empty;
    public TextMeshProUGUI mode_C_text_x0;
    public TextMeshProUGUI mode_C_text_minN;
    public TextMeshProUGUI mode_C_text_maxN;
    public TextMeshProUGUI mode_C_text_minC;
    public TextMeshProUGUI mode_C_text_maxC;
    public TextMeshProUGUI mode_C_text_steps;
    public TextMeshProUGUI mode_C_text_dotSize;
    public TextMeshProUGUI mode_C_text_scale;
    public TMP_InputField mode_C_inputField_x0;
    public TMP_InputField mode_C_inputField_minN;
    public TMP_InputField mode_C_inputField_maxN;
    public TMP_InputField mode_C_inputField_minC;
    public TMP_InputField mode_C_inputField_maxC;
    public TMP_InputField mode_C_inputField_steps;
    public TMP_InputField mode_C_inputField_dotSize;
    public TMP_InputField mode_C_inputField_scale;
    public Button mode_C_button_reset;

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
        mode_A_inputField_initX.text = "0.01";
        mode_A_inputField_initY.text = "0.01";
        mode_A_inputField_initZ.text = "0.01";
        mode_A_inputField_traceTime.text = "10";
        mode_A_button_reset.onClick.AddListener(delegate { ModeAReset(); });
        // ! LSystem
        mode_B_inputField_lineWidth.text = "1";
        mode_B_inputField_level.text = "2";
        mode_B_inputField_w.text = "F+F+F+F";
        mode_B_inputField_newf.text = "F+b-F-FFF+F+b-F";
        mode_B_inputField_newb.text = "bbb";
        mode_B_inputField_angleInt.text = "0";
        mode_B_inputField_angleInc.text = "90";
        mode_B_inputField_scaler.text = "100";
        mode_B_inputField_scaleFactor.text = "0";
        mode_B_inputField_segmentLength.text = "1";
        mode_B_inputField_currentIndex.text = "0";
        mode_B_inputField_wFull.text = "N/A";
        mode_B_inputField_scaleFactor.readOnly = true;
        mode_B_inputField_segmentLength.readOnly = true;
        mode_B_inputField_currentIndex.readOnly = true;
        mode_B_inputField_wFull.readOnly = true;
        mode_B_button_reset.onClick.AddListener(delegate { ModeBReset(); });
        // ! Bifurcation Diagram
        mode_C_inputField_x0.text = "0";
        mode_C_inputField_minN.text = "100";
        mode_C_inputField_maxN.text = "250";
        mode_C_inputField_minC.text = "-2";
        mode_C_inputField_maxC.text = "0.25";
        mode_C_inputField_steps.text = "100";
        mode_C_inputField_dotSize.text = "1";
        mode_C_inputField_scale.text = "100";
        mode_C_button_reset.onClick.AddListener(delegate { ModeCReset(); });
    }

    // Update is called once per frame
    void Update()
    {

    }

    void DropdownValueChanged(TMP_Dropdown change)
    {
        // Common logic
        mode_B_empty.GetComponent<mode_B_Empty>().ClearLines();
        mode_B_empty.GetComponent<mode_B_Empty>().ResetVariable();
        mode_C_empty.GetComponent<mode_C_Empty>().ClearAllDots();
        mode_C_empty.GetComponent<mode_C_Empty>().ResetVariable();
        // Mode specific logic
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
        mode_B_toggle = false;
        mode_B_empty.gameObject.SetActive(false);
        mode_B_text_lineWidth.gameObject.SetActive(false);
        mode_B_text_level.gameObject.SetActive(false);
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
        mode_B_inputField_lineWidth.gameObject.SetActive(false);
        mode_B_inputField_level.gameObject.SetActive(false);
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
        mode_B_button_reset.gameObject.SetActive(false);
        mode_C_toggle = false;
        mode_C_empty.gameObject.SetActive(false);
        mode_C_text_x0.gameObject.SetActive(false);
        mode_C_text_minN.gameObject.SetActive(false);
        mode_C_text_maxN.gameObject.SetActive(false);
        mode_C_text_minC.gameObject.SetActive(false);
        mode_C_text_maxC.gameObject.SetActive(false);
        mode_C_text_steps.gameObject.SetActive(false);
        mode_C_text_dotSize.gameObject.SetActive(false);
        mode_C_text_scale.gameObject.SetActive(false);
        mode_C_inputField_x0.gameObject.SetActive(false);
        mode_C_inputField_minN.gameObject.SetActive(false);
        mode_C_inputField_maxN.gameObject.SetActive(false);
        mode_C_inputField_minC.gameObject.SetActive(false);
        mode_C_inputField_maxC.gameObject.SetActive(false);
        mode_C_inputField_steps.gameObject.SetActive(false);
        mode_C_inputField_dotSize.gameObject.SetActive(false);
        mode_C_inputField_scale.gameObject.SetActive(false);
        mode_C_button_reset.gameObject.SetActive(false);
        // * Enable UI elements for this mode
        mode_A_toggle = true;
        mode_A_sphere.gameObject.SetActive(true);
        mode_A_text_initX.gameObject.SetActive(true);
        mode_A_text_initY.gameObject.SetActive(true);
        mode_A_text_initZ.gameObject.SetActive(true);
        mode_A_text_traceTime.gameObject.SetActive(true);
        mode_A_inputField_initX.gameObject.SetActive(true);
        mode_A_inputField_initY.gameObject.SetActive(true);
        mode_A_inputField_initZ.gameObject.SetActive(true);
        mode_A_inputField_traceTime.gameObject.SetActive(true);
        mode_A_button_reset.gameObject.SetActive(true);
        // * Update component
        mode_A_sphere.GetComponent<mode_A_Tracer>().update = mode_A_toggle;
    }

    void ModeBLogic()
    {
        // ! LSystem
        // Debug.Log("LSystem");
        // * Disable UI elements for other modes
        mode_A_toggle = false;
        mode_A_sphere.gameObject.SetActive(false);
        mode_A_text_initX.gameObject.SetActive(false);
        mode_A_text_initY.gameObject.SetActive(false);
        mode_A_text_initZ.gameObject.SetActive(false);
        mode_A_text_traceTime.gameObject.SetActive(false);
        mode_A_inputField_initX.gameObject.SetActive(false);
        mode_A_inputField_initY.gameObject.SetActive(false);
        mode_A_inputField_initZ.gameObject.SetActive(false);
        mode_A_inputField_traceTime.gameObject.SetActive(false);
        mode_A_button_reset.gameObject.SetActive(false);
        mode_C_toggle = false;
        mode_C_empty.gameObject.SetActive(false);
        mode_C_text_x0.gameObject.SetActive(false);
        mode_C_text_minN.gameObject.SetActive(false);
        mode_C_text_maxN.gameObject.SetActive(false);
        mode_C_text_minC.gameObject.SetActive(false);
        mode_C_text_maxC.gameObject.SetActive(false);
        mode_C_text_steps.gameObject.SetActive(false);
        mode_C_text_dotSize.gameObject.SetActive(false);
        mode_C_text_scale.gameObject.SetActive(false);
        mode_C_inputField_x0.gameObject.SetActive(false);
        mode_C_inputField_minN.gameObject.SetActive(false);
        mode_C_inputField_maxN.gameObject.SetActive(false);
        mode_C_inputField_minC.gameObject.SetActive(false);
        mode_C_inputField_maxC.gameObject.SetActive(false);
        mode_C_inputField_steps.gameObject.SetActive(false);
        mode_C_inputField_dotSize.gameObject.SetActive(false);
        mode_C_inputField_scale.gameObject.SetActive(false);
        mode_C_button_reset.gameObject.SetActive(false);
        // * Enable UI elements for this mode
        mode_B_toggle = true;
        mode_B_empty.gameObject.SetActive(true);
        mode_B_text_lineWidth.gameObject.SetActive(true);
        mode_B_text_level.gameObject.SetActive(true);
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
        mode_B_inputField_lineWidth.gameObject.SetActive(true);
        mode_B_inputField_level.gameObject.SetActive(true);
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
        mode_B_button_reset.gameObject.SetActive(true);
        // * Update component
        mode_B_empty.GetComponent<mode_B_Empty>().update = mode_B_toggle;
    }

    void ModeCLogic()
    {
        // ! Bifurcation Diagram
        // Debug.Log("Bifurcation Diagram");
        // * Disable UI elements for other modes
        mode_A_toggle = false;
        mode_A_sphere.gameObject.SetActive(false);
        mode_A_text_initX.gameObject.SetActive(false);
        mode_A_text_initY.gameObject.SetActive(false);
        mode_A_text_initZ.gameObject.SetActive(false);
        mode_A_text_traceTime.gameObject.SetActive(false);
        mode_A_inputField_initX.gameObject.SetActive(false);
        mode_A_inputField_initY.gameObject.SetActive(false);
        mode_A_inputField_initZ.gameObject.SetActive(false);
        mode_A_inputField_traceTime.gameObject.SetActive(false);
        mode_A_button_reset.gameObject.SetActive(false);
        mode_B_toggle = false;
        mode_B_empty.gameObject.SetActive(false);
        mode_B_text_lineWidth.gameObject.SetActive(false);
        mode_B_text_level.gameObject.SetActive(false);
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
        mode_B_inputField_lineWidth.gameObject.SetActive(false);
        mode_B_inputField_level.gameObject.SetActive(false);
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
        mode_B_button_reset.gameObject.SetActive(false);
        // * Enable UI elements for this mode
        mode_C_toggle = true;
        mode_C_empty.gameObject.SetActive(true);
        mode_C_text_x0.gameObject.SetActive(true);
        mode_C_text_minN.gameObject.SetActive(true);
        mode_C_text_maxN.gameObject.SetActive(true);
        mode_C_text_minC.gameObject.SetActive(true);
        mode_C_text_maxC.gameObject.SetActive(true);
        mode_C_text_steps.gameObject.SetActive(true);
        mode_C_text_dotSize.gameObject.SetActive(true);
        mode_C_text_scale.gameObject.SetActive(true);
        mode_C_inputField_x0.gameObject.SetActive(true);
        mode_C_inputField_minN.gameObject.SetActive(true);
        mode_C_inputField_maxN.gameObject.SetActive(true);
        mode_C_inputField_minC.gameObject.SetActive(true);
        mode_C_inputField_maxC.gameObject.SetActive(true);
        mode_C_inputField_steps.gameObject.SetActive(true);
        mode_C_inputField_dotSize.gameObject.SetActive(true);
        mode_C_inputField_scale.gameObject.SetActive(true);
        mode_C_button_reset.gameObject.SetActive(true);
        // * Update component
    }

    void ModeAReset()
    {
        // mode_A_sphere.GetComponent<TrailRenderer>().emitting = false;
        mode_A_sphere.GetComponent<TrailRenderer>().Clear();
        var x = double.Parse(mode_A_inputField_initX.text);
        var y = double.Parse(mode_A_inputField_initY.text);
        var z = double.Parse(mode_A_inputField_initZ.text);
        // mode_A_sphere.GetComponent<mode_A_Tracer>().x = new double[3] { 0.01, 0, 0 };
        mode_A_sphere.GetComponent<mode_A_Tracer>().x = new double[3] { x, y, z };
        mode_A_sphere.GetComponent<TrailRenderer>().time = float.Parse(mode_A_inputField_traceTime.text);
        // mode_A_sphere.GetComponent<TrailRenderer>().emitting = true;
    }

    void ModeBReset()
    {
        mode_B_empty.GetComponent<mode_B_Empty>().ClearLines();
        mode_B_empty.GetComponent<mode_B_Empty>().ResetVariable();
        mode_B_empty.GetComponent<mode_B_Empty>().lineWidth = float.Parse(mode_B_inputField_lineWidth.text);
        mode_B_empty.GetComponent<mode_B_Empty>().level = int.Parse(mode_B_inputField_level.text);
        mode_B_empty.GetComponent<mode_B_Empty>().word = mode_B_inputField_w.text;
        mode_B_empty.GetComponent<mode_B_Empty>().newf = mode_B_inputField_newf.text;
        mode_B_empty.GetComponent<mode_B_Empty>().newb = mode_B_inputField_newb.text;
        mode_B_empty.GetComponent<mode_B_Empty>().angleInt = float.Parse(mode_B_inputField_angleInt.text);
        mode_B_empty.GetComponent<mode_B_Empty>().angleInc = float.Parse(mode_B_inputField_angleInc.text);
        mode_B_empty.GetComponent<mode_B_Empty>().scaler = float.Parse(mode_B_inputField_scaler.text);
        mode_B_empty.GetComponent<mode_B_Empty>().RunStart();
        mode_B_inputField_scaleFactor.text = mode_B_empty.GetComponent<mode_B_Empty>().scaleFactor.ToString();
        mode_B_inputField_segmentLength.text = mode_B_empty.GetComponent<mode_B_Empty>().segmentLength.ToString();
        mode_B_inputField_currentIndex.text = mode_B_empty.GetComponent<mode_B_Empty>().currentPositionIndex.ToString();
        mode_B_inputField_wFull.text = mode_B_empty.GetComponent<mode_B_Empty>().wordFull;
    }

    void ModeCReset()
    {
        mode_C_empty.GetComponent<mode_C_Empty>().ClearAllDots();
        mode_C_empty.GetComponent<mode_C_Empty>().ResetVariable();
        mode_C_empty.GetComponent<mode_C_Empty>().x0 = float.Parse(mode_C_inputField_x0.text);
        mode_C_empty.GetComponent<mode_C_Empty>().minN = int.Parse(mode_C_inputField_minN.text);
        mode_C_empty.GetComponent<mode_C_Empty>().maxN = int.Parse(mode_C_inputField_maxN.text);
        mode_C_empty.GetComponent<mode_C_Empty>().minC = float.Parse(mode_C_inputField_minC.text);
        mode_C_empty.GetComponent<mode_C_Empty>().maxC = float.Parse(mode_C_inputField_maxC.text);
        mode_C_empty.GetComponent<mode_C_Empty>().steps = int.Parse(mode_C_inputField_steps.text);
        mode_C_empty.GetComponent<mode_C_Empty>().dotSize = float.Parse(mode_C_inputField_dotSize.text);
        mode_C_empty.GetComponent<mode_C_Empty>().scaler = float.Parse(mode_C_inputField_scale.text);
        mode_C_empty.GetComponent<mode_C_Empty>().RunStart();
    }
}
