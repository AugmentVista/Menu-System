using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Info : MonoBehaviour
{
    public TMP_Text Speech;
    public Image InfoBackgroundPanel;

    [SerializeField] float timerMax;
    float timer = 0;
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
    private void Update()
    {
        // Handles hiding the info box once the timer runs out
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
        InfoBackgroundPanel.enabled = false;
        Speech.enabled = false;
        infoActive = false;
    }

    public void ShowInfo(string text)
    {
        if (Speech == null) return;
        InfoBackgroundPanel.enabled = true;
        Speech.enabled = true;
        Speech.text = text;
        timer = 0;
        infoActive = true;
    }
}
