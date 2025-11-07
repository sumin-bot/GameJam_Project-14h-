using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Player player;
    public Text playerHPTxt;
    public Text turnTxt;
    public GameObject gameOverPanel;

    void Update()
    {
        if (GameManager.Instance.isGame)
        {
            playerHPTxt.text = "HP :" + player.hp;
            turnTxt.text = "turn :" + SpawnManager.Instance.turn;
        }
        else
        {
            gameOverPanel.SetActive(true);
        }
    }
}
