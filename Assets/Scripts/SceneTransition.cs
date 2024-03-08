using UnityEngine.SceneManagement;
public static class SceneTransition
{
    public static void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public static void LoadGameplay1()
    {
        SceneManager.LoadScene("Gameplay1");
    }
    public static void LoadGameplay2()
    {
        SceneManager.LoadScene("Gameplay2");
    }
    public static void LoadGameWin()
    {
        SceneManager.LoadScene("GameWin");
    }
    public static void LoadGameLose()
    {
        SceneManager.LoadScene("GameLose");
    }
}