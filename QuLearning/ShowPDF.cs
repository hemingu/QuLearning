using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuLearning
{
    public partial class ShowPDF : Form
    {
        public ShowPDF(string path, string title, int page)
        {
            InitializeComponent();

            PDFReader.setCurrentPage(page);
            
            //PDFReader.setShowScrollbars(true);
            
            if (!PDFReader.LoadFile(path))
            {
                MessageBox.Show("PDFファイルが見つかりませんでした．", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            this.Text = title;

            //PDFReader.setShowToolbar(false);
            //PDFReader.setPageMode("none");
            //PDFReader.setNamedDest("応用物理");
            


        }
    }
}
