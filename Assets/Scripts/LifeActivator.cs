using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeActivator : MonoBehaviour
{
    [HideInInspector]
    public int blackCounter = 0;
    [HideInInspector]
    public int blackCounter_Up = 0;

    [SerializeField] private GameObject mainPathColorHalf;
    [SerializeField] private GameObject pathColor_Up;

    // Start is called before the first frame update
    void Awake()
    {
        mainPathColorHalf.SetActive(false);
        pathColor_Up.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(blackCounter == 6)
        {
            mainPathColorHalf.SetActive(true);
            Destroy(GameObject.Find("MainRoad"));
        }

        if(blackCounter_Up == 12)
        {
            pathColor_Up.SetActive(true);
            Destroy(GameObject.Find("Path_Up"));
        }
    }
}
