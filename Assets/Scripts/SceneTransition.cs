using UnityEngine.SceneManagement;
public static class SceneTransition
{
    public static void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public static void LoadGamePlay1()
    {
        SceneManager.LoadScene("GamePlay1");
    }
    public static void LoadGamePlay2()
    {
        SceneManager.LoadScene("GamePlay2");
    }
    public static void LoadGameWin()
    {
        SceneManager.LoadScene("GameWin");
    }
    public static void LoadGameOver()
    {
        SceneManager.LoadScene("GameLose");
    }
}