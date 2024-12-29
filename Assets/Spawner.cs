using System.Collections;

using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Vector3[] spawnPoints;
    public GameObject blockPrefab;
    public ScoreCounter sc;
    public float[] spawnRates;

    private float spawnRate;

    private void Start()
    {
        spawnRate = spawnRates[0];
        StartCoroutine(Spawn());
    }

    private void Update()
    {
        if (sc.score > 10 && spawnRate == spawnRates[0]) spawnRate = spawnRates[1];
        else if (sc.score > 30 && spawnRate == spawnRates[1]) spawnRate = spawnRates[2];
        else if (sc.score > 50 && spawnRate == spawnRates[2]) spawnRate = spawnRates[3];
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            var spawnTime = Random.Range(spawnRate - 0.5f, spawnRate + 0.5f);
            yield return new WaitForSeconds(spawnTime);

            Instantiate(
                blockPrefab, 
                spawnPoints[Random.Range(0, spawnPoints.Length)], 
                Quaternion.identity);
        }
    }
}
