using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PropAceitas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Conexao c = new Conexao();
        c.conectar();
        c.command.CommandText = "select count(*) as Aceitas from Anuncio where Anunciante_idAnunciante = @cod and validacao = 1";
        c.command.Parameters.Add("@cod", SqlDbType.Int).Value = ((int)Session["codigoAnunciante"]);
        SqlDataAdapter dAdapter = new SqlDataAdapter();
        DataSet dt = new DataSet();
        dAdapter.SelectCommand = c.command;
        dAdapter.Fill(dt);
        for (int i = 0; i<Convert.ToInt32(dt.Tables[0].DefaultView[0].Row["Aceitas"]); i++)
        {
            c.command.CommandText = "select titulo,link,descricao,imagem from Anuncio where Anunciante_idAnunciante = @cod and validacao = 1";
            DataSet dt2 = new DataSet();
            dAdapter.SelectCommand = c.command;
            dAdapter.Fill(dt2);
            string Titulo = dt2.Tables[0].DefaultView[i].Row["titulo"].ToString();
            string Link = dt2.Tables[0].DefaultView[i].Row["link"].ToString();
            string Descricao = dt2.Tables[0].DefaultView[i].Row["descricao"].ToString();
            byte[] imgBytes = (byte[])dt2.Tables[0].DefaultView[i].Row["imagem"];
            string strBase64 = Convert.ToBase64String(imgBytes);
            string anunAtual = "<div class='card'><style>.card-img-top{width='100%'; height: 225;} </style><img src='data:Images/jpg;base64," + strBase64 + "'class='card-img-top'/><div class='card-body'><h1 class='card-title'>" + Titulo + "</h1><br /><p class='card-text'>" + Descricao + "</p><br /><a href = '" + Link + "' class='btn btn-primary'>Ver Mais</a></div></div>";
            GeraAnun.InnerHtml += anunAtual;
            Titulo = "";
            Link = "";
        }
    }











    /**
            for(int f = 0; f < i; f++)
            {
                c.command.CommandText = "select titulo,link from Anuncio where Anunciante_idAnunciante = @cod and validacao = 1";
                DataSet dt3 = new DataSet();
                dAdapter.SelectCommand = c.command;
                dAdapter.Fill(dt3);
                string Titulo2 = dt3.Tables[0].DefaultView[0].Row["titulo"].ToString();
                string Link2 = dt3.Tables[0].DefaultView[0].Row["link"].ToString();
                string anunAtual2 = "<div class='card'> <div class='card-body'><h1 class='card-title'>" + Titulo2 + "</h1></asp:Label><br /><p class='card-text'>Algum texto de exemplo.Mais um texto de exemplo</p><br /><a href = '" + Link2 + "' class='btn btn-primary'>Ver Mais</a></div></div>";
                GeraAnun.InnerHtml = anunAtual2;
                Titulo2 = "";
                Link2 = "";
            }
         **/
}