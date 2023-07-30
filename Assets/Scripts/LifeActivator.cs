using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeActivator : MonoBehaviour
{
    [HideInInspector]
    public int blackCounter = 0;

    [SerializeField] private GameObject mainPathColorHalf;

    // Start is called before the first frame update
    void Awake()
    {
        mainPathColorHalf.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(blackCounter == 6)
        {
            mainPathColorHalf.SetActive(true);
            Destroy(GameObject.Find("MainRoad"));
        }
    }
}
