using UnityEngine;
using System.Collections;

public class little_flower : MonoBehaviour {

	public float timer = 0f;
	public int points = 0;
	public bool is_top;
	Vector3 original_size;
	
	// Use this for initialization
	void Start () {
		original_size = transform.localScale;
		transform.localRotation = Quaternion.identity;
	}
	
	// Update is called once per frame
	void Update () {
		timer+= Time.deltaTime;
		
		if(timer < 1f){
			points = 1;
			
		}
		else if(timer < 2f){
			points = 2;
			if(transform.localScale != original_size*1.1f)
				transform.localScale = original_size*1.1f;
		}
	
	}

}
