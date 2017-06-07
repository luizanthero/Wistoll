using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Processo
/// </summary>
public class Processo
{
    private int pro_cod;
    private string pro_numeroProcesso;
    private string pro_dataPedido;
    private string pro_ativo;
    private ModeloRequerimento _modeloRequerimento;
    private Requerente _requerente;
    private Status _status;
    private int? cod_fun;


    public int Pro_cod
    {
        set { pro_cod = value; }
        get { return pro_cod; }
    }

    public string Pro_numeroProcesso
    {
        set { pro_numeroProcesso = value; }
        get { return pro_numeroProcesso; }
    }

    public string Pro_dataPedido
    {
        set { pro_dataPedido = value; }
        get { return pro_dataPedido; }
    }

    public string Pro_ativo
    {
        set { pro_ativo = value; }
        get { return pro_ativo; }
    }

    public int? Cod_fun
    {
        set { cod_fun = value; }
        get { return cod_fun; }
    }

    public Requerente Requerente
    {
        get
        {
            return _requerente;
        }

        set
        {
            _requerente = value;
        }
    }

    public ModeloRequerimento ModeloRequerimento
    {
        get
        {
            return _modeloRequerimento;
        }

        set
        {
            _modeloRequerimento = value;
        }
    }

    public Status Status
    {
        get
        {
            return _status;
        }

        set
        {
            _status = value;
        }
    }
}