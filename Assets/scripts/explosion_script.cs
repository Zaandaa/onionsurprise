using UnityEngine;
using System.Collections;

public class explosion_script : MonoBehaviour {
	
	float timer = 0f;
	
	float lifespan = 3.0f;
	
	// Use this for initialization
	void Start () {
		Debug.Log("Spawned explosion");
	
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		
		if(timer > lifespan)
			Destroy(gameObject);
	
	}
	
	void OnTriggerEnter(Collider other){
		if(other.gameObject.name.Contains("flower")){
			Destroy(other.gameObject);
			Debug.Log("destroying flower");	
		}
		
		
	}
}
