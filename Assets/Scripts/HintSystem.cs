using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

public class HintSystem : MonoBehaviour
{
    [TextArea(3,10)]
    [SerializeField] private string[] hints;

    [SerializeField] private TMP_Text text;
    private int hintCount = 0;
    // Start is called before the first frame update
    
    public void NextHint()
    {
        if(hints.Count() >= hintCount)
        {
            text.text = hints[hintCount];
            hintCount++;
        }
    }
}
