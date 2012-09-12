using UnityEngine;
using System.Collections;

public class Bumper : MonoBehaviour {
	public float force = 1.0f;
	
	void Start () {
		
	}
	
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider c) {
		if (c.name == "Onion") {
			Vector3 directionVector = transform.up.normalized;
			
			Vector3 velocityVector = Vector3.Project(c.rigidbody.velocity, directionVector);
			
			velocityVector.Scale(new Vector3(-1 - force, -1 - force, -1 - force));
			
			c.rigidbody.velocity += velocityVector;
		}
	}
}
