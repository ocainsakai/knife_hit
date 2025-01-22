using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScene;
    [SerializeField] private UIDots uiDots;
    [SerializeField] private GameObject stageName;
    [SerializeField] private KnifeUI uiKnives;
    public void SetMaxKnives(int maxKnives)
    {
        uiKnives.UpdateKnivesMax(maxKnives);
    }
    public void UpdateDots(int dots)
    {
        uiDots.UpdateUI(dots);
    }
    public void UpdateKnives(int knivesUsed)
    {
        uiKnives.UpdateUI(knivesUsed);
    }
    public void SetStage(int stage)
    {
        stageName.GetComponent<TextMeshProUGUI>().text = "Stage " + (stage +1);
    }
    private void Awake()
    {
        gameOverScene.SetActive(false);
    }
    public void GameOverScene()
    {
        gameOverScene.SetActive(true);
    }
}
