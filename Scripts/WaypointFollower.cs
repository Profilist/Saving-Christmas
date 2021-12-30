using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currIndex = 0;

    [SerializeField] private float speed = 2f;

    private void Update()
    {
        if (Vector2.Distance(waypoints[currIndex].transform.position, transform.position) < .1f)
        {
            currIndex = currIndex >= waypoints.Length-1 ? 0 : currIndex+1;
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currIndex].transform.position, Time.deltaTime * speed);
    }
}
