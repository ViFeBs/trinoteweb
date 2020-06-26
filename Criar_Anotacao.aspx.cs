using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Criar_Anotacao : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSalvar_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {
            string Fonte = "";
            //Fonts
            if (DropDownList1.SelectedValue == "Amatic SC")
            {
                Fonte = "'Amatic SC',cursive;";
            }
            else if (DropDownList1.SelectedValue == "Sacramento")
            {
                Fonte = "'Sacramento', cursive;";
            }
            else if (DropDownList1.SelectedValue == "Dancing Script")
            {
                Fonte = "'Dancing Script', cursive;";
            }
            else if (DropDownList1.SelectedValue == "Press Start 2P")
            {
                Fonte = "'Press Start 2P', cursive;";
            }
            else if (DropDownList1.SelectedValue == "Tangerine")
            {
                Fonte = "'Tangerine', cursive;";
            }
            else if (DropDownList1.SelectedValue == "Notable")
            {
                Fonte = "'Notable', sans-serif;";
            }
            else if (DropDownList1.SelectedValue == "Reenie Beanie")
            {
                Fonte = "'Reenie Beanie', cursive;";
            }
            else if (DropDownList1.SelectedValue == "Pinyon Script")
            {
                Fonte = "'Pinyon Script', cursive;";
            }
            else if (DropDownList1.SelectedValue == "Ruge Boogie")
            {
                Fonte = "'Ruge Boogie', cursive;";
            }
            //"Pegando" a Imagem
            int length = FileUpload1.PostedFile.ContentLength;
            byte[] imgbyte = new byte[length];
            HttpPostedFile img = FileUpload1.PostedFile;
            img.InputStream.Read(imgbyte, 0, length);
            //Outros Dados
            DateTime dt = new DateTime();
            string Titulo = txtTitulo.Text, Conteudo = TxtAnotacao.Text;
            Conexao c = new Conexao();
            c.conectar();
            c.command.CommandText = "Insert into Anotacao(usuarioCria,usuarioVisualiza,usuarioAltera,usuarioComenta,usuarioExclui,titulo,conteudo,dataHoraCriacao,dataHoraAlteracao,dataHoraComentario,dataHoraExclusao,statusAnotacao,Imagem,Font) Values(@usuCri,@usuVi,@usuAlt,@usuCom,@usuExc,@tit,@con,@dtCri,@dtAlt,@dtCom,@dtExc,@stt,@img,@Fo)";
            c.command.Parameters.Add("@usuCri", SqlDbType.Int).Value = ((int)Session["codigoUsuario"]);
            c.command.Parameters.Add("@usuVi", SqlDbType.Int).Value = ((int)Session["codigoUsuario"]);
            c.command.Parameters.Add("@usuAlt", SqlDbType.Int).Value = ((int)Session["codigoUsuario"]);
            c.command.Parameters.Add("@usuCom", SqlDbType.Int).Value = ((int)Session["codigoUsuario"]);
            c.command.Parameters.Add("@usuExc", SqlDbType.Int).Value = ((int)Session["codigoUsuario"]);
            c.command.Parameters.Add("@tit", SqlDbType.VarChar).Value = Titulo;
            c.command.Parameters.Add("@con", SqlDbType.VarChar).Value = Conteudo;
            c.command.Parameters.Add("@dtCri", SqlDbType.DateTime).Value = DateTime.Now;
            c.command.Parameters.Add("@dtAlt", SqlDbType.DateTime).Value = DateTime.Now;
            c.command.Parameters.Add("@dtCom", SqlDbType.DateTime).Value = DateTime.Now;
            c.command.Parameters.Add("@dtExc", SqlDbType.DateTime).Value = DateTime.Now;
            c.command.Parameters.Add("@stt", SqlDbType.Bit).Value = 1;
            c.command.Parameters.Add("@img", SqlDbType.VarBinary).Value = imgbyte;
            c.command.Parameters.Add("@Fo", SqlDbType.VarChar).Value = Fonte;
            c.command.ExecuteNonQuery();
            c.fechaConexao();
            Response.Redirect("HomeLog.aspx?cod=1");
        }
        else
        {
            
        }
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(DropDownList1.SelectedValue == "Amatic SC")
        {
            txtTitulo.Font.Name = "Amatic SC";
            TxtAnotacao.Font.Name = "Amatic SC";
            lblFont.Font.Name = "Amatic SC";
            txtTitulo.Font.Size = 30;
            TxtAnotacao.Font.Size = 20;
        }
        else if(DropDownList1.SelectedValue == "Sacramento")
        {
            txtTitulo.Font.Name = "Sacramento";
            TxtAnotacao.Font.Name = "Sacramento";
            lblFont.Font.Name = "Sacramento";
            txtTitulo.Font.Size = 30;
            TxtAnotacao.Font.Size = 20;
        }
        else if (DropDownList1.SelectedValue == "Dancing Script")
        {
            txtTitulo.Font.Name = "Dancing Script";
            TxtAnotacao.Font.Name = "Dancing Script";
            lblFont.Font.Name = "Dancing Script";
            txtTitulo.Font.Size = 30;
            TxtAnotacao.Font.Size = 20;
        }
        else if (DropDownList1.SelectedValue == "Press Start 2P")
        {
            txtTitulo.Font.Name = "Press Start 2P";
            TxtAnotacao.Font.Name = "Press Start 2P";
            lblFont.Font.Name = "Press Start 2P";
            txtTitulo.Font.Size = 30;
            TxtAnotacao.Font.Size = 20;
        }
        else if (DropDownList1.SelectedValue == "Tangerine")
        {
            txtTitulo.Font.Name = "Tangerine";
            TxtAnotacao.Font.Name = "Tangerine";
            lblFont.Font.Name = "Tangerine";
            txtTitulo.Font.Size = 30;
            TxtAnotacao.Font.Size = 20;
        }
        else if (DropDownList1.SelectedValue == "Notable")
        {
            txtTitulo.Font.Name = "Notable";
            TxtAnotacao.Font.Name = "Notable";
            lblFont.Font.Name = "Notable";
            txtTitulo.Font.Size = 30;
            TxtAnotacao.Font.Size = 20;
        }
        else if (DropDownList1.SelectedValue == "Reenie Beanie")
        {
            txtTitulo.Font.Name = "Reenie Beanie";
            TxtAnotacao.Font.Name = "Reenie Beanie";
            lblFont.Font.Name = "Reenie Beanie";
            txtTitulo.Font.Size = 30;
            TxtAnotacao.Font.Size = 20;
        }
        else if (DropDownList1.SelectedValue == "Pinyon Script")
        {
            txtTitulo.Font.Name = "Pinyon Script";
            TxtAnotacao.Font.Name = "Pinyon Script";
            lblFont.Font.Name = "Pinyon Script";
            txtTitulo.Font.Size = 30;
            TxtAnotacao.Font.Size = 20;
        }
        else if (DropDownList1.SelectedValue == "Ruge Boogie")
        {
            txtTitulo.Font.Name = "Ruge Boogie";
            TxtAnotacao.Font.Name = "Ruge Boogie";
            lblFont.Font.Name = "Ruge Boogie";
            txtTitulo.Font.Size = 30;
            TxtAnotacao.Font.Size = 20;
        }
    }

    protected void btnTeste_Click(object sender, EventArgs e)
    {
        TxtAnotacao.Font.Name = "Amatic SC";
        TxtAnotacao.Font.Size = 20;
    }
}