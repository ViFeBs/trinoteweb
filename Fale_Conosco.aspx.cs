using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;

public partial class Fale_Conosco : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public int ValidarForm()
    {
        Regex rg = new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");
        if (rdnBug.Checked == false && rdnHate.Checked == false && rdnOutro.Checked == false)
        {
            return 1;
        }
        else if (txtNome.Text == "")
        {
            return 2;
        }
        else if (txtEmail.Text == "")
        {
            return 3;
        }
        else if (txtMen.Text == "")
        {
            return 4;
        }
        if (txtNome.Text == "" && txtEmail.Text == "" && txtMen.Text == "" && rdnBug.Checked == false && rdnHate.Checked == false && rdnOutro.Checked == false) 
        {
            return 5;
        }  
        if (rg.IsMatch(txtEmail.Text) == false)
        {
            return 6;
        }    
        return 0;
    }

    protected void btnEnv_Click(object sender, EventArgs e)
    {
        int retorno = 0;
        retorno = ValidarForm();
        if (retorno == 1)//Motivo
        {
            Response.Write("<script language = 'javascript'>alert('Por favor Selecione um Motivo do contato');</script>");
        }
        if (retorno == 2)//Nome
        {
            Response.Write("<script language = 'javascript'>alert('O Campo Nome Está Vazio');</script>");
        }
        if (retorno == 3)//E-mail
        {
            Response.Write("<script language = 'javascript'>alert('O Campo E-mail Está Vazio');</script>");
        }
        if (retorno == 4)//Mensagem
        {
            Response.Write("<script language = 'javascript'>alert('O Campo Mensagem Está Vazio');</script>");
        }
        if (retorno == 5)//Todos
        {
            Response.Write("<script language = 'javascript'>alert('Todos os Campos estão vazios');</script>");            
        }
        if (retorno == 6)//Email não valido
        {
            Response.Write("<script language = 'javascript'>alert('Esse E-mail não é valido');</script>");
        }
        if (retorno == 0)
        {
            Response.Write("<script language = 'javascript'>alert('Mensagem enviada com sucesso');</script>");
        
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress("emailtrinote@gmail.com");
            msg.To.Add(new MailAddress("trinotesuporte@gmail.com"));
            if (rdnBug.Checked == true)
            {
                msg.Subject = "Reportar Bug";
            }
            if (rdnHate.Checked == true)
            {
                msg.Subject = "Reclamação";
            }
            if (rdnOutro.Checked == true)
            {
                msg.Subject = "Outro";
            }
            msg.IsBodyHtml = true;
            msg.Body = "Nome: " + txtNome.Text + "\nE-mail: " + txtEmail.Text + "\nMensagem: " + txtMen.Text;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            System.Net.NetworkCredential ntcd = new NetworkCredential();
            ntcd.UserName = "emailtrinote@gmail.com";
            ntcd.Password = "b3gk2040";
            smtp.Credentials = ntcd;
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.Send(msg);
        }        
    }
}