using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swords_attack : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 200f;
    public float attack_cd = 1f;
    float time_count;
    public Transform prefab;
    private Vector3 target;
    GameObject ChiYou;
    GameObject Returing_object;
    private Vector3 normalizeDirection;
    public Rigidbody2D rb;
    Player_state buffed;
    public Transform damageText;
    //bool moving = false;

    private State _state;
    GameObject game_control;
    dialog_state st;

    public enum State
    {
        Initial,
        Attacking,
        Returning,
        Buffed
    }
    

    void Start()
    {
        time_count = 0f;
        _state = State.Initial;
        ChiYou = GameObject.FindWithTag("ChiYou");
        buffed = GameObject.Find("Knight(Clone)").GetComponent<Player_state>();
        game_control = GameObject.Find("Dialog_start");
        st = game_control.GetComponent<dialog_state>();
        
        //normalizeDirection = (ChiYou.transform.position - transform.position).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        if(st.game_state != 1){
            return;
        }
        else if(buffed.state == 0){
            if(Input.GetMouseButtonDown(0) && _state == State.Initial){
                _state = State.Attacking;
                normalizeDirection = (ChiYou.transform.position - transform.position).normalized;
                rb = transform.gameObject.AddComponent<Rigidbody2D>();
                rb.gravityScale = 0f;
                rb.mass = 1f;
                rb.drag = 1;
                transform.parent = GameObject.Find("LocalPlayer").transform;
                return;
            }
            if (_state == State.Attacking) {
                //time_count += Time.deltaTime;
                rb.AddForce(normalizeDirection * 50f);
                //transform.position += normalizeDirection * 20f * Time.deltaTime;
            }
            if (_state == State.Returning) {
                time_count += Time.deltaTime;
                rb.AddForce((Returing_object.transform.position - ChiYou.transform.position).normalized * 10f);
            }
            if(time_count > 5f){
                rb.velocity = Vector2.zero;
                transform.position = GameObject.Find("sword_location").transform.position;
                _state = State.Initial;
                time_count = 0f;
                transform.parent = GameObject.Find("Knight(Clone)").transform;
                Destroy (rb);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.tag == "ChiYou" && _state == State.Attacking){
            _state = State.Returning;
            Returing_object = FindRandomTarget();
            Transform popup = Instantiate(damageText, transform.position, Quaternion.identity);
            Damage_POP damage_pop = popup.GetComponent<Damage_POP>();
            time_count = 0f;
            GameObject ChiYou = GameObject.Find("ChiYou");
            Debug.Log(ChiYou.transform.position);
            ChiYou_health health_script = ChiYou.GetComponent<ChiYou_health>();
            health_script.sword_attack();
        }

        if((other.transform.tag == "Catch_sword" && _state == State.Returning)){
            rb.velocity = Vector2.zero;
            transform.parent = GameObject.Find("Knight(Clone)").transform;
            transform.position = GameObject.Find("sword_location").transform.position;
            _state = State.Initial;
            time_count = 0f;
            Destroy (rb);
        }
    }
    GameObject FindRandomTarget(){
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag ("Hook");
        int rand = Random.Range(0, gos.Length);
        
        return gos[rand];
    }

}
