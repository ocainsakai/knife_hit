using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScene;

    private void Awake()
    {
        gameOverScene.SetActive(false);
    }
    public void GameOverScene()
    {
        gameOverScene.SetActive(true);
    }
}
