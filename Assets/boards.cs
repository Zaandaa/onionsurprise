using UnityEngine;
using System.Collections;

public class boards : MonoBehaviour {
	
	public TextAsset leaderboards;
	
	
	public string[] lines;
	
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this);
		
		GameObject[] objs = GameObject.FindGameObjectsWithTag("Player");
		
		if(objs.Length > 1)
			Destroy (gameObject);
			
		lines = leaderboards.text.Split('\n');
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
