using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hook_detect : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject hook;
    GameObject player;
    float cood_down = 10f;
    float cd_time = 0f;
    bool in_cd = false;
    BoxCollider2D m_Collider;
    Ray2D ray;
    RaycastHit2D hit;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(1)){
            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, LayerMask.GetMask("Hook"));
            if(hit.collider.gameObject.tag == "Hook"){
                hook = hit.collider.gameObject;
                StartCoroutine(Move_player());
            }
        }
        
    }

    IEnumerator Move_player()
    {
        yield return new WaitForSeconds(0.5f);
        player = GameObject.FindWithTag("Player");

        if(Vector2.Distance(hook.transform.position, player.transform.position) < 5.5)
        {
            
            player.transform.position = hook.transform.position + new Vector3(0, 2f, 0);
        }
    }
}
