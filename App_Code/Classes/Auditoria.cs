using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Auditoria
/// </summary>
public class Auditoria
{
    private int aud_cod;
    private int aud_funcionario;
    private string aud_tabela;
    private string aud_acao;
    private string aud_data;
    private string aud_dadosAntes;
    private string aud_dadosDepois;

    public int Aud_cod
    {
        set { aud_cod = value; }
        get { return aud_cod; }
    }

    public int Aud_funcionario
    {
        set { aud_funcionario = value; }
        get { return aud_funcionario; }
    }

    public string Aud_tabela
    {
        set { aud_tabela = value; }
        get { return aud_tabela; }
    }

    public string Aud_acao
    {
        set { aud_acao = value; }
        get { return aud_acao; }
    }

    public string Aud_data
    {
        set { aud_data = value; }
        get { return aud_data; }
    }

    public string Aud_dadosAntes
    {
        set { aud_dadosAntes = value; }
        get { return aud_dadosAntes; }
    }

    public string Aud_dadosDepois
    {
        set { aud_dadosDepois = value; }
        get { return aud_dadosDepois; }
    }

}