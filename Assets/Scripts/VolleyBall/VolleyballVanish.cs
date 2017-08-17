using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolleyballVanish : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	IEnumerator Vanish()
    {
        yield return new WaitForSeconds(1);
		Destroy(this.gameObject);
		//GameObject VolleyballController = GameObject.Find("VolleyBallController");
        //volleyballControl volleyballControlScript = VolleyballController.GetComponent<volleyballControl>();
        //volleyballControlScript.hit = false;
    }
	
	void OnCollisionEnter (Collision col)
    {
		//Debug.Log(col.gameObject.name);
		StartCoroutine(Vanish());
		
    }
}
