using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressionBar {

    public int current;
    public int max;

    public Vector3 position;

    public Slider bar;

    public Image background;
    public Image fill;

    public Color maxColor;
    public Color minColor;


    public ProgressionBar(int max, Slider slider)
    {
        this.max = max;
        this.current = max;
        bar = Object.Instantiate(slider);

        background = bar.GetComponentsInChildren<Image>()[0];
        fill = bar.GetComponentsInChildren<Image>()[1];

        UpdateBar();
    }
    
    public void UpdateBar() {
        bar.value = (float)current / (float)max;
        fill.color = Color.Lerp(maxColor, minColor, (float)current / (float)max);
    }
    
    public int Inc(int amount)
    {
        if (current + amount > max)
            current = max;
        else if (current + amount < 0)
            current = 0;
        else current = current + amount;

        UpdateBar();
        return current;
    }

    public int Dec(int amount) {
        return Inc(-amount);
    }
}
