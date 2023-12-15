using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.UI;

public class playerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int health;
    public Slider healthSlider;
// Start is called before the first frame update
void Start()
    {
        health = maxHealth;


        if (healthSlider == null)
        {
            Debug.LogError("Health Slider is not assigned to the PlayerHealthUI script!");
        }

        // Set the max value of the health slider
        healthSlider.maxValue = maxHealth;
        // Set the initial health value
        healthSlider.value = health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamage()
    {
        //if health is 0 or less than 0 it shows the dead message to try again or quit and you can use your mouse
        if (health <= 0)
        {
            Debug.Log(health);
            //Dead.gameObject.SetActive(true);
            //UpdateCursorState();
        }
        //if health is more than 0 it will decrease it by 1 and update the health bar
        else
        {
            // Health decreases by 1 and shows how much health is remaining
            health--;
            //healthSlider.value = health;
            //Debug.Log(health + " Goddamn you fuckin' assholes");
        }
    }
}
