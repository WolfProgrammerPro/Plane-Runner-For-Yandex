using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBox : MonoBehaviour
{
    
    public static DataBox Instance { get; private set; }
    public int currentLevel = 1;
    public float speed = 1;
    public int statuses = 3;
    public int deathes;
    public int score;
    public int maxScore;
    public int maxHealth;
    public int coinMultiplier;
    public int coins;
    public int maxLevel;
    public string language = "en";
    public bool isPlaying = true;
    public List<int> levelScores = new List<int>() { 0, 4500, 5500, 6000, 100 };
    public List<int> levelMaxHealth = new List<int>() { 0, 3, 4, 4, 1 };
    public List<float> levelSpeed = new List<float>() { 0, 3, 4, 4, 1};
    public bool isComputer = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
