using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenuController : MonoBehaviour
{
    public Slider CatchDistanceSlider;
    public Slider CatchClickSlider;

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
        }
        
        CatchDistanceSlider.value += 0.333f;
    }

    public void DecreaseCatchDistanceDifficulty()
    {
        if (Globals.catchDistanceDifficulty > 0)
        {
            Globals.catchDistanceDifficulty -= 1;
        }
        
        CatchDistanceSlider.value -= 0.333f;
    }

    public void IncreaseCatchClickDifficulty()
    {
        if (Globals.catchClickDifficulty < 3)
        {
            Globals.catchClickDifficulty += 1;
        }

        CatchClickSlider.value += 0.333f;
    }

    public void DecreaseCatchClickDifficulty()
    {
        if (Globals.catchClickDifficulty > 0)
        {
            Globals.catchClickDifficulty -= 1;
        }

        CatchClickSlider.value -= 0.333f;
    }
}
