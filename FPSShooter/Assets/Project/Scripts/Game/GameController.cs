using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
            infoText.gameObject.SetActive(true);
            infoText.text = "You win! \n Good job!";

        }
    }
}
