using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Observacao
/// </summary>
public class Observacao
{
    private int obs_cod;
    private string obs_valor;
    private string obs_dataObservacao;
    private Tramitacao _tramitacao;
    private Funcionario _funcionario;

    public int Obs_cod
    {
        get
        {
            return obs_cod;
        }

        set
        {
            obs_cod = value;
        }
    }

    public string Obs_valor
    {
        get
        {
            return obs_valor;
        }

        set
        {
            obs_valor = value;
        }
    }

    public string Obs_dataObservacao
    {
        get
        {
            return obs_dataObservacao;
        }

        set
        {
            obs_dataObservacao = value;
        }
    }

    public Tramitacao Tramitacao
    {
        get
        {
            return _tramitacao;
        }

        set
        {
            _tramitacao = value;
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