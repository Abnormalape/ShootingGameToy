using System;
using Unity.Properties;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;



public class EnemySpawner : MonoBehaviour
{
    [Serializable]
    public class EnemySpawnInfo
    {
        [SerializeField] private GameObject prefab;
        [SerializeField] private float spawnTime;

        public GameObject Prefab { get { return prefab; } }
        public float SpawnTime { get {  return spawnTime; } }
    }

    [SerializeField] private EnemySpawnInfo[] spawnInfo;

    public void OnGameStarted()
    {
        Invoke("Spawn", spawnInfo[currentIndex].SpawnTime);
    }

    private int currentIndex = 0;
    private void Awake()
    {
        
    }
    private void Spawn()
    {
        //Instantiate(spawnInfo[currentIndex].Prefab, transform.position, Quaternion.identity);
        //currentIndex = (currentIndex + 1) % spawnInfo.Length ;
        //Invoke("Spawn", spawnInfo[currentIndex].SpawnTime);
    }
}
