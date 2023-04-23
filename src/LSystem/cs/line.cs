using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor.Recorder;

public class line : MonoBehaviour
{
    private LineRenderer lineRenderer;
    // public string Cpath = @"D:\Note_Database\Subject\CF Chaos and Fractals\hw4\level3\Q3_co.csv"; // path to the CSV file
    public enum Task { UpdateLine, DrawAllLines };
    public Task task;
    public float lineWidth = 0.01f;
    public int level = 5;
    public string w = "F";
    public string newf = "F-F++F-F";
    public string newb = "";
    public int angleInt = 0;
    public int angleInc = 60;
    public float scaler = 5;
    public float scaleFactor;
    public float segmentLength = 1f;
    public Vector2 topMost;
    public Vector2 rightMost;
    public Vector2 leftMost;
    public Vector2 bottomMost;
    public string w_full = "";
    public int currentPositionIndex = 0; // index of the current position in the array
    public List<Vector2> positions = new List<Vector2>(); // array of positions to follow
    public List<int> dIndex = new List<int>(); // array of positions to follow
    public List<float> widthList = new List<float>(); // array of positions to follow
    public static bool lineFullyDrawn = false;
    public static int fps = 60; // frames per second
    private float timer;
    private List<List<Vector2>> lineCoordinateList = new List<List<Vector2>>();
    private List<LineRenderer> lineRendererList = new List<LineRenderer>();
    private int numLines = 3;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
        // LoadCoordinate();
        LSystem();
        GenerateCoordinate();
        OffsetAllCoordinate();
        ScaleAllCoordinate();
        SplitLineCoordinate();
        if (task.ToString() == "UpdateLine")
        {
            SetLineRendererSettings();
        }
        Debug.Log("Start Done");
    }

    // Update is called once per frame
    void Update()
    {
        if (task.ToString() == "UpdateLine")
        {
            UpdateLine();
        }
        else if (task.ToString() == "DrawAllLines")
            DrawAllLines();

        // Debug.Log($"Frame: {Time.frameCount}");
    }

    // void LoadCoordinate()
    // {
    //     // load the CSV file and add each position to the positions array
    //     Debug.Log($"Loading {Cpath}...");
    //     using (var reader = new StreamReader(Cpath))
    //     {
    //         int i = 0;
    //         while (!reader.EndOfStream)
    //         {
    //             var line = reader.ReadLine();
    //             var values = line.Split(',');
    //             // check if both values can be converted to float
    //             if (float.TryParse(values[0], out float x) && float.TryParse(values[1], out float y) && float.TryParse(values[2], out float z))
    //             {
    //                 positions.Add(new Vector2(x, z));
    //                 i++;
    //             }
    //             else
    //             {
    //                 Debug.LogError("Invalid data in CSV file: " + line);
    //             }
    //         }
    //     }
    //     Debug.Log($"Loaded {positions.Count} positions from CSV file.");
    // }

    void LSystem()
    {
        Debug.Log($"L-system...");
        char[] w_char = w.ToCharArray();
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
        w_full = new string(w_char);
        Debug.Log($"w_full: {w_full}");
        Debug.Log($"L-system Done");
    }

    void GenerateCoordinate()
    {
        Debug.Log($"GenerateCoordinates...");
        char[] w_full_char = w_full.ToCharArray();
        float angle = angleInt;
        Vector2 currentPos = new Vector2(0, 0);
        Vector2 nextPos = new Vector2(0, 0);
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
                nextPos = new Vector2(currentPos.x + segmentLength * Mathf.Cos(angle * Mathf.Deg2Rad), currentPos.y + segmentLength * Mathf.Sin(angle * Mathf.Deg2Rad));
                positions.Add(nextPos);
                currentPos = nextPos;
            }
            else if (w_full_char[i] == 'b')
            {
                nextPos = new Vector2(currentPos.x + segmentLength * Mathf.Cos(angle * Mathf.Deg2Rad), currentPos.y + segmentLength * Mathf.Sin(angle * Mathf.Deg2Rad));
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
        Debug.Log($"DIndex: {dIndexString}");
        Debug.Log($"DIndex count: {dIndex.Count}");
        Debug.Log($"Coordinates count: {positions.Count}");
        Debug.Log($"GenerateCoordinates Done");
    }

    void OffsetAllCoordinate()
    {
        // get top-most, right-most, left-most, and bottom-most positions
        topMost = positions[0];
        rightMost = positions[0];
        leftMost = positions[0];
        bottomMost = positions[0];
        foreach (Vector2 position in positions)
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

        Debug.Log($"Top: {topMost}");
        Debug.Log($"Right: {rightMost}");
        Debug.Log($"Left: {leftMost}");
        Debug.Log($"Bottom: {bottomMost}");

        // offset all positions by the midpoint of the top, right, left, and bottom-most positions
        Vector2 offset = new Vector2((rightMost.x + leftMost.x) / 2, (topMost.y + bottomMost.y) / 2);
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
        List<Vector2> tempCoorList = new List<Vector2>();
        for (int i = 0; i < positions.Count; i++)
        {
            if (dIndex.Contains(i))
            {
                if (tempCoorList.Count >= 0)
                {
                    lineCoordinateList.Add(tempCoorList);
                    tempCoorList = new List<Vector2>();
                }
                tempCoorList = new List<Vector2>();
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
        lineCoordinateList[lineCoordinateList.Count - 1].Add(positions[positions.Count - 1]);

        // print out the number of lines
        Debug.Log($"Number of lines: {lineCoordinateList.Count}");
        for (int i = 0; i < lineCoordinateList.Count; i++)
        {
            Debug.Log($"Line {i + 1} has {lineCoordinateList[i].Count} coordinates");
        }
    }

    void SetLineRendererSettings()
    {
        // get the LineRenderer component and set its settings
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.positionCount = positions.Count;
    }

    void UpdateLine()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            float updateFrequency = 1 / fps;
            if (currentPositionIndex < positions.Count)
            {
                lineRenderer.SetPosition(currentPositionIndex, positions[currentPositionIndex]);
                currentPositionIndex++;
            }
            else
            {
                lineFullyDrawn = true;
            }
        }
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
