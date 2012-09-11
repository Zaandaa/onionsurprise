using UnityEngine;
using System.Collections;

public class Field : MonoBehaviour {
	
	// (fore/aft, rotation, left/right)
	static Vector3 angleCap = new Vector3(20.0f, 0.0f, 20.0f);
	static Vector3 angleScale = new Vector3(0.5f, 0.0f, 0.5f);
	
	void Start () {
		Input.compass.enabled = true;
		Input.gyro.enabled = true;
	}
	
	void Update () {
		Vector3 angleValue;
		
		if (Input.gyro.enabled) {
			Debug.Log("Using gyro: " + Input.gyro.attitude.eulerAngles.ToString());
			angleValue = Input.gyro.attitude.eulerAngles;
		//} else if (Input.acceleration != Vector3.zero) {
		} else if (Input.compass.enabled) {
			Debug.Log("Using accel: " + Quaternion.LookRotation(Input.acceleration.normalized).eulerAngles.ToString());
			if (Input.acceleration.normalized == Vector3.zero) {
				angleValue = Vector3.zero;
			} else {
				//Vector3 accel = Quaternion.LookRotation(Input.acceleration.normalized).eulerAngles;
				//angleValue = Vector3(accel.y, 0.0f, accel.x);
				angleValue = Quaternion.LookRotation(Input.acceleration.normalized).eulerAngles;
			}
		} else {
			angleValue = Vector3.zero;
		
			if (Input.GetKey(KeyCode.D)) {
				angleValue.z = -angleCap.z;
			} else if (Input.GetKey(KeyCode.A)) {
				angleValue.z = angleCap.z;
			}
		
			if (Input.GetKey(KeyCode.S)) {
				angleValue.x = -angleCap.x;
			} else if (Input.GetKey(KeyCode.W)) {
				angleValue.x = angleCap.x;
			}
		}
		
		angleValue = Vector3.Scale(angleValue, angleScale);
		
		angleValue.x = Mathf.Clamp(angleValue.x, -angleCap.x, angleCap.x);
		angleValue.y = Mathf.Clamp(angleValue.y, -angleCap.y, angleCap.y);
		angleValue.z = Mathf.Clamp(angleValue.z, -angleCap.z, angleCap.z);
		
		
		transform.rotation = Quaternion.Euler(angleValue);
	}
}
