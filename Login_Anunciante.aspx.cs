using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login_Anunciante : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnLog_Click(object sender, EventArgs e)
    {
        string login = txtNome.Text;
        string senha = txtSenha.Text;
        Conexao c = new Conexao();
        c.conectar();
        c.command.CommandText = "select * from Anunciante where loginAnunciante=@Login and senhaAnunciante=@Senha";
        c.command.Parameters.Add("@Login", SqlDbType.VarChar).Value = login;
        c.command.Parameters.Add("@Senha", SqlDbType.VarChar).Value = senha;
        SqlDataAdapter dAdapter = new SqlDataAdapter();
        DataSet dt = new DataSet();
        dAdapter.SelectCommand = c.command;
        dAdapter.Fill(dt);
        int qtde = dt.Tables[0].DefaultView.Count;
        if (qtde >= 1)
        {
            Session["codigoAnunciante"] = Convert.ToInt32(dt.Tables[0].DefaultView[0].Row["idAnunciante"]);
            Response.Redirect("Home_Anunciante.aspx");
        }
        else
        {
            Response.Write("<script language = 'javascript'>" + "alert('Login invalido');</script>");
        }
    }
}