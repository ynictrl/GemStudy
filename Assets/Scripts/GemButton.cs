using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GemButton : MonoBehaviour
{
    Controller control;
    public string title;
    public string hardness;
    public string density;
    public string classification;
    public TMPro.TextMeshProUGUI tmp;

    public TMPro.TextMeshProUGUI description;

    // Start is called before the first frame update
    void Start()
    {
        control = GameObject.FindGameObjectWithTag("GameController").GetComponent<Controller>();
    }

    // Update is called once per frame
    void Update()
    {
        //GameObject.GetComponent<TextMeshPro>().
        tmp.text = title;

        switch (control.filter)
        {
            case 0:
                description.text = "";
            break;
            case 1:
                description.text = hardness;
            break;
            case 2:
                description.text = density;
            break;
            
        }
    }

    public void EnterAbout()
    {
        control.infos[0].text = title;
        control.infos[1].text = hardness;
        control.infos[2].text = density;
        control.infos[3].text = classification;

        control.canvas[0].SetActive(false);
        control.canvas[1].SetActive(true);
    }
}
