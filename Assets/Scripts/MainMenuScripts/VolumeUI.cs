using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class VolumeUI : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    [SerializeField] private float rotation = 5f;
    [SerializeField] private float rotationTime = 1f;
    [SerializeField] private GameObject icon;
    private int selection;

    public void OnSelect(BaseEventData _)
    {
        icon.transform.LeanRotateZ(-rotation, rotationTime).setEaseInSine().setOnComplete(Rotation);
    }

    private void Rotation()
    {
        selection = icon.transform.LeanRotateZ(rotation, rotationTime).setEaseInSine().setLoopPingPong().id;
    }

    public void OnDeselect(BaseEventData _)
    {
        LeanTween.cancel(selection);
        icon.transform.LeanRotateZ(0f, rotationTime/2).setEaseInSine();
    }
}
