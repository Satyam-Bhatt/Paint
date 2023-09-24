using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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
    [HideInInspector]
    public int guitarColorActivtor = 0;
    [HideInInspector]
    public int gunManColorActivator = 0;
    [HideInInspector]
    public int snakeColorActivator = 0;
    [HideInInspector]
    public int snakeToRope_Activator = 0;
    [HideInInspector]
    public int houseActivator = 0;

    [SerializeField] private GameObject mainPathColorHalf;
    [SerializeField] private GameObject pathColor_Up;
    [SerializeField] private GameObject mainPathColor_Full;
    [SerializeField] private GameObject pathColor_Left;
    [SerializeField] private GameObject pathColor_Right;

    [SerializeField] private GameObject knightColor;
    [SerializeField] private GameObject GuitarGirlColor;
    [SerializeField] private GameObject gunManColor;
    [SerializeField] private GameObject snakeColor;
    [SerializeField] private GameObject snakeToRope_Color;
    [SerializeField] private GameObject house_Color;

    [Header("Paint Strokes")]
    [SerializeField] private GameObject parent;

    private bool houseChecker = false;

    // Start is called before the first frame update
    void Awake()
    {
        mainPathColorHalf.SetActive(false);
        pathColor_Up.SetActive(false);
        mainPathColor_Full.SetActive(false);
        pathColor_Left.SetActive(false);
        pathColor_Right.SetActive(false);

        knightColor.SetActive(false);   
        GuitarGirlColor.SetActive(false);
        gunManColor.SetActive(false);
        snakeColor.SetActive(false);
        snakeToRope_Color.SetActive(false);
        house_Color.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(blackCounter == 6)
        {
            mainPathColorHalf.SetActive(true);
            Destroy(GameObject.Find("MainRoad"));
            blackCounter++;

            DestroyMeshes();
        }

        if(blackCounter_Up == 12)
        {
            pathColor_Up.SetActive(true);
            Destroy(GameObject.Find("Path_Up"));
            blackCounter_Up++;

            DestroyMeshes();
        }

        if(brownCounter == 10)
        {
            mainPathColor_Full.SetActive(true);
            Destroy(GameObject.Find("ExceptRoad"));
            brownCounter++;

            DestroyMeshes();
        }

        if(blackCounter_Left == 6)
        {
            pathColor_Left.SetActive(true);
            Destroy(GameObject.Find("Path_Left"));
            blackCounter_Left++;

            DestroyMeshes();
        }

        if(blackCounter_Right == 6)
        {
            pathColor_Right.SetActive(true);
            Destroy(GameObject.Find("Path_Right"));
            blackCounter_Right++;

            DestroyMeshes();
        }

        if(knighColorActivator >= 6  && knighColorActivator <= 20)
        {
            knightColor.SetActive(true);
            knighColorActivator = 40;

            DestroyMeshes();
        }

        if(guitarColorActivtor >= 1 && guitarColorActivtor <= 20) 
        {
            GuitarGirlColor.SetActive(true);
            guitarColorActivtor = 40;

            DestroyMeshes();
        }

        if(gunManColorActivator >= 1  && gunManColorActivator <= 20)
        {
            gunManColor.SetActive(true);
            gunManColorActivator = 40;

            DestroyMeshes();
        }

        if(snakeColorActivator >= 1 && snakeColorActivator <= 20)
        {
            snakeColor.SetActive(true);
            snakeColorActivator = 40;

            DestroyMeshes();
        }

        if(snakeToRope_Activator >= 1 && snakeToRope_Activator <= 10 && houseChecker)
        {
            snakeToRope_Color.SetActive(true);
            snakeToRope_Activator = 40;

            DestroyMeshes();
        }

        if(houseActivator >= 6  && houseActivator <=20)
        {
            house_Color.SetActive(true);
            houseChecker = true;
            houseActivator = 40;

            DestroyMeshes();
        }
    }

    public void DestroyMeshes()
    {
        for(int i = parent.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(parent.transform.GetChild(i).gameObject);
        }
    }
}
