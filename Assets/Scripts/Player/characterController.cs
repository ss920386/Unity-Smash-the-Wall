using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour {
	
	public float speed = 5.0f;
	
	// Use this for initialization
	void Start () {
		/*When Locked, the cursor is placed in the center of the view and cannot be moved. 
		  The cursor is invisible in this state, regardless of the value of Cursor.visible.*/
		Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () {
		float translation = Input.GetAxisRaw("Vertical")*speed;
		float straffe = Input.GetAxisRaw("Horizontal")*speed;
		translation *= Time.deltaTime;
		straffe *= Time.deltaTime;
		transform.Translate(straffe,0,translation);
		
		if(Input.GetKeyDown("escape"))
		{
			Cursor.lockState = CursorLockMode.None;
		}
	}
}
