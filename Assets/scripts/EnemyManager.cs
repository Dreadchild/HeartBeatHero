using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {


    int _numEnemies;
    public int _maxEnemies;

	// Use this for initialization
	void Start () {
	    _numEnemies = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Aumentar()
    {
        ++_numEnemies;
    }

    public void Disminuir()
    {
        --_numEnemies;
    }

    public bool canSpawn() {
        return _numEnemies < _maxEnemies;
    }
}
