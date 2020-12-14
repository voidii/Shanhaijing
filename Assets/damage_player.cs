﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damage_player : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform damageText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerExit2D(Collider2D other){
        if(other.transform.tag == "Player"){
            Transform popup = Instantiate(damageText, transform.position, Quaternion.identity);
            Damage_POP damage_pop = popup.GetComponent<Damage_POP>();
            GameObject player = GameObject.Find("Knight(Clone)");
            Player_state health_script = player.GetComponent<Player_state>();
            health_script.arrow_attack();
            return;
        }
    }
}
