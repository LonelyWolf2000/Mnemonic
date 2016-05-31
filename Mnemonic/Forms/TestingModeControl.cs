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
    public partial class TestingModeControl : UserControl
    {
        private static TestingModeControl _instance;

        public static TestingModeControl Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new TestingModeControl();
                return _instance;
            }
        }
        public TestingModeControl()
        {
            InitializeComponent();
        }
    }
}
