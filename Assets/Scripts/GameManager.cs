using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    public GameObject painelTrocarItemAP;
    public GameObject painelTrocarItemAS;
    public Text dinheiroText;
    public Text avisosText;
    public float valorTemporario;
    public ArmasPrimarias armasPrimarias = new ArmasPrimarias(0);
    public ArmasSecundaria armasSecundaria = new ArmasSecundaria(0);
    public Consumiveis consumiveis = new Consumiveis(0);
    [SerializeField] private float dinheiro = 1500;


    void Start()
    {
        gameManager = this;   //Instancia o GameManager
        UpdateUI();
        AvisosManager(0);
    }

    public void ComprarArmaPrimaria(float valor)    //Função pra comprar as Armas Primarias
    {
        if(armasPrimarias.acumulativo == false)
        {
            painelTrocarItemAP.SetActive(true);
            valorTemporario = valor;
            return;
        }
        else
        {
            armasPrimarias.Preco = valor;
            ChecarDinheiro(armasPrimarias);
            armasPrimarias.acumulativo = false;
        }
        
       
    }

    public void TrocarValorAcumulativoAP()
    {
        dinheiro -= valorTemporario;
        painelTrocarItemAP.SetActive(false);
        ChecarDinheiro(armasPrimarias);
    }
    

    public void ComprarArmaSecundaria(float valor)
    {
        if(armasSecundaria.acumulativo == false)
        {
            painelTrocarItemAS.SetActive(true);
            valorTemporario = valor;
            return;
        }
        else
        {
            armasSecundaria.Preco = valor;
            ChecarDinheiro(armasSecundaria);
            armasSecundaria.acumulativo = false;
        }
    }
    public void TrocarValorAcumulativoAS()
    {
        dinheiro -= valorTemporario;
        painelTrocarItemAS.SetActive(false);
        ChecarDinheiro(armasSecundaria);
    }

    public void ComprarConsumiveis(float valor)
    {
        consumiveis.Preco = valor;
        ChecarDinheiro(consumiveis);
    }

    public void AddDinheiro(float total)   //Adiciona dinheiro ao total
    {
        dinheiro += total;
        UpdateUI();
    }

    public void ReduzirDinheiro(float total)   //Tira dinheiro do total
    {
        if(dinheiro >= total)
        {
            dinheiro -= total;
        }
        else
        {
            AvisosManager(2);
        }
        
        
        UpdateUI();
    }

    public void ChecarDinheiro(Itens item)    //Checar o dinheiro
    {
        if(item.Preco < dinheiro)       //Função pra saber se tem dinheiro
        {
            dinheiro -= item.Preco;
            UpdateUI();
        }
        else
        {
            AvisosManager(1);
        }
        
    }

    void UpdateUI()
    {
        dinheiroText.text = "Dinheiro: " + dinheiro.ToString();
    }

    public void AvisosManager(int opcao)
    {
         if(opcao == 0) //Função pra mostrar o Aviso
        {
            avisosText.text = "";
        }

        if(opcao == 1) //Função pra mostrar o Aviso
        {
            avisosText.text = "Dinheiro Insuficiente";
        }

        if(opcao == 2) //Função pra mostrar o Aviso
        {
            avisosText.text = "Não pode descontar mais";
        }
    }

    
  
}
