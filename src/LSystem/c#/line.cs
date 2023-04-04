using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor.Recorder;

public class line : MonoBehaviour
{
    private LineRenderer lineRenderer;
    public List<Vector2> positions = new List<Vector2>(); // array of positions to follow
    private int currentPositionIndex = 0; // index of the current position in the array
    public string path = @"D:\Note_Database\Subject\CF Chaos and Fractals\hw3\Q3_l5.csv"; // path to the CSV file
    public static bool lineFullyDrawn = false;
    public static int fps = 60; // frames per second
    public float updateFrequency = 1 / fps; // how often to update the line
    private float timer;
    public string task = "UpdateLine"; // "UpdateLine" or "DrawAllLines"

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
        LoadCoordinate();
        OffsetAllCoordinate();
        SetLineRendererSettings();
        Debug.Log("Start Done");
    }

    // Update is called once per frame
    void Update()
    {
        if (task == "UpdateLine")
            UpdateLine();
        else if (task == "DrawAllLines")
            DrawAllLines();

        // Debug.Log($"Frame: {Time.frameCount}");
    }

    void LoadCoordinate()
    {
        // load the CSV file and add each position to the positions array
        Debug.Log($"Loading {path}...");
        using (var reader = new StreamReader(path))
        {
            int i = 0;
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');
                // check if both values can be converted to float
                if (float.TryParse(values[0], out float x) && float.TryParse(values[1], out float y) && float.TryParse(values[2], out float z))
                {
                    positions.Add(new Vector2(x, z));
                    i++;
                }
                else
                {
                    Debug.LogError("Invalid data in CSV file: " + line);
                }
            }
        }
        Debug.Log($"Loaded {positions.Count} positions from CSV file.");
    }

    void OffsetAllCoordinate()
    {
        // get top-most, right-most, left-most, and bottom-most positions
        Vector2 topMost = positions[0];
        Vector2 rightMost = positions[0];
        Vector2 leftMost = positions[0];
        Vector2 bottomMost = positions[0];
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

    void SetLineRendererSettings()
    {
        // get the LineRenderer component and set its settings
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.startWidth = 0.02f;
        lineRenderer.endWidth = 0.02f;
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.positionCount = positions.Count;
    }

    void UpdateLine()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            // update the line every updateFrequency seconds to prevent weird artifacts
            if (currentPositionIndex < positions.Count)
            {
                lineRenderer.SetPosition(currentPositionIndex, positions[currentPositionIndex]);
                currentPositionIndex++;
            }
            else
            {
                lineFullyDrawn = true;
            }
            timer = updateFrequency;
        }
    }

    void DrawAllLines()
    {
        for (int i = 0; i < positions.Count; i++)
        {
            lineRenderer.SetPosition(i, positions[i]);
        }
    }
}
