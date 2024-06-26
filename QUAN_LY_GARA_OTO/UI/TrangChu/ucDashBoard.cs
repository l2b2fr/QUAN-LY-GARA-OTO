using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QUAN_LY_GARA_OTO.UI
{
    public partial class ucDashBoard : DevExpress.XtraEditors.XtraUserControl
    {
        public ucDashBoard()
        {
            InitializeComponent();
        }

        private int imagesNumber = 1;

        private void loadImages()
        {
            if (imagesNumber == 8)
            {
                imagesNumber = 1;
            }
            picSlide.ImageLocation = string.Format(@"Images\{0}.jpg",imagesNumber);
            imagesNumber++;
        }

        private void ucDashBoard_Load(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            loadImages();
        }
    }
}
