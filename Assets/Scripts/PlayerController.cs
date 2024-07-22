using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Rigidbody2D rigidbody2D;
    BoxCollider2D boxCollider2D;

    [SerializeField] float jumpPower;
    [SerializeField] int maxUpperStatus;
    [SerializeField] int maxLowerStatus;
    [SerializeField] int health;
    [SerializeField] Text hpText;
    [SerializeField] Text cashText;
    [SerializeField] GameObject menu;
    [SerializeField] bool isDead;
    [SerializeField] GameObject particles;
    [SerializeField] GameObject buttonUp;
    [SerializeField] GameObject buttonDown;
    int status;
    
    void Start()
    {
        isDead = false;
        health = DataBox.Instance.maxHealth;
        // rigidbody2D = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        maxUpperStatus = (DataBox.Instance.statuses - 1) / 2;
        maxLowerStatus = (DataBox.Instance.statuses - 1) / -2;
        ShowHP(health);
        ShowCash();
        if (DataBox.Instance.isComputer == false)
        {
            buttonUp.SetActive(true);
            buttonDown.SetActive(true);
        }
        else
        {
            buttonUp.SetActive(false);
            buttonDown.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.UpArrow) & isDead == false & DataBox.Instance.isPlaying|| Input.GetKeyDown(KeyCode.W) & isDead == false & DataBox.Instance.isPlaying)
        {
            ToUp();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) & isDead == false & DataBox.Instance.isPlaying || Input.GetKeyDown(KeyCode.S) & isDead == false & DataBox.Instance.isPlaying)
        {
            ToDown();
        }



    }
    public void ToUp()
    {
        if (status < maxUpperStatus)
        {
            transform.position += new Vector3(0, jumpPower, 0);
            status++;
        }
    }
    public void ToDown()
    {
        if (status > maxLowerStatus)
        {
            transform.position -= new Vector3(0, jumpPower, 0);
            status-=1;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.transform.rotation = Quaternion.identity;
        if (collision.gameObject.CompareTag("KillObject") & isDead == false)
        {
            particles.SetActive(true);
            StartCoroutine(StopParticles());
            health -= collision.gameObject.GetComponent<TrassObjectController>().minusingHP;
            Destroy(collision.gameObject);
            
            if (health <= 0)
            {
                Death();
            }
            ShowHP(health);
        }
        if (collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            DataBox.Instance.coins += 1 * DataBox.Instance.coinMultiplier;
            ShowCash();
        }
    }

    void ShowHP(int hp)
    {
        hpText.text = hp.ToString();
    }
    void Death()
    {
        DataBox.Instance.isPlaying = false;
        menu.SetActive(true);
        isDead = true;
        boxCollider2D.isTrigger = true;
        hpText.gameObject.SetActive(false);
        DataBox.Instance.deathes++;
        
       // Time.timeScale = 0;
    }
    IEnumerator StopParticles()
    {
        yield return new WaitForSeconds(1);
        particles.SetActive(false);
    }
    public void ShowCash()
    {
        cashText.text = DataBox.Instance.coins.ToString();
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(DataBox.Instance.currentLevel);
        DataBox.Instance.isPlaying = true;
        isDead = false;
        boxCollider2D.isTrigger = false;
        DataBox.Instance.score = 0;
    }
}
