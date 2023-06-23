using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mode_D_Empty : MonoBehaviour
{
    // * Variable with UI
    public bool update = false;
    public int minN = 0;
    public int maxN = 0;
    public double c = -2.0;
    public double x0_A = 0.1;
    public double x0_B = 0.10001;
    public double scale = 1.0;
    public float lineWidth = 0.01f;

    // * Variable for Bifurcation Diagram
    private List<double> result_A = new List<double>();
    private List<double> result_B = new List<double>();
    private List<GameObject> lineList = new List<GameObject>();
    private List<LineRenderer> lineRendererList = new List<LineRenderer>();
    private int drawDataIndex = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (update)
        {
            if (drawDataIndex >= result_A.Count)
            {
                update = false;
            }
            else
            {
                var coordinateA = new Vector3((float)(drawDataIndex * scale), (float)(result_A[drawDataIndex] * scale), 0.0f);
                var coordinateB = new Vector3((float)(drawDataIndex * scale), (float)(result_B[drawDataIndex] * scale), 0.0f);
                lineRendererList[0].SetPosition(drawDataIndex, coordinateA);
                lineRendererList[1].SetPosition(drawDataIndex, coordinateB);
                drawDataIndex++;
            }
        }
        else
        {
            update = false;
        }
    }

    public void ResetVariable()
    {
        update = false;
        minN = 0;
        maxN = 250;
        c = -2.0;
        x0_A = 0.1;
        x0_B = 0.10001;
        scale = 1.0;
        lineWidth = 0.01f;
        result_A = new List<double>();
        result_B = new List<double>();
        lineList = new List<GameObject>();
        lineRendererList = new List<LineRenderer>();
        drawDataIndex = 0;
        result_A.Add(x0_A);
        result_B.Add(x0_B);
    }

    public void ClearLines()
    {
        if (lineList.Count > 0)
        {
            foreach (LineRenderer lineRenderer in lineRendererList)
            {
                Destroy(lineRenderer);
            }
            foreach (GameObject line in lineList)
            {
                Destroy(line);
            }
        }
    }

    public void RunStart()
    {
        GenerateCoordinate();
        InitiateLines();
        update = true;
    }

    void GenerateCoordinate()
    {
        for (int i = 0; i < maxN; i++)
        {
            double x = result_A[i];
            double y = result_B[i];
            double x1 = x * x + c;
            double y1 = y * y + c;
            result_A.Add(x1);
            result_B.Add(y1);
        }
        result_A.RemoveRange(0, minN);
        result_B.RemoveRange(0, minN);
    }

    void InitiateLines()
    {
        // * Line A
        GameObject lineA = new GameObject("Mode D Line A");
        LineRenderer lineRendererA = lineA.AddComponent<LineRenderer>();
        lineRendererA.startWidth = lineWidth;
        lineRendererA.endWidth = lineWidth;
        lineRendererA.material = new Material(Shader.Find("Sprites/Default"));
        lineRendererA.material.color = Color.red;
        lineRendererA.positionCount = result_A.Count;
        lineList.Add(lineA);
        lineRendererList.Add(lineRendererA);
        // * Line B
        GameObject lineB = new GameObject("Mode D Line B");
        LineRenderer lineRendererB = lineB.AddComponent<LineRenderer>();
        lineRendererB.startWidth = lineWidth;
        lineRendererB.endWidth = lineWidth;
        lineRendererB.material = new Material(Shader.Find("Sprites/Default"));
        lineRendererB.material.color = Color.blue;
        lineRendererB.positionCount = result_B.Count;
        lineList.Add(lineB);
        lineRendererList.Add(lineRendererB);
    }
}
