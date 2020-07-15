using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Anotacao_Compartilhada : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Conexao c = new Conexao();
        c.conectar();
        c.command.CommandText = "Select * from Anotacao where idAnotacao = @id";
        c.command.Parameters.Add("@id", SqlDbType.Int).Value = Convert.ToInt32(Request.QueryString["id"]);
        SqlDataAdapter dAdapter = new SqlDataAdapter();
        DataSet dt = new DataSet();
        dAdapter.SelectCommand = c.command;
        dAdapter.Fill(dt);

        byte[] imgBytes;
        if (dt.Tables[0].DefaultView[0].Row["Imagem"] == DBNull.Value)
        {
            imgBytes = BitConverter.GetBytes(0);
        }
        else
        {
            imgBytes = (byte[])dt.Tables[0].DefaultView[0].Row["Imagem"];
        }
        string strBase64 = Convert.ToBase64String(imgBytes);
        imgAnotacao.ImageUrl = "data:Images/jpg;base64," + strBase64;

        lblTitulo.InnerHtml = dt.Tables[0].DefaultView[0].Row["titulo"].ToString();
        lblConteudo.InnerHtml = dt.Tables[0].DefaultView[0].Row["conteudo"].ToString();

        string font = dt.Tables[0].DefaultView[0].Row["Font"].ToString();
        fonte.InnerHtml += " .font{font-family:" + font + "}";

    }
}