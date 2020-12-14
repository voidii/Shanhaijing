using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialog_state : MonoBehaviour
{
    // Start is called before the first frame update
    public int game_state = 0; //0是开打之前，1是开打

    public GameObject dialog_panel;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.transform.tag == "Player" && game_state == 0){
            dialog_panel.SetActive(true);
        }
    }
}
