using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour {

    public GameObject[] fruitPrefab;
    public Transform[] spawnPoints;
    public float minDelay = .1f;
    public float maxDelay = 1f;

	// Use this for initialization
	void Start () {
        StartCoroutine(SpawnFruits());
	}
	
	IEnumerator SpawnFruits()
    {
        while(true)
        {
            float delay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(delay);

            //3. 스폰 지점을 랜덤으로 설정하기 위해 범위를 정한다.
            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPoin = spawnPoints[spawnIndex];

            //4. 다양한 도형을 스폰합니다.
            int ShapeIndex = Random.Range(0, fruitPrefab.Length);
            GameObject Shape = fruitPrefab[ShapeIndex];

            GameObject spawnedFruit = Instantiate(Shape, spawnPoin.position, spawnPoin.rotation);
            Destroy(spawnedFruit, 5f);
        }
    }
}
