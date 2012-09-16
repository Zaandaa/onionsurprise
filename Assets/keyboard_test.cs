using UnityEngine;
using System.Collections;

public class keyboard_test : MonoBehaviour {
	
	TouchScreenKeyboard keyboard;
	string test = "blalala";
	
	// Use this for initialization
	void Start () {
		keyboard = TouchScreenKeyboard.Open (test);		
		
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI(){
		GUI.Label (new Rect(0, 0, 100, 100), keyboard.text);	
	}
}
