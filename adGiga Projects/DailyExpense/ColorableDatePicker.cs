//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Text;
//using System.Windows.Forms;

//namespace ShopKeeper
//{
//    public partial class ColorableDatePicker : DateTimePicker
//    {
//        public ColorableDatePicker()
//        {
//            InitializeComponent();
//        }

//        protected override void OnPaint(PaintEventArgs pe)
//        {
//         //   base.OnPaint(pe);
//        }
//        private SolidBrush _BackColorBrush = new SolidBrush(SystemColors.Window);

//        public override Color BackColor
//        {
//            get
//            {
//                return base.BackColor;
//            }
//            set
//            {
//                if (null != _BackColorBrush)
//                {
//                    _BackColorBrush.Dispose();
//                }
//                base.BackColor = value;
//                _BackColorBrush = new SolidBrush(value);
//                this.Invalidate();
//            }
//        }

//        protected override void WndProc(ref Message m)
//        {
//            const int WM_ERASEBKGND = 0x14;
//            if (m.Msg == WM_ERASEBKGND)
//            {
//                Graphics g = Graphics.FromHdc(m.WParam);
//                g.FillRectangle(_BackColorBrush, this.ClientRectangle);
//                g.Dispose();
//                return;
//            }

//            base.WndProc(ref m);
//        }

//    }
//}


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
namespace ShopKeeper
{
    public partial class ColorableDatePicker : DateTimePicker
    {
        
        public ColorableDatePicker()
        {
            this.BackColor = Color.White;
            this.SetStyle(ControlStyles.UserPaint, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            string format = "";
            switch (this.Format)
            {
                case DateTimePickerFormat.Long:
                    format = Thread.CurrentThread.CurrentCulture.DateTimeFormat.LongDatePattern;
                    break;
                case DateTimePickerFormat.Short:
                    format = Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;
                    break;
                case DateTimePickerFormat.Time:
                    format = Thread.CurrentThread.CurrentCulture.DateTimeFormat.LongTimePattern;
                    break;
                case DateTimePickerFormat.Custom:
                    format = this.CustomFormat;
                    break;
            }
            using (Brush b = new SolidBrush(Color.Black))
            {
                e.Graphics.DrawString(this.Value.ToString(format),
                this.Font, b, 0, 2);
            }
            ControlPaint.DrawComboButton(e.Graphics, 
                new Rectangle(this.ClientRectangle.Left + this.ClientRectangle.Width - 20,
                this.ClientRectangle.Top, 20, this.ClientRectangle.Height),
                ButtonState.Flat);
            ControlPaint.DrawBorder(e.Graphics, this.DisplayRectangle,
                Color.Gray, ButtonBorderStyle.Solid);
            base.OnPaint(e);
        }
    }
}