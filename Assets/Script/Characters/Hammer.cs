﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    private Transform target;

    public int damages;
    
    void OnTriggerEnter2D(Collider2D target)
    {
        target.GetComponent<Enemy>().TakeDamage(damages);
    }
}
