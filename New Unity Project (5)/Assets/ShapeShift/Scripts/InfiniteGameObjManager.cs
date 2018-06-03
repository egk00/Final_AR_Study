using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteGameObjManager : MonoBehaviour
{
    public static InfiniteGameObjManager Instance;
    protected internal List<Vector3> lastCollectbleSpawnPosition = new List<Vector3>();
    protected internal List<Vector3> lastObstacleSpawnPosition = new List<Vector3>();
    protected internal List<GameObject> gameObjSpawned = new List<GameObject>();
    public List<int> inGameObstacleSpawnIndex = new List<int>();
    public GameObject startingBlock;
    public int amountOfActiveGround, groundDir;
    public float groundPositionX, groundPositionZ;
    private const int spawnAmount = 5;
    public bool spawning = false;
    private GameObject obstacle, ground;
    private void Awake()
    {
        Instance = this;
    }
    public void InstantiateGameObjects()
    {
        for (int x =0; x < SaveLoad.Instance.shapes.Count; x++)
        {
            GameObject shape = (GameObject)Instantiate(SaveLoad.Instance.shapes[x].ShapeObj);
            shape.name = " shape" + "[" + x + "]";
            SaveLoad.Instance.shapes[x].ShapeObj = shape;
            shape.gameObject.transform.position = new Vector3(0, 5.41f, 0);
            SaveLoad.Instance.shapes[x].ShapeObj.transform.parent = ShapeManager.Instance.transform;
            shape.SetActive(false);
            shape.tag = SaveLoad.Instance.shapes[x].type.ToString();
            shape.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    void Update()
    {
        if (ShapeShiftGameManager.Instance.GameStart)
        {
            if (amountOfActiveGround < 25 && spawning == false)
            {
                StartCoroutine(SpawnGround());
            }
        }
    }
    public void StartGround()
    {
        for(int x =0; x < 15; x++)
        {
            groundPositionZ += 1;
            ground = (GameObject)Instantiate(SaveLoad.Instance.Ground[0].groundObj, SaveLoad.Instance.Ground[0].groundObj.transform.position = new Vector3(groundPositionX, 0, groundPositionZ), Quaternion.identity);
            gameObjSpawned.Add(ground);
            ground.tag = "ground";
            ground.name = "Ground";
            groundDir = 1; 
            if (x == 14)
            {
                ShapeManager.Instance.shapeMoveTowardsPositions.Add(ground.transform.position);
            }
            ActiveGround(1, true);
        }
    }
    private IEnumerator SpawnGround()
    {
        spawning = true;
        for (int x = 0; x < spawnAmount; x++)
        {
            if (groundDir == 0)
            {
                groundPositionZ += 1;
            }
            else if (groundDir == 1)
            {
                groundPositionX += 1;
            }
            ground = (GameObject)Instantiate(SaveLoad.Instance.Ground[0].groundObj, SaveLoad.Instance.Ground[0].groundObj.transform.position = new Vector3(groundPositionX, 0, groundPositionZ), Quaternion.identity);
            gameObjSpawned.Add(ground);
            ground.tag = "ground";
            ground.name = "Ground";
            SpawnCollectible(ground.transform.position);
            if (x == 1 | x == 2 | x == 3)
            {
                SpawnObstacle(ground.transform.position, groundDir);
            }
            ActiveGround(1, true);
            if (x == 4)
            {
                ShapeManager.Instance.shapeMoveTowardsPositions.Add(ground.transform.position);
            }
            yield return new WaitForSeconds(0.02f);
        }
        
        if(groundDir == 0)
        {
            groundDir = 1;
        }
        else if (groundDir == 1)
        {
            groundDir = 0;
        }
        spawning = false;
    }
    private void SpawnObstacle(Vector3 pos, int dir)
    {
        float distance = Vector3.Distance(lastObstacleSpawnPosition[lastObstacleSpawnPosition.Count - 1], new Vector3(pos.x, pos.y + 5.41f, pos.z));
        float y = Random.Range(5.0f, 15.0f);
        if (distance > y)
        {
            int x = inGameObstacleSpawnIndex[Random.Range(0, inGameObstacleSpawnIndex.Count)];
            obstacle = (GameObject)Instantiate(SaveLoad.Instance.Obstacles[x].obstacleObj, SaveLoad.Instance.Obstacles[x].obstacleObj.transform.position = new Vector3(pos.x, pos.y + 5.5f, pos.z), Quaternion.identity);
            gameObjSpawned.Add(obstacle);
            lastObstacleSpawnPosition.Add(new Vector3(pos.x, pos.y + 5.41f, pos.z));
            obstacle.name = " Obstacle" + "[" + x + "]";
            obstacle.tag = SaveLoad.Instance.Obstacles[x].type.ToString();// remove
            GameObjColor.Instance.obstaclecolor(obstacle);
            if (dir == 1)
                {
                    obstacle.gameObject.transform.rotation = Quaternion.Euler(0, 90, 0);
                }
                else if (dir == 0)
                {
                    obstacle.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
                }
        }
    }
    private void SpawnCollectible(Vector3 pos)
    {
        float distance = Vector3.Distance(lastCollectbleSpawnPosition[lastCollectbleSpawnPosition.Count - 1], new Vector3(pos.x, pos.y + 5.5f, pos.z));
        float y = Random.Range(30.0f, 200.0f);
        if (distance > y)
        {
            GameObject collectible = (GameObject)Instantiate(SaveLoad.Instance.Collectables[0].CollectablesObj, SaveLoad.Instance.Collectables[0].CollectablesObj.transform.position = new Vector3(pos.x, pos.y + 5.5f, pos.z), Quaternion.identity);
            gameObjSpawned.Add(collectible);
            collectible.tag = "Collectible";
            collectible.name = "Collectible";
            lastCollectbleSpawnPosition.Add(collectible.transform.position);
        }
    }
    public void  ActiveGround(int x, bool add)
    {
        if(add)
        {
            amountOfActiveGround += x;
        }
        if(!add)
        {
            amountOfActiveGround -= x;
        }
    }
}
