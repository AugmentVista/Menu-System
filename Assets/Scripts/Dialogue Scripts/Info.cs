using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Info : MonoBehaviour
{
    public TMP_Text Speech;
    public Image InfoBackgroundPanel;

    // new code from rowan
    // how long should info stay on screen for? assign in inspector
    [SerializeField] float timerMax;
    // this variable counts up and tracks when the info box should disappear
    float timer = 0;
    // this boolean tracks whether or not the info box is on the screen
    bool infoActive = false;

    private void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void Start()
    {
        Speech = ReferenceManager.infoTextDependant;
        InfoBackgroundPanel = ReferenceManager.infoBackgroundPanelDependant;
    }

    // new code from rowan
    private void Update()
    {
        // this code handles hiding the info box after the timer runs out
        if (infoActive)
        {
            timer += Time.deltaTime;
            if (timer >= timerMax)
                HideInfo();
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        HideInfo();
    }

    public void HideInfo()
    {
        // new code from rowan
        InfoBackgroundPanel.enabled = false;
        Speech.enabled = false;
        infoActive = false;
    }

    public void ShowInfo(string text)
    {
        if (Speech == null) return;
        Debug.Log(text);
        InfoBackgroundPanel.enabled = true;
        Speech.enabled = true;
        Speech.text = text;
        timer = 0;
        infoActive = true;
    }
}
