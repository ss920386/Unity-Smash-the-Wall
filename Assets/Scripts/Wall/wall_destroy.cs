using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall_destroy : MonoBehaviour {
	// Use this for initialization
	public GameObject wall_frac;
	private int hit_cnt=0;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnCollisionEnter (Collision col)
    {	
		Debug.Log(hit_cnt);
		switch(hit_cnt){
			case 0:			
				if(col.gameObject.name=="ball"){
					GetComponent<Renderer>().enabled = false;	//Outer wall invisible
					int children = wall_frac.transform.childCount;	//Get the number of all wall fracture
					for(int i=0;i<children;i++){
						Transform child = wall_frac.transform.GetChild(i);	//Get wall fracture game object
						child.GetComponent<Rigidbody>().Sleep();		//Deactivate wall frac rb and collision
						child.GetComponent<Collider>().enabled=false;
					}
					wall_frac.SetActive(true);	//wall frac visible					
					hit_cnt++;
				}
				break;
				
			case 1:			
				if(col.gameObject.name=="ball"){
					int children = wall_frac.transform.childCount;
					for(int i=0;i<children;i++){
						Transform child = wall_frac.transform.GetChild(i);	
						child.GetComponent<Rigidbody>().drag = 50;	
						child.GetComponent<Collider>().enabled=true;							
					}
					hit_cnt++;
					GetComponent<Collider>().isTrigger = true;
				}
				break;
				
			// case 2:
				// if(col.gameObject.name=="ball"){
					// int children = wall_frac.transform.childCount;					
					// for(int i=0;i<children;i++){
						// Transform child = wall_frac.transform.GetChild(i);	
						// child.GetComponent<Rigidbody>().drag = 20;	
					// }
					// hit_cnt++;
				// }
				// break;
			// case 3:
				// if(col.gameObject.name=="ball"){
					
					// int children = wall_frac.transform.childCount;					
					// for(int i=0;i<children;i++){
						// Transform child = wall_frac.transform.GetChild(i);	
						// Physics.IgnoreCollision(child.GetComponent<Collider>(), GetComponent<Collider>(),false);	//Or wall explode with fractures			
					// }
					// hit_cnt++;
				// }
				// break;
			default:
				break;
		}
		
		
		
		
		
    }
	
	void OnTriggerEnter(Collider col)
	{
		Debug.Log(col.name);
		if(col.gameObject.name=="ball" && hit_cnt == 4){
			int children = wall_frac.transform.childCount;					
			for(int i=0;i<children;i++){	
				Transform child = wall_frac.transform.GetChild(i);	
				child.GetComponent<Rigidbody>().drag = 0;
				child.GetComponent<Rigidbody>().useGravity = true;				
				child.GetComponent<Rigidbody>().WakeUp();
					
			}
			
			Destroy(this);
			
		}
		else if(col.gameObject.name=="ball" && hit_cnt == 3){
			int children = wall_frac.transform.childCount;					
			for(int i=0;i<children;i++){
				Transform child = wall_frac.transform.GetChild(i);	
				//child.GetComponent<Rigidbody>().drag = 20;	
			}
			hit_cnt++;			
		}
		else{
			hit_cnt++;
		}
	}
}
