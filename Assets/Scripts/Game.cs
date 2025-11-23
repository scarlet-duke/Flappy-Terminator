using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [SerializeField] private Life _life;

    private void OnEnable()
    {
        _life.Death += GameOver;
    }

    private void OnDisable()
    {
        _life.Death -= GameOver;
    }

    public void GameOver()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
