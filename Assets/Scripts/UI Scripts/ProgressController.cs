using UnityEngine;
using UnityEngine.UI;

public class ProgressController : MonoBehaviour
{
    public Image progressBar;
    public QuestManager questManager;

    private void Start()
    {
        if (questManager == null)
        {
            Debug.LogError("QuestManager not found!");
        }
    }

    private void Update()
    {
        if (questManager != null)
        {
            UpdateQuestProgress();
        }
    }

    private void UpdateQuestProgress()
    {
        float questValue = questManager.questsCompleted / questManager.totalQuests;
        questValue = Mathf.Clamp01(questValue);
        progressBar.fillAmount = questValue;
    }
}
