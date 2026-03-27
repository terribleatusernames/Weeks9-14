using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Pulse : MonoBehaviour
{
    public LineRenderer linerenderer;
    public List<Vector2> positions;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        positions = new List<Vector2>();
        positions.Add(transform.position);

        linerenderer.positionCount = 1;
        linerenderer.SetPosition(linerenderer.positionCount - 1, transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lastPos = linerenderer.GetPosition(linerenderer.positionCount - 1);
        Vector3 newPos = lastPos + Vector3.right * 2 * Time.deltaTime;

        linerenderer.positionCount++;
        linerenderer.SetPosition(linerenderer.positionCount - 1, newPos);

        UpdateLine();

        if(positions.Count > 100)
        {
            positions.RemoveAt(0);
        }
    }

    void UpdateLine()
    {
        linerenderer.positionCount = positions.Count;
        for (int i = 0; i < positions.Count; i++)
        {
            linerenderer.SetPosition(i, positions[i]);
        }

    }
}

