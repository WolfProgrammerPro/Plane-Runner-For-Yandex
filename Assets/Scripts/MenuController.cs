using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] List<Text> translatedTextes = new List<Text>();
    [SerializeField] List<string> EnTranslate =  new List<string>();
    [SerializeField] List<string> RuTranslate = new List<string>();
    void Start()
    {
        Translate(DataBox.Instance.language);
    }

   public void LoadLevel(int level)
    {
        
        if (level <= DataBox.Instance.maxLevel)
        {
            SceneManager.LoadScene(level);
            
            DataBox.Instance.score = 0;
            DataBox.Instance.maxScore = DataBox.Instance.levelScores[level];
            DataBox.Instance.maxHealth = DataBox.Instance.levelMaxHealth[level];
            DataBox.Instance.speed = DataBox.Instance.levelSpeed[level];
            DataBox.Instance.isPlaying = true;
            DataBox.Instance.score = 0;
            DataBox.Instance.currentLevel = level;
        }
    }
    public void OpenFrame(GameObject frame)
    {
        frame.SetActive(true);
    }
    public void CloseFrame(GameObject frame)
    {
        frame.SetActive(false);
    }
    public void Translate(string language)
    {
        for (int i = 0; i < translatedTextes.Count; i++)
        {
            if (language == "en")
            {
                translatedTextes[i].text = EnTranslate[i];
            }
            if (language == "ru")
            {
                translatedTextes[i].text = RuTranslate[i];
            }
            DataBox.Instance.language = language;
        }
    }
}
