using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mode_B_Tracer : MonoBehaviour
{
    // * Variable with UI
    public bool update = false;
    public float lineWidth = 0.01f;
    public int level = 0;
    public string word = "";
    public string newf = "";
    public string newb = "";
    public float angleInt = 0.0f;
    public float angleInc = 0.0f;
    public float scaler = 0.0f;
    public float scaleFactor = 0.0f;
    public float segmentLength = 1.0f;
    public int currentPositionIndex = 0;
    public string wordFull = "";

    // * Variable for L-System
    private Vector3 topMost;
    private Vector3 bottomMost;
    private Vector3 leftMost;
    private Vector3 rightMost;
    private List<Vector3> positions = new List<Vector3>(); // array of positions to follow
    private List<int> dIndex = new List<int>(); // array of indices to follow
    private static bool lineFullyDrawn = false;
    private List<List<Vector3>> lineCoordinateList = new List<List<Vector3>>();
    private List<LineRenderer> lineRendererList = new List<LineRenderer>();
    private int numLines = 3;
    // Start is called before the first frame update
    void Start()
    {
        // RunStart();
    }

    // Update is called once per frame
    void Update()
    {
        // if (update)
        // {
        // RunStart();
        // update = false;
        // DrawAllLines();
        // if (lineFullyDrawn)
        // {
        //     update = false;
        // }
        // }
    }

    public void RunStart()
    {
        LSystem();
        GenerateCoordinate();
        OffsetAllCoordinate();
        ScaleAllCoordinate();
        SplitLineCoordinate();
        DrawAllLines();
    }

    public void ClearLines()
    {
        if (lineRendererList.Count != 0)
        {
            foreach (LineRenderer line in lineRendererList)
            {
                Destroy(line.gameObject, 0.1f);
            }
            lineRendererList.Clear();
        }
    }

    public void ResetVariable()
    {
        topMost = new Vector3(0, 0, 0);
        bottomMost = new Vector3(0, 0, 0);
        leftMost = new Vector3(0, 0, 0);
        rightMost = new Vector3(0, 0, 0);
        positions = new List<Vector3>();
        dIndex = new List<int>();
        lineFullyDrawn = false;
        lineCoordinateList = new List<List<Vector3>>();
        lineRendererList = new List<LineRenderer>();
        numLines = 3;
    }

    void LSystem()
    {
        Debug.Log($"L-system...");
        char[] w_char = word.ToCharArray();
        char[] newf_char = newf.ToCharArray();
        char[] newb_char = newb.ToCharArray();
        while (level > 0)
        {
            List<char> w_list = new List<char>();
            for (int i = 0; i < w_char.Length; i++)
            {
                if (w_char[i] == '+')
                {
                    w_list.Add('+');
                }
                else if (w_char[i] == '-')
                {
                    w_list.Add('-');
                }
                else if (w_char[i] == 'F')
                {
                    w_list.AddRange(newf_char);
                }
                else if (w_char[i] == 'b')
                {
                    w_list.AddRange(newb_char);
                }
                else
                {
                    w_list.Add(w_char[i]);
                }
            }
            w_char = w_list.ToArray();
            level--;
        }
        // Debug.Log($"w_char: {new string(w_char)}");
        wordFull = new string(w_char);
        // Debug.Log($"wordFull: {wordFull}");
        // Debug.Log($"L-system Done");
    }

    void GenerateCoordinate()
    {
        char[] w_full_char = wordFull.ToCharArray();
        float angle = angleInt;
        Vector3 currentPos = new Vector3(0, 0, 0);
        Vector3 nextPos = new Vector3(0, 0, 0);
        positions.Add(currentPos);
        for (int i = 0; i < w_full_char.Length; i++)
        {
            if (w_full_char[i] == '+')
            {
                angle += angleInc;
            }
            else if (w_full_char[i] == '-')
            {
                angle -= angleInc;
            }
            else if (w_full_char[i] == 'F')
            {
                nextPos = new Vector3(currentPos.x + segmentLength * Mathf.Cos(angle * Mathf.Deg2Rad), currentPos.y + segmentLength * Mathf.Sin(angle * Mathf.Deg2Rad));
                positions.Add(nextPos);
                currentPos = nextPos;
            }
            else if (w_full_char[i] == 'b')
            {
                nextPos = new Vector3(currentPos.x + segmentLength * Mathf.Cos(angle * Mathf.Deg2Rad), currentPos.y + segmentLength * Mathf.Sin(angle * Mathf.Deg2Rad));
                positions.Add(nextPos);
                currentPos = nextPos;
                dIndex.Add(positions.Count - 1);
            }
        }
        string dIndexString = "";
        foreach (int index in dIndex)
        {
            dIndexString += index.ToString() + ", ";
            // dIndexString += index.ToString();
        }
        // Debug.Log($"DIndex: {dIndexString}");
        // Debug.Log($"DIndex count: {dIndex.Count}");
        // Debug.Log($"Coordinates count: {positions.Count}");
        // Debug.Log($"GenerateCoordinates Done");
    }

    void OffsetAllCoordinate()
    {
        // get top-most, right-most, left-most, and bottom-most positions
        topMost = positions[0];
        rightMost = positions[0];
        leftMost = positions[0];
        bottomMost = positions[0];
        foreach (Vector3 position in positions)
        {
            if (position.y > topMost.y)
            {
                topMost = position;
            }

            if (position.x > rightMost.x)
            {
                rightMost = position;
            }

            if (position.x < leftMost.x)
            {
                leftMost = position;
            }

            if (position.y < bottomMost.y)
            {
                bottomMost = position;
            }
        }

        // Debug.Log($"Top: {topMost}");
        // Debug.Log($"Right: {rightMost}");
        // Debug.Log($"Left: {leftMost}");
        // Debug.Log($"Bottom: {bottomMost}");

        // offset all positions by the midpoint of the top, right, left, and bottom-most positions
        Vector3 offset = new Vector3((rightMost.x + leftMost.x) / 2, (topMost.y + bottomMost.y) / 2);
        for (int i = 0; i < positions.Count; i++)
        {
            positions[i] -= offset;
        }
    }

    void ScaleAllCoordinate()
    {
        // get the scale factor
        scaleFactor = scaler / Mathf.Max(Mathf.Abs(rightMost.x - leftMost.x), Mathf.Abs(topMost.y - bottomMost.y));

        // scale all positions by the scale factor
        for (int i = 0; i < positions.Count; i++)
        {
            positions[i] *= scaleFactor;
        }

        // adjust parameters that depend on the scale factor
        segmentLength *= scaleFactor;
        topMost *= scaleFactor;
        rightMost *= scaleFactor;
        leftMost *= scaleFactor;
        bottomMost *= scaleFactor;
    }

    void SplitLineCoordinate()
    {
        // split the line into multiple lines and stores in lineCoordinateList
        List<Vector3> tempCoorList = new List<Vector3>();
        for (int i = 0; i < positions.Count; i++)
        {
            if (dIndex.Contains(i))
            {
                if (tempCoorList.Count >= 0)
                {
                    lineCoordinateList.Add(tempCoorList);
                    tempCoorList = new List<Vector3>();
                }
                tempCoorList = new List<Vector3>();
                if (dIndex.Contains(i) && dIndex.Contains(i + 1)) { }
                else
                {
                    tempCoorList.Add(positions[i]);
                }
            }
            else
            {
                tempCoorList.Add(positions[i]);
            }
        }
        if (tempCoorList.Count > 0)
        {
            lineCoordinateList.Add(tempCoorList);
        }

        // print out the number of lines
        // Debug.Log($"Number of lines: {lineCoordinateList.Count}");
        // for (int i = 0; i < lineCoordinateList.Count; i++)
        // {
        //     Debug.Log($"Line {i + 1} has {lineCoordinateList[i].Count} coordinates");
        // }
    }

    void DrawAllLines()
    {
        if (lineFullyDrawn)
        {
            return;
        }
        else
        {
            numLines = lineCoordinateList.Count;
            for (int i = 0; i < numLines; i++)
            {
                GameObject lineObject = new GameObject("Line " + i);
                LineRenderer line = lineObject.AddComponent<LineRenderer>();
                line.startWidth = lineWidth;
                line.endWidth = lineWidth;
                line.material = new Material(Shader.Find("Sprites/Default"));
                line.positionCount = lineCoordinateList[i].Count;
                for (int j = 0; j < lineCoordinateList[i].Count; j++)
                {
                    line.SetPosition(j, lineCoordinateList[i][j]);
                }
                lineRendererList.Add(line);
            }
            lineFullyDrawn = true;
        }
    }

}
