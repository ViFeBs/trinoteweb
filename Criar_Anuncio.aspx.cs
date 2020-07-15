using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Criar_Anuncio : System.Web.UI.Page
{
    int length = 0;
    byte[] imgbyte = null;
    HttpPostedFile img = null;
    string CaminhoImagem = "";
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSend_Click(object sender, EventArgs e)
    {

    }
    /**
    public void UploadFile(object sender,EventArgs e)
    {
        string folderPath = Server.MapPath("~/Images/");
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }
        FileUpload1.SaveAs(folderPath + Path.GetFileName(FileUpload1.FileName));
        CaminhoImagem = "~/Images/" + Path.GetFileName(FileUpload1.FileName);
    }
    **/
    protected void btnSend_Click1(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {
            //"Pegando" a Imagem
            length = FileUpload1.PostedFile.ContentLength;
            imgbyte = new byte[length];
            img = FileUpload1.PostedFile;
            img.InputStream.Read(imgbyte, 0, length);
            //Outros Dados
            string Titulo = txtTitulo.Text, Link = txtLink.Text, Anuncio = txtAnuncio.Text;
            DateTime termino = DateTime.Now;
            decimal valor = 0;
            if (DropDownList1.SelectedValue == "1 Semana R$30 Reais")
            {
                termino = termino.AddDays(7);
                valor = 30;
            }
            else if (DropDownList1.SelectedValue == "1 Mês R$100 Reais")
            {
                termino = termino.AddMonths(1);
                valor = 100;
            }
            else if (DropDownList1.SelectedValue == "1 Ano R$1000,00 Reais")
            {
                termino = termino.AddYears(1);
                valor = 1000;
            }
            Conexao c = new Conexao();
            c.conectar();
            //Insert dos Dados
            c.command.CommandText = "insert into Anuncio(Anunciante_idAnunciante,titulo,imagem,valor,link,descricao,dataTermino,validacao) values(@anu,@tit,@img,@val,@lin,@des,@dat,@stt)";
            c.command.Parameters.Add("@anu", SqlDbType.Int).Value = ((int)Session["codigoAnunciante"]);
            c.command.Parameters.Add("@tit", SqlDbType.VarChar).Value = Titulo;
            c.command.Parameters.Add("@img", SqlDbType.VarBinary).Value = imgbyte;
            c.command.Parameters.Add("@val", SqlDbType.Decimal).Value = valor;
            c.command.Parameters.Add("@lin", SqlDbType.VarChar).Value = Link;
            c.command.Parameters.Add("@des", SqlDbType.VarChar).Value = Anuncio;
            c.command.Parameters.Add("@dat", SqlDbType.DateTime).Value = termino;
            c.command.Parameters.Add("@stt", SqlDbType.Int).Value = 0;
            c.command.ExecuteNonQuery();
            Response.Redirect("Home_Anunciante.aspx?cod=1");
        }
        else
        {         
            string Titulo = txtTitulo.Text, Link = txtLink.Text, Anuncio = txtAnuncio.Text;
            DateTime termino = DateTime.Now;
            decimal valor = 0;
            if (DropDownList1.SelectedValue == "5 Minutos $10-Reais")
            {
                termino = termino.AddMinutes(5);
                valor = 10;
            }
            Conexao c = new Conexao();
            c.conectar();
            //Insert dos Dados
            c.command.CommandText = "insert into Anuncio(Anunciante_idAnunciante,titulo,valor,link,descricao,dataTermino,validacao) values(@anu,@tit,@val,@lin,@des,@dat,@stt)";
            c.command.Parameters.Add("@anu", SqlDbType.Int).Value = ((int)Session["codigoAnunciante"]);
            c.command.Parameters.Add("@tit", SqlDbType.VarChar).Value = Titulo;
            c.command.Parameters.Add("@val", SqlDbType.Decimal).Value = valor;
            c.command.Parameters.Add("@lin", SqlDbType.VarChar).Value = Link;
            c.command.Parameters.Add("@des", SqlDbType.VarChar).Value = Anuncio;
            c.command.Parameters.Add("@dat", SqlDbType.DateTime).Value = termino;
            c.command.Parameters.Add("@stt", SqlDbType.Int).Value = 0;
            c.command.ExecuteNonQuery();
            Response.Redirect("Home_Anunciante.aspx?cod=1");
        }
    }
}