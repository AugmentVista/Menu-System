using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Info : MonoBehaviour
{
    public TMP_Text Speech;
    public Image InfoBackgroundPanel;

    private void Start()
    {
        Speech = ReferenceManager.infoTextDependant;
        InfoBackgroundPanel = ReferenceManager.infoBackgroundPanelDependant;
    }

    public void SetText(string text)
    {
        if (Speech != null)
        {
            Speech.text = text;
            
        }
    }
}
