using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Tramitacao
/// </summary>
public class Tramitacao
{
    private int tra_cod;
    private string tra_localAtual;
    private string tra_localAnteriror;
    private string tra_localEnviado;
    private string tra_dataEnvio;
    private string tra_observacao;
    private DetalhesProcesso _detalhesProcesso;
    private Funcionario _funcionario;
    private int? cod_fun;

    public int Tra_cod
    {
        set { tra_cod = value; }
        get { return tra_cod; }
    }

    public string Tra_localAtual
    {
        set { tra_localAtual = value; }
        get { return tra_localAtual; }
    }

    public string Tra_localAnteriror
    {
        set { tra_localAnteriror = value; }
        get { return tra_localAnteriror; }
    }

    public string Tra_localEnviado
    {
        set { tra_localEnviado = value; }
        get { return tra_localEnviado; }
    }

    public string Tra_dataEnvio
    {
        set { tra_dataEnvio = value; }
        get { return tra_dataEnvio; }
    }

    public string Tra_observacao
    {
        set { tra_observacao = value; }
        get { return tra_observacao; }
    }

    public int? Cod_fun
    {
        set { cod_fun = value; }
        get { return cod_fun; }
    }

    public DetalhesProcesso DetalhesProcesso
    {
        get
        {
            return _detalhesProcesso;
        }

        set
        {
            _detalhesProcesso = value;
        }
    }

    public Funcionario Funcionario
    {
        get
        {
            return _funcionario;
        }

        set
        {
            _funcionario = value;
        }
    }
}