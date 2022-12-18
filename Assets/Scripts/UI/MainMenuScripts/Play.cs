using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    public void PlayOnClick()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
}
