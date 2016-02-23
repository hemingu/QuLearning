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
    public partial class FormMain : Form
    {
        FormQM formQM;
        FormSearch formSearch;
        public const string DBPath = @"DB\AllItems.db";
        public FormMain()
        {
            InitializeComponent();
        }

        private void buttonQM_Click(object sender, EventArgs e)
        {
            if(formQM == null || formQM.IsDisposed)
            {
                formQM = new FormQM();
            }
            else
            {
                formQM.Close();
                formQM = new FormQM();
            }

            formQM.Show(this);
            
        }

        private void buttonTerms_Click(object sender, EventArgs e)
        {
            if (formSearch == null || formSearch.IsDisposed)
            {
                formSearch = new FormSearch();
            }
            else
            {
                formSearch.Close();
                formSearch = new FormSearch();
            }

            formSearch.Show(this);
        }

        private void FormMain_Activated(object sender, EventArgs e)
        {
            Console.WriteLine("FormMain Activated");
        }


    }
}
