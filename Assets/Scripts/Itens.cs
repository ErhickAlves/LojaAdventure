using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Itens
{
    protected Identificador indentificador; //Iniciar o enun
    protected string nome;
    public string Nome 
    {
        get
        {
            return nome;
        }
        set
        {
            nome = value;

            
        }
    }

    protected float preco;
    public float Preco 
    {
        get
        {
            return preco;
        }
        set
        {
            preco = value;

            
        }
    }

    public abstract void TrocarValor(float valor);
    
}

public class ArmasPrimarias : Itens
{
    public bool acumulativo = true;
    public ArmasPrimarias(float preco)
    {
        indentificador = Identificador.ArmasPrimaria;
        this.preco = preco;
    }

    public override void TrocarValor(float valor)
    {
        valor = preco;
    }
}

public class ArmasSecundaria : Itens

{
     public bool acumulativo = true;
    public ArmasSecundaria(float preco)
    {
        indentificador = Identificador.ArmasSecundaria;
        this.preco = preco;
    }

    public override void TrocarValor(float valor)
    {
        valor = preco;
    }
}

public class Consumiveis : Itens
{
    public Consumiveis(float preco)
    {
        indentificador = Identificador.Consumiveis;
        this.preco = preco;
    }

    public override void TrocarValor(float valor)
    {
        valor = preco;
    }
}


