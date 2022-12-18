using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int maxHealth = 4;

    public void DamagePlayer(int health)
    {
        int afterHealth = Mathf.Min(0, PlayerPrefs.GetInt("PlayerHealth") - health);
        PlayerPrefs.SetInt("PlayerHealth", afterHealth);
        if (afterHealth == 0) GameOver();
    }

    public void HealPlayer(int health)
    {
        PlayerPrefs.SetInt("PlayerHealth", Mathf.Min(maxHealth, PlayerPrefs.GetInt("PlayerHealth") + health));
    }

    private void GameOver()
    {
        PlayerPrefs.SetInt("PlayerHealth", maxHealth);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }
}
