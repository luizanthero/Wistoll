using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wistoll.Funcoes;

/// <summary>
/// Summary description for FuncionarioCrypto
/// </summary>
public class FuncionarioCrypto : Funcionario
{
    public override string Fun_senha
    {
        get
        {
            return base.Fun_senha;
        }

        set
        {
            base.Fun_senha = Funcoes.HashTexto(value);
        }
    }
}