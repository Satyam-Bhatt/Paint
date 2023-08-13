using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeActivator : MonoBehaviour
{
    [HideInInspector]
    public int blackCounter = 0;
    [HideInInspector]
    public int blackCounter_Up = 0;
    [HideInInspector]
    public int brownCounter = 0;
    [HideInInspector]
    public int blackCounter_Left = 0;
    [HideInInspector]
    public int blackCounter_Right = 0;

    [HideInInspector]
    public int knighColorActivator = 0;

    [SerializeField] private GameObject mainPathColorHalf;
    [SerializeField] private GameObject pathColor_Up;
    [SerializeField] private GameObject mainPathColor_Full;
    [SerializeField] private GameObject pathColor_Left;
    [SerializeField] private GameObject pathColor_Right;

    [SerializeField] private GameObject knightColor;

    // Start is called before the first frame update
    void Awake()
    {
        mainPathColorHalf.SetActive(false);
        pathColor_Up.SetActive(false);
        mainPathColor_Full.SetActive(false);
        pathColor_Left.SetActive(false);
        pathColor_Right.SetActive(false);

        knightColor.SetActive(false);   
    }

    // Update is called once per frame
    void Update()
    {
        if(blackCounter == 6)
        {
            mainPathColorHalf.SetActive(true);
            Destroy(GameObject.Find("MainRoad"));
            blackCounter++;
        }

        if(blackCounter_Up == 12)
        {
            pathColor_Up.SetActive(true);
            Destroy(GameObject.Find("Path_Up"));
            blackCounter_Up++;
        }

        if(brownCounter == 10)
        {
            mainPathColor_Full.SetActive(true);
            Destroy(GameObject.Find("ExceptRoad"));
            brownCounter++;
        }

        if(blackCounter_Left == 6)
        {
            pathColor_Left.SetActive(true);
            Destroy(GameObject.Find("Path_Left"));
            blackCounter_Left++;
        }

        if(blackCounter_Right == 6)
        {
            pathColor_Right.SetActive(true);
            Destroy(GameObject.Find("Path_Right"));
            blackCounter_Right++;
        }

        if(knighColorActivator == 6)
        {
            knightColor.SetActive(true);
            knighColorActivator++;
        }
    }
}
