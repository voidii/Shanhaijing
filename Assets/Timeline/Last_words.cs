using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Last_words : MonoBehaviour
{
    // Start is called before the first frame update
    public Text textLabel;
    public TextAsset textFile;
    void Start()
    {
        textLabel.text = textFile.text;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q)){
            Application.Quit();
        }
    }
}
