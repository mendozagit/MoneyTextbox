using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoneyTextbox
{
    [ProvideProperty("MoneyBox", typeof(Control))]
    public partial class MoneyBox : TextBox
    {
        public MoneyBox()
        {
            InitializeComponent();
        }

        public MoneyBox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }


        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Is Numerical TextBox? if value is true then just typed numbers, and if false then typed any chars."), Category("Behavior")]
        [DefaultValue(false)]
        public bool IsNumerical { get; set; }


        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Show Thousands Separator in TextBox? if value is true then split any 3 numerical digits by char ',' .\n\rNote: IsNumerical must be 'true' for runes this behavior."), Category("Behavior")]
        [DisplayName("Thousands Separator"), DefaultValue(false)]
        public bool ThousandsSeparator { get; set; }


        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("The decimal real value of text box"), Category("Appearance")]
        [DisplayName("Real value"), DefaultValue(false)]
        public decimal Value
        {
            get
            {
                GetValor();
                return _value;
            }
            set { _value = value; }
        }


        private void GetValor()
        {
            _value = decimal.TryParse(Text, out _value) == false ? decimal.Zero : _value;
        }
        private decimal _value;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            if (ThousandsSeparator)
            {
                var indexSelectionBuffer = SelectionStart;
                if (!string.IsNullOrEmpty(Text) && e.KeyData != Keys.Left && e.KeyData != Keys.Right)
                {

                    var style = NumberStyles.Number | NumberStyles.AllowCurrencySymbol;
                    var culture = CultureInfo.CreateSpecificCulture("es-MX");
                    if (decimal.TryParse(Text, style, culture, out decimal d))
                    {
                        Text = string.Format(culture, "{0:N0}", d);
                        Value = d;
                        if (e.KeyData != Keys.Delete && e.KeyData != Keys.Back)
                            Select(Text.Length, 0);
                        else Select(indexSelectionBuffer, 0);
                    }
                }
            }
        }


        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            //
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == '.'))
                e.Handled = true;


            if (e.KeyChar.Equals(".") && Text.Contains("."))
                e.Handled = true;
        }
    }
}
