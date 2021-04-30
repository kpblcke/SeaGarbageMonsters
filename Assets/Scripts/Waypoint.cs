using UnityEngine;

namespace DefaultNamespace
{
    public class Waypoint : MonoBehaviour
    {
        [SerializeField] GameObject towerPrefab;
        [SerializeField] bool isPlaceable;
        
        void OnMouseDown() {
            if(isPlaceable){
                Instantiate(towerPrefab, transform.position, Quaternion.identity);
                isPlaceable = false;
            }
        }

    }
}