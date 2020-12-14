using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShanBi_detect : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator animator;
    bool in_an = false;
    GameObject player;
    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.Find("Knight(Clone)");
    }

    // Update is called once per frame
    void Update()
    {
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if(Input.GetMouseButton(1) && other.tag == "ChiYou_attack"){
            //Debug.Log("duobile: " + other.tag);
            StartCoroutine(ShanBi_SUccess());
        }
    }
    IEnumerator ShanBi_SUccess(){
        in_an = true;
        animator.SetTrigger("DuoBi");
        player.GetComponent<Player_state>().set_state(1);
        yield return new WaitForSeconds(0.1f);
        //m_SpriteRenderer.enabled = false;
        in_an = false;
    }
}
