using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DNABar : MonoBehaviour
{
    public Slider dnaSlider;
    public Gradient dnaGradient;
    public Image dnaFill;

    // Start is called before the first frame update
    void Start()
    {
        dnaSlider.maxValue = 10;
        //dnaSlider.value = 0;
        dnaFill.color = dnaGradient.Evaluate(0f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetDNAPoints(int DNAPoints)
    {
        dnaSlider.value = DNAPoints;

        dnaFill.color = dnaGradient.Evaluate(dnaSlider.normalizedValue);
    }
}
