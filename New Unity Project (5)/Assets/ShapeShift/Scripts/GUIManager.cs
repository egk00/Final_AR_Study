using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour
{
    public static GUIManager Instance;
    public GameObject mainPanel, inGamePanel;
    public Button soundon, soundoff;
    public List<Rect> inGameShapeSelectButtonPos = new List<Rect>();
    public List<Image> inGameShapeSelectButton = new List<Image>();
    public Text inGameScore, bestScore, collectible, gameOverScore, newRecord;
    public int y = 0;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        inGameShapeSelectButtonPos.Add(new Rect(-150, 280, 30,30));
        inGameShapeSelectButtonPos.Add(new Rect(-115, 280, 30,30));
        inGameShapeSelectButtonPos.Add(new Rect(-80, 280, 30,30));
        inGameShapeSelectButtonPos.Add(new Rect(-45, 280, 30,30));
       
    }
    //preview of  shapes in a game instance. located @ the top  left of the screen
    public void InGameButtonAlignment()
    {
        for (int x = 0; x < InfiniteGameObjManager.Instance.inGameObstacleSpawnIndex.Count; x++)
        {
            inGameShapeSelectButton[InfiniteGameObjManager.Instance.inGameObstacleSpawnIndex[x]].transform.localPosition = inGameShapeSelectButtonPos[x].position;
            inGameShapeSelectButton[InfiniteGameObjManager.Instance.inGameObstacleSpawnIndex[x]].rectTransform.sizeDelta = new Vector2(inGameShapeSelectButtonPos[x].width, inGameShapeSelectButtonPos[x].height);
            GUIManager.Instance.inGameShapeSelectButton[InfiniteGameObjManager.Instance.inGameObstacleSpawnIndex[x]].gameObject.SetActive(true);
        }
    }
 
    //Update UI text
    public void UpdateScore(int amount)
    {
        inGameScore.text = amount.ToString();
    }
    public void UpdateCollectible(int amount)
    {
        collectible.text = amount.ToString();
    }
    public void UpdateBestScore(int amount)
    {
        bestScore.text = amount.ToString();
    }
    public void UpdateGameOverScore(int amount)
    {
        gameOverScore.text = amount.ToString();
    }
    //toggle game sound
    public void Soundtoggle(int x)
    {
        if(x==1)
        {
            soundoff.gameObject.SetActive(true);
            soundon.gameObject.SetActive(false);
        }
        else if (x==0)
        {
            soundoff.gameObject.SetActive(false);
            soundon.gameObject.SetActive(true);
        }

    }

}