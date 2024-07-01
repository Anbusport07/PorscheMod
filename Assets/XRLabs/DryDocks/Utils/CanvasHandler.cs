using UnityEngine;

public class CanvasHandler : MonoBehaviour
{
    public static CanvasHandler instance;

    [System.Serializable]
    public class Screens
    {
        public string name;
        public GameObject UI;
    }

    public Screens[] screens;

    private void Awake()
    {
        instance = this;
    }

    public void EnableRequestedScreen(string name)
    {
        foreach (var screen in screens)
        {
            screen.UI.SetActive(false);
        }
        
        foreach (var screen in screens)
        {
            if(screen.name == name)
                screen.UI.SetActive(true);
        }
    }
}
