using UnityEngine;
using System.Collections;

public class JustRotate : MonoBehaviour {

	private Vector3 vRotateDirection;
	private float vLastTime = 0f;
	private float vcurTime = 0f;
	public GameManager2D vGameManager;

	// Use this for initialization
	void Start () {
			//initialize variable
			float vVelocityX = (float)Random.Range(1, 5); //random direction
			float vVelocityY = (float)Random.Range(3, 12); //random height

			int randomIndex = Random.Range(0, 2);
			if (randomIndex == 0)
				vRotateDirection = Vector3.forward;
			else {
				vVelocityX *= -1; //goes on the other direction
				vRotateDirection = Vector3.forward * -1;
			}

			//make the debris a push in air
			Rigidbody2D vRigidBody = gameObject.GetComponent<Rigidbody2D> ();
			vRigidBody.AddForce (new Vector2 (vVelocityX, vVelocityY)); 
	}
	
	// Update is called once per frame
	void Update () {

		//update time
		vcurTime += Time.deltaTime;

		if (vcurTime != vLastTime) {
			vLastTime = vcurTime;
			transform.Rotate (vRotateDirection);
		}
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		//destroy itself when falling 
		if (col.tag == "Border") 
			GameObject.Destroy (this.gameObject);
	}
}
