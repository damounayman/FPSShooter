﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ShootingEnemy : Enemy
{
    public float shootingInterval = 4f;
    public float shootingDistance = 3f;
    public float chasingInterval = 2f;
    public float chasingDistance = 12f;

    private Player player;
    private float shootingTimer;
    private float chasingTimer;
    private NavMeshAgent agent;
   
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        agent = GetComponent<NavMeshAgent>();
        shootingTimer =Random.Range(0, shootingInterval);
        agent.SetDestination(player.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        // shooting logic
        shootingTimer -= Time.deltaTime;
        if (shootingTimer <= 0 && Vector3.Distance(transform.position,player.transform.position)<= shootingDistance )
        {
            shootingTimer = shootingInterval;

            GameObject bullet = ObjectPoolingManager.Instance.GetBullet(false);
            bullet.transform.position = transform.position;
            bullet.transform.forward = (player.transform.position - transform.position).normalized;

        }
        // chasing logic 
        chasingTimer -= Time.deltaTime;
        if (chasingTimer <= 0 && Vector3.Distance(transform.position,player.transform.position)<= chasingDistance)
        {
            chasingTimer = chasingInterval;
            agent.SetDestination(player.transform.position);
        }
    }
    protected override void OnKill()
    {
        base.OnKill();
        agent.enabled = false;
        this.enabled = false;
        transform.localEulerAngles = new Vector3(10, transform.localEulerAngles.y, transform.localEulerAngles.z);
    }
}
