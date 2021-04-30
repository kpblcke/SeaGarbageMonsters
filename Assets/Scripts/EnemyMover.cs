using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private List<Waypoint> path = new List<Waypoint>(); 
    [SerializeField] [Range(0f, 5f)] float speed = 1f; 
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FollowPath());
    }

    IEnumerator FollowPath() 
    {
        foreach(Waypoint waypoint in path) 
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = waypoint.transform.position;
            Quaternion startRotation = transform.rotation;
            Quaternion endRotation = Quaternion.LookRotation(startPosition - endPosition);
            float travelPercent = 0f;

            while(travelPercent < 1f) {
                travelPercent += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                transform.rotation = Quaternion.Lerp(startRotation, endRotation, travelPercent * 10);
                yield return new WaitForEndOfFrame();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
