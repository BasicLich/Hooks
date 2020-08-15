﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : Tickable {

    public LayerMask enemyLayerMask;

    public UnityEvent gameOverEvent = new UnityEvent();

    public override void Tick()
    {
        Collider2D enemy = Physics2D.OverlapPoint(
               new Vector2(transform.position.x, transform.position.y),
               enemyLayerMask);

        if(enemy != null)
        {
            gameOverEvent.Invoke();
        }
    }


    //Singleton boilerplate
    private static Player _instance;

    public static Player Instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
}