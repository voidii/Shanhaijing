using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChiYou_Being_attacked : MonoBehaviour
{
    // Start is called before the first frame update
    int player_state;
    GameObject player;
    private Animator animator;
    RaycastHit2D hit;
    public GameObject ChiYou;
    void Start()
    {
        //ChiYou = GameObject.Find("ChiYou");  
    }

    // Update is called once per frame
    void Update()
    {


        //player_state = player.GetComponent<Player_state>().state;
        
        if(Input.GetMouseButtonDown(0)){
            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            player = GameObject.Find("Knight(Clone)");
            animator = GetComponent<Animator>();
            player_state = player.GetComponent<Player_state>().get_state();
            being_attacked();
        }
        
    }

    void being_attacked(){
        if(player_state == 1 && hit.collider.tag == "ChiYou"){
            animator.SetTrigger("attack");
            transform.GetComponent<damage_text>().create_damage_text();
            Debug.Log("being attacled");
            ChiYou_health health_script = ChiYou.GetComponent<ChiYou_health>();
            health_script.powerful_attack();
        }
    }
}
