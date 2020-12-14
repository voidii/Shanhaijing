using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialog : MonoBehaviour
{
    // Start is called before the first frame update
    public Text textLabel;
    public Image faceImage;

    public TextAsset textFile;
    public int index;
    public bool if_is_opening = false;
    bool in_dia;

    public Sprite ChiYou_head;
    public Sprite XuanYuan_head;
    public float text_speed;
    public GameObject dialog_panel;
    public GameObject instruction_panel;

    List<string> textList = new List<string>();

    void Start()
    {
        GetTextFromFile(textFile);
        index = 0;
        textLabel.text = "";
        in_dia = true;
        StartCoroutine(SetText());
        if(!if_is_opening){
            switch(textList[index]){
                case "A":
                    faceImage.sprite = ChiYou_head;
                    index++;
                    break;
                case "B":
                    faceImage.sprite = XuanYuan_head;
                    index++;
                    break;
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(index == textList.Count){
            instruction_panel.SetActive(true);
            dialog_panel.SetActive(false);
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

        if(!if_is_opening){
            switch(textList[index]){
                case "A":
                    faceImage.sprite = ChiYou_head;
                    index++;
                    break;
                case "B":
                    faceImage.sprite = XuanYuan_head;
                    index++;
                    break;
            }
        }

        for(int i = 0; i < textList[index].Length; i++){
            textLabel.text += textList[index][i];
            //index++;
            yield return new WaitForSeconds(text_speed);
        }
        index++;
        in_dia = false;
    }
}
