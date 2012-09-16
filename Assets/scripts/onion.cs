using UnityEngine;
using System.Collections;

public class onion : MonoBehaviour {
	
	public GameObject explosion;
	public int lives = 3;
	Vector3 spawnpos;
	public GameObject TM;
	
	
	// Use this for initialization
	void Start () {
		spawnpos = transform.position;
	
	}
	
	// Update is called once per frame
	void Update () {
		if(lives < 0){
			TM.GetComponent<touchscript>().RecordScores();
			Destroy(gameObject);
			
			
		}
			
	
	}
	
	IEnumerator spawntimer(){
		lives--;
		yield return new WaitForSeconds(2f);
		transform.position = spawnpos;
		
	}
	
	
	
	void OnTriggerEnter(Collider other){
		if(other.name.Contains("flower")){
			//spawn the explosion
			Instantiate(explosion, transform.position, transform.rotation);
			//get rid of onion for a little while
			transform.position = new Vector3(100, 100, -100);
			StartCoroutine(spawntimer());
			rigidbody.velocity = Vector3.zero;
		}
		
	}
}
