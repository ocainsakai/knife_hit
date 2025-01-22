using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewLevelConfigs", menuName = "Game/LevelConfigs")]
public class LevelConfigs : ScriptableObject
{
    public List<LevelData> levels;
}

[System.Serializable]
public class LevelData
{
    public LevelType levelType;
    public int knivesRequired;     
    public float bossRotationSpeed;
}
public enum LevelType
{
    Stage,
    Boss
}