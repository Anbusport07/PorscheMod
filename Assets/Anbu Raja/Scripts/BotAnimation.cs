using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotAnimation : MonoBehaviour
{
    [SerializeField]
    private float moveDistance = 1f;
    [SerializeField]
    private float moveDuration = 1f;
    // Start is called before the first frame update
    void Start()
    {
        LeanUpdate();
    }


    private void LeanUpdate()
    {
        LeanTween.moveLocalY(this.gameObject, moveDistance, moveDuration)
            .setEaseInOutSine()
            .setLoopPingPong()
            .setOnUpdate((float value)=>
            {
            });
    }
}
