using UnityEngine;
using System.Collections;

public class onion : MonoBehaviour {
	
	public GameObject explosion;
	public int lives = 3;
	Vector3 spawnpos;
	public GameObject TM;
	
	public float movement = 0;
	Vector3 last_pos = Vector3.zero;
	
	// Use this for initialization
	void Start () {
		spawnpos = transform.position;
		last_pos = spawnpos;
	
	}
	
	// Update is called once per frame
	void Update () {
		if(lives < 0){
			TM.GetComponent<touchscript>().RecordScores();
			Destroy(gameObject);
		}
		
		movement -= Time.deltaTime;
		movement += Mathf.Abs(last_pos.magnitude - transform.position.magnitude);
		//Debug.Log(last_pos.sqrMagnitude - transform.position.sqrMagnitude);
		last_pos = transform.position;
		if(movement > 20)
			movement = 20;
		
		
		if(movement  < 0){
			transform.localScale = transform.localScale*1.5f;
			movement = 5;
			Debug.Log("EXPLOSSSSION!!!!!");
		}
			
	
	}
	
	IEnumerator spawntimer(){
		Debug.Log("spawning... lives " + lives);
		lives--;
		yield return new WaitForSeconds(2f);
		transform.position = spawnpos;
		
	}
	
	
	
	void OnTriggerEnter(Collider other){
		if(other.name.Contains("flower")){
			//spawn the explosion
			GameObject go = Instantiate(explosion, transform.position, transform.rotation) as GameObject;
			go.active = true;
			go.transform.parent = transform.parent;
			//get rid of onion for a little while
			transform.position = new Vector3(100, 100, -100);
			StartCoroutine(spawntimer());
			rigidbody.velocity = Vector3.zero;
		}
		
	}
}
