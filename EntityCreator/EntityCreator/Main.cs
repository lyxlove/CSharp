using CCWin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace EntityCreator
{
    public partial class Main : CCSkinMain
    {
        public Main()
        {
            InitializeComponent();
        }

        public void UpdateUI()
        {
            if (this.InvokeRequired)
            {
                this.Invoke((EventHandler)(delegate {
                }));
            }
        }
    }


}
