using UnityEngine.UI;
using UnityEngine;

public class StepsProgress : MonoBehaviour
{

    public GameObject[] chapters;
    public Text title;
    public Text description;
    public Text currentStep;

    public int index = 0;
    public Slider progressBar;

    private int totalSteps = 3;

    private void OnEnable()
    {
        ResetDataValues();
        ChapterData data = chapters[index].GetComponent<ChapterData>();
        title.text = data.title;
        description.text = data.description;       

        data.statusImage.sprite = data.selectedSprite;
        LeanTween.alpha(data.highlightImage.rectTransform, 1f, 0.5f).setEase(LeanTweenType.linear);

        float currentProgressValue = progressBar.value;
        float nextProgressValue = (float)index+1 / (float)totalSteps;

        LeanTween.value(chapters[index], currentProgressValue, nextProgressValue, 1f).setOnUpdate((float val) =>
        {           
            progressBar.value = val;
        }).setEase(LeanTweenType.linear);

        index++;

//        int v = index + 1;
        currentStep.text = "0"+index.ToString();
    }

    public void ResetDataValues()
    {
        foreach (GameObject go in chapters)
        {
            ChapterData dat = go.GetComponent<ChapterData>();
            dat.statusImage.sprite = dat.normalSprite;
            
            Color col = dat.highlightImage.color;
            col.a = 0f;
            dat.highlightImage.color = col;

            title.text = "";
            description.text = "";
        }
    }

    public void NextSteps()
    {
        if (index < totalSteps)
        {
            ResetDataValues();
           
            ChapterData data = chapters[index].GetComponent<ChapterData>();
            title.text = data.title;
            description.text = data.description;

            data.statusImage.sprite = data.selectedSprite;
            LeanTween.alpha(data.highlightImage.rectTransform, 1f, 0.5f).setEase(LeanTweenType.linear);

            float currentProgressValue = progressBar.value;            
            float nextProgressValue = (float)(index+1) / (float)totalSteps;

            LeanTween.value(chapters[index], currentProgressValue, nextProgressValue, 1f).setOnUpdate((float val) =>
            {
                //Debug.Log("Val: " + val);
                progressBar.value = val;
            }).setEase(LeanTweenType.linear);

            index++;

            currentStep.text = "0" +index.ToString();
        }
    }

    public void PreviousSteps()
    {
        Debug.Log($"PreviousSteps {index}");
        if (index > 1)
        {
            ResetDataValues();
            index--;

            ChapterData data = chapters[index - 1].GetComponent<ChapterData>();
            title.text = data.title;
            description.text = data.description;

            data.statusImage.sprite = data.selectedSprite;
            LeanTween.alpha(data.highlightImage.rectTransform, 1f, 0.5f).setEase(LeanTweenType.linear);

            float currentProgressValue = progressBar.value;
            //Debug.Log("Current: " + currentProgressValue);
            float nextProgressValue = (float)(index) / (float)totalSteps;
            //Debug.Log("NExt: " + nextProgressValue);

            LeanTween.value(chapters[index - 1], currentProgressValue, nextProgressValue, 1f).setOnUpdate((float val) =>
            {
                //Debug.Log("Val: " + val);
                progressBar.value = val;
            }).setEase(LeanTweenType.linear);
            
            currentStep.text = "0" + index.ToString();
        }
    }
}