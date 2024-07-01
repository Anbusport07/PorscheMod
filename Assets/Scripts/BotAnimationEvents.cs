using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotAnimationEvents : MonoBehaviour
{
    [SerializeField]
    private Texture2D blinkTex;
    [SerializeField]
    private Texture2D resetTex;
    [SerializeField]
    private Material botMat;

    public void StartBlink()
    {
        botMat.SetTexture("_EmissionMap", blinkTex);
    }

    public void ResetBlink()
    {
        botMat.SetTexture("_EmissionMap", resetTex);
    }
}
