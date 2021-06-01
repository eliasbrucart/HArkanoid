﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rb;

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        rb.velocity = Vector3.right * horizontalInput * speed;
    }
}