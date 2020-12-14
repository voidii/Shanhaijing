using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damage_text : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform damageText;
    void Start()
    {
        //Transform popup = Instantiate(damageText, transform.position, Quaternion.identity);
        //Damage_POP damage_pop = popup.GetComponent<Damage_POP>();
        //damage_pop.Setup(1000);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void create_damage_text(){
        Transform popup = Instantiate(damageText, transform.position, Quaternion.identity);
        Damage_POP damage_pop = popup.GetComponent<Damage_POP>();
        damage_pop.Set(1000);
    }
}
