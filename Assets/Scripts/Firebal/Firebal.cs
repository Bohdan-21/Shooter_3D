using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firebal : MonoBehaviour
{
    private float _speed = 10;
    private int _damage = 1;

    void Update()
    {
        transform.Translate(0, 0, _speed * Time.deltaTime);        
    }

    private void OnTriggerEnter(Collider other)
    {
        Character character = other.GetComponent<Character>();

        if(character != null)
        {
            character.Hurt(_damage);
        }

        Destroy(gameObject);
    }
}
