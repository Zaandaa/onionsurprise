using UnityEngine;
using System.Collections;

public class boards : MonoBehaviour {
	
	public TextAsset leaderboards;
	
	
	public string[] lines;
	
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this);
		
		lines = leaderboards.text.Split('\n');
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
