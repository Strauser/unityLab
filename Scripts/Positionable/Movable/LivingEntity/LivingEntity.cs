using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LivingEntity : MovableObject {

    public Health health;
    public Slider sliderTemplate;

    public void StartWithParameter(MovementManager mv, int maxHealth) {

        base.StartWithParameter(mv);

        health = new Health(maxHealth, sliderTemplate);

        Start();
    }
    // Use this for initialization
    new void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public int TakeDamage(int damage) {
        if(health.Dec(damage) <= 0)
            Debug.Log("you are dead");

        return health.current;
    }

    public int Heal(int amount)
    {
        return health.Inc(amount);
    }
}
