using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public void LoadMainMenu()
    {
        SceneTransition.LoadMainMenu();
    }
    public void LoadGameplay1()
    {
        SceneTransition.LoadGameplay1();
    }
    public void LoadGameplay2()
    {
        SceneTransition.LoadGameplay2();
    }
    public void LoadEndGame()
    {
        SceneTransition.LoadEndGame();
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
        }
    }
    void PlayerToSpawnPoint() { }
}
