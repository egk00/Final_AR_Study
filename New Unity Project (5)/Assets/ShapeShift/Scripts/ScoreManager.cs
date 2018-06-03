using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public int bestScore, score, collectible;
    private void Awake()
    {
        Instance = this;// Create An Instance of "this" script
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Collectible")
        {
            AddCollectible(Random.Range(1, 3));// calls add collectibe and passes random collectible amount "1" or "2"
            Destroy(other.gameObject);//animate
            SoundManager.Instance.PlaySound(SoundManager.Instance.collectible);
        }
        if (other.tag == ShapeManager.Instance.activeShape.tag)
        {
            AddScore(1); //calls add score and passes score amount "1"
            //print("Shape Name: " + other.tag);
            SoundManager.Instance.PlaySound(SoundManager.Instance.hitshape);
        }
        else if (other.tag != ShapeManager.Instance.activeShape.tag && other.tag != "Collectible")
        {

            SoundManager.Instance.PlaySound(SoundManager.Instance.gameover);
            ShapeShiftGameManager.Instance.GameOver();
        }
    }
   public void AddScore(int amount)
    {
        score = score + amount;
        GUIManager.Instance.UpdateScore(score);
        NewHighScoreCheck();
    }
    private void AddCollectible(int amount)
    {
        collectible = collectible + amount;
        GUIManager.Instance.UpdateCollectible(collectible);
       
    }
    public void NewHighScoreCheck()
    {
        if (score > bestScore)
        {
            bestScore = score;
            GUIManager.Instance.UpdateBestScore(bestScore);
        }
    }
    public void gameoverscore()
    {
        GUIManager.Instance.newRecord.gameObject.SetActive(false);
        if (GUIManager.Instance.gameOverScore.gameObject.activeInHierarchy == false)
        {
            GUIManager.Instance.gameOverScore.gameObject.SetActive(true);
        }
        if (score >= bestScore)
        {
            GUIManager.Instance.newRecord.gameObject.SetActive(true);
        }
        GUIManager.Instance.UpdateGameOverScore(score);
    }
}
