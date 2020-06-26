using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Home_Anunciante : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToInt32(Request.QueryString["cod"]) == 1)
        {
            Response.Write("<script language = 'javascript'>alert('Proposta enviada com sucesso!');</script>");
        }
        PropEnviadas();
        PropAceitas();
        PropRecusadas();
    }
    public void PropEnviadas()
    {
        Conexao c = new Conexao();
        c.conectar();
        c.command.CommandText = "select count(*) as Enviadas from Anuncio where Anunciante_idAnunciante = @cod and validacao = 0";
        c.command.Parameters.Add("@cod", SqlDbType.Int).Value = ((int)Session["codigoAnunciante"]);
        SqlDataAdapter dAdapter = new SqlDataAdapter();
        DataSet dt = new DataSet();
        dAdapter.SelectCommand = c.command;
        dAdapter.Fill(dt);
        lblEnviados.Text = dt.Tables[0].DefaultView[0].Row["Enviadas"].ToString();
    }
    public void PropAceitas()
    {
        Conexao c = new Conexao();
        c.conectar();
        c.command.CommandText = "select count(*) as Aceitas from Anuncio where Anunciante_idAnunciante = @cod and validacao = 1";
        c.command.Parameters.Add("@cod", SqlDbType.Int).Value = ((int)Session["codigoAnunciante"]);
        SqlDataAdapter dAdapter = new SqlDataAdapter();
        DataSet dt = new DataSet();
        dAdapter.SelectCommand = c.command;
        dAdapter.Fill(dt);
        lblAceitos.Text = dt.Tables[0].DefaultView[0].Row["Aceitas"].ToString();
    }
    public void PropRecusadas()
    {
        Conexao c = new Conexao();
        c.conectar();
        c.command.CommandText = "select count(*) as Recusadas from Anuncio where Anunciante_idAnunciante = @cod and validacao = 2";
        c.command.Parameters.Add("@cod", SqlDbType.Int).Value = ((int)Session["codigoAnunciante"]);
        SqlDataAdapter dAdapter = new SqlDataAdapter();
        DataSet dt = new DataSet();
        dAdapter.SelectCommand = c.command;
        dAdapter.Fill(dt);
        lblRecusados.Text = dt.Tables[0].DefaultView[0].Row["Recusadas"].ToString();
    }
}