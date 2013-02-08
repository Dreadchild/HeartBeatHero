using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {
	public float width;
	public float height;
	public float buttonWidth;
	public float buttonHeight;
	private float puntuacion;
	public GUIStyle nueva;
	public GUIStyle salir;
	public GUIStyle header;
	public GUISkin skinn;
	
	
	void OnGUI () {
		// Make a background box
		print ("entro");
		buttonHeight = height/1.7f;
		buttonWidth = width*2-40;
		float coloca = buttonHeight*2.5f;
		// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
		GUI.Box(new Rect(Screen.width/2.85f,40,width*2-20,height*2-20), "", header);
		GUI.BeginGroup(new Rect((Screen.width/2)-(width),(Screen.height/3)-(height),width*2,height*4));
			
			coloca += buttonHeight;
			if(GUI.Button(new Rect(20,coloca,buttonWidth,buttonHeight), "", nueva)) {
				Application.LoadLevel(1);
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
		GameObject player = GameObject.FindWithTag("Player");
		width = Screen.width/2;
		height = Screen.height/1.5f;
		//playerController p = player.GetComponent<playerController>();
		//puntuacion = p.getPuntuacion();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
