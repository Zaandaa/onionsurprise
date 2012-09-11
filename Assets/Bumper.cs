using UnityEngine;
using System.Collections;

public class Bumper : MonoBehaviour {
	float force;
	
	void Start () {
		force = 5.0f;
	}
	
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider c) {
		Debug.Log(c.name);
		if (c.rigidbody) {
			Debug.Log("Bump");
			Vector3 forceVector = -transform.forward.normalized;
			forceVector.Scale(new Vector3(force, force, force));
			c.rigidbody.AddForce(forceVector);
		}
	}
}
