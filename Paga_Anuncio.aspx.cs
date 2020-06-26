using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Paga_Anuncio : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }

    public bool ValidaCartao(string num, string cvv)
    {
        var cardCheck = new Regex(@"^(1298|1267|4512|4567|8901|8933)([\-\s]?[0-9]{4}){3}$");
        var monthCheck = new Regex(@"^(0[1-9]|1[0-2])$");
        var yearCheck = new Regex(@"^20[0-9]{2}$");
        var cvvCheck = new Regex(@"^\d{3}$");

        if (!cardCheck.IsMatch(num)) // <1>check card number is valid
            return false;
        else if (!cvvCheck.IsMatch(cvv)) // <2>check cvv is valid as "999"
            return false;
        else
            return true;

    }

    protected void btnValida_Click(object sender, EventArgs e)
    {
        bool valida = ValidaCartao(txtCreditCard.Text, txtCVV.Text);
        if (valida == true)
            txtCreditCard.CssClass += "has-sucess";
    }
}