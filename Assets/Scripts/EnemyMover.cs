using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private List<Waypoint> waypoints = new List<Waypoint>(); 
    // Start is called before the first frame update
    void Start()
    {
        PrintWaypointName();
    }

    void PrintWaypointName()
    {
        foreach (var VARIABLE in waypoints)
        {
            Debug.Log(VARIABLE.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
