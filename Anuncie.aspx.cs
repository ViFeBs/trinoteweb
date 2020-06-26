using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Anuncie : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public int ValidarForm()
    {
        Regex rg = new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");
        if (txtNome.Text == "" && txtTel.Text =="" && txtCNPJ.Text == "" && txtEmail.Text == "" && txtLog.Text == "" && txtSen.Text == "" && txtConsen.Text == "")
        {
            return 1;
        }
        else if(txtNome.Text == "")
        {
            return 2;
        }
        else if(txtTel.Text == "")
        {
            return 3;
        }
        else if(txtCNPJ.Text == "")
        {
            return 4;
        }
        else if(txtEmail.Text =="")
        {
            return 5;
        }
        else if(txtLog.Text == "")
        {
            return 6;
        }
        else if(txtSen.Text == "")
        {
            return 7;
        }
        else if(txtConsen.Text == "")
        {
            return 8;
        }
        if (ValidaCNPJ.IsCnpj(txtCNPJ.Text) == false)
        {
            return 9;
        }
        if(rg.IsMatch(txtEmail.Text) == false)
        {
            return 10;
        }
        if(txtSen.Text != txtConsen.Text)
        {
            return 11;
        }
        return 0;
    }
    /**valida form retorna um valor que vai validar os campos
     * 1 = todos os campos estão vazios;
     * 2 = nome está vazio
     * 3 = telefone está vazio
     * 4 = cnpj está vazio
     * 5 = email está vazio
     * 6 = link está vazio
     * 7 = titulo está vazio
     * 8 = Anuncio está vazio
     * 9 = CNPJ não é valido
     * 10 = email não é valido
     * 0 = todos os campos foram preenchidos e validados
     * if (Validacao.ValidaCNPJ.IsCnpj(valor))
                {
                    mensagem = "O número é um CNPJ Válido !";
                }
                else
                {
                    mensagem = "O número é um CNPJ Inválido !";
                }
    **/
    protected void btnSend_Click(object sender, EventArgs e)
    {
       
    }

    protected void btnSend_Click1(object sender, EventArgs e)
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
        if (retorno == 4)//CNPJ
        {
            Response.Write("<script language = 'javascript'>alert('O Campo CNPJ Está Vazio');</script>");
        }
        if (retorno == 5)//EMAIL
        {
            Response.Write("<script language = 'javascript'>alert('O Campo E-Mail Está Vazio');</script>");
        }
        if (retorno == 6)//LOGIN
        {
            Response.Write("<script language = 'javascript'>alert('O Campo Login Está Vazio');</script>");
        }
        if (retorno == 7)//SENHA
        {
            Response.Write("<script language = 'javascript'>alert('O Campo Senha Está Vazio');</script>");
        }
        if (retorno == 8)//CONFIRMARSENHA
        {
            Response.Write("<script language = 'javascript'>alert('O Campo Confirmar Senha Está Vazio');</script>");
        }
        if (retorno == 9)//CNPJ
        {
            Response.Write("<script language = 'javascript'>alert('O CNPJ Não é Valido');</script>");
        }
        if (retorno == 10)//E-Mail
        {
            Response.Write("<script language = 'javascript'>alert('O E-Mail Não é Valido');</script>");
        }
        if(retorno == 11)
        {
            Response.Write("<script language = 'javascript'>alert('Os Campos Senha e Confirmar Senha devem ser iguais');</script>");
        }
        if (retorno == 0)//Cadastrar
        {
            //Dados a Serem Inseridos
            string nome = txtNome.Text, email = txtEmail.Text, telefone = txtTel.Text, cnpj = txtCNPJ.Text,Log = txtLog.Text,Sen = txtSen.Text;
            Visivel.Visible = false;
            Conexao c = new Conexao();
            c.conectar();
            //Insert dos Dados
            c.command.CommandText = "insert into Anunciante(nomeAnunciante,emailAnunciante,telefoneAnunciante,cnpj,loginAnunciante,senhaAnunciante) values(@nome, @email,@tel,@cnpj,@log,@sen)";
            c.command.Parameters.Add("@nome", SqlDbType.VarChar).Value = nome;
            c.command.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
            c.command.Parameters.Add("@tel", SqlDbType.VarChar).Value = telefone;
            c.command.Parameters.Add("@cnpj", SqlDbType.VarChar).Value = cnpj;
            c.command.Parameters.Add("@log", SqlDbType.VarChar).Value = Log;
            c.command.Parameters.Add("@sen", SqlDbType.VarChar).Value = Sen;
            c.command.ExecuteNonQuery();
            Response.Write("<script language = 'javascript'>alert('Proposta enciada com sucesso!');</script>");
            Response.Redirect("Login_Anunciante.aspx");
        }
    }
}