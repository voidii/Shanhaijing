using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_state : MonoBehaviour
{
    // Start is called before the first frame update
    public int state = 0;//0是正常，1是加强
    public float buff_time = 10f;
    public float health = 100f;
    public Slider healthbar;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        healthbar.value = health / 100f;
        if(health < 0f){
            SceneManager.LoadScene(3);
        }
        if(state == 1){
            buff_time -= Time.deltaTime;
        }
        if(state == 1 && buff_time < 0){
            state = 0;
            buff_time = 10f;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(3);
        }
    }
    public void set_state(int i){
        state = i;
    }
    public int get_state(){
        return state;
    }
    public void arrow_attack(){
        health -= 3f;
    }
    public void powerful_attack(){
        health -= 6f;
    }
}
