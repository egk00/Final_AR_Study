using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameManager2D : MonoBehaviour {

	[System.Serializable]
	public class cSpawnList
	{
		//1st spawn 
		public GameObject vSpawnObject;
		public List<GameObject> vSpawnList;
	}

	[System.Serializable]
	public class cShape
	{
		//1st spawn 
		public string vForm;
		public Color vColor;
	}

	//public enum eForms {Square, Circle, Triangle, Trapezoid, Star, Hexagone};
	public List<string> vGameForms; 				//keep all the forms 
	public List<cShape> vUsedForms; 				//keep all the forms being used currently (buttons, ennemy)
	public List<cSpawnList> vSpawnList; 			//handle different spawn position + get the number of enemy per line so we try to send new enemy on the line with the lowest count
	public List<GameObject> vButtonsList;			//keep all the buttons
	public int vLevel = 1; 							//keep in mind the level for the player. Higher level has deadly enemies
	public int vNbrButton = 2; 						//start with 2x buttons, then go to 3x then 4x.
	public GameObject vEnemyPrefab; 
	public float vSpawnSpeed = 2f;					//check how many time we summon new ennemy
	public GameObject vPlayer;	
	public GameObject vBeamLight;					//where we will spawn a beam of light of the color of the destroyed shape
	public GameObject vGroupButton;					//used to get the animator on that group button to add NEW ones
	public float vTimeNeededNext = 1f; 				//how much time for the next enemy?
	public Text vScore;
	public int vScoreValue = 0;
	public List<cEnemy> vCurEnemy; 						//current enemy where it can be destroyed
	public GameObject vDebris;
	public GameObject vBeginText;
	public GameObject vAlertText; 
	public GameObject vGameOverText;
	public GameObject vBlackBackground;				//we use this variable to show or hide the black background between each game
	public List<Color> vGameColors;					//configure here all the colors used for Enemies or Balls
	public AudioSource vAudioSource; 				//manage all the sound 
	public AudioSource vAudioSource2; 				//just to make sure we can play 2 sound at once
	public AudioClip vSndStartGame;
	public AudioClip vSndGameOver;
	public AudioClip vSndEnemyDie; 
	public AudioClip vChangingButtonSound;			//make a sound when we are about to change button
	public AudioClip vAddButtonSound; 				//sound when we increas the number of buttons
	public int vEnemyTimer = 6;						//how many enemy we summon to refresh shapes + colors 
	public int vRoundtimer = 2; 					//check how many round we need to pass to get new button
	public bool GameStarted = false;				//handle if the game is running (prevent player to try to attack, move enemy)
	public bool WaitForGameOver = false;

	//private variables
	private float SpawnTimeNext = 0f;
	private Animator vBeamAnimator;
	private Animator vButtonAnimator;
	private int vEnemyCount = 0;
	private int vRound = 0;
	private string vAction = "";					//can contain ChangeRound, JustShuffle 
	private int vRoundCounter = 0;					//count the difficulty of the game 
	private AudioSource vLastSource; 
	private int vNbrSpawnLoc = 0;

    //이전 화면으로 가는 버튼
    public GameObject QuitGUI;

	void Awake()
	{
		//make the game 60fps
		Application.targetFrameRate = 60;
	}

	// Use this for initialization
	void Start () {

		//get the animator to use it further
		if (vBeamLight != null)
			vBeamAnimator = vBeamLight.GetComponent<Animator> ();

		//get the animator to use it further
		if (vGroupButton != null)
			vButtonAnimator = vGroupButton.GetComponent<Animator> ();

		//모든 속성 초기화
		RefreshVariables ();
	}

	void RefreshVariables()
	{
		//refresh score
		vScoreValue = 0;
		vScore.text = "0";
		vEnemyCount = 0;
		vRoundCounter = 0;
		vRound = 0;
		vNbrButton = 2;
		vNbrSpawnLoc = vSpawnList.Count;

		//initialize variables
		vLevel = 1;
		GameStarted = false;
		WaitForGameOver = false;
		SpawnTimeNext = 0f;

		//disable the score text
		vScore.enabled = false;

		//enable the player to shoot
		vPlayer.SetActive(false);

		//show the main menu 
		vBeginText.SetActive (true);

        //시작 버튼 키기
        QuitGUI.SetActive(true);

        //handle the alert text
        vAlertText.SetActive (false);

		//hide game over message
		vGameOverText.SetActive(false);

		//hide 
		vBlackBackground.SetActive (false);

		//reset all spawnlist
		foreach (cSpawnList vSList in vSpawnList)
			vSList.vSpawnList = new List<GameObject> ();

		//reset list of current enemy to be destroyed
		vCurEnemy = new List<cEnemy>();
	}

	void CleanEnemy()
	{
		//destroy all enemy
		foreach (cSpawnList vSpawn in vSpawnList)
			foreach (Transform child in vSpawn.vSpawnObject.transform)
				GameObject.Destroy (child.gameObject);
	}

	//get a random form
	string GetRandomForm()
	{
		string vNewShape = "";

		//get random shape
		vNewShape = vGameForms[Random.Range(0, vGameForms.Count)];

		return vNewShape;
	}

	//get the new shape
	void ShuffleShapes()
	{
		//flush old variable
		vUsedForms = new List<cShape> ();

		for (int i = 0; i < vNbrButton; i++)
		{
			//create temporary shape
			cShape vNewShape = new cShape();
			vNewShape.vColor = GetRandomColor (); //get a random unique color. Canno have same colors
			vNewShape.vForm = GetRandomForm (); //get a random form

			//add it to the list
			vUsedForms.Add(vNewShape);	
		}

		//refresh button with new shape!
		RefreshButton();
	}

	//show the current Shape + colors in the button
	void RefreshButton()
	{
		for (int i = 0; i < vNbrButton; i++)
		{
			//change the border sprite on the button
			vButtonsList [i].transform.Find ("Shape").GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Enemies/" + vUsedForms [i].vForm + "/Border");

			Image vImageInside = vButtonsList [i].transform.Find ("Shape").Find ("Inside").GetComponent<Image> ();
			//change the inside sprite on the button
			vImageInside.sprite = Resources.Load<Sprite> ("Enemies/" + vUsedForms [i].vForm + "/Inside");

			//change the color from inside
			vImageInside.color = vUsedForms[i].vColor;

			//check if the button hasen't been activated yet
			if (!vButtonsList [i].activeSelf)
				vButtonsList [i].SetActive (true);
		}
	}

	public void GameOver (cEnemy vEnemy)
	{
		//need to wait for the gameover animation to finish before clicking
		WaitForGameOver = true;

		//remove other text
		vAlertText.SetActive (false);

		//stop the game
		GameStarted = false;

		//hide game over message
		vGameOverText.SetActive(true);

		//play sound
		PlaySound(vSndGameOver, 1f);

		//make sure dying enemy is above everything else
		vEnemy.vBorder.sortingOrder = 101;
		vEnemy.vInside.sortingOrder = 100;

		//make the target go VERY big 
		vEnemy.GetComponent<Animator> ().SetTrigger("GameOver");

		//hide 
		vBlackBackground.SetActive (false);

		//go back to 2 buttons
		vButtonAnimator.SetBool ("2Buttons", true);

		//hide button
		foreach (GameObject vButton in vButtonsList)
			vButton.SetActive (false);
	}

	public void CleanGame()
	{
		//can now click
		WaitForGameOver = false;

		//hide the text to begin
		vBeginText.SetActive (false);

		//clean all the enemy in this game
		CleanEnemy();

		//clean all the variable
		RefreshVariables ();
	}

	//try to get the matching enemy in the enemylist
	cEnemy GetMatchingEnemy(int vButtonIndex)
	{
		cEnemy vEnemyFound = null;

		//check if it match
		foreach (cEnemy vEnemy in vCurEnemy)
			if (vEnemy.vShape.vColor == vUsedForms [vButtonIndex].vColor && vEnemy.vShape.vForm == vUsedForms [vButtonIndex].vForm)
				vEnemyFound = vEnemy;

		return vEnemyFound;
	}

	//get the right shape to check if it match
	public void ButtonClick(int vButtonIndex)
	{
		//can only destroy enemy when in range
		if (vCurEnemy.Count > 0 && GameStarted) 
		{
			//get current shape of the enemy to compare
			cEnemy vEnemyFound = GetMatchingEnemy(vButtonIndex);

			//make sure color + shape match
			if (vEnemyFound != null) {

				//make the beam the same color 
				vBeamLight.GetComponent<SpriteRenderer> ().color = vEnemyFound.vShape.vColor;

				//show the animation!
				vBeamAnimator.SetTrigger ("LaunchBeam");

				//destroy current enemy in line
				vEnemyFound.GetComponent<Animator>().SetTrigger("Die");

				//remove itself from the spawnlist
				foreach (GameManager2D.cSpawnList vList in vSpawnList)
					if (vList.vSpawnList.Contains (vEnemyFound.gameObject))
						vList.vSpawnList.Remove (vEnemyFound.gameObject);

				//remove itself from the vCurEnemy
				vCurEnemy.Remove(vEnemyFound);

				//enemy die, so increase value
				EnemyDied ();
			}
		}
	}
	
	// Update is called once per frame
	void Update () {

		//check if game started!
		if (GameStarted) 
		{
			//reduce time to check if we spawn a new enemy
			SpawnTimeNext -= Time.deltaTime;
			if (SpawnTimeNext <= 0f  && vAction == "") {
				//reset timer
				SpawnTimeNext = vTimeNeededNext-(vRoundCounter*0.05f);

				//check if we spawn 1 or 2 enemy at once
				//spawna  new enemy
				int vRandomInt = Random.Range (0, 100);
				cEnemy vTempEnemy;

				//check if we have enought enemy to spawn 2x forms. if not only one
				if (GetMaxNbr() - vEnemyCount <= 1)
					vRandomInt = 0;

				if (vRandomInt < 85)
				{
					vTempEnemy = SpawnNewEnemy (-1);	//-1 = random
				}
				else {
					vTempEnemy = SpawnNewEnemy (0);	//1st spawn location
					vTempEnemy = SpawnNewEnemy (1,vTempEnemy);	//2nd spawn location
				}
			}
			else if (vAction != "" && (vSpawnList[0].vSpawnList.Count+vSpawnList[1].vSpawnList.Count) <= 0) //make sure all enemy have been destroyed before shuffling new shapes + colors!
			{
				//check if we change round
				if (vAction == "ChangeRound") {

					//play Upgrade Sound
					PlaySound(vAddButtonSound, 1f);

					//add new button
					vNbrButton++;

					string vvAction = "3Buttons";
					if (vNbrButton == 4)
						vvAction = "4Buttons";

					//enable new button
					vButtonsList [vNbrButton - 1].SetActive (true);

					//make the new animation
					vButtonAnimator.SetTrigger (vvAction);

					//reset round
					vRound = 0;
				}
					
				//shuffle 
				ShuffleShapes ();

				//refresh new button
				RefreshButton ();

				//remove the Action!
				vAction = "";

				//remove the alert
				vAlertText.SetActive (false);
			}
		}
	}

	//return true if we found the color
	bool ColorNotUsed(Color vColor)
	{
		//init variable
		bool vFound = false;

		//check all current used shape in game and check if we had this color already. 
		foreach (cShape vShape in vUsedForms)
			if (vShape.vColor == vColor)
				vFound = true;

		//return value
		return vFound;
	}

	//get a random color from the color list
	public Color GetRandomColor()
	{
		//init variable
		Color vColor = vGameColors[0]; 
		bool vGotColor = false;

		//check here if we got a random color
		while (!vGotColor) {
			vColor = vGameColors [Random.Range (0, vGameColors.Count)];
			if (!ColorNotUsed(vColor))
				vGotColor = true;
		}

		//return the right color
		return vColor;
	}

	cShape GetRandomUsedShape(cEnemy vTempEnemy)
	{
		//intialise variable
		cShape vRandomShape = new cShape ();

		List<cShape> vShapeList = new List<cShape> ();
		if (vTempEnemy != null) {
			//reconstruct the shape we can use
			foreach (cShape vCurShape in vUsedForms)
				if (vTempEnemy.vShape.vColor != vCurShape.vColor || vTempEnemy.vShape.vForm != vCurShape.vForm)
					vShapeList.Add (vCurShape);
		} else
			vShapeList = vUsedForms;

		//get random shape in the list
		vRandomShape = vShapeList[Random.Range (0, vShapeList.Count)];

		//return value
		return vRandomShape;
	}

	//canno thave more than 50 enemy to fight between each round
	int GetMaxNbr()
	{
		int vNbrMax = vEnemyTimer/*+vRoundCounter*/;
		if (vNbrMax >= 50)
			vNbrMax = 50;

		return vNbrMax;
	}

	//check which mod we are and spawn a random enemy in the list on a random line
	cEnemy SpawnNewEnemy(int vIndex, cEnemy vTempEnemy = null)
	{
		//get a random enemy in the current game mod
		GameObject vNewEnemy = Instantiate (vEnemyPrefab);

		//modify the enemy (shape + color)
		cShape vNewShape = new cShape();
		vNewShape = GetRandomUsedShape (vTempEnemy);

		//get it's componnet
		cEnemy vEnemy = vNewEnemy.GetComponent<cEnemy> ();

		//send it's shape to the enemy to be used when we try to destroy it
		vEnemy.vShape = vNewShape;

		//create enemy border
		vEnemy.vBorder.sprite = Resources.Load<Sprite> ("Enemies/" + vNewShape.vForm + "/Border");

		//change the inside sprite on the button
		vEnemy.vInside.sprite = Resources.Load<Sprite> ("Enemies/" + vNewShape.vForm + "/Inside");
		vEnemy.vInside.color = vNewShape.vColor;

		//we randomize all the enemy for all mobs but SIMPLE
		vEnemy.Initialise (this);

		//check if we spawn to a random spawn location
		if (vIndex == -1)
			vIndex = Random.Range (0, vNbrSpawnLoc);

		//spawn it on the correct location
		cSpawnList vRandomSpawn = vSpawnList [vIndex];

		//get a random spawn position now
		vNewEnemy.transform.position = vRandomSpawn.vSpawnObject.transform.position;

		//make this enemy a child of the current line to be able to delete it when game is finish
		vNewEnemy.transform.parent = vRandomSpawn.vSpawnObject.transform;
		vRandomSpawn.vSpawnList.Add (vNewEnemy);

		//increase counter
		vEnemyCount++;

		//mean we are about to change round
		//add some more enemy to fight between each chang of colors so the rounds are longer each time
		//cannot have more than 50 enemy to kills
		if (vEnemyCount >= GetMaxNbr()) {
			vRound++;
			vRoundCounter++;

			//play alert sound!
			PlaySound (vChangingButtonSound, 1f);

			//show alert
			vAlertText.SetActive (true);

			//also check if we need to add new button. Cannot add more than 4x button
			if (vRound >= vRoundtimer && vNbrButton < 4) 
				vAction = "ChangeRound";
			else
				vAction = "JustShuffle";

			//reset counter
			vEnemyCount = 0;
		}

		return vEnemy;
	}

	public void EnemyDied()
	{
		//if the score is disabled, we just enable it and refresh the score to 0
		if (!vScore.enabled) {
			vScore.enabled = true;
			vScore.text = "0";
		}

		//play sound
		PlaySound(vSndEnemyDie, 0.5f);

		//increase the score by 1
		vScoreValue++;

		//change the score
		vScore.text = vScoreValue.ToString();
	}

	public void PlaySound(AudioClip vClip, float vVolume)
	{
		//try to play every sound in the game without any cut
		if (vLastSource != vAudioSource)
			vLastSource = vAudioSource;
		else 
			vLastSource = vAudioSource2;
		
		//play the sound once
		vLastSource.clip = vClip;
		vLastSource.volume = vVolume;
		vLastSource.Play ();
	}

	//function which start the game
	public void StartGame()
	{
		//make sure we waited for the game over animation
		if (!WaitForGameOver) {
			//be sure we don't go back to 2x buttons when we play
			vButtonAnimator.SetBool ("2Buttons", false);

			//play sound
			PlaySound (vSndStartGame, 1f);

			//hide 
			vBlackBackground.SetActive (true);

			//start it already
			ShuffleShapes ();

			//hide the text to begin
			vBeginText.SetActive (false);

			//enable the player to shoot
			vPlayer.SetActive (true);

			//let's play!
			GameStarted = true;

            //게임 종료 버튼 끄기
            QuitGUI.SetActive(false);
		}
	}

    public void QuitGame()
    {
        SceneManager.LoadScene("MainScene");
    }
}
