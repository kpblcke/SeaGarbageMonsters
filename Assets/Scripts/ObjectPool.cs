using System;
using System.Collections;
using UnityEngine;

namespace DefaultNamespace
{
    public class ObjectPool : MonoBehaviour
    {
        [SerializeField] GameObject enemyPrefab;
        [SerializeField] 
        [Range(0, 50)]
        int poolSize = 5;
        [SerializeField] 
        [Range(0.1f, 30f)]
        private float spawnDelta = 1f;

        GameObject[] pool;

        void Awake()
        {
            PopulatePool();
        }

        private void Start()
        {
            StartCoroutine(InfiniteSpawn());
        }
        
        void PopulatePool()
        {
            pool = new GameObject[poolSize];

            for(int i = 0; i < pool.Length; i++)
            {
                pool[i] = Instantiate(enemyPrefab, transform);
                pool[i].SetActive(false);
            }
        }
        
        void EnableObjectInPool()
        {
            for(int i = 0; i < pool.Length; i++)
            {
                if(pool[i].activeInHierarchy == false)
                {
                    pool[i].SetActive(true);
                    return;
                }
            }
        }

        IEnumerator InfiniteSpawn()
        {
            while (true)
            {
                EnableObjectInPool();
                yield return new WaitForSeconds(spawnDelta);
            }
        }
    }
}