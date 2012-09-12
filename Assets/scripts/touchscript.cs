using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class touchscript : MonoBehaviour {
	
	//keep track of score here just for funziez
	int botscore = 0;
	int topscore = 0;
	public TextAsset leaderboards;
	bool scoring_top = false;
	bool scoring_bot = false;
	int toprank = -1;
	int botrank = -1;
	
	string pname = "";
	TouchScreenKeyboard keyboard;
	
	
	public string[] lines;
	
	void OnGUI(){
		//scoring stuff	
		if(scoring_top){
			GUI.Label(new Rect(15, 15, Screen.width-15, 200), "HIGH SCORE TOP PLAYER! ENTER YOUR NAME!");
			pname = keyboard.text;
			
			if(keyboard.done){
				string[] temp = lines[toprank].Split(' ');
				temp[0] = pname;
				lines[toprank] = "";
				foreach(string tt in temp)
					lines[toprank] += tt;
				
				pname = "";
				scoring_top = false;
			}
			
			
			
		}
		else if(scoring_bot){
			GUI.Label(new Rect(15, 15, Screen.width-15, 200), "HIGH SCORE BOTTOM PLAYER! ENTER YOUR NAME!");
			pname = keyboard.text;
			
			if(keyboard.done){
				string[] temp = lines[botrank].Split(' ');
				temp[0] = pname;
				lines[botrank] = "";
				foreach(string tt in temp)
					lines[botrank] += tt;
				
				scoring_bot = false;
			}
			
		}
		
	}
	
	void Insert(int i, string s){
		for(int k = lines.Length - 1; k >= 0; k--){
			if(k > i)
				lines[k+1] = lines[k];
			else if(k == i)
				lines[k] = s;
			
		}
		
	}
	
	
	public void RecordScores(){
		
		
		int toprank = -1;
		int botrank = -1;
		int i = 0;
		
		
		//if(lines){
		foreach(string line in lines){
			string [] fields = line.Split(' ');
			int score = int.Parse(fields[fields.Length-1]);
			if(topscore > score){
				scoring_top = true;
				toprank = i;
				Insert(i, "Placeholder " + topscore);
				keyboard = TouchScreenKeyboard.Open(pname, TouchScreenKeyboardType.Default, false);
				
				
			}
			else if(botscore > score){
				botrank = i;
				scoring_bot = true;
				Insert(i, "Placeholder " + botscore);
				keyboard = TouchScreenKeyboard.Open(pname, TouchScreenKeyboardType.Default, false);
				
			}
			
			i++;
		}
		//}
		
		
	}
	
	// Use this for initialization
	void Start () {		
		lines = leaderboards.text.Split('\n');
	
	}
	
	// Update is called once per frame
	void Update () {
		
		for(int i = 0; i < Input.touchCount; i++){
			RaycastHit hit = new RaycastHit();
			Ray ray = Camera.main.ScreenPointToRay(new Vector3(Input.GetTouch(i).position.x, Input.GetTouch(i).position.y, 0f));
			if(Physics.Raycast(ray, out hit, Mathf.Infinity)){
				if(hit.rigidbody.gameObject.name.Contains("big_flower")){
					if(hit.rigidbody.gameObject.transform.parent.name == "bottom_side")
						botscore += hit.rigidbody.gameObject.GetComponent<big_flower>().points;
					else
						topscore += hit.rigidbody.gameObject.GetComponent<big_flower>().points;
					
					Destroy(hit.rigidbody.gameObject);
				}
				else if(hit.rigidbody.gameObject.name.Contains("little_flower")){
					if(hit.rigidbody.gameObject.transform.parent.name == "bottom_side")
						botscore += hit.rigidbody.gameObject.GetComponent<little_flower>().points;
					else
						topscore += hit.rigidbody.gameObject.GetComponent<little_flower>().points;
					
					Destroy(hit.rigidbody.gameObject);
					
					
				}
				
				Debug.Log("Registered a hit");
			}
			
		}
	
	}
}
