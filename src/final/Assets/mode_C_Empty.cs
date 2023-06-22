using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mode_C_Empty : MonoBehaviour
{
    // * Variable with UI
    public bool update = false;
    public float x0 = 0.0f;
    public int minN = 100;
    public int maxN = 250;
    public float minC = -2.0f;
    public float maxC = 0.25f;
    public int steps = 10000;
    public float dotSize = 0.1f;
    public float scaler = 1.0f;

    // * Variable for Bifurcation Diagram
    private List<List<float>> result = new List<List<float>>();
    private int resultUpdateIndex = 0;
    private int resultCount = 0;
    private float increment = 0.0f;
    private List<float> cRange = new List<float>();
    private List<GameObject> dotList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (update)
        {
            if (resultUpdateIndex < resultCount)
            {
                // render result[resultUpdateIndex]
                UpdateCoordinate(resultUpdateIndex);
                resultUpdateIndex++;
            }
            else
            {
                update = false;
            }
        }
    }

    public void ResetVariable()
    {
        update = false;
        x0 = 0.0f;
        minN = 100;
        maxN = 250;
        minC = -2.0f;
        maxC = 0.25f;
        steps = 10000;
        dotSize = 0.1f;
        result = new List<List<float>>();
        resultUpdateIndex = 0;
        resultCount = 0;
        increment = 0.0f;
        cRange = new List<float>();
        dotList = new List<GameObject>();
    }

    public void ClearAllDots()
    {
        if (dotList.Count > 0)
        {
            foreach (GameObject dot in dotList)
            {
                Destroy(dot);
            }
        }
    }

    public void RunStart()
    {
        GenerateCoordinate();
        ScaleAllCoordinate();
        resultCount = result.Count;
        update = true;
    }

    void GenerateCoordinate()
    {
        increment = Mathf.Abs((maxC - minC) / steps);
        for (float i = minC; i < maxC; i += increment)
        {
            cRange.Add(i);
        }
        foreach (float c in cRange)
        {
            List<float> temp = new List<float>();
            temp.Add(x0);
            for (int n = 0; n < maxN; n++)
            {
                float last_temp = temp[temp.Count - 1];
                float y = last_temp * last_temp + c;
                temp.Add(y);
            }
            temp = temp.GetRange(minN, temp.Count - minN);
            result.Add(temp);
        }
    }

    void ScaleAllCoordinate()
    {
        for (int i = 0; i < result.Count; i++)
        {
            for (int j = 0; j < result[i].Count; j++)
            {
                result[i][j] *= scaler;
            }
        }
        for (int i = 0; i < cRange.Count; i++)
        {
            cRange[i] *= scaler;
        }
    }

    void UpdateCoordinate(int index)
    {
        for (int i = 0; i < result[index].Count; i++)
        {
            GameObject dot = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            dot.transform.position = new Vector3(cRange[index], result[index][i], 0.0f);
            dot.transform.localScale = new Vector3(dotSize, dotSize, dotSize);
            // dot.material.color = Color.red;
            dotList.Add(dot);
        }
    }
}
