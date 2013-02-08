using UnityEngine;
using System.Collections;

public class SpawnEnemy : MonoBehaviour {
	
	public Transform _enemigo1;
    public Transform _enemigo2;
	public float _respawnTime = 1;
	public int _nEnemies = 30;
	private float _timeStamp = 0.0f;
    private float _timeStamp2 = 0.0f;
	private float cuadridulaX;
	private float cuadriculaZ;
	private float _radius;

    public int _maxEnemies;


    int _numEnemies;

	Transform world;
	float lat, longi;


    float _offset;



	// Use this for initialization
	void Start () {

        _numEnemies = 0;


        _offset = 1;
		world = GameObject.FindGameObjectWithTag("world").transform;
		//Vector3 aux = transform.position - world.transform.position;
		//SphereCollider a = world.GetComponent<SphereCollider>();
		//_radius = a.radius;
		//lat = Mathf.Asin(transform.position.z/_radius);
		//longi = Mathf.Atan2(transform.position.y, transform.position.x);
		lat = transform.localScale.x;
		longi = transform.localScale.z;




        _timeStamp = 100;
	}
	
	// Update is called once per frame
	void Update () {


		cuadridulaX = 0;
		cuadriculaZ = 0;
		//cada X tiempo, respawnean enemigos
		Vector3 spawnPos = transform.position;
		/*auxpos = (transform.position-world.position);
		auxpos.x = auxpos.x*transform.position.x;
		auxpos.y = auxpos.y*transform.position.y;
		auxpos.z = auxpos.z*transform.position.z;*/
		if(_respawnTime<=_timeStamp){
            GameObject respawnManager = GameObject.FindGameObjectWithTag("respawnManager");
            if (respawnManager.GetComponent<EnemyManager>().canSpawn())
            {
                for (int i = 0; i < _nEnemies; i++)
                {
                    respawnManager.GetComponent<EnemyManager>().Aumentar();
                    spawnPos.z += cuadriculaZ;//+ _offset;
                    spawnPos.x += cuadridulaX;// +_offset;
                    //spawnPos.z = _radius * Mathf.Cos (lat+cuadriculaZ+5);
                    //spawnPos.x = _radius * Mathf.Sin(longi+cuadridulaX);
                    //spawnPos.y = _radius * Mathf.Cos(longi+cuadridulaX);
                    //print (spawnPos);
                    
                    if (i % 2 == 0)
                    {
                        Instantiate(_enemigo1, spawnPos, transform.rotation);
                        cuadriculaZ += longi;
                    }
                    else
                    {
                        Instantiate(_enemigo2, spawnPos, transform.rotation);
                        cuadridulaX += lat;
                    }
                }
            }
			_timeStamp=0;

            
            
            _respawnTime -= 0.05f;
            if (_respawnTime < 0)
                _respawnTime = 0;

            _offset += 2;

            if (_timeStamp2 > 10)
            {
                _numEnemies++;
            }


            if (_offset > 10)
                _offset = 0;
			return;
		}
		_timeStamp+=Time.deltaTime;
        _timeStamp2+= Time.deltaTime;
		
		
		
		
		
	}


    
}
