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
    void Start()
    {
        animator = transform.Find("attack_g").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        attack_cd += Time.deltaTime;
        if(attack_cd > attack_frequecny){
            StartCoroutine(ShanBi_SUccess());
            
            attack_cd = 0;
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
