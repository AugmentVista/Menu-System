using UnityEngine;
using TMPro;

public class Info : MonoBehaviour
{
    public TMP_Text Speech;
    public float displayDuration;
    private float timer;

    void Start()
    {
        TimeTextReset();
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            TimeTextReset();
        }
    }

    public void SetText(string text)
    {
        if (Speech != null)
        {
            Speech.text = text;
            timer = displayDuration;
        }
    }

    private void TimeTextReset()
    {
        timer = 0;
        if (Speech != null)
        {
            Speech.text = "";
        }
    }
}
