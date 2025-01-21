using System;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public KnifeHolder knifeHolder => FindFirstObjectByType<KnifeHolder>();
    [SerializeField] private KnifeUI ui => FindFirstObjectByType<KnifeUI>();

    [SerializeField] private LevelConfigs levelConfig;
    public int currentLevelIndex = 0;
    public int currentKnivesUsed = 0;
    private bool isEmptyKnife =>
        currentKnivesUsed == levelConfig.levels[currentLevelIndex].knivesRequired;

    public event Action newLevel;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
    private void Start()
    {
        StartLevel(0);
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isEmptyKnife && !knifeHolder.isProcessing)
        {
            OnKnifeHit();
        } 
    }
    
    public void StartLevel(int levelIndex)
    {
        Debug.Log(" level." + levelIndex);
        currentLevelIndex = levelIndex;
        currentKnivesUsed = 0;
        knifeHolder.DestroyKnives();

        LevelData level = levelConfig.levels[currentLevelIndex];
        GameManager.instance.SetBoss(level.bossRotationSpeed, level.knivesRequired);
        newLevel?.Invoke();
        ui.UpdateKnivesMax(level.knivesRequired);
    }

    public void OnKnifeHit()
    {
        knifeHolder.Fire();
        currentKnivesUsed++;
        ui.UpdateUI(currentKnivesUsed);

    }
}
