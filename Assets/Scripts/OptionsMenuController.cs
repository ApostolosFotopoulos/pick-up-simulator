using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenuController : MonoBehaviour
{
    public Slider CatchDistanceSlider;
    public Slider CatchClickSlider;
    public TextMeshProUGUI distanceText;
    public TextMeshProUGUI clicksText;

    void Start()
    {
        if (Globals.catchDistanceDifficulty == 0)
        {
            CatchDistanceSlider.value = 0f;
        }
        else if (Globals.catchDistanceDifficulty == 1)
        {
            CatchDistanceSlider.value = 0.333f;
        }
        else if (Globals.catchDistanceDifficulty == 2)
        {
            CatchDistanceSlider.value = 0.666f;
        }
        else
        {
            CatchDistanceSlider.value = 1f;
        }

        if (Globals.catchClickDifficulty == 0)
        {
            CatchClickSlider.value = 0f;
        }
        else if (Globals.catchClickDifficulty == 1)
        {
            CatchClickSlider.value = 0.333f;
        }
        else if (Globals.catchClickDifficulty == 2)
        {
            CatchClickSlider.value = 0.666f;
        }
        else
        {
            CatchClickSlider.value = 1f;
        }
    }

    public void IncreaseCatchDistanceDifficulty()
    {
        
        if (Globals.catchDistanceDifficulty < 3)
        {
            Globals.catchDistanceDifficulty += 1;
            distanceText.text = (Globals.catchDistanceDifficulty + 1).ToString();
        }
        
        CatchDistanceSlider.value += 0.333f;
    }

    public void DecreaseCatchDistanceDifficulty()
    {
        if (Globals.catchDistanceDifficulty > 0)
        {
            Globals.catchDistanceDifficulty -= 1;
            distanceText.text = (Globals.catchDistanceDifficulty + 1).ToString();
        }
        
        CatchDistanceSlider.value -= 0.333f;
    }

    public void IncreaseCatchClickDifficulty()
    {
        if (Globals.catchClickDifficulty < 3)
        {
            Globals.catchClickDifficulty += 1;
            clicksText.text = (Globals.catchClickDifficulty + 1).ToString();
        }

        CatchClickSlider.value += 0.333f;
    }

    public void DecreaseCatchClickDifficulty()
    {
        if (Globals.catchClickDifficulty > 0)
        {
            Globals.catchClickDifficulty -= 1;
            clicksText.text = (Globals.catchClickDifficulty + 1).ToString();
        }

        CatchClickSlider.value -= 0.333f;
    }
}
