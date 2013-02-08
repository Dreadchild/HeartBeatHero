using UnityEngine;
using System.Collections;

public class credits : MonoBehaviour {
	public GUIStyle menu;
	
	void OnGUI () {
		// Make a background box
		float buttonHeight = 80;
		float buttonWidth = 300;
			if(GUI.Button(new Rect((Screen.width/2)-buttonWidth/2,Screen.height-2*buttonHeight,buttonWidth,buttonHeight), "", menu)) {
                Application.LoadLevel(0);
			}
		

		// Make the second button.
		
	}
	
	
	// Use this for initialization
	void Start () {
		// init text here, more space to work than in the Inspector (but you could do that instead)
	}
	
	// Update is called once per frame
	void Update () {
		GUIText tc = GetComponent<GUIText>();
    	string creds = "\nDesigned by: \nFrancisco Aisa\n";
    	creds += "\nArt: \nLuz Quiñonero\n";
    	creds += "\nProgramming: \nRuben Mulero\n";
    	creds += "Antonio Jesus Narvaez\n";
    	creds += "Francisco Aisa\n";
		creds += "\nSound: \njamendo.com ... Blackalexxx\n";
		creds += "GameJam 2013\n";
		tc.text=creds;
		tc.pixelOffset=new Vector2(Screen.width/2,-1*(Screen.height/3));
	}
}
