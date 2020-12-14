using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game_instrcution : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject instruction_panel;
    public int ins_state = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F)){
            instruction_panel.SetActive(false);
            GameObject game_control = GameObject.Find("Dialog_start");
            dialog_state st = game_control.GetComponent<dialog_state>();
            st.game_state = 1;
        }
        
    }
}
