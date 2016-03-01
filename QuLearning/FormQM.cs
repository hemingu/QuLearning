using System;
using System.Windows.Forms;
using System.Drawing;
using System.Data;
using System.Data.SQLite;
using System.Collections.Generic;
using System.Collections;
using System.Linq;




namespace QuLearning
{
    public partial class FormQM : Form
    {
        private List<Lecture> lecture = new List<Lecture>();
        
        private string PDFPath;
        

        public FormQM()
        {
            InitializeComponent();
            comboBox1.BeginUpdate();
            //PDFReader.setShowScrollbars(true);
            //PDFReader.setShowToolbar(false);
            //PDFReader.setPageMode("none");


            // Lectureテーブルの内容を取得しておく．
            using (SQLiteConnection con = new SQLiteConnection("Data Source=" + FormMain.DBPath))
            {
                con.Open();
                using (SQLiteCommand cmd = new SQLiteCommand("SELECT rowid, * from Lecture", con))
                {
                    //cmd.CommandType = CommandType.StoredProcedure;
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lecture.Add(new Lecture(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3)));
                        }
                    }
                }
            }

            // combobox1に講義資料タイトルを追加する．
            foreach(var item in lecture)
            {
                comboBox1.Items.Add(item.id.ToString() + ". " + item.title);
            }

            comboBox1.EndUpdate();
        }

        




        private void buttonRelation_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < 0)
                return;

            DataTable dataTable = new DataTable();
            dataGridView1.DataSource = dataTable;

            // combobox1のSelectedIndexをもとに，lectureのtitleから関連項目が登録されているテーブル名を取得し，表示する．
            using (SQLiteConnection con = new SQLiteConnection("Data Source=" + FormMain.DBPath))
            using (SQLiteDataAdapter adapter = new SQLiteDataAdapter("select * from " + lecture[comboBox1.SelectedIndex].title, con))
            {
                adapter.Fill(dataTable);
                    
            }
            

            // ページ数とPDFパスの列を非表示
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[3].Visible = false;

            //記事名の列幅のみFill
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            foreach (DataGridViewColumn c in dataGridView1.Columns)
                c.SortMode = DataGridViewColumnSortMode.NotSortable;

        }

        private void buttonContent_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < 0 || PDFPath == lecture[comboBox1.SelectedIndex].path)
                return;

            PDFPath = lecture[comboBox1.SelectedIndex].path;

           
            PDFReader.LoadFile(PDFPath);


            
        }


        
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            // グリッドを基準としたカーソル位置のポイントを取得
            Point p = dataGridView1.PointToClient(Cursor.Position);
            // 取得したポイントからHitTestでセル位置取得
            DataGridView.HitTestInfo ht = dataGridView1.HitTest(p.X, p.Y);

            if(ht.RowIndex < 0 || ht.ColumnIndex <= 0)
            {
                return;
            }


            ShowPDF formShowPDF = new ShowPDF(dataGridView1.Rows[ht.RowIndex].Cells[3].Value.ToString(), dataGridView1.Rows[ht.RowIndex].Cells[1].Value.ToString(),Convert.ToInt32(dataGridView1.Rows[ht.RowIndex].Cells[2].Value));
            formShowPDF.Show(this);
        }


        private void FormQM_Load(object sender, EventArgs e)
        {
            this.Activate();
        }

        private void FormQM_FormClosing(object sender, FormClosingEventArgs e)
        {
            //AcroRd32.exeをKill
            System.Diagnostics.Process[] ps = System.Diagnostics.Process.GetProcessesByName("AcroRd32");

            foreach (System.Diagnostics.Process p in ps)
            {
                //プロセスを強制的に終了させる
                p.Kill();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonRelation_Click(sender, e);
            buttonContent_Click(sender, e);
        }
    }
    /// <summary>
    /// DBのLectureテーブルの内容
    /// </summary>
    class Lecture
    {
        public int id { get; private set; }
        public string type { get; private set; }
        public string title { get; private set; }
        public string path { get; private set; }

        public Lecture(int id, string type, string title, string path)
        {
            this.id = id;
            this.type = type;
            this.title = title;
            this.path = path;
        }
    }
}
