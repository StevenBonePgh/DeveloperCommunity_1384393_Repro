using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormDesignerAbstractBase
{
    [System.ComponentModel.DesignerCategory("Form")] // so VS does show this inherited class in the designer.
    public partial class InheritedControl : AbstractBaseControl
    {
        public InheritedControl()
        {
            InitializeComponent();
        }

        public override bool SomeAbstractMethod()
        {
            throw new NotImplementedException();
        }
    }
}
