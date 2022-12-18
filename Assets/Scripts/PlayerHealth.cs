using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int maxHealth = 4;
    [SerializeField] private Slider slider;

    private void Start()
    {
        slider.value = PlayerPrefs.GetInt("PlayerHealth", maxHealth);
    }

    public void DamagePlayer(int health)
    {
        int afterHealth = Mathf.Max(0, PlayerPrefs.GetInt("PlayerHealth") - health);
        PlayerPrefs.SetInt("PlayerHealth", afterHealth);
        slider.value = afterHealth;
        if (afterHealth == 0) GameOver();
    }

    public void HealPlayer(int health)
    {
        int afterHealth = Mathf.Min(maxHealth, PlayerPrefs.GetInt("PlayerHealth") + health);
        slider.value = afterHealth;
        PlayerPrefs.SetInt("PlayerHealth", afterHealth);
    }

    private void GameOver()
    {
        PlayerPrefs.SetInt("PlayerHealth", maxHealth);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }
}
