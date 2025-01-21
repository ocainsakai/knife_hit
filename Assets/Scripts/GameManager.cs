using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private KnifeUI inventory;
    public LevelManager levelManager => GetComponent<LevelManager>();
    public UIManager uiManager => GetComponent<UIManager>();
    public Wood wood => FindFirstObjectByType<Wood>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } else
        {
            Destroy(gameObject);
        }
    }
   
    public void SetBoss(float speed, int bossHP)
    {
        wood.Init(speed, bossHP);
    }
    public void PauseGame()
    {
        Time.timeScale = 0f;
    }
    public void StartGame()
    {
        Time.timeScale = 1f;

        levelManager.StartLevel(0);
    }

    public void LevelComplete()
    {

        //scoreManager.AddScore(1000);  
        levelManager.StartLevel(levelManager.currentLevelIndex + 1);
    }

    public async void GameOver()
    {
        Debug.Log("Game Over! ");

        await Task.Delay(1000);
        uiManager.GameOverScene();
        //PauseGame();
        //RestartGame();

    }
    public void RestartGame()
    {
        //SoundManager.instance.PlaybtnSfx();
        GeneralFunction.LoadSceneByName("GameScene");
    }
    public void BackToHome()
    {
        //SoundManager.instance.PlaybtnSfx();
        GeneralFunction.LoadSceneByName("HomeScene");
    }
}
