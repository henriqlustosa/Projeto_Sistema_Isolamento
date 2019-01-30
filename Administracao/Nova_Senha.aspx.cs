using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class Administracao_Nova_Senha : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           
          
            DropDownList1.DataSource = Membership.GetAllUsers();
            DropDownList1.DataBind();

            DropDownList1.Items.Insert(0, new ListItem("Selecione o Usuário", ""));
            Password.Text = "";
            UserName.Text = "";

            
        }
    }
    protected void btnCad_Click(object sender, EventArgs e)
    {

        string username = UserName.Text;
        string password = Password.Text;
        // criar validação
        MembershipUser mu = Membership.GetUser(username);
        if (mu != null)
        {
            mu.ChangePassword(mu.ResetPassword(), password);

            Response.Write("<script language='javascript'>alert('Alterada senha com sucesso!');</script>");
            DropDownList1.SelectedItem.Text = "Selecione o Usuário";
            UserName.Text = "";
            Password.Text = "";
        }
        else
        {
            Response.Write("<script language='javascript'>alert('Erro ao alterar a senha. Por favor, tente outra vez.');</script>");
            DropDownList1.SelectedItem.Text = "Selecione o Usuário";
            UserName.Text ="";
            Password.Text = "";
        }



        ConfirmPassword.Text = "";
        Password.Text = "";
        UserName.Text = "";
        
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    { if (!DropDownList1.SelectedIndex.Equals(0))
        {
            UserName.Text = DropDownList1.SelectedItem.Value;
       
        }
        else
        {
          UserName.Text = "";
        }
    }

}
