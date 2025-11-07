using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Player player;
    public Text playerHPTxt;

    void Update()
    {
        playerHPTxt.text = "HP :" + player.hp;
    }
}
