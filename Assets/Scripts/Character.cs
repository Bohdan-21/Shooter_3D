using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private int _healthPointer = 5;


    public void Hurt(int damage)
    {
        _healthPointer -= damage;
    }
}
