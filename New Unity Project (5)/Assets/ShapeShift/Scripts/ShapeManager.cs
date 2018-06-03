using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeManager : MonoBehaviour
{
    public static ShapeManager Instance;
    public List<Vector3> shapeMoveTowardsPositions = new List<Vector3>();
    public int shapeMoveTowardsPositionIndex;
    private const int amountOfShapesInGameInstance = 3;
    private bool increment = true;
    public GameObject activeShape;
    public int shapeindex, j;
    public  int y = 0;
   
    private void Awake()
    {
        Instance = this;
    }
    private void LateUpdate()
    {
        if (ShapeShiftGameManager.Instance.GameStart && shapeMoveTowardsPositions.Count != 0)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(shapeMoveTowardsPositions[shapeMoveTowardsPositionIndex].x, shapeMoveTowardsPositions[shapeMoveTowardsPositionIndex].y + 5.5f, shapeMoveTowardsPositions[shapeMoveTowardsPositionIndex].z), 6f * Time.deltaTime);
            float distance = Vector3.Distance(this.transform.position, shapeMoveTowardsPositions[shapeMoveTowardsPositionIndex]);
            if (distance <= 5.5f && increment)
            {
                shapeMoveTowardsPositionIndex++;
                StartCoroutine(IncrementControl());
            }
        }
    }
    public void RandomInGameShapes(int AmountOfShapesInUse)
    {
        for(int x = 0; x < SaveLoad.Instance.shapes.Count; x++)
        {
            if(SaveLoad.Instance.shapes[x].beingUsed == true)
            {
                AmountOfShapesInUse++;
            }
        }
        if(AmountOfShapesInUse < amountOfShapesInGameInstance)
        {
            int x = Random.Range(0, SaveLoad.Instance.shapes.Count);
            if(SaveLoad.Instance.shapes[x].beingUsed == false)
            {
                SaveLoad.Instance.shapes[x].beingUsed = true;
                SaveLoad.Instance.Obstacles[x].beingUsed = true;
                InfiniteGameObjManager.Instance.inGameObstacleSpawnIndex.Add(x);
            }
            RandomInGameShapes(0);
        }
        if (AmountOfShapesInUse == amountOfShapesInGameInstance)
        {
            GUIManager.Instance.InGameButtonAlignment();
        }
    }
    public IEnumerator IncrementControl()
    {
        ShapeRotation();//change rotation on every turn
        increment = false;
        yield return new WaitForSeconds(0.2f);
        increment = true;
    }
    public void ShapeRotation()
    {
        for (int x = 0; x < SaveLoad.Instance.shapes.Count; x++)
        {
            if (SaveLoad.Instance.shapes[x].beingUsed == true)
            {
                if (y == 0)
                {
                    SaveLoad.Instance.shapes[x].ShapeObj.transform.rotation = Quaternion.Euler(0, 90, 0);
                }
                if (y == 1)
                {
                    SaveLoad.Instance.shapes[x].ShapeObj.transform.rotation = Quaternion.Euler(0, 0, 0);

                }
            }
        }
        if (y == 0)
        {
            y = 1;
        }
        else if (y == 1)
        {
            y = 0;
        }
    }
    //public void changeshape()
    //{
    //    StartCoroutine(cliked());
    //}
    //private IEnumerator cliked()
    public void changeshape()
    {
        for (int x = 0; x < SaveLoad.Instance.shapes.Count; x++)
        {
            SaveLoad.Instance.shapes[x].ShapeObj.SetActive(false);
        }
        if (shapeindex >= InfiniteGameObjManager.Instance.inGameObstacleSpawnIndex.Count)
        {
            shapeindex = 0;
        }
        j = InfiniteGameObjManager.Instance.inGameObstacleSpawnIndex[shapeindex++];
        ShapeManager.Instance.activeShape = SaveLoad.Instance.shapes[j].ShapeObj;
        SaveLoad.Instance.shapes[j].ShapeObj.SetActive(true);
        //yield return null;
    }
    public void ResetShapeRotation()
    {
        for (int x = 0; x < SaveLoad.Instance.shapes.Count; x++)
        {
            SaveLoad.Instance.shapes[x].ShapeObj.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
   }
}
