using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public GameObject last_word;

    bool show_all = false;
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
        if(index == textList.Count && Input.GetKeyDown(KeyCode.F)){
            gameObject.SetActive(false);
            index = 0;
            if(SceneManager.GetActiveScene().buildIndex == 0){
                SceneManager.LoadScene(1);
            }
            else{
                last_word.SetActive(true);
                gameObject.SetActive(false);
            }
            
            return;
        }
        else if(Input.GetKeyDown(KeyCode.F) && !in_dia && index != textList.Count){
            textLabel.text = "";
            in_dia = true;
            StartCoroutine(SetText());
        }

        if(Input.GetKeyDown(KeyCode.T) && in_dia){
            show_all = true;
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
        //faceImage.SetNativeSize();
        for(int i = 0; i < textList[index].Length; i++){
            if(show_all){
                show_all = false;
                textLabel.text = textList[index];
                break;
            }
            textLabel.text += textList[index][i];
            
            yield return new WaitForSeconds(0.01f);
        }
        index++;
        
        in_dia = false;
    }


}
