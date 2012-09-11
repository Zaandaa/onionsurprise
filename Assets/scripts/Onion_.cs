using UnityEngine;
using System.Collections;

public class Onion_ : MonoBehaviour {
	
	public float speedCap = 100.0f;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (rigidbody.velocity.sqrMagnitude > Mathf.Pow(speedCap, 2.0f)) {
			rigidbody.velocity = rigidbody.velocity.normalized * speedCap;
		}
	}
}
