using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private void OnEnable()
    {
        PlayerHealth.onPlayerDead += PlayerHealth_onPlayerDead;
    }

    private void OnDisable()
    {
        PlayerHealth.onPlayerDead -= PlayerHealth_onPlayerDead;
    }

    private void PlayerHealth_onPlayerDead()
    {
        StartCoroutine(RestartScene());
    }

    private IEnumerator RestartScene()
    {
        yield return new WaitForSeconds(1);

        if (LoadSceneManager.Instance != null)
        {
            LoadSceneManager.Instance.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
