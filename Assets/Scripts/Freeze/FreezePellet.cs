using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezePellet : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D (Collider2D hit)
    {
        if (hit.gameObject.tag == "Player") return;
        if (hit.gameObject.layer == 3)
        {
            hit.gameObject.GetComponent<Freezable>().FreezeObject();
        }
        Destroy(this.gameObject);
    }

    void OnCollisionEnter2D(Collision2D hit)
    {
        if(hit.gameObject.layer == 6)
            Destroy(this.gameObject);
        if (hit.gameObject.tag == "Player") return;
        if (hit.gameObject.layer == 3)
        {
            hit.gameObject.GetComponentInParent<Freezable>().FreezeObject();
        }
        Destroy(this.gameObject);
    }

}
