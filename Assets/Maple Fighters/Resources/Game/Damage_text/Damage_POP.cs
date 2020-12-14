using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Damage_POP : MonoBehaviour
{
    // Start is called before the first frame update
    TextMeshPro textMesh;
    float exist_time = 0f;
    byte toumingdu = 255;
    void Start()
    {
        textMesh = transform.GetComponent<TextMeshPro>();
        
    }

    // Update is called once per frame
    public void Set(int damage){
        textMesh.SetText(damage.ToString());
    }

    void Update(){
        transform.position += new Vector3(0, 2f, 0) * Time.deltaTime;

        exist_time += Time.deltaTime;
        if(exist_time > 2f){
            Destroy(gameObject);
        }
    }
    void FixedUpdate(){
        textMesh.faceColor = new Color32(255, 191, 126, (byte)toumingdu);
        toumingdu -= 2;
    }
}
