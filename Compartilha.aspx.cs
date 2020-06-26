using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Compartilha : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int idAmigo = Convert.ToInt32(Request.QueryString["idAmigo"]);
        int idAnotacao = Convert.ToInt32(Request.QueryString["idAnotacao"]);
        int idReamigo = Convert.ToInt32(Request.QueryString["idReamigo"]);

        Conexao c = new Conexao();
        c.conectar();
        c.command.CommandText = "insert into Anotacao_Compartilhada(idUsuario,idAmigo,idAnotacao) values(@cod,@idAmi,@idAno)";
        c.command.Parameters.Add("@cod", SqlDbType.Int).Value = (int)Session["codigoUsuario"];
        c.command.Parameters.Add("@idAmi", SqlDbType.Int).Value = idReamigo;
        c.command.Parameters.Add("@idAno", SqlDbType.Int).Value = idAnotacao;
        c.command.ExecuteNonQuery();
        c.fechaConexao();

        Response.Redirect("HomeLog.aspx?Share=1");
    }
}