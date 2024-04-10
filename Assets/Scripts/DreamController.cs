using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DreamController : MonoBehaviour
{
    //private float hope;
    //private bool SpillOver = false;
    //public GameObject hopeBar;
    //public TMP_Dropdown hopeBarDropdown;
    //private void Start()
    //{
    //    Game_Manager.OnGamePlay1 += ResetScene;
    //    ResetScene();
    //}
    //void ResetScene()
    //{
    //    hope = 3000;
    //    SpillOver = false;
    //}

    //public void UpdateHope()
    //{
    //    switch (hope)
    //    {
    //        case 0:
    //            hopeBarDropdown.value = 0;
    //            Lose = true;
    //            break;
    //        case 3000:
    //            hopeBarDropdown.value = 1;
    //            break;
    //        case 5000:
    //            hopeBarDropdown.value = 2;
    //            break;
    //        case 7000:
    //            hopeBarDropdown.value = 3;
    //            break;
    //        case 10000:
    //            hopeBarDropdown.value = 4;
    //            break;
    //        case 15000:
    //            hopeBarDropdown.value = 5;
    //            break;
    //        case 20000:
    //            hopeBarDropdown.value = 6;
    //            Win = true;
    //            break;
    //    }
    //}

    //private void Update()
    //{
    //    hopeBar.GetComponent<Image>().fillAmount = hope / 20000;
    //    UpdateHope();
    //}
    //public override void CheckWinClause()
    //{
    //    if (Win)
    //    {
    //        Singleton.instance.GetComponent<Game_Manager>().gameState = Game_Manager.GameState.GameWin;
    //        Singleton.instance.GetComponent<Game_Manager>().ChangeGameState(Game_Manager.GameState.GameWin);
    //        Debug.Log("This is where I would put my win screen if I had one");
    //    }
    //    else if (Lose)
    //    {
    //        Singleton.instance.GetComponent<Game_Manager>().gameState = Game_Manager.GameState.GameOver;
    //        Singleton.instance.GetComponent<Game_Manager>().ChangeGameState(Game_Manager.GameState.GameOver);
    //        Debug.Log("This is where I would put my lose screen if I had one");
    //    }
    //    else { return; }
    //}
    //void LoseHope()
    //{
    //    hope --;
    //    Debug.Log("Hope is " + hope);
    //}
    //public void Changehopeup(float amount)
    //{
    //    hope += amount;
    //    hope = Mathf.Clamp(hope, 0f, 20000.0f);
    //}
}