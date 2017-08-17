using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class volleyballAttack : MonoBehaviour {

	public int throw_force = 60;
	public int attack_force = 150;
	//public GameObject Volleyball;
	//public Rigidbody ball_rb;
	private Transform ball_tag;
	private Transform hit_tag;
	public Transform volleyBallPrefab;
	private bool hit = false;
		 
	private GameObject ball = null;
	private bool rotate_control = true;
	private Vector3 rotate_angle = new Vector3(0, 0, 0);
		
	
	// Use this for initialization
	void Start () {
		ball_tag = transform.FindChild("ball_tag");
		hit_tag = transform.FindChild("hit_tag");		
	}
	
	// Update is called once per frame
	void Update () {
		if(!ball && Input.GetMouseButtonDown(1))
		{
			ball = Instantiate(Resources.Load("volleyBall")) as GameObject;
			
			ball.name="ball";
			ball.transform.position = ball_tag.transform.position;
			ball.transform.rotation = ball_tag.transform.rotation;
			//Vector3 dest = ball_tag.transform.position;
			//ball.transform.position = dest;
			//ball_rb.velocity = Vector3.zero;
			//ball_rb.angularVelocity = Vector3.zero;
			ball.GetComponent<Rigidbody>().AddForce(Vector3.up.normalized * throw_force, ForceMode.Impulse);
			
			
		}
		
		if(ball && Input.GetMouseButtonDown(0))
		{
			//hit = true;		
			Vector3 dir = ball.transform.position - hit_tag.transform.position;
			dir.y*=(-1);
			//Debug.Log("DIR:"+dir);
			ball.GetComponent<Rigidbody>().AddForce(dir.normalized * attack_force, ForceMode.Impulse);
			rotate_control=false;
		}
		
	}
	
	
	
}
