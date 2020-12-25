using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [Header("Game")]
    public Player player;
    public GameObject enemyContainer;
    [Header("UI")]
    public Text healthText; 
    public Text ammoText;
    public Text enemyText;
    public Text infoText;
    private float resetTimer = 3f;
    private bool gameOver = false;



    private int initialEnemyCount;
    // Start is called before the first frame update
    void Start()
    {
        initialEnemyCount = enemyContainer.GetComponentsInChildren<Enemy>().Length;
        infoText.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        healthText.text = "Health: " + player.Health;
        ammoText.text = "Ammo: " + player.Ammo;
        int killedEnemies = 0;
        foreach(Enemy enemy in enemyContainer.GetComponentsInChildren<Enemy>())
        {
            if (enemy.Killed == true)
            {
                killedEnemies++;
            }
        }
        enemyText.text = "Enemies: " + (initialEnemyCount - killedEnemies);

        if((initialEnemyCount - killedEnemies) == 0)
        {
            gameOver = true;
            infoText.gameObject.SetActive(true);
            infoText.text = "You win! ~(^-^)~ \n Good job!";

        }
        if (player.Killed == true)
        {
            gameOver = true;
            infoText.gameObject.SetActive(true);
            infoText.text = "You lose ಥ_ಥ \n Try again!";
        }
        if(gameOver == true)
        {
            resetTimer -= Time.deltaTime;
            if (resetTimer <= 0)
            {
                SceneManager.LoadScene("Menu");
            }
        }
    }
}
