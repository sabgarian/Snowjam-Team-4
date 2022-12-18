using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoopingBG : MonoBehaviour
{
    [SerializeField] private float speed = 0.5f;
    [SerializeField] private RawImage img;

    // Update is called once per frame
    void Update()
    {
        img.uvRect = new Rect(img.uvRect.position + new Vector2(speed, 0) * Time.deltaTime, img.uvRect.size);

    }
}
