using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Player player;
    public Text playerHPTxt;
    public Text turnTxt;

    void Update()
    {
        playerHPTxt.text = "HP :" + player.hp;
        turnTxt.text = "turn :" + SpawnManager.Instance.turn;
    }
}
