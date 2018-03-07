using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {
	public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		var h = Input.GetAxis ("Horizontal");
		var v = Input.GetAxis ("Vertical");
		transform.Translate (h *speed *Time.deltaTime, 0, v * speed * Time.deltaTime);
	}
}
