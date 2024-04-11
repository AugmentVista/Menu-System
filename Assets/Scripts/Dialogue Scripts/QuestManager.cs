using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class QuestManager : MonoBehaviour
{
    public GameObject DialogueParent;
    public Image DialogueBackground;
    public TextMeshProUGUI Dialogue;

    public static bool isTalking = false;
    public static bool SecondCondition = false;
    public static bool ThirdCondition = false;

    private void Start()
    {
        DialogueParent.SetActive(false);
    }


}
