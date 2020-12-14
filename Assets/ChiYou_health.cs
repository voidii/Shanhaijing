using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChiYou_health : MonoBehaviour
{
    // Start is called before the first frame update
    public int health = 1000;
    public Slider healthbar;
    void Start()
    {
        healthbar.value = health / 1000f;
    }

    // Update is called once per frame
    void Update()
    {
        healthbar.value = health / 1000f;
        if(health < 0){
            Debug.Log("Chi You Dead");
        }
    }

    public void sword_attack(){
        health -= 31;
    }
    public void powerful_attack(){
        health -= 9;
    }
}
