using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstatiateatPalm : MonoBehaviour
{
    public GameObject HoloCar;
    public Transform instantiatePos;

    private GameObject temp;

    /*// Update is called once per frame
    void Update()
    {
        if(instantiatePos != null)
        {
            Instantiate(HoloCar, instantiatePos.transform.position, Quaternion.identity);
        }
    }*/

    public void CallFunction()
    {
        if (instantiatePos != null)
        {
            temp =  Instantiate(HoloCar, instantiatePos.transform.position, Quaternion.identity);
            temp.SetActive(true);
        }
    }

    public void DestroyFun()
    {
        Destroy(temp);
    }
}
