using UnityEngine;
using System.Collections;

public class Field : MonoBehaviour {
	
	// (fore/aft, rotation, left/right)
	static float angleCap = 60f;//new Vector3(20.0f, 0.0f, 20.0f);
	static float angleMid = 180f;
	static float angleFullCircle = 360f;
	static Vector3 angleScale = new Vector3(0.5f, 0.0f, 0.5f);
	
	void Start () {
		Input.compass.enabled = true;
		Input.gyro.enabled = true;
	}
	
	void Update () {
		Vector3 angleValue = Vector3.zero;
		
		if (Input.gyro.enabled) {
			Debug.Log("Using gyro: " + Input.gyro.attitude.eulerAngles.ToString());
			angleValue = Input.gyro.attitude.eulerAngles;
		} else if (Input.acceleration != Vector3.zero) {
//		} else if (Input.compass.enabled) {
			//Debug.Log("Using accel: " + Quaternion.LookRotation(Input.acceleration.normalized).eulerAngles.ToString());
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
				angleValue.z = -angleCap;
			} else if (Input.GetKey(KeyCode.A)) {
				angleValue.z = angleCap;
			}
		
			if (Input.GetKey(KeyCode.S)) {
				angleValue.x = -angleCap;
			} else if (Input.GetKey(KeyCode.W)) {
				angleValue.x = angleCap;
			}
		}
		
		//angleValue = Vector3.Scale(angleValue, angleScale);
		
		//allow for negative rotation before clamping
		if (angleValue.x > angleMid) {
			angleValue.x -= angleFullCircle;
		}
		angleValue.y -= angleMid;
		
		//don't exceed angles above angleCap
		float x = angleValue.x;
		angleValue.x = Mathf.Clamp(-angleValue.y, -angleCap, angleCap);
		angleValue.y = 0f;//Mathf.Clamp(angleValue.y, -angleCap, angleCap);
		angleValue.z = Mathf.Clamp(-x, -angleCap, angleCap);
		
		transform.rotation = Quaternion.Euler(angleValue);
	}
}
