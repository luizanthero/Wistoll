using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;

/// <summary>
/// Summary description for UsuarioDB
/// </summary>
public class UsuarioDB
{
	public UsuarioDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    //select
    public static DataSet SelectPerfil()
    {
        DataSet ds = new DataSet();
        IDbConnection objConnection;
        IDbCommand objCommand;
        IDataAdapter objDataAdapter;
        objConnection = Mapped.Connection();
        objCommand = Mapped.Command("SELECT * FROM pfl_perfil ORDER BY pfl_descricao", objConnection);
        objDataAdapter = Mapped.Adapter(objCommand);
        objDataAdapter.Fill(ds); // O objeto DataAdapter vai preencher o DataSet com os dados do BD, 
        //O método Fill é o responsável por preencher o DataSet 
        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return ds;
    }

}