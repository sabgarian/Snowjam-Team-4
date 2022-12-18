using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Hazard : MonoBehaviour
{
    [SerializeField] private int damageDealt = 1;
    [SerializeField] private UnityEvent trigger;
    private bool disabled = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.isTrigger && collision.tag == "Player" && !disabled)
        {
            collision.gameObject.GetComponent<PlayerHealth>().DamagePlayer(damageDealt);
            trigger?.Invoke();
        }
    }
    public void changeProp(bool change)
    {
        disabled = change;
    }
}
