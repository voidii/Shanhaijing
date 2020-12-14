using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class english_op : MonoBehaviour
{
    // Start is called before the first frame update
    public Text textLabel;
    public TextAsset textFile;
    bool in_dia;
    public int index;
    public Image faceImage;
    public Sprite PanGu;
    public Sprite NvWa;
    public Sprite XuanYuan_ShenNong;
    public Sprite ChiYou;
    List<string> textList = new List<string>();
    List<Sprite> picList = new List<Sprite>();
    void Start()
    {
        GetTextFromFile(textFile);
        index = 0;
        textLabel.text = "Press F to continue";
        picList.Add(PanGu);
        picList.Add(NvWa);
        picList.Add(XuanYuan_ShenNong);
        picList.Add(ChiYou);
        faceImage.sprite = picList[index];
    }

    // Update is called once per frame
    void Update()
    {
        if(index == textList.Count + 1){
            gameObject.SetActive(false);
            index = 0;
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
        faceImage.sprite = picList[index];
        for(int i = 0; i < textList[index].Length; i++){
            textLabel.text += textList[index][i];
            yield return new WaitForSeconds(0.03f);
        }
        index++;
        
        in_dia = false;
    }
}
