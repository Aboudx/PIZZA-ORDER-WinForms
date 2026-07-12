using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pizza_Project_WinForms_C_
{
   
    public partial class frmPizzaOrder : Form
    {
        int BasePrice = 0;
        public frmPizzaOrder()
        {
            InitializeComponent();
            ResetForm();
        }

        private void DisableAllButtons()
        {
            grSize.Enabled = false;
            gbCrustType.Enabled = false;
            gbToppings.Enabled = false;
            gbWhereToEat.Enabled = false;
            btnOrderPizza.Enabled = false;

        }

        private void EnableAllButtons()
        {
            grSize.Enabled = true;
            gbCrustType.Enabled = true;
            gbToppings.Enabled = true;
            gbWhereToEat.Enabled = true;
            gbOrderSummury.Enabled = true;
            btnOrderPizza.Enabled = true;
        }

        private void UnChackedAllButtons()
        {
            rbSmall.Checked = false;
            rbMedium.Checked = false;
            rbLarge.Checked = false;
            rbThinCrust.Checked = false;
            rbThickCrust.Checked = false;

            chkExtraChess.Checked = false;
            chkMushrooms.Checked = false;
            chkTomatoes.Checked = false;

            rbEatIn.Checked = false;
            rbTakeOut.Checked = false;
        }

        private void OrderPizzaButton()
        {
            if (lbSize.Text == "" || lbCrustType.Text=="" || lbWhereToEat.Text=="")
            {
                MessageBox.Show(" You Want To Finish Before Order", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show("Order Finished", "PIZZA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DisableAllButtons();

        }

        private void ResetForm()
        {

            UnChackedAllButtons();
            EnableAllButtons();
            
            lbSize.Text = "";
            lbToppings.Text = "No Toppings";
            lbCrustType.Text = "";
            lbPrice.Text = "0";
            lbWhereToEat.Text = "";
            BasePrice = 0;
            lbPrice.Text = "0";
        }
        private void ChangePriceFromrpButton(RadioButton Control)
        {
            if (Control.Checked)
                BasePrice += Convert.ToInt32(Control.Tag);
            else
                BasePrice -= Convert.ToInt32(Control.Tag);

            lbPrice.Text = (BasePrice * nudQuantity.Value).ToString();
        }

        private void ChangeInfoOrderSummuryForSizerpButton(RadioButton Control)
        {
            ChangePriceFromrpButton(Control);
            lbSize.Text = Control.Text;

        }

        private void ChangeInfoOrderSummuryForCrustrpButton(RadioButton Control)
        {
            ChangePriceFromrpButton(Control);
            lbCrustType.Text = Control.Text;
        }

        private void rbSmall_CheckedChanged(object sender, EventArgs e)
        {
            ChangeInfoOrderSummuryForSizerpButton(rbSmall);
        }

        private void rbMedium_CheckedChanged(object sender, EventArgs e)
        {
            ChangeInfoOrderSummuryForSizerpButton(rbMedium);
        }

        private void rbLarge_CheckedChanged(object sender, EventArgs e)
        {
            ChangeInfoOrderSummuryForSizerpButton(rbLarge);
        }

        private void rbThinCrust_CheckedChanged(object sender, EventArgs e)
        {
            ChangeInfoOrderSummuryForCrustrpButton(rbThinCrust);
        }

        private void rbThinkCrust_CheckedChanged(object sender, EventArgs e)
        {
            ChangeInfoOrderSummuryForCrustrpButton(rbThickCrust);
        }

        private void ChangePriceFromchkButton(CheckBox Control)
        {
            if (Control.Checked)
                BasePrice += Convert.ToInt32(Control.Tag);
            else
                BasePrice -= Convert.ToInt32(Control.Tag);

            lbPrice.Text = (BasePrice * nudQuantity.Value).ToString();
        }

        private void UpdateToppings()
        {
            List<string> lstToppings = new List<string>();
            if (chkExtraChess.Checked)
                lstToppings.Add(chkExtraChess.Text);
            if(chkMushrooms.Checked)
                lstToppings.Add(chkMushrooms.Text);
            if (chkTomatoes.Checked)
                lstToppings.Add(chkTomatoes.Text);

            if (lstToppings.Count == 0)
                lbToppings.Text = "No Toppings";

            else
                lbToppings.Text = string.Join(",", lstToppings);
        }

        private void chkExtraChess_CheckedChanged(object sender, EventArgs e)
        {
            ChangePriceFromchkButton(chkExtraChess);
            UpdateToppings();
        }

        private void chkMushrooms_CheckedChanged(object sender, EventArgs e)
        {
            ChangePriceFromchkButton(chkMushrooms);
            UpdateToppings();

        }

        private void chkTomatoes_CheckedChanged(object sender, EventArgs e)
        {
            ChangePriceFromchkButton(chkTomatoes);
            UpdateToppings();

        }

        private void rbEatIn_CheckedChanged(object sender, EventArgs e)
        {
            lbWhereToEat.Text = rbEatIn.Text;
        }

        private void rbTakeOut_CheckedChanged(object sender, EventArgs e)
        {
            lbWhereToEat.Text = rbTakeOut.Text;
        }

        private void btnOrderPizza_Click(object sender, EventArgs e)
        {
            OrderPizzaButton();
        }

        private void btnResetForm_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void UpdatePriceFromNud()
        {
            lbPrice.Text = (BasePrice * nudQuantity.Value).ToString();
        }

        private void nudQuantity_ValueChanged(object sender, EventArgs e)
        {
            UpdatePriceFromNud();
        }
    }
}
