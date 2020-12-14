using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChiYou_attack_2 : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject player;
    float cd;
    Animator att;
    public float Damagae_count_down = 2f;
    Collider2D coll;
    public Transform damageText;
    GameObject game_control;
    dialog_state st;
    void Start()
    {
        player = GameObject.Find("LocalPlayer");
        att = GetComponent<Animator>();
        GetComponent<BoxCollider2D>().enabled = false;
        cd = 0f;
        game_control = GameObject.Find("Dialog_start");
        st = game_control.GetComponent<dialog_state>();
        
        //collider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(st.game_state != 1){
            return;
        }
        cd += Time.deltaTime;
        if(cd > 8f){
            GetComponent<BoxCollider2D> ().enabled = true;
            cd = 0f;
            transform.position = GameObject.Find("LocalPlayer").transform.position;
            
            att.SetTrigger("attack_2");
        }
    }

    void OnTriggerStay2D(Collider2D other){
        //Debug.Log(other);
        if(other.transform.tag == "Player"){
            Damagae_count_down -= Time.deltaTime;
            if(Damagae_count_down < 0f){
                GetComponent<BoxCollider2D>().enabled = false;
                GameObject player = GameObject.Find("Knight(Clone)");
                Player_state health_script = player.GetComponent<Player_state>();
                health_script.powerful_attack();
                //damageText.GetComponent<Damage_POP>().Set(1000);
                Transform popup = Instantiate(damageText, transform.position, Quaternion.identity);
                Damage_POP damage_pop = popup.GetComponent<Damage_POP>();
                damage_pop.Set(1000);
                
                Damagae_count_down = 2f;
                return;
            }
            //Debug.Log(Damagae_count_down);
            
        }
    }
    void OnTriggerExit2D(Collider2D other){
        if(other.transform.tag == "Player"){
            Damagae_count_down = 2f;
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
