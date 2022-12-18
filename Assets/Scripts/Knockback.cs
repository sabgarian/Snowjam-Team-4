using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    [SerializeField] private float force = 5f, delay = 0.15f;
    [SerializeField] private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        if(!player) player = GetComponent<PlayerController>().gameObject;
    }

    public void KnockbackPlayer()
    {
        Vector2 direction = (player.transform.position - transform.position).normalized;
        Debug.Log(direction);
        player.GetComponent<Rigidbody2D>().AddForce(direction * force, ForceMode2D.Impulse);
        StartCoroutine(Reset());
    }

    IEnumerator Reset()
    {
        yield return new WaitForSeconds(delay);
        player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
    }
}
