using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Health : ProgressionBar {

    public Health(int maxHealth, Slider slider) : base(maxHealth, slider)
    {
        background.color = new Color(70, 20, 20);        
        maxColor = Color.red;
        minColor = Color.green;

        UpdateBar();
    }

}
