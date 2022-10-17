using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerManager : MonoBehaviour
{
    public static bool GameOver;//static meaning other scripts can access it and bool means true or false.
    public GameObject GameOverPanel; 
    public static bool isGameStarted;
    public GameObject Startingtext;
    public static int NumberOfCoins;
    public Text coinsText;
    // Start is called before the first frame update
    void Start()
    {
        NumberOfCoins = 0;
        GameOver = false;
        Time.timeScale = 1;//brings the time scale back to 1 after the game is replayed
        isGameStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameOver)
        {
            Time.timeScale = 0;//if the gameoveris true then the time scale will stop and the game will stop
            GameOverPanel.SetActive(true);//after game is over the gameoverpanel will be true and appear
        }
        coinsText.text = "Coins: " + PlayerManager.NumberOfCoins;
        if(SwipeManager.tap)
        {
            isGameStarted = true;
            Destroy(Startingtext);
        }
    }

}