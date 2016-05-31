using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mnemonic
{
    public partial class RepeatingModeControl : UserControl
    {
        private static RepeatingModeControl _instance;

        public static RepeatingModeControl Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new RepeatingModeControl();
                return _instance;
            }
        }
        public RepeatingModeControl()
        {
            InitializeComponent();
        }
    }
}
