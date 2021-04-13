using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "ScriptableObjects/GameSettings")]
public  class GameSettings : ScriptableObject
{

    [SerializeField] private int levelCount;

    public int LevelCount { get { return levelCount; }  private set { levelCount = value; } }
}
