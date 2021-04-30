using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

namespace DefaultNamespace
{
    [RequireComponent(typeof(Enemy))]
    public class EnemyMover : MonoBehaviour
    {
        [SerializeField] private List<Waypoint> path = new List<Waypoint>();
        [SerializeField] [Range(0f, 5f)] float speed = 1f;
        Enemy enemy;

        void OnEnable()
        {
            FindPath();
            ReturnToStart();
            StartCoroutine(FollowPath());
        }

        void Start()
        {
            enemy = GetComponent<Enemy>();
        }

        void FindPath()
        {
            path.Clear();
            GameObject parent = GameObject.FindWithTag("Path");

            foreach (Transform tile in parent.transform)
            {
                Waypoint waypoint = tile.GetComponent<Waypoint>();

                if(waypoint != null)
                {
                    path.Add(waypoint);
                }
            }
        }

        void ReturnToStart()
        {
            transform.position = path[0].transform.position;
        }

        IEnumerator FollowPath()
        {
            foreach (Waypoint waypoint in path)
            {
                Vector3 startPosition = transform.position;
                Vector3 endPosition = waypoint.transform.position;
                Quaternion startRotation = transform.rotation;
                Quaternion endRotation = Quaternion.LookRotation(startPosition - endPosition);
                float travelPercent = 0f;

                while (travelPercent < 1f)
                {
                    travelPercent += Time.deltaTime * speed;
                    transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                    transform.rotation = Quaternion.Lerp(startRotation, endRotation, travelPercent * 10);
                    yield return new WaitForEndOfFrame();
                }
            }

            FinishPath();
        }
        
        void FinishPath()
        {
            enemy.StealGold();
            gameObject.SetActive(false);
        }

    }
}
