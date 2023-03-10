using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonShared : MonoBehaviour, ISelectHandler, IDeselectHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private float leanScale = 1.15f;
    [SerializeField] private float leanScaleTime = 0.35f;
    [SerializeField] private float leanMoveTime = 0.50f;
    private int selection;
    private void OnEnable()
    {
        Vector2 temp = transform.localPosition;
        transform.localPosition = new Vector2(transform.localPosition.x, -Screen.height);
        transform.LeanMoveLocalY(temp.y, leanMoveTime).setEaseOutQuart().setIgnoreTimeScale(true);
    }

    public void OnSelect(BaseEventData _)
    {
        selection = transform.LeanScale(new Vector2(leanScale, leanScale), leanScaleTime).setEaseInSine().setIgnoreTimeScale(true).id;
    }

    public void OnDeselect(BaseEventData _)
    {
        LeanTween.cancel(selection);
        transform.LeanScale(Vector3.one, leanScaleTime).setIgnoreTimeScale(true).setEaseOutSine();
    }

    public void OnPointerEnter(PointerEventData _)
    {
        OnSelect(null);
    }

    public void OnPointerExit(PointerEventData _)
    {
        OnDeselect(null);
    }
}
