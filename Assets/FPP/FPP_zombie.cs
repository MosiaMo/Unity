﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FPP_zombie : MonoBehaviour
{
    private Transform player;
	
	// Start is called before the first frame update
    void Start()
    {
    player=GameObject.FindWithTag("Player").transform;    
    }

    // Update is called once per frame
    void Update()
    {
    GetComponent<NavMeshAgent>().destination=player.position;    
    }
}
