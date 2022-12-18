using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private float maxSpeed = 1f;
    private float speed;
    private Rigidbody2D rb;
    private BoxCollider2D groundDetect;
    private Rigidbody2D enemy;
    private bool isFacingLeft = true;
    private void Start()
    {
        speed = maxSpeed;
        enemy = transform.parent.GetComponent<Rigidbody2D>();
    }

    public void FreezePath()
    {
        speed = maxSpeed / 4;
    }

    public void UnfreezePath()
    {
        speed = maxSpeed;
    }

    private void Update()
    {

        if (isFacingLeft)
        {
            enemy.velocity = new Vector2(-speed, 0f);
        }
        else
        {
            enemy.velocity = new Vector2(speed, 0f);
        }
    }

    private bool IsFacingLeft()
    {
        return transform.localScale.x < Mathf.Epsilon;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        //turn when reached edge or wall
        transform.parent.localScale = new Vector2(
            -transform.parent.localScale.x, transform.parent.localScale.y);
        isFacingLeft = !isFacingLeft;
    }
    
}
