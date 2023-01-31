using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour
{
    [SerializeField] GameObject fireball;
    private GameObject _currentFirebal;

    private bool _alive;

    private float _speed = 3;
    private float _obstancleRange = 5;

    private void Start()
    {
        _alive = true;
    }


    void Update()
    {
        if (_alive)
        {
            transform.Translate(0, 0, _speed * Time.deltaTime);

            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            if (Physics.SphereCast(ray, 0.75f, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;

                if (hitObject.GetComponent<Character>())
                {
                    if (_currentFirebal == null)
                    {
                        _currentFirebal = Instantiate(fireball);

                        _currentFirebal.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);

                        _currentFirebal.transform.rotation = transform.rotation;
                    }
                }
                else if (hit.distance < _obstancleRange)
                {
                    float angle = Random.Range(-110, 110);
                    transform.Rotate(0, angle, 0);
                }
            }
        }
    }

    public void SetAlive(bool alive)
    {
        _alive = alive;
    }
}
