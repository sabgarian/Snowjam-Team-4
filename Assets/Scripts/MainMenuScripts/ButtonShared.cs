using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonShared : MonoBehaviour, ISelectHandler, IDeselectHandler, IPointerEnterHandler
{
    [SerializeField] private float leanScale = 1.15f;
    [SerializeField] private float leanScaleTime = 0.35f;
    [SerializeField] private float leanMoveTime = 0.50f;
    private LTDescr selection;
    private void OnEnable()
    {
        Vector2 temp = transform.localPosition;
        transform.localPosition = new Vector2(transform.localPosition.x, -Screen.height);
        transform.LeanMoveLocalY(temp.y, leanMoveTime).setEaseOutQuart();
    }

    public void OnSelect(BaseEventData _)
    {
        selection = transform.LeanScale(new Vector2(leanScale, leanScale), leanScaleTime).setEaseInSine();
    }

    public void OnDeselect(BaseEventData _)
    {
        LeanTween.cancel(selection.id);
        transform.LeanScale(Vector2.one, leanScaleTime).setEaseOutSine();
    }

    public void OnPointerEnter(PointerEventData _)
    {
        OnSelect(null);
    }
}
