using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    public GameObject[] gemButtons;
    public GameObject[] canvas;

    // [nome, dureza, densidade, classificação, formula, sistema, diafaneidade, clivagem, traço, brilho]
    public string[,] mineralList = new string[40,10]
                                    {{"Anfibólio", "5-6", "3.10", "Inossilicatos(c. dupla)", "", "Ortorrômbico, Monoclínico", "", "", "", ""}, 
                                    {"Apatita", "5", "3.18", "Fosfato", "", "", "", "", "", ""}, //mohs
                                    {"Barita", "3-3.5", "4.50", "Sulfato", "", "", "", "", "", ""}, 
                                    {"Bauxita", "1-3.5", "2.25", "Hidróxido", "", "", "", "", "", ""}, 
                                    {"Berilo", "7.5-8", "2.65", "Ciclossilicatos", "", "Hexagonal", "Translúcido", "Imperfeita[1]", "Incolor", "Não-metálico"}, 
                                    {"Biotita", "2.5-3", "3.00", "Filossilicatos", "", "", "", "", "", ""}, 
                                    {"Calcita", "3", "2.85", "Carbonato", "", "", "", "", "", ""}, //mohs
                                    {"Calcopirita", "3.5-4", "4.00", "Sufeto", "", "", "", "", "", ""}, 
                                    {"Cassiterita", "6-7", "7.00", "Óxido", "", "", "", "", "", ""}, 
                                    {"Caulinita", "1-2", "2.60", "Filossilicatos", "", "", "", "", "", ""}, 
                                    {"Cianita", "4.5-7", "3.60", "Nesossilicatos", "Al2SiO5", "Ortorrômbico", "Translúcido", "Perfeita[2]", "Incolor", "Não-metálico"}, 
                                    {"Clorita", "2-2.5", "3.00", "Filossilicatos", "", "", "", "", "", ""}, 
                                    {"Coríndon", "9", "4.00", "Óxido", "", "", "", "", "", ""}, //mohs
                                    {"Diamante", "10", "5.00", "Elementos Nativos", "", "", "", "", "", ""}, //mohs
                                    {"Dolomita", "3.5-4", "3.00", "Carbonato", "", "", "", "", "", ""}, 
                                    {"Epidoto", "6-7", "3.40", "Sorossilicatos", "", "Monoclínico", "Translúcido", "Perfeita[2]", "Incolor", "Não-metálico"}, 
                                    {"Esfalerita", "3.5-4", "4.00", "Sulfeto", "", "", "", "", "", ""}, 
                                    {"Esmectita", "1-2", "2.60", "Filossilicatos", "", "", "", "", "", ""}, 
                                    {"Espodumênio", "6-7", "3.50", "Inossilicatos(c. simples)", "", "", "", "Perfeita[2]", "Incolor", "Não-metálico"}, 
                                    {"Fluorita", "4", "3.40", "Haleto", "", "", "", "", "", ""}, //mohs
                                    {"Galena", "2-3", "8.90", "Sulfeto", "", "", "", "", "", ""}, 
                                    {"Gipsita", "2", "2.30", "Sulfato", "", "", "", "", "", ""}, //mohs
                                    {"Granada", "6.5-7.5", "3.80", "Nesossilicatos", "", "Isométrico", "Translúcido", "Sem clivagem", "Incolor", "Não-metálico"},
                                    {"Hematita", "5.5-6.5", "5.20", "Óxido", "", "", "", "", "", ""}, 
                                    {"Illita", "1-2", "2.60", "Filossilicatos", "", "", "", "", "", ""}, 
                                    {"Ilmenita", "5-6", "4.50", "Óxido", "", "", "", "", "", ""},
                                    {"K-feldspato", "6", "2.57", "Tectossilicatos", "", "", "", "", "", ""}, //mohs
                                    {"Magnetita", "5.5-6.5", "5.17", "Óxido", "", "", "", "", "", ""}, 
                                    {"Molibdenita", "1-1.5", "4.70", "Sulfeto", "", "", "", "", "", ""},
                                    {"Muscovita", "2.5-4", "2.80", "Filossilicatos", "", "", "", "", "", ""}, 
                                    {"Olivina", "6.5-7", "3.00", "Nesossilicatos", "", "Ortorrômbico", "Translúcido", "Imperfeita[2]", "Incolor", "Não-metálico"},
                                    {"Ouro", "2.5-3", "19.32", "Elementos Nativos", "", "", "", "", "", ""},
                                    {"Pirita", "6-6.5", "5.02", "Sulfeto", "", "", "", "", "", ""},
                                    {"Piroxênio", "5-6", "3.20", "Inossilicatos(c. simples)", "", "Ortorrômbico/Monoclínico", "Transparente/Translúcido", "Perfeita[2]", "Varíavel", "Não-metálico"}, 
                                    {"Plagioclásio", "6-6.5", "2.62", "Tectossilicatos", "", "", "", "", "", ""},
                                    {"Quartzo", "7", "2.65", "Tectossilicatos", "", "", "", "", "", ""}, //mohs
                                    {"Romanechita", "5-5.5", "6.56", "Óxido", "", "", "", "", "", ""},
                                    {"Talco", "1", "2.75", "Filossilicatos", "", "", "", "", "", ""}, //mohs
                                    {"Topázio", "8", "3.50", "Nesossilicatos", "", "Ortorrômbico", "Translúcido", "Perfeita[1]", "Incolor", "Não-metálico"}, //mohs
                                    {"Turmalina", "7-7.5", "3.10", "Ciclossilicatos", "", "Hexagonal", "Translúcido", "Sem clivagem", "Incolor", "Não-metálico"}};

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

    //slicatos na ordem de grupo
    public string[] silicateList = {"Granada", "Olivina", "Cianita", "Topázio", 
                                    "Epidoto", "Turmalina", "Berilo", "Piroxênio", 
                                    "Anfibólio", "Espodumênio", "Caulinita", "Esmectita", 
                                    "Illita", "Muscovita", "Biotita", "Talco",
                                    "Clorita", "K-feldspato", "Plagioclásio", "Quartzo"};

    public string[] notSilicateList = {"Esfalerita", "Galena", "Pirita", "Calcopirita", 
                                       "Molibdenita", "Barita", "Gipsita", "Apatita", 
                                       "Diamante", "Ouro", "Hematita", "Ilmenita", 
                                       "Cassiterita", "Romanechita", "Magnetita", "Coríndon",
                                       "Bauxita", "Calcita", "Dolomita", "Fluorita"};
  
    public TMPro.TextMeshProUGUI[] infos; //textos nas infos

    // public bool growingOrder; // ordem crescente
    public int filter; // 0: alfabetica, 1: dureza
    public int filterClass; // 0: todos 1: silicatos 2: Não silicatos
    public int filterGroupSilicate; // 0: todos 1: neso 2: soro 3: ciclo 4: ino 5: filo 6: tecto 7: óxidos
    public int filterGroupNotSilicate; // 0: todos 1: sulfetos 2: sulfatos 3: fosfatos 4: óxidos 5: sulfatos 6: óxidos 4: hidróxidos 5: carbonatos 6: haletos

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
        //SetButton();

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
        
        // switch (filterClass)
        // {
        //     case 0:
        //         //todos
        //     break;
        //     case 1:
        //         //ÓxidoOrder();
        //     break;
            
        // }
    }

    public void SetButton()
    {
        for(int i=0; i<40; i++)//button
        {
            for(int j=0; j<40; j++)//titulos
            {
                if(gemButtons[i].GetComponent<GemButton>().title == mineralList[j,0])
                {
                    gemButtons[i].GetComponent<GemButton>().title = mineralList[j,0];
                    gemButtons[i].GetComponent<GemButton>().hardness = mineralList[j,1];
                    gemButtons[i].GetComponent<GemButton>().density = mineralList[j,2];
                    gemButtons[i].GetComponent<GemButton>().classification = mineralList[j,3];
                    gemButtons[i].GetComponent<GemButton>().formula = mineralList[j,4];
                    gemButtons[i].GetComponent<GemButton>().system = mineralList[j,5];
                    gemButtons[i].GetComponent<GemButton>().diaphaneity = mineralList[j,6];
                    gemButtons[i].GetComponent<GemButton>().cleavage = mineralList[j,7];
                    gemButtons[i].GetComponent<GemButton>().trace = mineralList[j,8];
                    gemButtons[i].GetComponent<GemButton>().shine = mineralList[j,9];
                }
            }
        }
    }


    public void ChangeFilter(int i)
    {
        filter = i;
    }

    public void BackMenu() // entrar e sair do menu de detalhes
    {
        canvas[0].SetActive(true);
        canvas[1].SetActive(false);
    }

    public void AlphabeticalOrder()// Ordenar nome
    {
        switch (filterClass)
        {
            case 0: //todos
                for(int i=0; i<40; i++)
                {
                    gemButtons[i].SetActive(true);
                    gemButtons[i].GetComponent<GemButton>().title = mineralList[i,0];
                }
            break;
            case 1: //silicatos
                // int a = 0;
                // int b = 0;

                // while(a<40)//button
                // {
                //     if(a<20)
                //     {
                //         while(b<40)//MINERALLIST
                //         {
                //             if(mineralList[b,0] == silicateList[a])
                //             {
                //                 gemButtons[a].SetActive(true);
                //                 gemButtons[a].GetComponent<GemButton>().title = mineralList[b,0];
                //                 a++;
                //             }
                //             b++;
                //         }
                //     }else{
                //         gemButtons[a].SetActive(false);
                //     }
                // }


                // int i = 0;
                // while(i<40)//button
                // {
                //     if(i < 20/*mineralList.length*/)// vai até os 20
                //     {
                //         gemButtons[i].SetActive(true);

                //         for(int j=0; j<40; j++)//minerallist
                //         {
                //             for(int k=0; k<20; k++)// silicatellist
                //             {
                //                 if(silicateList[k] == mineralList[j,0])
                //                 {
                //                     gemButtons[i].GetComponent<GemButton>().title = silicateList[k];
                //                     i++;
                //                 }
                                    
                //             }
                //         }
                //     }else{
                //         gemButtons[i].SetActive(false);
                //     }
                // }
            break;
            case 2: //não silicatos
                
            break;
            
        }
        
        SetButton();
    }

    public void HardnessOrder() // Ordenar dureza
    { 
        for(int i=0; i<40; i++)
        {
            gemButtons[i].GetComponent<GemButton>().title = hardnessList[i];
        }
        SetButton();
    }

    public void DensityOrder() // Ordenar demsidade
    {
        for(int i=0; i<40; i++)
        {
            gemButtons[i].GetComponent<GemButton>().title = densityList[i];
        }
        SetButton(); 
    }
  
}
