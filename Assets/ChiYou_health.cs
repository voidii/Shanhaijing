using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChiYou_health : MonoBehaviour
{
    // Start is called before the first frame update
    public int health = 1000;
    public Slider healthbar;
    public AudioSource AttackedSound;
    void Start()
    {
        healthbar.value = health / 1000f;
    }

    // Update is called once per frame
    void Update()
    {
        healthbar.value = health / 1000f;
        if(health < 0){
            Debug.Log("Chi You Dead");
            GameObject game_control = GameObject.Find("Dialog_start");
            dialog_state st = game_control.GetComponent<dialog_state>();
            st.game_state = 0;
            StartCoroutine(load_scene());
        }
    }

    public void sword_attack(){
        AttackedSound.Play();
        health -= 31;
    }
    public void powerful_attack(){
        health -= 9;
        AttackedSound.Play();
    }
    IEnumerator load_scene(){
        
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(2);
    }
}
