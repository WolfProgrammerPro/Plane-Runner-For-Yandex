using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] List<GameObject> lets;
    [SerializeField] Text scoreText;
    [SerializeField] Text plusingMoneyTxt;
    bool canSpawn = true;
    bool isStopped = false;
    [SerializeField] int spawnCd;
    [SerializeField] GameObject menu;
    [SerializeField] GameObject heartImg;
    [SerializeField] GameObject heartCount;
    [SerializeField] GameObject coinImg;
    [SerializeField] GameObject coinCount;
    //[SerializeField] GameObject Score;
    [SerializeField] GameObject player;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (DataBox.Instance.score < DataBox.Instance.maxScore & canSpawn)
        {
            canSpawn = false;
            int index = UnityEngine.Random.Range(0, lets.Count);
           // print(index);
            Instantiate(lets[index], new Vector3(7, UnityEngine.Random.Range(2 * ((DataBox.Instance.statuses) / -2), 2 * ((DataBox.Instance.statuses) / 2)), 0), Quaternion.identity);
            StartCoroutine(StartSpawning());
            
        }
        if (DataBox.Instance.score >= DataBox.Instance.maxScore)
        {
            DataBox.Instance.isPlaying = false;
            if (!isStopped)
            {
                menu.SetActive(true);
                isStopped = true;
                scoreText.gameObject.SetActive(false);
                heartImg.SetActive(false);
                heartCount.SetActive(false);
                coinImg.SetActive(false);
                coinCount.SetActive(false);
                int plussing = DataBox.Instance.score / 1000;
                string coinsName = "";
                if (DataBox.Instance.language == "en")
                {
                    coinsName = " coins";
                }
                if (DataBox.Instance.language == "ru")
                {
                    coinsName = " монет";
                }
                plusingMoneyTxt.text = "+ " + plussing.ToString() + coinsName;
                DataBox.Instance.coins += plussing;
                if (DataBox.Instance.maxLevel < DataBox.Instance.currentLevel + 1)
                {
                    DataBox.Instance.maxLevel = DataBox.Instance.currentLevel + 1;
                }
                BoxCollider2D PlayerboxCollider2D = player.GetComponent<BoxCollider2D>();
                PlayerboxCollider2D.isTrigger = true;
            }
        }
        if (DataBox.Instance.isPlaying)
        {
            DataBox.Instance.score += 1;
            
        }
        string scoreTextName = "";
        if (DataBox.Instance.language == "en")
        {
            scoreTextName = "Score: ";
        }
        if (DataBox.Instance.language == "ru")
        {
            scoreTextName = "—чЄт: ";
        }
        scoreText.text = scoreTextName + DataBox.Instance.score;
    }

    IEnumerator StartSpawning()
    {
        yield return new WaitForSeconds(spawnCd);
        canSpawn = true;
    }
}
