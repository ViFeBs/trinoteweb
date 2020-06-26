using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Criar_Login : System.Web.UI.Page
{
    int length = 0;
    byte[] imgbyte = null;
    HttpPostedFile img = null;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public int ValidarForm()
    {
        Regex rg = new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");
        if (txtNome.Text == "" && txtTel.Text == "" && txtEmail.Text == "" && txtCemail.Text == "" && txtLog.Text == "" && txtSenha.Text == "" && txtCsenha.Text == "")
        {
            return 1;
        }
        else if (txtNome.Text == "")
        {
            return 2;
        }
        else if (txtTel.Text == "")
        {
            return 3;
        }
        else if (txtEmail.Text == "")
        {
            return 4;
        }
        else if (txtCemail.Text == "")
        {
            return 5;
        }
        else if (txtLog.Text == "")
        {
            return 6;
        }
        else if (txtSenha.Text == "")
        {
            return 7;
        }
        else if (txtCsenha.Text == "")
        {
            return 8;
        }
        //else if (txtLog.Text == txtSenha.Text)
        //{
        //    return 9;
        //}
        if (rg.IsMatch(txtEmail.Text) == false)
        {
            return 10;
        }
        if (txtCemail.Text != txtEmail.Text)
        {
            return 11;
        }
        if (txtCsenha.Text != txtSenha.Text)
        {
            return 12;
        }
        return 0;
    }

    protected void btnCad_Click(object sender, EventArgs e)
    {
        int retorno = 0;
        retorno = ValidarForm();
        if (retorno == 1)//Todos
        {
            Response.Write("<script language = 'javascript'>alert('Todos os Campos estão vazios');</script>");
        }
        if (retorno == 2)//Nome
        {
            Response.Write("<script language = 'javascript'>alert('O Campo Nome Está Vazio');</script>");
        }
        if (retorno == 3)//Telefone
        {
            Response.Write("<script language = 'javascript'>alert('O Campo Telefone Está Vazio');</script>");
        }
        if (retorno == 4)//E-Mail
        {
            Response.Write("<script language = 'javascript'>alert('O Campo E-mail Está Vazio');</script>");
        }
        if (retorno == 5)//CEMAIL Vazio
        {
            Response.Write("<script language = 'javascript'>alert('O Campo Confirmar e-mail Está Vazio');</script>");
        }
        if (retorno == 6)//Login
        {
            Response.Write("<script language = 'javascript'>alert('O Campo Login Está Vazio');</script>");
        }
        if (retorno == 7)//Senha
        {
            Response.Write("<script language = 'javascript'>alert('O Campo Senha Está Vazio');</script>");
        }
        if (retorno == 8)//CSenha Vazio
        {
            Response.Write("<script language = 'javascript'>alert('O Campo Confirmar Senha Está Vazio');</script>");
        }
        //if (retorno == 9)//Se a senha for igual ao login
        //{
        //    Response.Write("<script language = 'javascript'>alert('O login não pode ser igual a sua senha');</script>");
        //}
        if (retorno == 10)//E-Mail
        {
            Response.Write("<script language = 'javascript'>alert('O E-Mail Não é Valido');</script>");
        }
        if(retorno == 11)//Emails não batem
        {
            Response.Write("<script language = 'javascript'>alert('Os e-mails devem ser iguais');</script>");
        }
        if (retorno == 12)//Senhas não batem
        {
            Response.Write("<script language = 'javascript'>alert('As Senhas devem ser iguais');</script>");
        }
        if (retorno == 0)//Cadastrar
        {
            string nome = txtNome.Text, telefone = txtTel.Text, email = txtCemail.Text, login = txtLog.Text, senha = txtSenha.Text;
            Boolean isLoginValido;
            Boolean isEmailValido;
            isLoginValido = checarCampo(login,"login");
            isEmailValido = checarCampo(email, "email");
            if (isLoginValido && isEmailValido)
            {
                if (FileUpload1.HasFile)
                {
                    //"Pegando" a Imagem
                    length = FileUpload1.PostedFile.ContentLength;
                    imgbyte = new byte[length];
                    img = FileUpload1.PostedFile;
                    img.InputStream.Read(imgbyte, 0, length);
                    //Outros Dados
                    Conexao c = new Conexao();
                    c.conectar();
                    //Insert dos Dados
                    c.command.CommandText = "insert into Usuario(nomeUsuario,emailUsuario,telefoneUsuario,loginUsuario,senhaUsuario,foto,descricao,capa) values(@nom,@ema,@tel,@log,@sen,@pic,@des,@cap)";
                    c.command.Parameters.Add("@nom", SqlDbType.VarChar).Value = nome;
                    c.command.Parameters.Add("@ema", SqlDbType.VarChar).Value = email;
                    c.command.Parameters.Add("@tel", SqlDbType.VarChar).Value = telefone;
                    c.command.Parameters.Add("@log", SqlDbType.VarChar).Value = login;
                    c.command.Parameters.Add("@sen", SqlDbType.VarChar).Value = senha;
                    c.command.Parameters.Add("@pic", SqlDbType.VarBinary).Value = imgbyte;
                    c.command.Parameters.Add("@des", SqlDbType.VarChar).Value = "";
                    c.command.Parameters.Add("@cap", SqlDbType.VarBinary).Value = DBNull.Value;
                    //c.command.Parameters.Add("@pre", SqlDbType.Bit).Value = 0;
                    //c.command.Parameters.Add("@ass", SqlDbType.Decimal).Value = 0;                
                    c.command.ExecuteNonQuery();
                    Response.Redirect("index.aspx?cod=1");
                }
                else
                {
                    Conexao c = new Conexao();
                    c.conectar();
                    //Insert dos Dados
                    c.command.CommandText = "insert into Usuario(nomeUsuario,emailUsuario,telefoneUsuario,loginUsuario,senhaUsuario,foto,descricao,capa) values(@nom,@ema,@tel,@log,@sen,@pic,@des,@cap)";
                    c.command.Parameters.Add("@nom", SqlDbType.VarChar).Value = nome;
                    c.command.Parameters.Add("@ema", SqlDbType.VarChar).Value = email;
                    c.command.Parameters.Add("@tel", SqlDbType.VarChar).Value = telefone;
                    c.command.Parameters.Add("@log", SqlDbType.VarChar).Value = login;
                    c.command.Parameters.Add("@sen", SqlDbType.VarChar).Value = senha;
                    c.command.Parameters.Add("@pic", SqlDbType.VarBinary).Value = DBNull.Value;
                    c.command.Parameters.Add("@des", SqlDbType.VarChar).Value = "";
                    c.command.Parameters.Add("@cap", SqlDbType.VarBinary).Value = DBNull.Value;
                    //c.command.Parameters.Add("@pre", SqlDbType.Bit).Value = 0;
                    //c.command.Parameters.Add("@ass", SqlDbType.Decimal).Value = 0;
                    c.command.ExecuteNonQuery();
                    Response.Redirect("index.aspx?cod=1");
                    //Response.Redirect("Home_Anunciante.aspx?cod=1");
                }

            }
            else
            {
                if (!isLoginValido && isEmailValido)
                {
                    Response.Write("<script language = 'javascript'>alert('Login inválido.');</script>");
                    txtLog.Text = "";
                }
                else if (isLoginValido && !isEmailValido)
                {
                    Response.Write("<script language = 'javascript'>alert('E-mail inválido.');</script>");
                    txtEmail.Text = "";
                }
                else if (!isLoginValido && !isEmailValido)
                {
                    Response.Write("<script language = 'javascript'>alert('Login e E-mail inválido.');</script>");
                    txtLog.Text = "";
                    txtEmail.Text = "";
                }
                
            }
        }
    }    

    protected Boolean checarCampo(string campo,string tipo)
    {
        Conexao c = new Conexao();
        c.conectar();
        //Checando se o login já existe no banco
        if (tipo.Equals("login"))
        {
            c.command.CommandText = "select * from Usuario where loginUsuario = @log";
            c.command.Parameters.Add("@log", SqlDbType.VarChar).Value = campo;
        }
        else if(tipo.Equals("email"))
        {
            c.command.CommandText = "select * from Usuario where emailUsuario = @ema";
            c.command.Parameters.Add("@ema", SqlDbType.VarChar).Value = campo;
        }

        SqlDataAdapter dAdapter = new SqlDataAdapter();
        DataSet dt = new DataSet();
        dAdapter.SelectCommand = c.command;
        dAdapter.Fill(dt);

        int qtdeRegistro = dt.Tables[0].DefaultView.Count;

        if (qtdeRegistro == 0)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
    
}