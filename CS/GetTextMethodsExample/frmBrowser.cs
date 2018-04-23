using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GetTextMethods {
    public partial class frmBrowser : Form {
        public frmBrowser() {
            InitializeComponent();
        }

        public void SetHtml(string htmlText) {
            this.webBrowser1.DocumentText = htmlText;
        }
    }
}
