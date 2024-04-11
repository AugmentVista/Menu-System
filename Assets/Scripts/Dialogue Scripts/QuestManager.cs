using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class QuestManager : MonoBehaviour
{
    public GameObject DialogueParent;
    public Image DialogueBackground;
    public TextMeshProUGUI Dialogue;

    public static bool isTalking = false;
    public static bool Thing2 = false;
    public static bool Thing3 = false;

    private void Start()
    {
        DialogueParent.SetActive(false);
    }


}
