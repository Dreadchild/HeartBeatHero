using UnityEngine;
using System.Collections;

public class PrincipalMenu : MonoBehaviour {
	
	public float width;
	public float height;
	public float buttonWidth;
	public float buttonHeight;
	public GUIStyle nueva;
	public GUIStyle salir;
	public GUIStyle header;
	public GUIStyle creditos;
	public GUISkin skinn;
	void OnGUI () {
		// Make a background box
		buttonHeight = height/5f;
		buttonWidth = width/2-40;
		float coloca = buttonHeight*5f;
		// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
		GUI.Box(new Rect(Screen.width/3.8f,20,width/1.25f-20,height/1.5f-20), "", header);
		GUI.BeginGroup(new Rect((Screen.width/2)-(width/3),(Screen.height/3)-(height),width*2,height*4));
			
			coloca += buttonHeight;
			if(GUI.Button(new Rect(20,coloca,buttonWidth,buttonHeight), "", nueva)) {
				Application.LoadLevel(1);
			}
			coloca+= buttonHeight+20;
			if(GUI.Button(new Rect(20,coloca,buttonWidth,buttonHeight), "", creditos)) {
				Application.LoadLevel(2);
			}
			coloca+= buttonHeight+20;
			if(GUI.Button(new Rect(20,coloca,buttonWidth,buttonHeight), "", salir)) {
				Application.Quit();
			}
		GUI.EndGroup();
		

		// Make the second button.
		
	}
	
	
	// Use this for initialization
	void Start () {
		width = Screen.width/2;
		height = Screen.height/1.5f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
