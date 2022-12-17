using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnableOnClick : MonoBehaviour
{
    [SerializeField] private GameObject[] buttons;
    [SerializeField] private float leanMove = 2f;
    [SerializeField] private float fadeTime = 0.1f;
    private bool buttonPressed = false;

    // Initialize everything to be inactive at the start before the prompt and
    void Start()
    {
        foreach  (GameObject gameobject in buttons) {
            gameobject.SetActive(false);
        }

        transform.LeanMoveLocal(new Vector2(0, (transform.localPosition.y) + leanMove), 1).setEaseInSine().setLoopPingPong();
    }

    // Update is called once per frame
    void Update()
    {
        if(!buttonPressed && Input.anyKeyDown)
        {
            foreach (GameObject gameobject in buttons)
            {
                gameobject.SetActive(true);
            }
            if(buttons[0])
            {
                buttons[0].GetComponent<Button>().Select();
            }
            buttonPressed = true;
            StartCoroutine(Fade());
        }
    }

    IEnumerator Fade()
    {
        TMP_Text tmText = GetComponent<TMP_Text>();
        Color curr = tmText.color;
        for (float alpha = 1f; alpha >= -0.05f; alpha -= 0.1f)
        {
            curr.a = alpha;
            tmText.color = curr;
            yield return new WaitForSeconds(fadeTime);
        }
        this.gameObject.SetActive(false);
    }
}
