using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;

public class touchscript : MonoBehaviour {
	
	//keep track of score here just for funziez
	int botscore = 0;
	int topscore = 0;
	public TextAsset leaderboards;
	bool scoring_top = false;
	bool scoring_bot = false;
	int toprank = -1;
	int botrank = -1;
	
	bool bot_needs = false;
	bool top_needs = false;
	
	bool game_over = false;
	
	string pname = "";
	TouchScreenKeyboard keyboard;
	TouchScreenKeyboard keyboard2;
	
	public GameObject lbs;
	
	public string[] lines;
	
	void OnGUI(){
		//scoring stuff	
		if(scoring_top){
			GUI.Label(new Rect(15, 15, Screen.width-15, 200), "HIGH SCORE TOP PLAYER! ENTER YOUR NAME!");
			pname = keyboard.text;
			GUI.Label (new Rect(15, 100, 100, 25), toprank.ToString());
			GUI.Label (new Rect(15, 75, 100, 25), lines[toprank]);
			
			if(!TouchScreenKeyboard.visible){
				string[] temp = lines[toprank].Split(' ');
				GUI.Label (new Rect(15, 50, 100, 25), temp.Length + " " + pname);
				temp[0] = pname;
				lines[toprank] = "";
				foreach(string tt in temp)
					lines[toprank] += tt;
				
				pname = "";
				
				
				scoring_top = false;
				top_needs = false;
			}
			
			
			
		}
		else if(scoring_bot){
			GUI.Label(new Rect(15, 15, Screen.width-15, 200), "HIGH SCORE BOTTOM PLAYER! ENTER YOUR NAME!");
			pname = keyboard2.text;
			
			if(!TouchScreenKeyboard.visible){
				string[] temp = lines[botrank].Split(' ');
				temp[0] = pname;
				lines[botrank] = "";
				foreach(string tt in temp)
					lines[botrank] += tt;
				
				pname = "";				
				
				scoring_bot = false;
				bot_needs = false;
			}
			
			
			
		}
		
		
		
	}
	
	void Insert(int i, string s){
		for(int k = lines.Length - 2; k >= 0; k--){
			if(k > i)
				lines[k+1] = lines[k];
			else if(k == i)
				lines[k] = s;
			
		}
		
	}
	
	IEnumerator bottom_scoring(){
		bot_needs = true;
		
		while(scoring_top)
			yield return new WaitForSeconds(.2f);
		
		
		keyboard2 = TouchScreenKeyboard.Open(pname, TouchScreenKeyboardType.Default, false);
		scoring_bot = true;
		
	}
	
	IEnumerator top_scoring(){
		top_needs = true;
		
		while(scoring_bot)
			yield return new WaitForSeconds(.2f);
		
		scoring_top = true;
		keyboard = TouchScreenKeyboard.Open(pname, TouchScreenKeyboardType.Default, false);

	}
	
	public void RecordScores(){
		
		Debug.Log ("Recording scores...");
		
		int i = 0;
		
		
		//if(lines){
		foreach(string line in lines){
			string [] fields = line.Split(' ');
			int score = int.Parse(fields[fields.Length-1]);
			if(topscore > score && toprank == -1){
				
				toprank = i;
				Insert(i, "Placeholder " + topscore);
				StartCoroutine(top_scoring());
								
				
			}
			else if(botscore > score && botrank == -1){
				botrank = i;
				Insert(i, "Placeholder " + botscore);
				StartCoroutine(bottom_scoring());
				//StartCoroutine(bottom_scoring());
				
				
			}
			
			i++;
		}
		//}
		
		Debug.Log("Game Over");
		game_over = true;
		
		
		
	}
	
	// Use this for initialization
	void Start () {	
		lbs = GameObject.Find ("leaderboards");
		lines = lbs.GetComponent<boards>().lines;
	
	}
	
	// Update is called once per frame
	void Update () {
		
		
		if(game_over && !top_needs && !bot_needs){
			//save new scores
			/*TextWriter tw = new StreamWriter("text.txt");
			foreach(string line in lines)
				tw.WriteLine (line);
			tw.Close();
			*/
			
		lbs.GetComponent<boards>().lines = lines;	
			Application.LoadLevel("menu");
			
		}
		
		
		for(int i = 0; i < Input.touchCount; i++){
			if (Input.GetTouch(i).phase.ToString().Equals("Began")) {
				RaycastHit hit = new RaycastHit();
				Ray ray = Camera.main.ScreenPointToRay(new Vector3(Input.GetTouch(i).position.x, Input.GetTouch(i).position.y, 0f));
				if(Physics.Raycast(ray, out hit, Mathf.Infinity)){
					
					//miss any rigidbody
					if (!hit.rigidbody) {
						continue;
					}
					
					if(hit.rigidbody.gameObject.name.Contains("big_flower")){
						big_flower temp = hit.rigidbody.gameObject.GetComponent<big_flower>();
						if(temp.is_top)
							topscore += temp.points;
						else
							botscore += temp.points;
						/*if(hit.rigidbody.gameObject.transform.parent.name == "bottom_side")
							botscore += hit.rigidbody.gameObject.GetComponent<big_flower>().points;
						else
							topscore += hit.rigidbody.gameObject.GetComponent<big_flower>().points;
						*/
						Destroy(hit.rigidbody.gameObject);
					}
					else if(hit.rigidbody.gameObject.name.Contains("little_flower")){
						little_flower temp = hit.rigidbody.gameObject.GetComponent<little_flower>();
						if(temp.is_top)
							topscore += temp.points;
						else
							botscore += temp.points;
						/*if(hit.rigidbody.gameObject.transform.parent.name == "bottom_side")
							botscore += hit.rigidbody.gameObject.GetComponent<little_flower>().points;
						else
							topscore += hit.rigidbody.gameObject.GetComponent<little_flower>().points;
						*/
						Destroy(hit.rigidbody.gameObject);
						
						
					}
					
					Debug.Log("Registered a hit");
				}
			}
		}
	
	}
}
