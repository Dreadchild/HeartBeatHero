using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {

	
	
	float puntuation;
	
    public float _speed;
    public float _radius;
	public float _maxDistance=300;
	public Transform map;
	private float _timestamp = 0;
	private int _time = 0;

    public GUIStyle style;
	public GUIText _tiempo;
	public GUIText _puntuacion;

  


    Quaternion offsetRotation;
	// Use this for initialization
	void Start () {
		puntuation = 0;
		_timestamp=0;
        _speed = 8;

        DontDestroyOnLoad(gameObject);

        offsetRotation = transform.rotation;



        // gameObject.animation.playAutomatically = true;
        // Debug.Log(gameObject.animation.Play("Take 001"));
	}
	
	public float getSpeed(){
		return _speed;
	}
	
	public void setSpeed(float speed){
		_speed = speed;
	}
	public float getPuntuacion(){
		
		return puntuation;
	}
	
	public void addPuntuacion (float puntuacion){
		
		puntuation += puntuacion;
	}


    private Rect puntGUI = new Rect(17 * Screen.width / 20, 1 * Screen.height / 20, 3 * Screen.width / 20, 1 * Screen.height / 10);


    private Rect timeGUI = new Rect(3*Screen.width / 7 , 1 * Screen.height / 20, 1 * Screen.width / 7, 1 * Screen.height / 10);


    public GUIStyle cuadritoRojo;
    public GUIStyle cuadritoVerde;

	void OnGUI(){

        cuadritoRojo.fontSize = Screen.height / 24;
        cuadritoVerde.fontSize = Screen.height / 24;

        //GUI.Box(timeGUI,"");
        GUI.Box(timeGUI, _time.ToString() + " segs.", cuadritoVerde);
        //GUI.Box(puntGUI,"");
        GUI.Box(puntGUI, puntuation.ToString(), cuadritoRojo);
		//_tiempo.text = _time.ToString();
		//_puntuacion.text = puntuation.ToString();
	}
	
	// Update is called once per frame
	void Update () {
        
        //Debug.LogWarning("hollaaa:   " + transform.animation.Play("Take 001"));

        Transform nextpos = transform;
		bool button = false;
		Vector3 aux = new Vector3();
		if(Input.GetKey(KeyCode.A)){
			button = true;
			aux+=Vector3.left;
		}
		if(Input.GetKey(KeyCode.S)){
			aux+=Vector3.back;
			button = true;
		}
		if(Input.GetKey(KeyCode.D)){
			aux+=Vector3.right;
			button = true;
		}
		if(Input.GetKey(KeyCode.W)){
			aux+=Vector3.forward;
			button = true;
		}
		if(button){
			transform.rotation = Quaternion.LookRotation(-1*aux);
			Vector3 position = new Vector3(transform.position.x,transform.position.y,transform.position.z);
			float distancia = Vector3.Distance(position, map.position);

            //Debug.Log(distancia);
            //Debug.Log(_maxDistance);
			transform.Translate(Vector3.back*Time.deltaTime*_speed);
			if(Vector3.Distance(transform.position, map.position)> _maxDistance){
				transform.position = position;
			}
			
		}
		if(_timestamp>1){
				puntuation+=21;
				_timestamp = 0;
				_time++;
		}
        _timestamp+=Time.deltaTime;
		
		
		
	}


}
