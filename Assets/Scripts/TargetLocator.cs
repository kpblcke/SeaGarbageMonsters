using UnityEngine;

namespace DefaultNamespace
{
    public class TargetLocator : MonoBehaviour
    {
        [SerializeField] Transform weapon;
        Transform target;

        void Start()
        {
            target = FindObjectOfType<EnemyMover>().transform;
        }

        void Update()
        {
            AimWeapon();
        }

        void AimWeapon() 
        {
            weapon.LookAt(target);
        }

    }
}