using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    public Pathway pathway; // Assign Pathway in Inspector
    public float speed = 2f;
    private int currentWaypointIndex = 0;

    private void Update()
    {
        if (pathway == null || pathway.waypoints.Count == 0) return;

        Transform targetWaypoint = pathway.GetWaypoint(currentWaypointIndex);
        if (targetWaypoint == null) return;

        // Move NPC towards the waypoint
        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, speed * Time.deltaTime);

        // Check if NPC reached the waypoint
        if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.1f)
        {
            currentWaypointIndex++; // Move to the next waypoint
            if (currentWaypointIndex >= pathway.waypoints.Count)
            {
                currentWaypointIndex = 0; // Loop back to the start
            }
        }
    }
}
