using UnityEngine;
using System.Collections;

public class enemyDie : MonoBehaviour {
    public float _destroyMeIn;

    float timeStamp;
    bool _destroy;

    public GameObject particles;
	// Use this for initialization
	void Start () {
        timeStamp = _destroyMeIn;
        _destroy = false;
	}
	
	// Update is called once per frame
	void Update () {
	
        if(_destroy)
            timeStamp -= Time.deltaTime;

        if (timeStamp < 0)
        {
            GameObject respawnManager = GameObject.FindGameObjectWithTag("respawnManager");
            respawnManager.GetComponent<EnemyManager>().Disminuir();

            
            Destroy(transform.gameObject);
        }

	}
    void OnTriggerEnter(Collider col)
    {
        //print("debo morir");
        
        GameObject[] player = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < player.Length; ++i)
        {
            playerController pc = (playerController)player[i].GetComponent("playerController");
            pc.addPuntuacion(83);
        }
        _destroy = true;
        Instantiate(particles,transform.position,transform.rotation);
       
    }

}
