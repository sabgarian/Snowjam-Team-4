using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonShared : MonoBehaviour, ISelectHandler, IDeselectHandler, IPointerEnterHandler
{
    [SerializeField] private float leanScale = 1.15f;
    [SerializeField] private float leanTime = 0.35f;
    LTDescr selection;
    private void OnEnable()
    {
        
    }

    public void OnSelect(BaseEventData _)
    {
        selection = transform.LeanScale(new Vector2(leanScale, leanScale), leanTime).setEaseInSine();
    }

    public void OnDeselect(BaseEventData _)
    {
        LeanTween.cancel(selection.id);
        transform.LeanScale(Vector2.one, leanTime).setEaseOutSine();
    }

    public void OnPointerEnter(PointerEventData _)
    {
        OnSelect(null);
    }
}
