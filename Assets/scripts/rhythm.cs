using UnityEngine;
using System.Collections;

public class rhythm : MonoBehaviour {

    
    public float _minRit;
    public float _maxRit;

    public float _ritMinusPerSecond;
    

    public float _ritForInput;

    float _actualRit;

    public int _vidasTotales;
    int _vidasActual;
    float _timeStamp;

    int _numParpadeos;
    int _parpadeosTotal;

    bool _inmune;

    public struct Tdisparo{
        public float maxSize;
        public float factorCrecimiento;
        public float coolDown;
    }

    public Tdisparo[] disparos;

    public bool _cheater;

    public GUIStyle style;
	// Use this for initialization

    private Rect vidaGUI = new Rect(1*Screen.width / 14 , 1 * Screen.height / 20, 1 * Screen.width / 7, 1 * Screen.height / 10);

    public GUIStyle cuadritoRojo;


    void OnGUI() {


        cuadritoRojo.fontSize = Screen.height / 24;

        //GUI.Box(timeGUI,"");
        GUI.Box(vidaGUI, _vidasActual.ToString() + " Vidas", cuadritoRojo);


    
    }


	void Start () {
        _numParpadeos = 0;
        _parpadeosTotal = 7;
        _timeStamp = 0;
        _inmune = false;
        _vidasActual = _vidasTotales;

        _minRit = 5;
        _maxRit = 86;

        _actualRit = 45;
        _ritMinusPerSecond = 5;
        _ritForInput = 2;
        

        disparos = new Tdisparo[5];

        disparos[0].factorCrecimiento = 0.5f;
        disparos[0].maxSize =  5;
        disparos[0].coolDown = 5;

        disparos[1].factorCrecimiento = 0.5f;
        disparos[1].maxSize =  3.5f;
        disparos[1].coolDown = 4;

        disparos[2].factorCrecimiento = 0.5f;
        disparos[2].maxSize = 2.75f;
        disparos[2].coolDown = 3;

        disparos[3].factorCrecimiento = 0.5f;
        disparos[3].maxSize = 1.6f;
        disparos[3].coolDown = 2;

        disparos[4].factorCrecimiento = 0.5f;
        disparos[4].maxSize = 0.9f;
        disparos[4].coolDown = 1;
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown (KeyCode.Return))
        {
            _actualRit += _ritForInput;
        }

        _actualRit -= _ritMinusPerSecond * Time.deltaTime;

        //Debug.LogWarning(_actualRit);
        
        
        shoot gc = (shoot)gameObject.GetComponent("shoot");
        guiManager gm = (guiManager)Camera.mainCamera.GetComponent("guiManager");
        playerController pc = (playerController)gameObject.GetComponent("playerController");

        if (_actualRit < 20 && _actualRit > 6)
        {
            //print("1");
            gm.changeStatus(1);
            gc.disparo(disparos[0].factorCrecimiento, disparos[0].maxSize, disparos[0].coolDown);
            pc.setSpeed(2);
        }else if (_actualRit < 40 && _actualRit > 21) {
            //print("2");
            gm.changeStatus(2);
            gc.disparo(disparos[1].factorCrecimiento, disparos[1].maxSize, disparos[1].coolDown);
            pc.setSpeed(3);
        }
        else if (_actualRit < 55 && _actualRit > 41)
        {
            gm.changeStatus(3);
            gc.disparo(disparos[2].factorCrecimiento, disparos[2].maxSize, disparos[2].coolDown);
            //print("3");
            pc.setSpeed(4);
        }
        else if (_actualRit < 70 && _actualRit > 56)
        {
            gm.changeStatus(4);
            gc.disparo(disparos[3].factorCrecimiento, disparos[3].maxSize, disparos[3].coolDown);
            pc.setSpeed(5);
            //print("4");
        }
        else if (_actualRit < 85 && _actualRit > 71)
        {
            gm.changeStatus(5);
            gc.disparo(disparos[4].factorCrecimiento, disparos[4].maxSize, disparos[4].coolDown);
            pc.setSpeed(6);
            
            //print("5");
        }

        // muere por pocas pulsaciones
        if (_actualRit < _minRit) { 
        
            //Aqui tb cargo lo de perder
            if (!_cheater)
                Application.LoadLevel(3);
        }

        // muerte por muchas pulsaciones
        if (_actualRit > _maxRit) {
            if (!_cheater)
                Application.LoadLevel(3);
            //Aqui tb cargo lo de perder

        }

        

        if (_inmune)
        {
            //print("Inmune = " + _inmune);
            _timeStamp += Time.deltaTime;
            if (_timeStamp > 0.25)
            {
                print("me han dao");
                ++_numParpadeos;
                _timeStamp = 0;
                gameObject.GetComponentInChildren<SkinnedMeshRenderer>().enabled = !gameObject.GetComponentInChildren<SkinnedMeshRenderer>().enabled;
            }
            if (_numParpadeos > _parpadeosTotal)
            {
                _numParpadeos = 0;
                _inmune = false;
            }
        }
	}

    void OnCollisionEnter(Collision col)
    {
        //// Aqui he de cargar el menu de juego de perder
        if (!_cheater)
        {
            if (_vidasActual <= 0)
            {
                Application.LoadLevel(3);
            }
            else
            {
                if(!_inmune)
                {
                    --_vidasActual;
                    _inmune = true;
                }
            }
        }
    }
}
