﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IPCS.Data;

namespace IPCS.Forms
{
    public partial class GetQuantityForm : CustomForm
    {
        #region Constructor

        public GetQuantityForm(Product product)
        {
            Product = product;
            InitializeComponent();
            ReInitializeComponent();
            UpdateComponent();
        }

        #endregion

        #region Properties

        public Product Product;

        private int _Value = 0;
        public int Value { get { return _Value; } }

        #endregion

        #region Threads

        public void ReInitializeComponent()
        {

        }

        public void UpdateComponent()
        {

        }

        public int GetInput()
        {
            try
            {
                return Convert.ToInt32(txtBoxQuantity.Text);
            }
            catch
            {
                return -1;
            }
        }

        #endregion

        #region Events

        private void txtBoxQuantity_Click(object sender, EventArgs e)
        {
            txtBoxQuantity.SelectAll();
        }

        private void integerTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtBoxQuantity_TextChanged(object sender, EventArgs e)
        {
            if (GetInput() > Product.Stock || GetInput() < 1)
            {
                NotifText = "Invalid value!";
                txtBoxQuantity.Text = "1";
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int quantity = 0;
            if (GetInput() >= Product.Stock)
            {
                quantity = Product.Stock;
                txtBoxQuantity.Text = quantity.ToString();
            }
            else
            {
                quantity = GetInput() + 1;
                txtBoxQuantity.Text = quantity.ToString();
            }
            NotifSetDefault();
        }

        private void btnSubtract_Click(object sender, EventArgs e)
        {
            int quantity = 1;
            if (GetInput() <= 1)
            {
                txtBoxQuantity.Text = quantity.ToString();
            }
            else
            {
                quantity = GetInput() - 1;
                txtBoxQuantity.Text = quantity.ToString();
            }
            NotifSetDefault();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            _Value = GetInput();
            DialogResult = DialogResult.OK;
            Dispose();
        }

        #endregion
    }
}
