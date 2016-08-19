using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OFC
{
    class DataGridViewCheckboxCellFilter : DataGridViewCheckBoxCell
    {
        public DataGridViewCheckboxCellFilter ()
            : base()
        {
            this.FalseValue = 0;
            this.TrueValue = 1;
            this.Value = FalseValue;
        }
    }
}
