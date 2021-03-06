﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private Transform target;

    public int damages;
    public float speed = 70f;
    public void Chase(Transform _target)
    {
        target = _target;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (target==null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude<=distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame,Space.World);

    }
    void HitTarget ()
    {
        target.GetComponent<Enemy>().TakeDamage(damages);       
        Destroy(gameObject);
    }
    
    
}
