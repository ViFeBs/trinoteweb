using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Solicitacoes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Conexao c = new Conexao();
        c.conectar();
        c.command.CommandText = "select count(*) as Solicitacoes from Solicitacao where idUsuario = @cod";
        c.command.Parameters.Add("@cod", SqlDbType.Int).Value = ((int)Session["codigoUsuario"]);
        SqlDataAdapter dAdapter = new SqlDataAdapter();
        DataSet dt = new DataSet();
        dAdapter.SelectCommand = c.command;
        dAdapter.Fill(dt);
        if (Convert.ToInt32(dt.Tables[0].DefaultView[0].Row["Solicitacoes"]) >= 1)
        {
            c.command.CommandText = "select idSolicitacao,dataHoraInicioSol,Motivo from Solicitacao where idUsuario = @cod and emAberto = 1";
            DataSet dt2 = new DataSet();
            dAdapter.SelectCommand = c.command;
            dAdapter.Fill(dt2);
            GridView1.DataSource = dt2;
            GridView1.DataBind();
        }
    }

    protected void btnEnv_Click(object sender, EventArgs e)
    {
        string Motivo = "";
        if (rdnBug.Checked == true)
        {
            Motivo = "Reportar Bug";
        }
        else if (rdnHate.Checked == true)
        {
            Motivo = "Reclamação";
        }
        else if (rdnOutro.Checked == true)
        {
            Motivo = "Outro";
        }
        Conexao c = new Conexao();
        c.conectar();
        //Insert dos Dados
        c.command.CommandText = "insert into Solicitacao(idUsuario,dataHoraInicioSol,Motivo,emEspera,emAberto) values(@cod,@dt,@mo,@emEsp,@emAber)";
        c.command.Parameters.Add("@cod", SqlDbType.Int).Value = ((int)Session["codigoUsuario"]);
        c.command.Parameters.Add("@dt", SqlDbType.DateTime).Value = DateTime.Now;
        c.command.Parameters.Add("@mo", SqlDbType.VarChar).Value = Motivo;
        c.command.Parameters.Add("@emEsp", SqlDbType.Bit).Value = 1;
        c.command.Parameters.Add("@emAber", SqlDbType.Bit).Value = 1;
        c.command.ExecuteNonQuery();
        Response.Redirect("Solicitacoes.aspx");
    }
}