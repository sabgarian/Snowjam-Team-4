using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    [SerializeField] private float force = 150f;
    [SerializeField] private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
    }

    public void KnockbackPlayer()
    {
        Vector2 direction = (player.transform.position - transform.position).normalized;
        direction.y = Mathf.Abs(direction.y);
        Debug.Log(direction);
        Rigidbody2D playerrb = player.GetComponent<Rigidbody2D>();
        playerrb.velocity = Vector2.zero;
        playerrb.AddForce(direction * force, ForceMode2D.Impulse);

    }

}
