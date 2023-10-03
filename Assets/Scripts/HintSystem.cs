using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

public class HintSystem : MonoBehaviour
{
    [SerializeField] private string[] hintNumber;
    [TextArea(3,10)]
    [SerializeField] private string[] hints;

    [SerializeField] private TMP_Text hintNumber_Text;
    [SerializeField] private TMP_Text text;

    private int hintCount = 0;
    // Start is called before the first frame update

    private void Start()
    {
        hintNumber_Text.text = hintNumber[0];
        text.text = hints[0];
    }
    public void NextHint()
    {
        if(hints.Count() > hintCount)
        {
            ++hintCount;
            if(hints.Count() > hintCount)
            {
                hintNumber_Text.text = hintNumber[hintCount];
                text.text = hints[hintCount];
            }
            else
            {
                hintCount = hints.Count() - 1;
            }
            
        }
    }

    public void PreviousHint()
    {
        if(hintCount > 0)
        {            
            hintNumber_Text.text = hintNumber[hintCount - 1];
            text.text = hints[hintCount - 1];
            --hintCount;
        }
        else
        {
            hintCount = 0;
        }
    }
}
