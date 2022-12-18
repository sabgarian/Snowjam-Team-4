using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OpenUI : MonoBehaviour
{
    [SerializeField] private float leanMoveTime = 0.50f;
    [SerializeField] private GameObject firstSelected;
    [SerializeField] private GameObject previousSelected;
    private Vector2 startPos;
    private int selection;

    private void Awake()
    {
        startPos = transform.localPosition;
    }

    private void OnEnable()
    {
        transform.localPosition = new Vector2(startPos.x, -Screen.height);
        selection = transform.LeanMoveLocalY(startPos.y, leanMoveTime).setEaseOutQuart().setIgnoreTimeScale(true).setOnComplete(() => EventSystem.current.SetSelectedGameObject(firstSelected)).id;
    }

    public void closeUI()
    {
        LeanTween.cancel(selection);
        if(previousSelected) EventSystem.current.SetSelectedGameObject(previousSelected);
        transform.LeanMoveLocalY(-Screen.height, leanMoveTime).setEaseInQuart().setIgnoreTimeScale(true).setOnComplete(() => this.gameObject.SetActive(false));
    }
}
