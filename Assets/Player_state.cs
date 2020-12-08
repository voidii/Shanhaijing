using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_state : MonoBehaviour
{
    // Start is called before the first frame update
    public int state = 0;//0是正常，1是加强
    public float buff_time = 10f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(state == 1){
            buff_time -= Time.deltaTime;
        }
        if(state == 1 && buff_time < 0){
            state = 0;
            buff_time = 10f;
        }
    }
    public void set_state(int i){
        state = i;
    }
    public int get_state(){
        return state;
    }
}
