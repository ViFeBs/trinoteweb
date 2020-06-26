using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Conexao
/// </summary>
public class Conexao
{
    public SqlConnection conexao;
    public SqlCommand command;
    //string strConexao = "Server=localhost;DataBase=TrinoteTeste;user id=sa;password=teste@123";
    //string strConexao = "Server=localhost;DataBase=TrinoteTeste;user id=sa;password=123456";
    //string strConexao = "Server=localhost;DataBase=TrinoteTeste;user id=sa;password=etesp";
    //string strConexao = "Server=trinoteserver-1.database.windows.net;DataBase=TrinoteTeste;user id=tnazureuser;password=5NTb3gkp";
    string strConexao = "Server=TriNote.mssql.somee.com;DataBase=TriNote;user id=Brunno19_SQLLogin_1;password=nv3avw4tzp";
    //string strConexao = "Server=localhost;DataBase=Trinote;trusted_connection=true";

    public Conexao()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public void conectar()
    {

        conexao = new SqlConnection(strConexao);
        conexao.Open();
        command = new SqlCommand();
        command.Connection = conexao;

    }

    public void fechaConexao()
    {
        conexao.Close();
        conexao = null;
        command = null;

    }
}
