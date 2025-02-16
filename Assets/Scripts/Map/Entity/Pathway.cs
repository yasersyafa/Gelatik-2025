using UnityEngine;
using System.Collections.Generic;

public class Pathway : MonoBehaviour
{
    public List<Transform> waypoints = new List<Transform>();

    private void Awake()
    {
        // Auto-populate the waypoints from child objects
        waypoints.Clear();
        foreach (Transform child in transform)
        {
            waypoints.Add(child);
        }
    }

    public Transform GetWaypoint(int index)
    {
        if (index >= 0 && index < waypoints.Count)
            return waypoints[index];
        return null;
    }
}
