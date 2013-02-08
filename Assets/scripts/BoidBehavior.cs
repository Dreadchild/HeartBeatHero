using UnityEngine;
using System.Collections;

public class BoidBehavior : MonoBehaviour {

    public const float NEIGHBOUR_RADIUS = 5f;
    public const float MINIMUM_RADIUS = 2f;
    public const float _MAX_FLOCK_SPEED = 10f;
    public const float _ALERT_RADIUS = 9999999f;

    private float _speed;
    
    void moveBoid() {
        Vector3 cohesionVector, alignementVector, separationVector;
        float vecinityCount, separationCount;

        vecinityCount = separationCount = 0;
        cohesionVector = alignementVector = separationVector = Vector3.zero;

        // Recorremos la bandada completa de pajaros aplicando las normas
        // de vuelo
        GameObject[] swarm = GameObject.FindGameObjectsWithTag("swarm");
        for (int i = 0; i < swarm.Length; ++i) {
            // Evitar comprobacion conmigo mismo
            if (swarm[i] != gameObject) {
                
                Vector3 distanceVector = transform.position - swarm[i].transform.position;
                float distanceMagnitude = distanceVector.magnitude;

                if(distanceMagnitude < NEIGHBOUR_RADIUS) {
                    // Obtenemos el campo _speed del componente de movimiento del pajaro
                    // que esta siendo estudiado
                    float boidSpeed = swarm[i].GetComponent<MovementController>()._speed;

                    // COHESION *********************************************************
                    cohesionVector += swarm[i].transform.position;
                    
                    // ALINEAMIENTO *****************************************************
                    alignementVector += swarm[i].transform.forward * boidSpeed;

                    ++vecinityCount;
                }

                // SEPARACION ***********************************************************
                if (distanceMagnitude < MINIMUM_RADIUS) {
                    separationVector -= (swarm[i].transform.position - transform.position) / 10f;
                    
                    ++separationCount;
                }
            }
        }

        if (vecinityCount > 0) {
            cohesionVector = cohesionVector / vecinityCount;
            cohesionVector = (cohesionVector - transform.position) / 100f;

            alignementVector = alignementVector / vecinityCount;
            alignementVector = (alignementVector - (transform.forward * _speed)) / 8f;

            // Si el vector de alineacion es demasiado grande, limitamos su velocidad
            // a _MAX_SPEED
            if (alignementVector.magnitude > _MAX_FLOCK_SPEED) {
                alignementVector.Normalize();
                alignementVector *= _MAX_FLOCK_SPEED;
            }
        }

        // Cambiar nuestra direccion y posicion en base a lo que dicte la bandada si es que
        // tenemos pajaros cercanos
        transform.position += (cohesionVector + alignementVector + separationVector) * _speed * Time.deltaTime;
        
        // STEERING BEHAVIOUR
        Vector3 playerPos = Vector3.zero;
        GameObject[] player = GameObject.FindGameObjectsWithTag("Player");
        for(int i = 0; i < player.Length; ++i) {
            playerPos += player[i].transform.position;
        }
        Vector3 vectorToHero = playerPos - transform.position;

        //Vector3 direction = cohesionVector + alignementVector + separationVector + vectorToHero;
		Vector3 direction;
		
        if (vectorToHero.magnitude < _ALERT_RADIUS) {
            direction = cohesionVector + alignementVector + separationVector + vectorToHero;
        }
        else {
            direction = cohesionVector + alignementVector + separationVector;
        }

        direction.Normalize();
        transform.forward += direction / 40f;
    }

    // Use this for initialization
    void Start() {
        // Obtener del componente de movimiento mi velocidad
        _speed = GetComponent<MovementController>()._speed;
	}
	
	// Update is called once per frame
	void Update () {
        moveBoid();
    }
}