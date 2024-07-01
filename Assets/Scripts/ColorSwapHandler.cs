using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSwapHandler : MonoBehaviour
{
    [SerializeField]
    private Color defaultColor;

    [SerializeField]
    private Color[] switchColor;

    [SerializeField]
    private GameObject[] textGO;

    [SerializeField]
    private AudioSource textAudioSource;
    [SerializeField] 
    private AudioClip[] textClip;

    [SerializeField]
    private Material carBodyMat;

    private int lastIndex;

    private float baseValue = -1.5f;

    private float currentAudioLength = 0;

    [SerializeField]
    private GameObject[] hotSpotGO;
    private bool hotSpotClicked = false;

    private void Start()
    {
        lastIndex = -1;
        defaultColor = carBodyMat.GetColor("_Color01");
    }

    private void OnDisable()
    {
        carBodyMat.color = defaultColor;
    }

    public void ColorChange_Body(int mIndex)
    {

        if (lastIndex == mIndex)
            return;

        carBodyMat.SetColor("_Color02", switchColor[mIndex]);

        if (lastIndex != -1)
        {
            carBodyMat.SetColor("_Color01", switchColor[lastIndex]);
        }

        LeanTween.value(this.gameObject, OnColorUpdate, -1.5f, 3, 1f);

        lastIndex = mIndex;

        //DisplayTextGO(mIndex);
    }

    private void OnColorUpdate(float deltaTime, float value)
    {
        var result = baseValue + (5 * value);
        carBodyMat.SetFloat("_ColorDiffusion", result);
    }

    public void DisplayTextGO(int index)
    {
        CancelInvoke(nameof(DisplayText));
        textAudioSource.Stop();

        for (int i = 0; i < textGO.Length; i++)
        {
            textGO[i].SetActive(i == index);
        }

        textAudioSource.clip = textClip[index];

        currentAudioLength = textAudioSource.clip.length;

        textAudioSource.Play();

        Invoke(nameof(DisplayText), currentAudioLength);
    }

    private void DisplayText()
    {
        for (int i = 0; i < textGO.Length; i++)
        {
            textGO[i].SetActive(false);
        }

        textAudioSource.Stop();
    }

    public void DisplayHotSpot()
    {
        hotSpotClicked = !hotSpotClicked;

        /*for (int i = 0; i < hotSpotGO.Length; ++i)
        {
            LeanTween.scale(hotSpotGO[i], (hotSpotClicked) ? Vector3.one : Vector3.zero, 1.5f);
        }*/

        if (hotSpotClicked == false)
            DisplayText();

        StartCoroutine(StartAnimation());
    }

    private IEnumerator StartAnimation()
    {
        for (int i = 0; i < hotSpotGO.Length; ++i)
        {
            LeanTween.scale(hotSpotGO[i], (hotSpotClicked) ? new Vector3(0.05f, 0.05f, 0.05f) : Vector3.zero, 0.5f);

            yield return new WaitForSeconds(0.2f);
        }
    }
}
