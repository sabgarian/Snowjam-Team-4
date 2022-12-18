using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FreezeMechanic : MonoBehaviour
{
    [SerializeField] private GameObject cooldownUI;
    [SerializeField] private float cooldownTimer = 5f;
    [SerializeField] private Sprite cooldown1;
    [SerializeField] private Sprite cooldown2;
    [SerializeField] private Camera cam;
    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform attackPoint;
    private float currentCoolDown = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FreezeObject();
        doUI();
    }

    private void doUI()
    {
        currentCoolDown = Mathf.Max(0, currentCoolDown - Time.fixedDeltaTime);
        if (currentCoolDown > 0)
        {
            cooldownUI.GetComponent<Image>().sprite = cooldown2;
        }
        else
        {
            cooldownUI.GetComponent<Image>().sprite = cooldown1;
        }
        cooldownUI.GetComponentInChildren<TMP_Text>().text = ((int)currentCoolDown).ToString();
    }

    public void FreezeObject()
    {

        if(Input.GetKeyDown(KeyCode.F) && currentCoolDown <= 0.05f)
        {
            currentCoolDown = cooldownTimer;
            Shoot();
        }
    }

    private void Shoot()
    {
        Instantiate(projectile, attackPoint.position, attackPoint.rotation);
    }
}
