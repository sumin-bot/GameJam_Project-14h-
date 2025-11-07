using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject gameOverPanel;

    public void Restart()
    {
        SpawnManager.Instance.Initialize();
        GameManager.Instance.Initialize();
        gameOverPanel.SetActive(false);
    }
}
