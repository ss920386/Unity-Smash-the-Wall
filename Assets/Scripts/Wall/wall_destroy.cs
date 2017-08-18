using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class wall_destroy : MonoBehaviour {
	// Use this for initialization
	public GameObject wall_frac;
	public GameObject healthCanvas;
	public Image healthBar;
	
	public Color green;
	public Color orange;
	public Color red;
	private float color_cal = 0f;
	
	private float health = 1f;
	private int hit_cnt=0;
	
	void Start () {
		healthCanvas.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		float bar_hp = healthBar.fillAmount;
		AdjustHealthBar(bar_hp);
	}
	
	void AdjustHealthBar(float bar_hp)
	{
		//Debug.Log(bar_hp);
		if(bar_hp>health){
			healthBar.fillAmount-=0.01f;
			if(bar_hp<0.75f && bar_hp>=0.5f){
				color_cal = 3f - 4f*bar_hp;		//calaulated by linear equation
				Debug.Log(color_cal);
				healthBar.color = Color.Lerp(green, orange, color_cal);		//color_cal=0 return green, =1 return orange
				
			}
			
			else if(bar_hp<0.5f && bar_hp>=0.25f){
				color_cal = 2f - 4f*bar_hp;		//calaulated by linear equation
				Debug.Log(color_cal);
				healthBar.color = Color.Lerp(orange, red, color_cal);		//color_cal=0 return green, =1 return orange
				
			}
		}
		
		if(bar_hp==0f)
			healthCanvas.SetActive(false);
	}
	
	void OnCollisionEnter (Collision col)
    {	
		Debug.Log(hit_cnt);
		switch(hit_cnt){
			case 0:
				healthCanvas.SetActive(true);
				if(col.gameObject.name=="ball"){
					GetComponent<Renderer>().enabled = false;	//Outer wall invisible
					int children = wall_frac.transform.childCount;	//Get the number of all wall fracture
					for(int i=0;i<children;i++){
						Transform child = wall_frac.transform.GetChild(i);	//Get wall fracture game object
						child.GetComponent<Rigidbody>().Sleep();		//Deactivate wall frac rb and collision
						child.GetComponent<Collider>().enabled=false;
					}
					wall_frac.SetActive(true);	//wall frac visible		
					health -=  0.25f;
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
					health -=  0.25f;
					hit_cnt++;
					GetComponent<Collider>().isTrigger = true;
				}
				break;
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
			health -=  0.25f;
			//Destroy(this.gameObject);
			GetComponent<Collider>().enabled = false;
			
		}
		else if(col.gameObject.name=="ball" && hit_cnt == 3){
			int children = wall_frac.transform.childCount;					
			for(int i=0;i<children;i++){
				Transform child = wall_frac.transform.GetChild(i);	
				//child.GetComponent<Rigidbody>().drag = 20;	
			}
			health -=  0.25f;
			hit_cnt++;			
		}
		else{
			hit_cnt++;
		}
	}
}
