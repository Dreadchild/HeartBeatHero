using UnityEngine;
using System.Collections;

public class a : MonoBehaviour {
	
	public float width = Screen.width/1.5f;
	public float height = Screen.height/1.5f;
	public float buttonWidth;
	public float buttonHeight;
	private float puntuacion;
	public GUIStyle nueva;
	public GUIStyle salir;
	public GUIStyle header;
	public GUIStyle pun;
	
	
	void OnGUI () {
		buttonHeight = height/5f;
		buttonWidth = width/2-40;
		float coloca = buttonHeight*6f;
		
		GUI.Box(new Rect(Screen.width/3.8f,20,width/1.25f-20,height/1.5f-20), "", header);
		
		GUI.BeginGroup(new Rect((Screen.width/2)-(width/3),(Screen.height/3)-(height),width*2,height*4));
			GUI.Box(new Rect(buttonWidth/5f,coloca,buttonWidth/2,buttonHeight/1.5f), "Puntuacion: "+puntuacion, pun);
			coloca += buttonHeight;
			if(GUI.Button(new Rect(20,coloca,buttonWidth,buttonHeight), "", nueva)) {
				Application.LoadLevel(1);
			}
			coloca+= buttonHeight+20;
			if(GUI.Button(new Rect(20,coloca,buttonWidth,buttonHeight), "", salir)) {
				Application.Quit();
			}
		GUI.EndGroup();
		
		
		
	}
	
	
	// Use this for initialization
	void Start () {
		width = Screen.width/2;
		height = Screen.height/1.5f;

        GameObject player = GameObject.FindWithTag("Player");
        playerController p = player.GetComponent<playerController>();
        puntuacion = p.getPuntuacion();
        Destroy(player);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
