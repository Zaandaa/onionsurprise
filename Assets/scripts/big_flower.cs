using UnityEngine;
using System.Collections;

public class big_flower : MonoBehaviour {
	
	public float timer = 0f;
	public int points = 0;
	public bool is_top;
	Vector3 original_size;
	
	
	
	// Use this for initialization
	void Start () {
		original_size = transform.localScale;
		transform.localRotation = Quaternion.identity; // I don't understand...
		
		if(is_top)
			transform.Rotate(0, 90, 0);
		else
			transform.Rotate(0, -90, 0);

	}
	
	// Update is called once per frame
	void Update () {
		timer+= Time.deltaTime;
		
		if(timer < 1f)
			points = 0;
		else if(timer < 3f){
			points = 1;
			if(transform.localScale != original_size*1.1f)
				transform.localScale = original_size*1.1f;
		}
		else if(timer < 6f){
			points = 3;
			if(transform.localScale != original_size*1.3f)
				transform.localScale = original_size*1.3f;
			
		}
		else{
			points = 6;
			if(transform.localScale != original_size*1.5f)
				transform.localScale = original_size*1.5f;
			
		}
		
	
	}
}
