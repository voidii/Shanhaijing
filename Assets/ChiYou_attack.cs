using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChiYou_attack : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform prefab;
    public float attack_frequecny = 10f;
    private float attack_cd = 0f;
    bool in_an = false;
    private Animator animator;
    GameObject game_control;
    dialog_state st;
    void Start()
    {
        animator = transform.Find("attack_g").GetComponent<Animator>();
        game_control = GameObject.Find("Dialog_start");
        st = game_control.GetComponent<dialog_state>();
    }

    // Update is called once per frame
    void Update()
    {
        if(st.game_state != 1){
            return;
        }
        else{
            attack_cd += Time.deltaTime;
            if(attack_cd > attack_frequecny){
                StartCoroutine(ShanBi_SUccess());

                attack_cd = 0;
            }
        }
    }

    IEnumerator ShanBi_SUccess(){
        in_an = true;
        animator.SetTrigger("attack_ges");
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        Instantiate(prefab, transform.position + new Vector3(5, 0, 0), Quaternion.identity);
        //m_SpriteRenderer.enabled = false;
        in_an = false;
    }
}
