using UnityEngine;
using TMPro;

public class StepProcess : MonoBehaviour
{
    public TMP_Text logText;
    private int count = 0;

    public void IncreamentStep()
    {
        count++;
        if (count < 15)
        {
            logText.text = "Step " + count.ToString();
        }
    }

    public void DecreamentStep()
    {
        count--;
        if (count > 0)
        {
            logText.text = "Step " + count.ToString();
        }
    }
}
