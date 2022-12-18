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
    [SerializeField] public float speed = 1f;
    private Rigidbody2D rb;
    private BoxCollider2D groundDetect;
    private Rigidbody2D enemy;
    private bool isFacingLeft = true;
    private void Start()
    {
        enemy = transform.parent.GetComponent<Rigidbody2D>();
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
        Debug.Log("exited");
        isFacingLeft = !isFacingLeft;
    }
    
}
