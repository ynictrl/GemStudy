using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    public GameObject[] gemButtons;
    public GameObject[] canvas;

    // [nome, dureza, densidade, classificação, formula, sistema cristalino, diafaneidade, traço, clivagem,  outros(mineral-minerio)]
    public string[,] mineralList = new string[40,4]
                                    {{"Anfibólio", "5-6", "3.10", "Inossilicatos(c. dupla)"}, 
                                    {"Apatita", "5", "3.18", "Fosfato"}, //mohs
                                    {"Barita", "3-3.5", "4.50", "Sulfato"}, 
                                    {"Bauxita", "1-3.5", "2.25", "Hidróxido"}, 
                                    {"Berilo", "7.5-8", "2.65", "Ciclossilicatos"}, 
                                    {"Biotita", "2.5-3", "3.00", "Filossilicatos"}, 
                                    {"Calcita", "3", "2.85", "Carbonato"}, //mohs
                                    {"Calcopirita", "3.5-4", "4.00", "Sufeto"}, 
                                    {"Cassiterita", "6-7", "7.00", "Óxido"}, 
                                    {"Caulinita", "1-2", "2.60", "Filossilicatos"}, 
                                    {"Cianita", "4.5-7", "3.60", "Nesossilicatos"}, 
                                    {"Clorita", "2-2.5", "3.00", "Filossilicatos"}, 
                                    {"Coríndon", "9", "4.00", "Óxido"}, //mohs
                                    {"Diamante", "10", "5.00", "Elementos Nativos"}, //mohs
                                    {"Dolomita", "3.5-4", "3.00", "Carbonato"}, 
                                    {"Epidoto", "6-7", "3.40", "Sorossilicatos"}, 
                                    {"Esfalerita", "3.5-4", "4.00", "Sulfeto"}, 
                                    {"Esmectita", "1-2", "2.60", "Filossilicatos"}, 
                                    {"Espodumênio", "6-7", "3.50", "Inossilicatos(c. simples)"}, 
                                    {"Fluorita", "4", "3.40", "Haleto"}, //mohs
                                    {"Galena", "2-3", "8.90", "Sulfeto"}, 
                                    {"Gipsita", "2", "2.30", "Sulfato"}, //mohs
                                    {"Granada", "6.5-7.5", "3.80", "Nesossilicatos"},
                                    {"Hematita", "5.5-6.5", "5.20", "Óxido"}, 
                                    {"Illita", "1-2", "2.60", "Filossilicatos"}, 
                                    {"Ilmenita", "5-6", "4.50", "Óxido"},
                                    {"K-feldspato", "6", "2.57", "Tectossilicatos"}, //mohs
                                    {"Magnetita", "5.5-6.5", "5.17", "Óxido"}, 
                                    {"Molibdenita", "1-1.5", "4.70", "Sulfeto"},
                                    {"Muscovita", "2.5-4", "2.80", "Filossilicatos"}, 
                                    {"Olivina", "6.5-7", "3.00", "Nesossilicatos"},
                                    {"Ouro", "2.5-3", "19.32", "Elementos Nativos"},
                                    {"Pirita", "6-6.5", "5.02", "Sulfeto"},
                                    {"Piroxênio", "5-6", "3.20", "Inossilicatos(c. simples)"}, 
                                    {"Plagioclásio", "6-6.5", "2.62", "Tectossilicatos"},
                                    {"Quartzo", "7", "2.65", "Tectossilicatos"}, //mohs
                                    {"Romanechita", "5-5.5", "6.56", "Óxido"},
                                    {"Talco", "1", "2.75", "Filossilicatos"}, //mohs
                                    {"Topázio", "8", "3.50", "Nesossilicatos"}, //mohs
                                    {"Turmalina", "7-7.5", "3.10", "Ciclossilicatos"}};

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
                                    "Biotita", "Clorita", "Dolomita", "Olivina", 
                                    "Anfibólio", "Turmalina", "Apatita", "Piroxênio", 
                                    "Epidoto", "Fluorita","Espodumênio", "Topázio", 
                                    "Cianita", "Granada","Calcopirita", "Coríndon", 
                                    "Esfalerita", "Barita","Ilmenita", "Molibdenita", 
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
                gemButtons[i].GetComponent<GemButton>().classification = mineralList[i,3];
            }
        }else{
            int j = 0;
            for(int i=39; i>-1; i--)
            {
                gemButtons[i].GetComponent<GemButton>().title = mineralList[j,0];
                gemButtons[i].GetComponent<GemButton>().hardness = mineralList[j,1];
                gemButtons[i].GetComponent<GemButton>().density = mineralList[j,2];
                gemButtons[i].GetComponent<GemButton>().classification = mineralList[i,3];
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
                gemButtons[i].GetComponent<GemButton>().title = hardnessList[i];// botao recebe talco
      
                for(int m = 0; m < 40; m++)
                {//lista dos min
                    if(hardnessList[i] == mineralList[m, 0])// se talco igual index
                    {
                        gemButtons[i].GetComponent<GemButton>().hardness = mineralList[m,1];
                        gemButtons[i].GetComponent<GemButton>().density = mineralList[m,2];
                        gemButtons[i].GetComponent<GemButton>().classification = mineralList[m,3];
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
                        gemButtons[i].GetComponent<GemButton>().hardness = mineralList[m,1];
                        gemButtons[i].GetComponent<GemButton>().density = mineralList[m,2];
                        gemButtons[i].GetComponent<GemButton>().classification = mineralList[m,3];
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
                        gemButtons[i].GetComponent<GemButton>().hardness = mineralList[m,1];
                        gemButtons[i].GetComponent<GemButton>().density = mineralList[m,2];
                        gemButtons[i].GetComponent<GemButton>().classification = mineralList[m,3];
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
                        gemButtons[i].GetComponent<GemButton>().hardness = mineralList[m,1];
                        gemButtons[i].GetComponent<GemButton>().density = mineralList[m,2];
                        gemButtons[i].GetComponent<GemButton>().classification = mineralList[m,3];
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
