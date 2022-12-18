using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freezable : MonoBehaviour
{
    private Hazard hazard;
    private EnemyPatrol enemy;
    [SerializeField] private float duration = 5f;
    [SerializeField] private Collider2D freezeCollider;
    // Start is called before the first frame update
    void Start()
    {
        hazard = GetComponentInChildren<Hazard>();
        enemy = GetComponentInChildren<EnemyPatrol>();
    }

    public void FreezeObject()
    {
        Debug.Log("test");
        if (hazard) hazard.changeProp(true);
        if (enemy) enemy.FreezePath();
        freezeCollider.enabled = true;
        Invoke("UnfreezeObject", duration);
    }

    public void UnfreezeObject()
    {
        Debug.Log("testun");
        if (hazard) hazard.changeProp(false);
        if (enemy) enemy.UnfreezePath();
        freezeCollider.enabled = false;
    }
}
