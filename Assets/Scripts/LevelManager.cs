using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public KnifeHolder knifeHolder => FindFirstObjectByType<KnifeHolder>();

    [SerializeField] private LevelConfigs levelConfig;
    public int currentLevelIndex = 0;
    public int currentKnivesUsed = 0;
    private bool isEmptyKnife =>
        currentKnivesUsed == levelConfig.levels[currentLevelIndex].knivesRequired;


    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isEmptyKnife && !knifeHolder.isProcessing)
        {
            OnKnifeHit();
        } 
    }
    
    public LevelData InitLevel(int levelIndex)
    {
        Debug.Log(" level." + levelIndex);
        currentLevelIndex = levelIndex;
        currentKnivesUsed = 0;
        DestroyItem();
        return levelConfig.levels[currentLevelIndex];
    }

    private void DestroyItem()
    {
        List<ObjAbstract> items = new List<ObjAbstract>();
        items.AddRange(FindObjectsByType<ObjAbstract>(FindObjectsSortMode.None));
        foreach (ObjAbstract item in items)
        {
            Destroy(item.gameObject);
        }
    }
    public void OnKnifeHit()
    {
        knifeHolder.Fire();
        currentKnivesUsed++;
        Debug.Log("knive used " + currentKnivesUsed);
        GameManager.instance.uiManager.UpdateKnives(currentKnivesUsed);
    }
}
