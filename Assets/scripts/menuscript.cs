using UnityEngine;
using System.Collections;

public class menuscript : MonoBehaviour {
	
	string which_menu = "Main";
	public TextAsset leaderboard;
	string[] lines;
	public Texture2D main_background;
	public Texture2D leader_background;
	public Texture2D transparent;
	public GUISkin skin;
	
	GameObject lbs;
	
	// Use this for initialization
	void Start () {
		lbs = GameObject.Find ("leaderboards");
		
		lines = lbs.GetComponent<boards>().lines;	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI(){
		
		if(which_menu == "Main"){
			GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), main_background);
			if(GUI.Button(new Rect(50, Screen.height/2, Screen.width - 100, Screen.height/10), transparent, ""))
				Application.LoadLevel("newtest");
			if(GUI.Button(new Rect(50, Screen.height/2 + Screen.height/8, Screen.width - 100, Screen.height/12), transparent, ""))
				which_menu = "Leaderboard";
			if(GUI.Button(new Rect(50, 7*Screen.height/10, Screen.width - 100, Screen.height/10), transparent, ""))
				;//which_menu = "Leaderboard";
			if(GUI.Button(new Rect(50, 8*Screen.height/10, Screen.width - 100, Screen.height/10), transparent, ""))
				Application.Quit();
			
			
		}
		else if(which_menu == "Leaderboard"){
			GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), leader_background);
			
			for(int i = 0; i < (Screen.height - 80)/25 && i < lines.Length; i++){
				GUI.Label(new Rect(50, 3*Screen.height/10 + i * 50, Screen.width-100, 50), lines[i], skin.label);
			}
			
			
			if(GUI.Button(new Rect(50, 8*Screen.height/10, Screen.width - 100, 50), "Back"))
				which_menu = "Main";
			
		}
		
		
	}
}
