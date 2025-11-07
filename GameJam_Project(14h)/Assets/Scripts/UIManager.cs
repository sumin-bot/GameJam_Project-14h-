using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Player player;
    public Text turnTxt;
    public Text playerHPTxt;
    public Text enemyTxt;
    public GameObject gameOverPanel;

    void Update()
    {
        if (GameManager.Instance.isGame)
        {
            playerHPTxt.text = "HP :" + player.hp;
            turnTxt.text = "Turn :" + SpawnManager.Instance.turn;
            enemyTxt.text = "Enemy : " + SpawnManager.Instance.enemyNumber;
        }
        else
        {
            gameOverPanel.SetActive(true);
        }
    }
}
