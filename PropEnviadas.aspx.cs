using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PropEnviadas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Conexao c = new Conexao();
        c.conectar();
        c.command.CommandText = "select count(*) as Enviadas from Anuncio where Anunciante_idAnunciante = @cod and validacao = 0";
        c.command.Parameters.Add("@cod", SqlDbType.Int).Value = ((int)Session["codigoAnunciante"]);
        SqlDataAdapter dAdapter = new SqlDataAdapter();
        DataSet dt = new DataSet();
        dAdapter.SelectCommand = c.command;
        dAdapter.Fill(dt);
        for (int i = 0; i < Convert.ToInt32(dt.Tables[0].DefaultView[0].Row["Enviadas"]); i++)
        {
            c.command.CommandText = "select titulo,link,descricao,imagem from Anuncio where Anunciante_idAnunciante = @cod and validacao = 0";
            DataSet dt2 = new DataSet();
            dAdapter.SelectCommand = c.command;
            dAdapter.Fill(dt2);
            string Titulo = dt2.Tables[0].DefaultView[i].Row["titulo"].ToString();
            string Link = dt2.Tables[0].DefaultView[i].Row["link"].ToString();
            string Descricao = dt2.Tables[0].DefaultView[i].Row["descricao"].ToString();
            //Troquei o byte[] imgBytes = (byte[])dt.Tables[0].DefaultView[0].Row["foto"]; 
            //pelo código abaixo para não crashar se não tiver imagem
            byte[] imgBytes = new byte[0];

            if (dt2.Tables[0].DefaultView[0].Row["imagem"] != DBNull.Value)
            {
                imgBytes = (byte[])dt2.Tables[0].DefaultView[i].Row["imagem"];
            }
            string strBase64 = Convert.ToBase64String(imgBytes);
            string anunAtual = "<div class='card'><style>.card-img-top{width='100%'; height: 225;} </style><img src='data:Images/jpg;base64," + strBase64 + "'class='card-img-top'/><div class='card-body'><h1 class='card-title'>" + Titulo + "</h1><br /><p class='card-text'>" + Descricao + "</p><br /><a href = '" + Link + "' class='btn btn-primary'>Ver Mais</a></div></div>";
            GeraAnun.InnerHtml += anunAtual;
            Titulo = "";
            Link = "";
            //<style>.card-img-top{width: 500px; height: 300px;} </style>
        }
    }
}