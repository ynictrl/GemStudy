using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    public GameObject[] gemButtons;
    public GameObject[] canvas;

    // [nome, dureza, densidade, classificação, formula, sistema, diafaneidade, clivagem, traço, brilho, outros]
    public string[,] mineralList = new string[40,10]
                                    {{"Anfibólio", "5-6", "3.10", "Inossilicatos(c. dupla)", "...", "Ortorrômbico, Monoclínico", "Translúcido", "Perfeita[2]{110}", "Incolor/váriado", "Não-metálico", "Branco,verde,preto. Prismáticos, quebradiços, fibrosos, colunares(amianto). Ex:Hornblenda"}, 
                                    {"Apatita", "5", "3.18", "Fósfato", "Ca5(PO4)3 (F,Cl,OH)", "Hexagonal", "Translúcido", "Imperfeita[2]", "Incolor/Branco", "Não-metálico", "Azul e cores variadas. Usualmente em prismas hexagonais"}, //mohs
                                    {"Barita", "3-3.5", "4.50", "Sulfato", "BaSO4", "Ortorrômbico", "Translúcido", "Perfeita[3]", "Incolor", "Não-metálico", "Branco, cores variadas. Brilho nacarado. Mineral-minério de Bário"}, 
                                    {"Bauxita", "1-3.5", "2.25", "Hidróxido", "misturas de hidróxos de Al", "Monoclínico", "Opáco", "Perfeita[1]", "Laranja", "Não-metálico", "(Gibbsita) Amarelo, castanho. Terroso, semelhante a argila "}, 
                                    {"Berilo", "7.5-8", "2.65", "Ciclossilicatos", "Be3Al2(Si6O18)", "Hexagonal", "Translúcido", "Imperfeita[1]", "Incolor", "Não-metálico(resinoso,vítro)", "Verde-azulado e cores váriadas.Prismas hexagonais terminados pela base. Faces de pirâmide são raras"}, 
                                    {"Biotita", "2.5-3", "3.00", "Filossilicatos", "K(Mg,Fe)3(AlSiO10)(OH)2", "Monoclínico", "Translúcido", "Perfeita[1]", "Branco/cinza/castanho", "Não-metálico(nacarado)", "Castanho escuro, verde a preto. Estampas da clivagem são eslásticas"}, 
                                    {"Calcita", "3", "2.85", "Carbonato", "CaCO3", "Romboédrico", "Translúcido", "Perfeita", "Incolor", "Não-metálico(Vítro)", "Incolor e cores variadas. Esfervece em ácido clorídrico frio"}, //mohs
                                    {"Calcopirita", "3.5-4", "4.00", "Sufeto", "CuFeS2", "Tetragonal", "Opáco", "Ausente", "Preto", "Metálico", "Amarelo latão. Mais frágil que a pirita"}, 
                                    {"Cassiterita", "6-7", "7.00", "Óxido", "SnO2", "Tetragonal", "Opáco", "Imperfeito[1]", "Incolor/Castalnho-claro", "Não-metálico", "Castanho a preto. Mineral-minério de estanho"}, 
                                    {"Caulinita", "1-2", "2.60", "Filossilicatos", "A2Si2O5(OH)4", "Triclínico", "Translúcido", "Perfeita[1]", "Incolor", "Não-metálico(nacarado,fosco,terroso)", "Branco,pode ser mais escuro. Quando molhado exala odor de argila. Adera a língua seca"}, 
                                    {"Cianita", "4.5-7", "3.60", "Nesossilicatos", "Al2SiO5", "Ortorrômbico", "Translúcido", "Perfeita[2]", "Incolor", "Não-metálico", "Azul, cresce em coluna. Paralela ao comprimento"}, 
                                    {"Clorita", "2-2.5", "3.00", "Filossilicatos", "(Mg,Fe)3(OH)6", "Monoclínico", "Translúcido", "Perfeita[1]", "Branco", "Não-metálico(nacarado,vítreo)", "Verde variado. Laminulas flexíveis, mas não elásticas."}, 
                                    {"Coríndon", "9", "4.00", "Óxido", "Al2O3", "Hexagonal", "Translúcido", "Ausente", "Incolor", "Não-metálico", "Roxo e cores váriadas. Forma cubica"}, //mohs
                                    {"Diamante", "10", "5.00", "Elementos Nativos", "C", "Isométrico", "Translúcido", "Ausente", "Incolor", "Cores variadas. Faces podem ser curvas"}, //mohs
                                    {"Dolomita", "3.5-4", "3.00", "Carbonato", "CaMg(CO3)2", "Romoédrico", "Translúcido", "Perfeita[3]", "Incolor", "Não-metálico", "Incolor, branco, roseo. Brilho macarado"}, 
                                    {"Epídoto", "6-7", "3.40", "Sorossilicatos", "...", "Monoclínico", "Translúcido", "Perfeita[2]", "Incolor", "Não-metálico(nacarado,resínoso,vítreo)", "Verde-amarelado a verde-escuro. Base lozangular. Cristais prismáticos estriados paralelamente ao comprimento"}, 
                                    {"Esfalerita", "3.5-4", "4.00", "Sulfeto", "ZnS", "Isométrico", "Opáco", "Perfeita[6]", "Preto", "Não-metálico", "Preto a castanho escuro, raramente vermelho."}, 
                                    {"Esmectita", "1-2", "2.60", "Filossilicatos", "(Al,Mg,fe)5(Si4O10)(OH)2", "Monoclínico", "Translúcido", "Perfeita[1]", "Incolor", "Não-metálico(terroso)", "Esverdeado"}, 
                                    {"Espodumênio", "6-7", "3.50", "Inossilicatos(c. simples)", "LiAlSi2O6", "Monoclínico", "Translúcido", "Perfeita[2]{110}", "Incolor", "Não-metálico", "(Piroxênio)Branco,cinzento, róseo, verde. Em cristais prismáticos achatados, estriados verticalmente. Também maciço"}, 
                                    {"Fluorita", "4", "3.40", "Haleto", "CaF2", "Isométrico", "Translúciodo", "Perfeita[4]", "Incolor", "Não-metálico", "Verde, cores variadas. Em cristais cubicos geminados por penetração"}, //mohs
                                    {"Galena", "2-3", "8.90", "Sulfeto", "PbS", "Isométrico", "Opáco", "Perfeita[3]", "Cinza", "Metálico", "Cinza. Mineral-minério de chumbo"}, 
                                    {"Gipsita", "2", "2.30", "Sulfato", "CaSO4.2H2O", "Monoclínico", "Translúcido", "Perfeita[3]", "Incolor", "Não-metálico", "Branco, cinza. Fibroso com brilho sedoso(gesso)"}, //mohs
                                    {"Granada", "6.5-7.5", "3.80", "Nesossilicatos", "A3B2(SiO4)3*", "Isométrico", "Translúcido", "Ausente", "Incolor", "Não-metálico(resinoso,vítero)", "Vermelho a castanho ou cores váriadas. Cresce em forma dodecaedros ou trapezoedros"},
                                    {"Hematita", "5.5-6.5", "5.20", "Óxido", "Fe2O3", "Hexagonal", "Opáco", "Ausente", "Vermelho", "Metálico", "Maciço, radiado"}, 
                                    {"Illita", "1-2", "2.60", "Filossilicatos", "...", "Monoclínico", "Translúcido", "Perfeita[1]", "Branco", "Não-metálico(fosco,terroso)", "(argilomineral)cinza. Forma agregados de cristais"}, 
                                    {"Ilmenita", "5-6", "4.50", "Óxido", "FeTiO3", "Romboédrico", "Opáco", "Ausente", "Preto", "Metálico", "Castanho escuro, preto. Levemente magnético. Mineral minério de titaneo"},
                                    {"K-feldspato", "6", "2.57", "Tectossilicatos", "K(AlSi3o10)", "Monoclínico", "Translúcido", "Perfeita[3]", "Incolor", "Não-metálico(marcado,vítreo)", "Rosa(Salmão). Cristais normalmente tabulares"}, //mohs
                                    {"Magnetita", "5.5-6.5", "5.17", "Óxido", "Fe3O4", "Isométrico", "Opáco", "Ausente", "Preto", "Metálico", "Preto. Fotermente magnético"}, 
                                    {"Molibdenita", "1-1.5", "4.70", "Sulfeto", "MoS2", "Hexagonal", "Opáco", "Perfeita[1]", "Cinza/Preto/Esverdeado", "Cinza, preto azulado. Tato untoso"},
                                    {"Muscovita", "2.5-4", "2.80", "Filossilicatos", "KAl2(AlSi3O10)(OH)2", "Monoclínico", "Translúcido", "Perfeita[1]", "Incolor", "Não-metálico", "Castanho pálido e cores variadas. Cristais tabulares com contornos hexagonal e rômbico"}, 
                                    {"Olivina", "6.5-7", "3.00", "Nesossilicatos", "(Mg,Fe)2 SiO4", "Ortorrômbico", "Translúcido", "Imperfeita[2]", "Incolor", "Não-metálico(resinoso,gorduroso,vítreo)", "Verde-Oliva a verde-acinzentado. Usualmente granulos disseminados em rochas ígneas"},
                                    {"Ouro", "2.5-3", "19.32", "Elementos Nativos", "Au", "Isométrico", "Opáco", "Ausente", "Amarelo", "Amarelo. Maleável"},
                                    {"Pirita", "6-6.5", "5.02", "Sulfeto", "FeS2", "Isométrico", "Opáco", "Ausente", "Preto", "Metálico", "Amarelo latão. Sulfeto mais comum"},
                                    {"Piroxênio", "5-6", "3.20", "Inossilicatos(c. simples)", "...", "Ortorrômbico/Monoclínico", "Transparente/Translúcido", "Perfeita[2]", "Varíavel", "Não-metálico(vítreo)", "Branco, preto, verde. Prismas grossos de secção transversal retãngular. Caracteriazdo pela clivagem"}, 
                                    {"Plagioclásio", "6-6.5", "2.62", "Tectossilicatos", "(Na,Ca)(AlSi4O8)", "Monoclínico", "Translúcido", "Perfeita[3]", "Incolor", "Não-metálico(nacarado,vítreo)", "Branco, incolor, cinzento, azulado"},
                                    {"Quartzo", "7", "2.65", "Tectossilicatos", "SiO2", "Hexagonal", "Translúcido", "Ausente", "Incolor", "Não-metálico(fosco,vítreo)", "Cores variadas. Prismáticos e ponteagudos. Romboédrico"}, //mohs
                                    {"Romanechita", "5-5.5", "6.56", "Óxido", "(BaH2O)2 ...", "Monoclínico", "Opáco", "Ausente", "Preto", "Submetálico", "Castanho escuro a preto. Maciço compacto, botroidal e estactítico"},
                                    {"Talco", "1", "2.75", "Filossilicatos", "Mg3Si4O10(OH)2", "Monoclínico", "Translúcido", "Perfeita[1]", "Branco", "Não-metálico(fosco,gorduroso)", "Branco. Quando impuro verde-maçã, cinza. Tato undoso, laminado ou micário"}, //mohs
                                    {"Topázio", "8", "3.50", "Nesossilicatos", "Al2SiO4(F,Oh)2", "Ortorrômbico", "Translúcido", "Perfeita[1]", "Incolor", "Não-metálico(vítro)", "Cores váriadas. Cristais bem formados, com faces prismáticas"}, //mohs
                                    {"Turmalina", "7-7.5", "3.10", "Ciclossilicatos", "...", "Hexagonal", "Translúcido", "Ausente", "Incolor", "Não-metálico(resínoso,vítreo)", "Preto e cores variadas. prismáticos com várias faces, estriado verticalmente"}};

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
  
    public GameObject[] infoButtons; // depois transforma em lista
    public TMPro.TextMeshProUGUI[] infos; //textos nas 
    public TMPro.TextMeshProUGUI[] nameFilter; //nome dos butao de filtro

    // public bool growingOrder; // ordem crescente
    public int filter; // 0: alfabetica, 1: dureza
    public int filterClass; // 0: todos 1: silicatos 2: Não silicatos
    public int filterGroupSilicate; // 0: todos 1: neso 2: soro 3: ciclo 4: ino 5: filo 6: tecto 
    public int filterGroupNotSilicate; // 0: todos 1: sulfetos 2: sulfatos 3: fosfatos 4: óxidos 5: sulfatos 6: óxidos 4: hidróxidos 5: carbonatos 6: haletos
    
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

        switch (filterClass)
        {
            case 0:
                infoButtons[0].SetActive(false);
                infoButtons[1].SetActive(false);
            break;
            case 1:
                infoButtons[0].SetActive(true);
                infoButtons[1].SetActive(false);
            break;
            case 2:
                infoButtons[0].SetActive(false);
                infoButtons[1].SetActive(true);
            break;
            
        }
    
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


    public void ChangeFilter(int i) // filtros de ordem
    {
        filter = i;
    }

    public void LimitFilterClass(int j) // limete do filtro, nome do boto
    {
        

        if(filterClass < j)
        {
            filterClass++;
            
        }else{
            filterClass = 0; 
        }

        // nameFilter[0].text = names[filterClass];
    }

    public void LimitFilterGroupSilicate(int k) // limete do filtro, nome do boto
    {

        if(filterGroupSilicate < k)
        {
            filterGroupSilicate++;
            
        }else{
            filterGroupSilicate = 0; 
        }
    }

    public void LimitFilterGroupNotSilicate(int l) // limete do filtro, nome do boto
    {
        // nameFilter[2].text = names[filterGroupNotSilicate];
     
        if(filterGroupNotSilicate < l)
        {
            filterGroupNotSilicate++;
            
        }else{
            filterGroupNotSilicate = 0; 
        }
        
    }

    public void ChangeFilterClass(int m) // filtrar a classe/grupo
    {
        // l == 0: class | l == 1: groupSilicates | l == 2: groupNotSilicates
        switch (m)
        {  
            case 0:
                string[] classes = {"Todos", "Silicatos", "Não Silicatos"};
                LimitFilterClass(classes.Length-1);
                nameFilter[0].text = classes[filterClass];
            break;
            case 1:

                string[] groupSillicate = {"Todos", "Neso", "Soro", "Ciclo", "Ino", "Filo", "Tecto"};
                LimitFilterGroupSilicate(groupSillicate.Length-1);
                nameFilter[1].text = groupSillicate[filterGroupSilicate];
            break;
            case 2:

            string[] groupNotSillicate = {"Todos", "Sulfetos", "Sulfatos", "Fosfatos", "E. Nativos", "Óxidos", "Hidróxidos", "Carbonatos", "Haletos"};
                LimitFilterGroupNotSilicate(groupNotSillicate.Length-1);
                nameFilter[2].text = groupNotSillicate[filterGroupNotSilicate];
            break;
        }
    }

    public void BackMenu() // entrar e sair do menu de detalhes
    {
        canvas[0].SetActive(true);
        canvas[1].SetActive(false);
    }

    public void Preencher(string[] lista)
    {
        for(int i=0; i<40; i++)// silicatellist
        {
            if(i < lista.Length)
            {
                gemButtons[i].SetActive(true);
                gemButtons[i].GetComponent<GemButton>().title = lista[i];
            }else{
                gemButtons[i].SetActive(false);
                }  
        }
    }

    public void AlphabeticalOrder()// Ordem alfabetica
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

                switch (filterGroupSilicate)
                {
                    //{"Todos", "Neso", "Soro", "Ciclo", "Ino", "Filo", "Tecto"};
                    case 0: //todos
                        string[] all = {"Anfibólio", "Berilo", "Biotita", "Caulinita", 
                                        "Cianita", "Clorita", "Epidoto", "Esmectita", 
                                        "Espodumênio", "Granada", "Illita", "K-feldspato", 
                                        "Muscovita", "Olivina", "Piroxênio", "Plagioclásio",
                                        "Quartzo", "Talco", "Topázio", "Turmalina"};
                        Preencher(all);
                    break;
                    case 1://neso
                        string[] neso = {"Cianita", "Granada", "Olivina","Topázio"};
                        Preencher(neso);
                    break;
                    case 2://soro
                        string[] soro = {"Epidoto"};
                        Preencher(soro);
                    break;
                    case 3://ciclo
                        string[] ciclo = {"Berilo","Turmalina"};
                        Preencher(ciclo);
                    break;
                    case 4://ino
                        string[] ino = {"Anfibólio", "Espodumênio", "Piroxênio"};
                        Preencher(ino);
                    break;
                    case 5://filo
                        string[] filo = {"Biotita", "Caulinita", "Clorita", "Esmectita", 
                                                 "Illita", "Muscovita", "Talco"};
                        Preencher(filo);
                    break;
                    case 6://tetco
                        string[] tecto = {"K-feldspato", "Plagioclásio", "Quartzo"};
                        Preencher(tecto);
                    break;
                }

                // Pensei em uma forma de filtrar as classes usando loops identados
                // mas por algum motivo o unity trava quando ativo
                // então por hora vou criar as listas filtradas dentro da função

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

                switch (filterGroupNotSilicate)
                {
                    //{"Todos", "Sulfetos", "Sulfatos", "Fosfatos", "E. Nativos", "Óxidos", "Hidróxidos", "Carbonatos", "Haletos"};
                    case 0: //todos
                        string[] all = {"Apatita", "Barita", "Bauxita", "Calcita", 
                                            "Calcopirita", "Cassiterita", "Coríndon", "Diamante", 
                                            "Dolomita", "Esfalerita", "Fluorita", "Galena", 
                                            "Gipsita", "Hematita", "Ilmenita", "Magnetita", 
                                            "Molibdenita", "Ouro", "Pirita", "Romanechita"};
                        Preencher(all);
                    break;
                    case 1://Sulfetos
                        string[] sulfetos = {"Calcopirita", "Esfalerita", "Galena", "Molibdenita",
                                            "Pirita"};
                        Preencher(sulfetos);
                    break;
                    case 2://Sulfatos
                        string[] sulfatos = {"Barita", "Gipsita"};
                        Preencher(sulfatos);
                    break;
                    case 3://Fosfatos
                        string[] fosfatos = {"Apatita"};
                        Preencher(fosfatos);
                    break;
                    case 4://eNativos
                        string[] eNativos = {"Diamante", "Ouro"};
                        Preencher(eNativos);
                    break;
                    case 5://oxidos
                        string[] oxidos = {"Cassiterita", "Coríndon", "Hematita", "Ilmenita", 
                                        "Magnetita", "Romanechita"};
                        Preencher(oxidos);
                    break;
                    case 6://Hidróxidos
                        string[] hidróxidos = {"Bauxita"};
                        Preencher(hidróxidos);
                    break;
                    case 7://Carbonatos
                        string[] carbonatos = {"Calcita", "Dolomita"};
                        Preencher(carbonatos);
                    break;
                    case 8://Haletos
                        string[] haletos = {"Fluorita"};
                        Preencher(haletos);
                    break;
                }
            break;
            
        }
        
        SetButton();
    }

    public void HardnessOrder() // Ordenar dureza
    { 
        switch (filterClass)
        {
            case 0: //todos
                for(int i=0; i<40; i++)
                {
                    gemButtons[i].SetActive(true);
                    gemButtons[i].GetComponent<GemButton>().title = hardnessList[i];
                }
                
            break;
            case 1: // silicatos

                switch (filterGroupSilicate)
                {
                    
                    //{"Todos", "Neso", "Soro", "Ciclo", "Ino", "Filo", "Tecto"};
                    case 0: //todos
                        string[] all = {"Talco", "Caulinita", "Esmectita", "Illita",
                                        "Clorita", "Biotita","Muscovita","Anfibólio", 
                                        "K-feldspato","Plagioclásio","Cianita", "Epidoto",
                                        "Espodumênio", "Piroxênio", "Olivina", "Quartzo",
                                        "Granada", "Berilo", "Turmalina", "Topázio"};
                        Preencher(all);
                    break;
                    case 1://neso
                        string[] neso = {"Cianita", "Olivina", "Granada", "Topázio"};
                        Preencher(neso);
                    break;
                    case 2://soro
                        string[] soro = {"Epidoto"};
                        Preencher(soro);
                    break;
                    case 3://ciclo
                        string[] ciclo = {"Berilo","Turmalina"};
                        Preencher(ciclo);
                    break;
                    case 4://ino
                        string[] ino = {"Anfibólio", "Espodumênio", "Piroxênio"};
                        Preencher(ino);
                    break;
                    case 5://filo
                        string[] filo = {"Talco", "Caulinita", "Esmectita", "Illita",
                                        "Clorita", "Biotita",  "Muscovita" };
                        Preencher(filo);
                    break;
                    case 6://tetco
                        string[] tecto = {"K-feldspato", "Plagioclásio", "Quartzo"};
                        Preencher(tecto);
                    break;
                }

            break;
            case 2: // não silicatos

                switch (filterGroupNotSilicate)
                {
                    //{"Todos", "Sulfetos", "Sulfatos", "Fosfatos", "E. Nativos", "Óxidos", "Hidróxidos", "Carbonatos", "Haletos"};
                    case 0: //todos
                        string[] all = {"Molibdenita", "Gipsita", "Bauxita", "Galena", 
                                        "Ouro", "Calcita", "Barita", "Calcopirita", 
                                        "Dolomita", "Esfalerita", "Fluorita", "Apatita",
                                        "Ilmenita", "Romanechita", "Hematita", "Magnetita", 
                                        "Pirita", "Cassiterita", "Coríndon", "Diamante"};
                        Preencher(all);
                    break;
                    case 1://Sulfetos
                        string[] sulfetos = {"Molibdenita", "Galena","Calcopirita", "Esfalerita",  
                                            "Pirita"};
                        Preencher(sulfetos);
                    break;
                    case 2://Sulfatos
                        string[] sulfatos = {"Gipsita", "Barita"};
                        Preencher(sulfatos);
                    break;
                    case 3://Fosfatos
                        string[] fosfatos = {"Apatita"};
                        Preencher(fosfatos);
                    break;
                    case 4://eNativos
                        string[] eNativos = {"Ouro", "Diamante",};
                        Preencher(eNativos);
                    break;
                    case 5://oxidos
                        string[] oxidos = { "Ilmenita", "Romanechita", "Hematita",
                                            "Magnetita", "Cassiterita", "Coríndon"};
                        Preencher(oxidos);
                    break;
                    case 6://Hidróxidos
                        string[] hidróxidos = {"Bauxita"};
                        Preencher(hidróxidos);
                    break;
                    case 7://Carbonatos
                        string[] carbonatos = {"Calcita", "Dolomita"};
                        Preencher(carbonatos);
                    break;
                    case 8://Haletos
                        string[] haletos = {"Fluorita"};
                        Preencher(haletos);
                    break;
                }
            break;
        }

        SetButton();
    }

    public void DensityOrder() // Ordenar densidade
    {
      
        switch (filterClass)
        {
            case 0: //todos
                for(int i=0; i<40; i++)
                {
                    gemButtons[i].SetActive(true);
                    gemButtons[i].GetComponent<GemButton>().title = densityList[i];
                }
                
            break;
            case 1: // silicatos

                switch (filterGroupSilicate)
                {
                    
                    //{"Todos", "Neso", "Soro", "Ciclo", "Ino", "Filo", "Tecto"};
                    case 0: //todos
                        string[] all = {"K-feldspato", "Caulinita", "Esmectita", "Illita", 
                                            "Plagioclásio", "Berilo", "Quartzo", "Talco",
                                            "Muscovita", "Biotita", "Clorita", "Olivina", 
                                            "Anfibólio", "Turmalina", "Piroxênio", "Epidoto",
                                            "Espodumênio", "Topázio", "Cianita", "Granada"};
                        Preencher(all);
                    break;
                    case 1://neso
                        string[] neso = { "Olivina", "Topázio", "Cianita","Granada"};
                        Preencher(neso);
                    break;
                    case 2://soro
                        string[] soro = {"Epidoto"};
                        Preencher(soro);
                    break;
                    case 3://ciclo
                        string[] ciclo = {"Berilo","Turmalina"};
                        Preencher(ciclo);
                    break;
                    case 4://ino
                        string[] ino = {"Anfibólio", "Piroxênio", "Espodumênio"};
                        Preencher(ino);
                    break;
                    case 5://filo
                        string[] filo = {"Caulinita", "Esmectita","Illita", "Talco",   
                                         "Muscovita", "Biotita","Clorita" };
                        Preencher(filo);
                    break;
                    case 6://tetco
                        string[] tecto = {"K-feldspato", "Plagioclásio", "Quartzo"};
                        Preencher(tecto);
                    break;
                }

            break;
            case 2: // não silicatos

                string[] notSilicateDensList = {"Bauxita", "Gipsita", "Calcita", "Dolomita",
                                        "Apatita","Fluorita", "Calcopirita", "Coríndon", 
                                        "Esfalerita", "Barita", "Ilmenita", "Molibdenita", 
                                        "Diamante", "Pirita","Magnetita", "Hematita", 
                                        "Romanechita", "Cassiterita", "Galena", "Ouro"};

                switch (filterGroupNotSilicate)
                {
                    //{"Todos", "Sulfetos", "Sulfatos", "Fosfatos", "E. Nativos", "Óxidos", "Hidróxidos", "Carbonatos", "Haletos"};
                    case 0: //todos
                        string[] all = {"Bauxita", "Gipsita", "Calcita", "Dolomita",
                                        "Apatita","Fluorita", "Calcopirita", "Coríndon", 
                                        "Esfalerita", "Barita", "Ilmenita", "Molibdenita", 
                                        "Diamante", "Pirita","Magnetita", "Hematita", 
                                        "Romanechita", "Cassiterita", "Galena", "Ouro"};
                        Preencher(all);
                    break;
                    case 1://Sulfetos
                        string[] sulfetos = {"Calcopirita", "Esfalerita", "Molibdenita",
                                            "Pirita", "Galena"};
                        Preencher(sulfetos);
                    break;
                    case 2://Sulfatos
                        string[] sulfatos = {"Gipsita", "Barita"};
                        Preencher(sulfatos);
                    break;
                    case 3://Fosfatos
                        string[] fosfatos = {"Apatita"};
                        Preencher(fosfatos);
                    break;
                    case 4://eNativos
                        string[] eNativos = {"Diamante", "Ouro"};
                        Preencher(eNativos);
                    break;
                    case 5://oxidos
                        string[] oxidos = {"Coríndon", "Ilmenita", "Magnetita",
                                            "Hematita","Romanechita", "Cassiterita"};
                        Preencher(oxidos);
                    break;
                    case 6://Hidróxidos
                        string[] hidróxidos = {"Bauxita"};
                        Preencher(hidróxidos);
                    break;
                    case 7://Carbonatos
                        string[] carbonatos = {"Calcita", "Dolomita"};
                        Preencher(carbonatos);
                    break;
                    case 8://Haletos
                        string[] haletos = {"Fluorita"};
                        Preencher(haletos);
                    break;
                }

            break;
        }
    

        SetButton();
    }
  
}
