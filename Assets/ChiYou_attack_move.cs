using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChiYou_attack_move : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject player;
    private float speed = 10.0f;
    private Vector3 normalizeDirection;
    float life = 0f;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        normalizeDirection = (player.transform.position - transform.position).normalized;
        float angle = Mathf.Atan2(normalizeDirection.y, normalizeDirection.x) * Mathf.Rad2Deg;
        transform.rotation =  Quaternion.AngleAxis(angle, Vector3.forward);

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += normalizeDirection * speed * Time.deltaTime;
        life += Time.deltaTime;
        if(life > 5f){
            Destroy(gameObject);
        }
    }
}
