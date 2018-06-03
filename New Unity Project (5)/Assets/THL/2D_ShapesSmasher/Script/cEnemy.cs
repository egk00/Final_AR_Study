using UnityEngine;
using System.Collections;

public class cEnemy : MonoBehaviour {
	
	public float vSpeed = 1f;
	public SpriteRenderer vBorder; 
	public SpriteRenderer vInside;
	public Color vColor;

	public bool vCanMove = true;

	public GameManager2D.cShape vShape;

	private Rigidbody2D vRigidBody;
	private BoxCollider2D vCollider;
	private GameManager2D vGameManager;

	// Use this for initialization
	void Start () {
		vCanMove = true;
		vRigidBody = GetComponent<Rigidbody2D>();
		vCollider = GetComponent<BoxCollider2D>();

		if (vRigidBody != null)
			vRigidBody.velocity = new Vector2 (-vSpeed, 0f);
	}
	
	// Update is called once per frame
	void Update () {
		if (vGameManager != null)
			if (!vGameManager.GameStarted)
				EnemyStop ();

		/*if (vCanMove) {
			transform.position = new Vector3 (
				transform.position.x + (-vSpeed * Time.deltaTime),
				transform.position.y,
				transform.position.z
			);
		}*/
	}

	public void GameFinish()
	{
		vGameManager.CleanGame ();
	}

	public void EnemyStop()
	{
		if (vRigidBody != null)
			vRigidBody.velocity = new Vector2 (0f, 0f);
		//vCanMove = false;
	}

	//kill this enemy
	public void Die()
	{
		//create multiple debris when dying
		for (int i = 0; i <= 4; i++)
		{
			GameObject vNewDebris =	Instantiate (vGameManager.vDebris); //create the debris
			vNewDebris.transform.position = transform.position; 		//create debris on this shape

			//change debris color like this one
			vNewDebris.transform.Find("Inside").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite> ("Enemies/" + vShape.vForm + "/Inside");
			vNewDebris.transform.Find ("Inside").GetComponent<SpriteRenderer> ().color = vShape.vColor;
			vNewDebris.transform.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite> ("Enemies/" + vShape.vForm + "/Border");
		}

		//destroy itself
		GameObject.Destroy (this.gameObject);
	}

	//initialise this enemy correctly 
	public void Initialise(GameManager2D vvGameManager)
	{
		//get the gamemanager
		vGameManager = vvGameManager;

		//add a little factor to be the fastest
		vSpeed += vGameManager.vScoreValue * 0.05f;

		//make sure we got a rigidbody attached for moving it.
		//ONLY the main enemy can move forward. all other pieces doesn't move and make a armor around the enemy
		if (vRigidBody != null)
			vRigidBody.velocity = new Vector2 (-vSpeed, 0f);
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		// If a enemy touch the front line, add this enemy to the gamemanager main list so we can compare shape with it
		if (col.tag == "FrontLine") 
		{
			if (vGameManager == null)
				vGameManager = GameObject.Find ("GameManager2D").GetComponent<GameManager2D>();

			//make this enemy the destroyable
			vGameManager.vCurEnemy.Add(this);
		}

		// If a enemy touch the border, it's game over
		if (col.tag == "Border") 
		{
			if (vGameManager == null)
				vGameManager = GameObject.Find ("GameManager2D").GetComponent<GameManager2D>();

			//game over
			vGameManager.GameOver (this);
		}
	}
}
