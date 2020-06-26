using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Perfil : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        txtNome.Visible = false;
        txtEmail.Visible = false;
        txtTel.Visible = false;
        fupImg.Visible = false;
        btnEdit.Visible = false;
        CarregaPage();
    }
    public void CarregaPage()
    {
        Conexao c = new Conexao();
        c.conectar();
        c.command.CommandText = "select nomeUsuario,emailUsuario,telefoneUsuario,foto from Usuario where idUsuario = @cod";
        c.command.Parameters.Add("@cod", SqlDbType.Int).Value = ((int)Session["codigoUsuario"]);
        SqlDataAdapter dAdapter = new SqlDataAdapter();
        DataSet dt = new DataSet();
        dAdapter.SelectCommand = c.command;
        dAdapter.Fill(dt);
        lblNome.Text = dt.Tables[0].DefaultView[0].Row["nomeUsuario"].ToString();
        lblEmail.Text = dt.Tables[0].DefaultView[0].Row["emailUsuario"].ToString();
        lblTel.Text = dt.Tables[0].DefaultView[0].Row["telefoneUsuario"].ToString();
        //Troquei o byte[] imgBytes = (byte[])dt.Tables[0].DefaultView[0].Row["foto"]; 
        //pelo código abaixo para não crashar se não tiver imagem
        byte[] imgBytes = new byte[0];

        if (dt.Tables[0].DefaultView[0].Row["foto"] != DBNull.Value)
        {
            imgBytes = (byte[])dt.Tables[0].DefaultView[0].Row["foto"];
        }

        string strBase64 = Convert.ToBase64String(imgBytes);
        imgPerfil.ImageUrl = "data:Images/jpg;base64," + strBase64;
    }
    public void CarregaEdit()
    {
        Conexao c = new Conexao();
        c.conectar();
        c.command.CommandText = "select nomeUsuario,emailUsuario,telefoneUsuario,foto from Usuario where idUsuario = @cod";
        c.command.Parameters.Add("@cod", SqlDbType.Int).Value = ((int)Session["codigoUsuario"]);
        SqlDataAdapter dAdapter = new SqlDataAdapter();
        DataSet dt = new DataSet();
        dAdapter.SelectCommand = c.command;
        dAdapter.Fill(dt);

        //Abilitar Items De Edição
        txtNome.Visible = true;
        txtEmail.Visible = true;
        txtTel.Visible = true;
        fupImg.Visible = true;
        btnEdit.Visible = true;

        //Desablitar Items de Visulalização
        lblNome.Visible = false;
        lblEmail.Visible = false;
        lblTel.Visible = false;

        //Caregar Items De Edição
        txtNome.Text = dt.Tables[0].DefaultView[0].Row["nomeUsuario"].ToString();
        txtEmail.Text = dt.Tables[0].DefaultView[0].Row["emailUsuario"].ToString();
        txtTel.Text = dt.Tables[0].DefaultView[0].Row["telefoneUsuario"].ToString();
    }



    protected void imgedit_Click(object sender, ImageClickEventArgs e)
    {
        CarregaEdit();
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        Conexao c = new Conexao();
        c.conectar();
        if (fupImg.HasFile)
        {
            int length = fupImg.PostedFile.ContentLength;
            byte[] imgbyte = new byte[length];
            HttpPostedFile img = fupImg.PostedFile;
            img.InputStream.Read(imgbyte, 0, length);
            c.command.CommandText = "update Usuario set foto = @fUsu where idUsuario = @cod";
            c.command.Parameters.Add("@cod", SqlDbType.Int).Value = ((int)Session["codigoUsuario"]);
            c.command.Parameters.Add("@fUsu", SqlDbType.VarBinary).Value = imgbyte;
            c.command.ExecuteNonQuery();

            c.command.CommandText = "update Usuario set nomeUsuario = @nUsu where idUsuario = @cod";
            c.command.Parameters.Add("@nUsu", SqlDbType.VarChar).Value = txtNome.Text;
            c.command.ExecuteNonQuery();

            c.command.CommandText = "update Usuario set emailUsuario = @eUsu where idUsuario = @cod";
            c.command.Parameters.Add("@eUsu", SqlDbType.VarChar).Value = txtEmail.Text;
            c.command.ExecuteNonQuery();

            c.command.CommandText = "update Usuario set telefoneUsuario = @tUsu where idUsuario = @cod";
            c.command.Parameters.Add("@tUsu", SqlDbType.VarChar).Value = txtTel.Text;
        }
        else 
        {
            c.command.CommandText = "update Usuario set nomeUsuario = @nUsu where idUsuario = @cod";
            c.command.Parameters.Add("@cod", SqlDbType.Int).Value = ((int)Session["codigoUsuario"]);
            c.command.Parameters.Add("@nUsu", SqlDbType.VarChar).Value = txtNome.Text;
            c.command.ExecuteNonQuery();

            c.command.CommandText = "update Usuario set emailUsuario = @eUsu where idUsuario = @cod";
            c.command.Parameters.Add("@eUsu", SqlDbType.VarChar).Value = txtEmail.Text;
            c.command.ExecuteNonQuery();

            c.command.CommandText = "update Usuario set telefoneUsuario = @tUsu where idUsuario = @cod";
            c.command.Parameters.Add("@tUsu", SqlDbType.VarChar).Value = txtTel.Text;
            c.command.ExecuteNonQuery();
        }
        Response.Redirect("Perfil.aspx");
    }
}