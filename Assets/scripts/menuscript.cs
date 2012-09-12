using UnityEngine;
using System.Collections;

public class menuscript : MonoBehaviour {
	
	string which_menu = "Main";
	public TextAsset leaderboard;
	string[] lines;
	
	// Use this for initialization
	void Start () {
		lines = leaderboard.text.Split('\n');	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI(){
		
		if(which_menu == "Main"){
			if(GUI.Button(new Rect(15, 15, Screen.width - 15, Screen.height/2 - 15), "Start Game"))
				Application.LoadLevel("test");
			if(GUI.Button(new Rect(15, Screen.height/2, Screen.width - 15, Screen.height/2 - 15), "Leaderboard"))
				which_menu = "Leaderboard";
		}
		else if(which_menu == "Leaderboard"){
			for(int i = 0; i < (Screen.height - 80)/25 && i < lines.Length; i++){
				GUI.Label(new Rect(15, 15 + i * 25, Screen.width-15, 25), lines[i]);				
			}
			
			
			if(GUI.Button(new Rect(15, Screen.height - 65, Screen.width - 15, 50), "Back"))
				which_menu = "Main";
			
		}
		
		
	}
}
