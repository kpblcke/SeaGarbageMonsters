using UnityEngine;

namespace DefaultNamespace
{
    public class EnemyHealth : MonoBehaviour
    {
        [SerializeField] int maxHitPoints = 5;
        [SerializeField] int currentHitPoints = 0;

        void Start()
        {
            currentHitPoints = maxHitPoints;        
        }

        void OnParticleCollision(GameObject other) 
        {
            ProcessHit();
        }

        void ProcessHit() 
        {
            currentHitPoints--;

            if(currentHitPoints <= 0)
            {
                Destroy(gameObject);
            }
        }

    }
}