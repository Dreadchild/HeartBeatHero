using UnityEngine;
using System.Collections;

public class MovementController : MonoBehaviour {

    public Vector3 _direction;
    public float _speed;
    public bool _isPlayer;
    public Transform distancePoint;
    public float _distanceMax;

    void Move(Vector3 direction) {
        transform.Translate(Vector3.forward * Time.deltaTime * _speed);
        
    }

	// Use this for initialization
	void Start () {
        transform.RotateAroundLocal(Vector3.up, Random.value * 360);
        distancePoint = GameObject.FindGameObjectWithTag("Player").transform;
        _speed = 1 + Random.value * 4f;
        //print(_speed);
	}
	
	// Update is called once per frame
	void Update () {
        Move(transform.forward);




        if( Vector3.Distance(transform.position, distancePoint.position) >  _distanceMax){
            GameObject respawnManager = GameObject.FindGameObjectWithTag("respawnManager");
            respawnManager.GetComponent<EnemyManager>().Disminuir();
            Destroy(gameObject);
        }
            
	}
}
