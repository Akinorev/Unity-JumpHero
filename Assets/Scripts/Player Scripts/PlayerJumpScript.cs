﻿using UnityEngine;
using System.Collections;

public class PlayerJumpScript : MonoBehaviour {

    public static PlayerJumpScript instance;

    private Rigidbody2D myBody;
    private Animator anim;

    [SerializeField]
    private float forceX, forceY;

    private float tresholdX = 7f;
    private float tresholdY = 14f;

    private bool setPower, didJump;

    void Awake ()
    {
        MakeInstance();
        Initialize();
    }

    void Update()
    {
        SetPower();
    }

    void Initialize()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void MakeInstance ()
    {
        if (instance == null)
            instance = this;
    }

    void SetPower()
    {
        if (setPower)
        {
            forceX += tresholdX * Time.deltaTime;
            forceY += tresholdY * Time.deltaTime;

            if (forceX > 6.5f)
                forceX = 6.5f;

            if (forceY > 13.5f)
                forceY = 13.5f;
        }
    }


    public void SetPower (bool SetPower)
    {
        this.setPower = SetPower;

        if (!setPower)
        {
            Jump();
        }
    }

    void Jump()
    {
        myBody.velocity = new Vector2(forceX, forceY);
        forceX = forceY = 0f;
        didJump = true;
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (didJump)
        {
            didJump = false;

            if (target.tag == "Platform")
            {
                Debug.Log("Landed on platform after jumping");
            }
        }
    }
}
