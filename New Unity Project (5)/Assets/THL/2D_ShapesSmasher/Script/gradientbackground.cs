using UnityEngine;
using System.Collections;

public class gradientbackground : MonoBehaviour {

	SpriteRenderer vRenderer;
	float vcptscale = 0f;
	float vadd = 0.001f;

	// Use this for initialization
	void Start () {
		vRenderer = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		//change the scale
		vcptscale += vadd;

		//get back to start
		if (vcptscale >= 1f)
			vcptscale = 0f;

		vRenderer.material.mainTextureOffset = new Vector2 (vcptscale, 0f);
	}
}
