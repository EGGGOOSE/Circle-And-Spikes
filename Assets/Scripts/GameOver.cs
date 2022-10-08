using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public static bool IsGameOver;

    [SerializeField] private GameObject _gameOverScreen;
    [SerializeField] private TextMeshProUGUI _winLoseLabel;
    [SerializeField] private GameObject _circle;

    private void Start()
    {
        IsGameOver = false;
    }

    public void Victory()
    {
        _winLoseLabel.color = Color.green;
        _winLoseLabel.SetText("Victory!");
        EndGame();
    }

    public void Defeat()
    {
        _winLoseLabel.color = Color.red;
        _winLoseLabel.SetText("Defeat!");
        EndGame();
    }

    private void EndGame()
    {
        Destroy(_circle);
        _gameOverScreen.SetActive(true);
        IsGameOver = true;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
