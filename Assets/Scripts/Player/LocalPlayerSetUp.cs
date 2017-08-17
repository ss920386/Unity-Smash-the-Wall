using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityStandardAssets.Characters.FirstPerson;

public class LocalPlayerSetUp : NetworkBehaviour {
	
	private RigidbodyFirstPersonController fpsController;
	private characterController chaController;
	private Camera playerCamera;
	private AudioListener playerAudioListener;
	
	// Use this for initialization
	void Start () {
		if(isLocalPlayer)
		{
			gameObject.name = "ME";
		}
		
		
		if(!isLocalPlayer)
		{
			fpsController = GetComponent<RigidbodyFirstPersonController>();
			chaController = GetComponent<characterController>();
			playerCamera = transform.FindChild("Camera").GetComponent<Camera>();
			playerAudioListener = transform.FindChild("Camera").GetComponent<AudioListener>();
			
			if(chaController)
			{
				chaController.enabled = false;
			}
			
			if(fpsController)
			{
				fpsController.enabled = false;
			}
			
			if(playerCamera)
			{
				playerCamera.enabled = false;
			}
			
			if(playerAudioListener)
			{
				playerAudioListener.enabled = false;
			}
			
		}		
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
