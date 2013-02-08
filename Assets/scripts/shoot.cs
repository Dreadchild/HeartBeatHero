using UnityEngine;
using System.Collections;

public class shoot : MonoBehaviour {

    public GameObject m_explosion;

    public GameObject m_SelectionArea;
    float _size;
    float _maxSize;
    float _factorCrecimiento;

    bool _shooting;
    float _coldDown;

    float _ActualColdDown;
    bool _creciendo;
    bool _canShoot;
	// Use this for initialization
	void Start () {
        _size = 0;
        _shooting = false;
        _creciendo = true;
        _ActualColdDown = 0;
        _canShoot = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (_canShoot && (Input.GetKey(KeyCode.Space)))
        {
            _shooting = true;
            _creciendo = true;
            _canShoot = false;
            
        }


        if (_shooting)
        {
            if ((_size < _maxSize) && (_creciendo))
            {
               // m_explosion.particleEmitter.maxEmission = _size*50;
                //m_explosion.particleEmitter.minEmission = _size*50;

                _size += _factorCrecimiento;
            }
            else
            {
                _creciendo = false;
                _size -= _factorCrecimiento;
               // m_explosion.particleEmitter.maxEmission = _size*50;
               // m_explosion.particleEmitter.minEmission = _size*50;

                
            }

            if (_size < 0)
                    {
                        _size = 0;
                        _ActualColdDown = 0;
                        _shooting = false;

                    }
        }
        else {
            _ActualColdDown += Time.deltaTime;
            
            if (_ActualColdDown > _coldDown) {
                _canShoot = true;
            }
        }
    


        

        //print(_size);
        m_SelectionArea.transform.localScale = new Vector3(_size, _size, _size);// * Time.deltaTime ;
       
        
        

       // Debug.LogWarning(_size);

	}


    public void disparo(float factorCrecimiento, float maxSize, float coldDown){
        
        _factorCrecimiento = factorCrecimiento;
        _maxSize = maxSize;
        _coldDown = coldDown;
    }
}
