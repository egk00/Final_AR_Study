using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeShiftGameManager : MonoBehaviour 
{
    public static ShapeShiftGameManager Instance;
    public int soundindex;
    public bool GameStart = false;// this bool will determine if we are inngame or not and also control some update functions
    private void Awake()
    {
        Instance = this;// Create An Instance of "this" script
    }
    public void StartButtonPressed()
    {
        StartCoroutine(startButtonPressed());
    }
    public IEnumerator startButtonPressed()
    {
        //InfiniteGameObjManager.Instance.StartGround();// load to start ground before zig zag starts
        //ShapeManager.Instance.RandomInGameShapes(0);// get some random shapes
        //StartingShape();// get the start shape 
        //GameObjColor.Instance.setshapecolor();
        //ScoreManager.Instance.score = 0;// set score to 0 on start
        //ScoreManager.Instance.AddScore(0);// set score to 0 on start
        //InfiniteGameObjManager.Instance.lastCollectbleSpawnPosition.Add(new Vector3(0, 0, 0));
        //InfiniteGameObjManager.Instance.lastObstacleSpawnPosition.Add(new Vector3(0, 0, 0));
        //GUIManager.Instance.mainPanel.SetActive(false);//Animate
        //GUIManager.Instance.inGamePanel.SetActive(true);//Animate
        //yield return new WaitForSeconds(0.80f);// this line is here mostly to compensate for animations
        //GameStart = true;

   
        ShapeManager.Instance.RandomInGameShapes(0);// get some random shapes
        StartingShape();// get the start shape 
        GameObjColor.Instance.setshapecolor();
        ScoreManager.Instance.score = 0;// set score to 0 on start
        ScoreManager.Instance.AddScore(0);// set score to 0 on start
        InfiniteGameObjManager.Instance.lastCollectbleSpawnPosition.Add(new Vector3(0, 0, 0));
        InfiniteGameObjManager.Instance.lastObstacleSpawnPosition.Add(new Vector3(0, 0, 0));
        InfiniteGameObjManager.Instance.StartGround();// load to start ground before zig zag starts
        yield return new WaitForSeconds(0.70f);// this line is here mostly to compensate for animations
        GUIManager.Instance.mainPanel.SetActive(false);//Animate
        GUIManager.Instance.inGamePanel.SetActive(true);//Animate
        yield return new WaitForSeconds(0.10f);
        GameStart = true;
    }
    public void GameOver()
    {
        StartCoroutine(gameover());
    }
    public IEnumerator gameover()
    { 
        GameStart = false;
        SaveLoad.Instance.Save();
        yield return new WaitForSeconds(0.26f);// this line is here mostly to compensate for animations and to ensure the "spawnground" method  is finshed spawning.
        ScoreManager.Instance.gameoverscore();
        GUIManager.Instance.mainPanel.SetActive(true);//Animate
        GUIManager.Instance.inGamePanel.SetActive(false);//Animate
        if (InfiniteGameObjManager.Instance.startingBlock == null)// if no starting block; spawn one
        {
            GameObject startingblock = (GameObject)Instantiate(Resources.Load<GameObject>("Prefabs/Ground/Ground"));// spawn the starting block that was destroyed
            InfiniteGameObjManager.Instance.startingBlock = startingblock;
            InfiniteGameObjManager.Instance.startingBlock.transform.position = new Vector3(0, 0, 0);
            InfiniteGameObjManager.Instance.startingBlock.SetActive(true);//animate
        }
        for(int x = 0; x < InfiniteGameObjManager.Instance.gameObjSpawned.Count; x++)
        {
            Destroy(InfiniteGameObjManager.Instance.gameObjSpawned[x]);// destroy all game object spwned that has not been destryed yet
        }
        for(int x = 0; x< SaveLoad.Instance.shapes.Count;x++)
        {
            SaveLoad.Instance.shapes[x].beingUsed = false;// reset shape being used
        }
        for (int x = 0; x < SaveLoad.Instance.shapes.Count; x++)
        {
            SaveLoad.Instance.shapes[x].beingUsed = false;
            SaveLoad.Instance.Obstacles[x].beingUsed = false;
            GUIManager.Instance.inGameShapeSelectButton[x].gameObject.SetActive(false);
            SaveLoad.Instance.shapes[x].ShapeObj.SetActive(false);
        }
        ShapeManager.Instance.ResetShapeRotation();
        ShapeManager.Instance.y = 0;
        ShapeManager.Instance.shapeMoveTowardsPositionIndex = 0;
        ShapeManager.Instance.transform.position = new Vector3(0, 5.5f, 0);
        ShapeManager.Instance.activeShape.gameObject.SetActive(false);
        ShapeManager.Instance.shapeMoveTowardsPositions.Clear();

        InfiniteGameObjManager.Instance.lastCollectbleSpawnPosition.Clear();
        InfiniteGameObjManager.Instance.lastObstacleSpawnPosition.Clear();
        InfiniteGameObjManager.Instance.amountOfActiveGround = 0;
        InfiniteGameObjManager.Instance.groundDir = 0;
        InfiniteGameObjManager.Instance.spawning = false;
        InfiniteGameObjManager.Instance.gameObjSpawned.Clear();
        InfiniteGameObjManager.Instance.groundPositionX = 0;
        InfiniteGameObjManager.Instance.groundPositionZ = 0;
        InfiniteGameObjManager.Instance.inGameObstacleSpawnIndex.Clear();
      
        GUIManager.Instance.y = 0;
        ShapeManager.Instance.shapeindex = 0;

        CameraController.Instance.CameraDefaultPosition();
    }
    private void StartingShape()
    {
        SaveLoad.Instance.shapes[InfiniteGameObjManager.Instance.inGameObstacleSpawnIndex[0]].ShapeObj.SetActive(true);// set the first shape active when game starts
        ShapeManager.Instance.activeShape = SaveLoad.Instance.shapes[InfiniteGameObjManager.Instance.inGameObstacleSpawnIndex[0]].ShapeObj;
    }
    public void Soundtoggle(int x)
    {
        if (x == 1)
        {
            SoundManager.Instance.audioSource.mute = true;
            GUIManager.Instance.soundoff.gameObject.SetActive(true);
            GUIManager.Instance.soundon.gameObject.SetActive(false);
            soundindex = 0;
        }
        else if (x == 0)
        {
            SoundManager.Instance.audioSource.mute = false;
            GUIManager.Instance.soundoff.gameObject.SetActive(false);
            GUIManager.Instance.soundon.gameObject.SetActive(true);
            soundindex = 1;
        }
        SaveLoad.Instance.Save();

    }
    public void SoundtoggleOnLoad(int x)
    {
        if(x == 1)
        {
            SoundManager.Instance.audioSource.mute = false;
            GUIManager.Instance.soundoff.gameObject.SetActive(false);
            GUIManager.Instance.soundon.gameObject.SetActive(true);
        }
        else
        {
            SoundManager.Instance.audioSource.mute = true;
            GUIManager.Instance.soundoff.gameObject.SetActive(true);
            GUIManager.Instance.soundon.gameObject.SetActive(false);
        }
    }


}
