using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    public GameObject[] gemButtons;
    public GameObject[] canvas;

    // [nome, dureza, densidade, diafaneridade, brilho, mineral-minerio, classificação]
    public string[,] mineralList = new string[40,3]
                                    {{"Anfibólio", "5.50", "3.10"}, 
                                    {"Apatita", "5.00", "3.18"}, //mohs
                                    {"Barita", "3.25", "4.50"}, 
                                    {"Bauxita", "2.25", "2.25"}, 
                                    {"Berilo", "7.25", "2.65"}, 
                                    {"Biotita", "2.75", "3.00"}, 
                                    {"Calcita", "3.00", "2.85"}, //mohs
                                    {"Calcopirita", "3.75", "4.00"}, 
                                    {"Cassiterita", "6.50", "7.00"}, 
                                    {"Caulinita", "1.50", "2.60"}, 
                                    {"Cianita", "6.50", "3.60"}, 
                                    {"Clorita", "2.25", "3.00"}, 
                                    {"Coríndon", "9.00", "4.00"}, //mohs
                                    {"Diamante", "10.00", "5.00"}, //mohs
                                    {"Dolomita", "3.75", "3.00"}, 
                                    {"Epidoto", "6.50", "3.40"}, 
                                    {"Esfalerita", "3.75", "4.00"}, 
                                    {"Esmectita", "1.50", "2.60"}, 
                                    {"Espodumênio", "6.50", "3.50"}, 
                                    {"Fluorita", "4.00", "3.40"}, //mohs
                                    {"Galena", "2.50", "8.90"}, 
                                    {"Gipsita", "2.00", "2.30"}, //mohs
                                    {"Granada", "7.00", "3.80"},
                                    {"Hematita", "6.00", "5.20"}, 
                                    {"Illita", "1.50", "2.60"}, 
                                    {"Ilmenita", "5.50", "4.50"},
                                    {"K-feldspato", "6.00", "2.57"}, //mohs
                                    {"Magnetita", "6.00", "5.17"}, 
                                    {"Molibdenita", "1.25", "4.70"},
                                    {"Muscovita", "3.25", "2.80"}, 
                                    {"Olivina", "6.75", "3.00"},
                                    {"Ouro", "2.75", "19.32"},
                                    {"Pirita", "6.25", "5.02"},
                                    {"Piroxênio", "6.50", "3.20"}, 
                                    {"Plagioclásio", "6.25", "2.62"},
                                    {"Quartzo", "7.00", "2.65"}, //mohs
                                    {"Romanechita", "5.50", "6.56"},
                                    {"Talco", "1.00", "2.75",}, //mohs
                                    {"Topázio", "8.00", "3.50"}, //mohs
                                    {"Turmalina", "7.25", "3.10"}};

    public string[] hardnessList = {"Talco", "Molibdenita", "Caulinita", "Esmectita", 
                                    "Illita", "Gipsita", "Bauxita", "Clorita", 
                                    "Galena", "Biotita", "Ouro", "Calcita", 
                                    "Barita", "Muscovita", "Calcopirita", "Dolomita", 
                                    "Esfalerita", "Fluorita", "Apatita", "Anfibólio", 
                                    "Ilmenita", "Romanechita","K-feldspato", "Hematita", 
                                    "Magnetita", "Pirita","Plagioclásio", "Cassiterita", 
                                    "Cianita", "Epidoto","Espodumênio", "Piroxênio", 
                                    "Olivina", "Quartzo","Granada", "Berilo", 
                                    "Turmalina", "Topázio", "Coríndon", "Diamante"};

    public string[] densityList = {"Bauxita", "Gipsita", "K-feldspato", "Caulinita", 
                                    "Esmectita", "Illita", "Plagioclásio", "Berilo", 
                                    "Quartzo", "Talco", "Muscovita", "Calcita", 
                                    "Biotica", "Clorita", "Dolomita", "Olivina", 
                                    "Anfibólio", "Turmalina", "Apatita", "Piroxênio", 
                                    "Epidoto", "Fluorita","Espodumênio", "Topázio", 
                                    "Cianita", "Granada","Calcopirita", "Coríndon", 
                                    "Esfarelita", "Barita","Ilmenita", "Molibdenita", 
                                    "Diamante", "Pirita","Magnetita", "Hematita", 
                                    "Romanechita", "Cassiterita", "Galena", "Ouro"};

    public TMPro.TextMeshProUGUI[] infos; //textos nas infos

    public bool growingOrder; // ordem crescente
    public int filter; // 0: alfabetica, 1: dureza

    // public string[] tirleList = {"Anfibólio", "Apatita", "Barita", "Bauxita", 
    //                                 "Berilo", "Biotita", "Calcita", "Calcopirita",
    //                                 "Cassiterita", "Caulinita", "Cianita", "Clorita", 
    //                                 "Coríndon", "Diamante", "Dolomita", "Epidoto", 
    //                                 "Esfalerita", "Esmectita", "Espodumênio", "Fluorita", 
    //                                 "Galena", "Gipsita", "Granada", "Hematita",
    //                                 "Illita", "Ilmenita", "K-feldspato", "Magnetita",
    //                                 "Molibdenita", "Muscovita", "Olivina", "Ouro",
    //                                 "Pirita", "Piroxênio", "Plagioclásio", "Quartzo",
    //                                 "Romanechita", "Talco", "Topázio", "Turmalina"};
    
    // //lista.length
    // public int[,] numeros = new int[2, 1]{{0}, {0}};
    // public char[,] letras = new char[2, 1]{{'0'}, {'0'}};

    

    // Start is called before the first frame update
    void Start()
    {
        //Console.WriteLine(numeros[0,0]);
    }

    // Update is called once per frame
    void Update()
    {

        switch (filter)
        {
            case 0:
                AlphabeticalOrder();
            break;
            case 1:
                HardnessOrder();
            break;
            case 2:
                DensityOrder();
            break;
            
        }
        
    }

    public void ChangeFilter(int i)
    {
        filter = i;
    }

    public void ChangeOrder()
    {
        if(growingOrder)
        {
            growingOrder = false;
        }else{
            growingOrder = true;
        }
    }

    public void BackMenu()
    {
        canvas[0].SetActive(true);
        canvas[1].SetActive(false);
    }

    public void AlphabeticalOrder()
    {
        if(growingOrder)
        {
            for(int i=0; i<40; i++)
            {
                gemButtons[i].GetComponent<GemButton>().title = mineralList[i,0];
                gemButtons[i].GetComponent<GemButton>().hardness = mineralList[i,1];
                gemButtons[i].GetComponent<GemButton>().density = mineralList[i,2];
            }
        }else{
            int j = 0;
            for(int i=39; i>-1; i--)
            {
                gemButtons[i].GetComponent<GemButton>().title = mineralList[j,0];
                gemButtons[i].GetComponent<GemButton>().hardness = mineralList[j,1];
                gemButtons[i].GetComponent<GemButton>().density = mineralList[j,2];
                j++;
            }
        }
    }

    public void HardnessOrder()
    {
        if(growingOrder)
        {
            for(int i=0; i<40; i++)
            {
                gemButtons[i].GetComponent<GemButton>().title = hardnessList[i];
      
                for(int m = 0; m < 40; m++)
                {//lista dos min
                    if(hardnessList[i] == mineralList[m, 0])
                    {
                        gemButtons[i].GetComponent<GemButton>().hardness = mineralList[m,1];
                    }
                }
            }
        }else{
            int j = 0;
            for(int i=39; i>-1; i--)
            {
                gemButtons[j].GetComponent<GemButton>().title = hardnessList[i];
          
                for(int m = 0; m < 40; m++)
                {//lista dos min
                    if(hardnessList[i] == mineralList[m, 0])
                    {
                        gemButtons[j].GetComponent<GemButton>().hardness = mineralList[m,1];
                    }
                }

                j++;
            }
        }

        
    }

    public void DensityOrder()
    {
        if(growingOrder)
        {
            for(int i=0; i<40; i++)
            {
                gemButtons[i].GetComponent<GemButton>().title = densityList[i];
      
                for(int m = 0; m < 40; m++)
                {//lista dos min
                    if(densityList[i] == mineralList[m, 0])
                    {
                        gemButtons[i].GetComponent<GemButton>().density = mineralList[m,2];
                    }
                }
            }
        }else{
            int j = 0;
            for(int i=39; i>-1; i--)
            {
                gemButtons[j].GetComponent<GemButton>().title = densityList[i];
          
                for(int m = 0; m < 40; m++)
                {//lista dos min
                    if(densityList[i] == mineralList[m, 0])
                    {
                        gemButtons[j].GetComponent<GemButton>().density = mineralList[m,2];
                    }
                }
                j++;
            }
        }  
    }

    // while(hardnessList.length() < 40)
        // {
        //     for(int i = 0; i < 40; i++)
        //     {
        //         for(float j = 0; j < 10; j += 0.25)
        //         {
        //             if()
        //         }
        //     }
        // }
    // public class Mineral
    // {
    //     public string Nome {get; set;}
    //     public int Dureza {get; set;}
    //     public Mineral(string nome, int dureza)
    //     {
    //         Nome = nome;
    //         Dureza = dureza;
    //     }
    // }

    // public void Main()
    // {
    //     Mineral amanda = new Mineral("Amanda", 24);
    //     Mineral beto = new Mineral("Beto", 20);

    //     List<Mineral> mineral = new List<Mineral>()
    //         {amanda, beto};

    //     mineral.Sort(delegate (Mineral x, Mineral y)
    //     {
    //         return x.Dureza.CompareTo(y.Dureza);
    //     });
        
    //     for(int i=0; i<2; i++)
    //     {
    //         GemButtons[i].GetComponent<GemButton>().title = mineral(Mineral x, Mineral y);
    //     }
            
    // }


    //public void GrowingHardnessOrder()
    //{
        // float prev = 0;
        // for(int i=0; i<40; i++)
        // {
        //     if(Convert.ToFloat(mineralList[i,1]) )
        //     Convert.ToFloat(mineralList[i,1]);
        // }

        //List<float> dureza = new List<float>();
        // for(int i=0; i<40; i++)
        // {
        //     dureza.Add(global::System.Single.Parse(mineralList[i,1]));
        // }
        // float prev = 0;
        // int j = 0;
        // for(int i=0; i<40; i++)
        // {
        //     while(mineralList[i,1] == dureza[j])
        //     {

        //     }
        //     j++;
        //Array.Add(mineralList);
        //dureza = Add.a(6);
    //}
}
