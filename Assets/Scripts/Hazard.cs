using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Hazard : MonoBehaviour
{
    [SerializeField] private int damageDealt = 1;
    [SerializeField] private UnityEvent trigger;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.tag == "Player")
        {
            Debug.Log("called)");
            collision.gameObject.GetComponent<PlayerHealth>().DamagePlayer(damageDealt);
            trigger?.Invoke();
        }
    }
}
