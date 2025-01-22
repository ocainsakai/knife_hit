using System.Threading.Tasks;
using UnityEngine;

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
    private void Start()
    {
        if (levelManager == null) return;
        Time.timeScale = 1f;
        StartLevel(0);
    }
    public void SetBoss(float speed, int bossHP)
    {
        wood.Init(speed, bossHP, 2, 2);
    }
    public void PauseGame()
    {
        Time.timeScale = 0f;
    }
    public void UpdateLevel(float speed, int number, int level)
    {
        SetBoss(speed, number);
        uiManager.SetMaxKnives(number);
        uiManager.UpdateDots(level);
        uiManager.SetStage(level);
    }
    public void StartLevel(int level)
    {
        Time.timeScale = 1f;
        LevelData data = levelManager.InitLevel(level);
        UpdateLevel(data.bossRotationSpeed, data.knivesRequired, level);
    }
    public void NextLevel()
    {
        StartLevel(levelManager.currentLevelIndex + 1);
    }
    public async void GameOver()
    {
        Debug.Log("Game Over! ");

        await Task.Delay(500);
        uiManager.GameOverScene();
        
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
