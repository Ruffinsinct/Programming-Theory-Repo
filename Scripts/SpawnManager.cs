using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] foodPrefab;

    public Vector3 spawnRange = new Vector3(10f, 0f, 10f);

    public int foodCount = 6;

    public float spawnRate = 8.0f;
    

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnObjects());
    }

    // Update is called once per frame
    IEnumerator SpawnObjects()
    {
        for(int i = 0; i < foodCount; i++)
        {
            Vector3 randomPosition = transform.position + new Vector3(Random.Range(-spawnRange.x, spawnRange.x), 0f, Random.Range(-spawnRange.z, spawnRange.z));

            int randomIndex = Random.Range(0, foodPrefab.Length);

            Instantiate(foodPrefab[randomIndex], randomPosition, Quaternion.identity);

            yield return new WaitForSeconds(spawnRate);
        }
    }
}
