using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chinese_op : MonoBehaviour
{
    // Start is called before the first frame update
    public Text textLabel;
    public TextAsset textFile;
    bool in_dia;
    public int index;
    List<string> textList = new List<string>();
    void Start()
    {
        GetTextFromFile(textFile);
        index = 0;
        textLabel.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if(index == textList.Count + 1){
            gameObject.SetActive(false);
            index = 0;
            GameObject game_control = GameObject.Find("Dialog_start");
            dialog_state st = game_control.GetComponent<dialog_state>();
            st.game_state = 2;
            return;
        }
        if(Input.GetKeyDown(KeyCode.F) && !in_dia){
            textLabel.text = "";
            in_dia = true;
            StartCoroutine(SetText());
        }
    }
    void GetTextFromFile(TextAsset file){
        textList.Clear();
        index = 0;

        var lineData = file.text.Split('\n');

        foreach (var line in lineData){
            textList.Add(line);
        }
    }
    IEnumerator SetText(){

        for(int i = 0; i < textList[index].Length; i++){
            textLabel.text += textList[index][i];
            yield return new WaitForSeconds(0.1f);
        }
        index++;
        in_dia = false;
    }
}
