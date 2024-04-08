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

    public TMPro.TextMeshProUGUI tmp;

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
    }

    public void EnterAbout()
    {
        control.infos[0].text = title;
        control.infos[1].text = hardness;
        control.infos[2].text = density;

        control.canvas[0].SetActive(false);
        control.canvas[1].SetActive(true);
    }
}
