using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenUI : MonoBehaviour
{
    [SerializeField] private float leanMoveTime = 0.50f;
    private LTDescr selection;

    private void OnEnable()
    {
        Vector2 temp = transform.localPosition;
        transform.localPosition = new Vector2(transform.localPosition.x, -Screen.height);
        selection = transform.LeanMoveLocalY(temp.y, leanMoveTime).setEaseOutQuart();
    }

    private void closeUI()
    {
        LeanTween.cancel(selection.id);
        transform.LeanMoveLocalY(-Screen.height, leanMoveTime).setEaseOutQuart();
    }
}
