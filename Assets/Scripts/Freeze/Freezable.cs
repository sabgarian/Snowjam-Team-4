using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freezable : MonoBehaviour
{
    private Hazard hazard;
    [SerializeField] private float duration = 5f;
    [SerializeField] private Collider2D freezeCollider;
    // Start is called before the first frame update
    void Start()
    {
        hazard = GetComponentInChildren<Hazard>();
    }

    public void FreezeObject()
    {
        Debug.Log("test");
        if (hazard) hazard.changeProp(true);
        freezeCollider.enabled = true;
        Invoke("UnfreezeObject", duration);
    }

    public void UnfreezeObject()
    {
        Debug.Log("testun");
        if (hazard) hazard.changeProp(false);
        freezeCollider.enabled = false;
    }
}
