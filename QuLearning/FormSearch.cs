using System;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Data;
using System.Drawing;

namespace QuLearning
{
    public partial class FormSearch : Form
    {
        public FormSearch()
        {
            InitializeComponent();
        }

        private void buttonIndex_Click(object sender, EventArgs e)
        {
            char[] delimiterChars = {' ', '　'};
            string[] searchWords = textBox1.Text.Split(delimiterChars);
            string sql = @"select 用語,記事名,ページ,PDFパス from 索引 inner join Lecture on 索引.lectureid = Lecture.rowid where 用語 like";
            int size = searchWords.Length;


            int sum = 0;
            //searchWordsがすべて空白ならreturn
            foreach (string word in searchWords)
            {
                sum += word.Length;
            }
#if DEBUG
            sum = 1;
#endif
            if(sum == 0)
            {
                return;
            }

            sql += string.Format("'%{0}%' ", searchWords[0]);
            for(int i=1;i<size;i++)
            {
                sql += string.Format("and 用語 like '%{0}%' ", searchWords[i]);
            }

            sql += "order by 用語 ";

            DataTable dataTable = new DataTable();
            dataGridView1.DataSource = dataTable;

            try
            {
                using (SQLiteConnection con = new SQLiteConnection("Data Source=" + FormMain.DBPath))
                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(sql, con))
                {
                    adapter.Fill(dataTable);

                }
            }
            catch
            {
                MessageBox.Show("SQLエラー", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            //PDFパスの列を非表示
            dataGridView1.Columns[3].Visible = false;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // グリッドを基準としたカーソル位置のポイントを取得
            Point p = dataGridView1.PointToClient(Cursor.Position);
            // 取得したポイントからHitTestでセル位置取得
            DataGridView.HitTestInfo ht = dataGridView1.HitTest(p.X, p.Y);

            if (ht.RowIndex < 0 || ht.ColumnIndex < 0)
            {
                return;
            }

            //PDFパスの列番号を取得
            int pathColumn;
            for(pathColumn=0; pathColumn < dataGridView1.ColumnCount; pathColumn++)
            {
                if (dataGridView1.Columns[pathColumn].HeaderCell.Value.ToString() == "PDFパス")
                    break;
            }

            
            //dataGridViewの列数を取得 3列なら記事名検索 4列なら索引検索
            if(dataGridView1.ColumnCount == 3)
            {
                ShowPDF formShowPDF = new ShowPDF(dataGridView1.Rows[ht.RowIndex].Cells[2].Value.ToString(), dataGridView1.Rows[ht.RowIndex].Cells[1].Value.ToString(), 1);
                if (!formShowPDF.IsDisposed)
                    formShowPDF.Show(this);
            }
            else if(dataGridView1.ColumnCount == 4)
            {
                ShowPDF formShowPDF = new ShowPDF(dataGridView1.Rows[ht.RowIndex].Cells[3].Value.ToString(), dataGridView1.Rows[ht.RowIndex].Cells[0].Value.ToString(), Convert.ToInt32(dataGridView1.Rows[ht.RowIndex].Cells[2].Value));
                if (!formShowPDF.IsDisposed)
                    formShowPDF.Show(this);
            }
        }

        private void buttonTitle_Click(object sender, EventArgs e)
        {
            char[] delimiterChars = { ' ', '　' };
            string[] searchWords = textBox1.Text.Split(delimiterChars);

#if RELEASE
            int sum = 0;
            //searchWordsがすべて空白ならreturn
            foreach (string word in searchWords)
            {
                sum += word.Length;
            }
            if(sum == 0)
            {
                return;
            }
#endif
            string sqlWords = "";
            foreach(string words in searchWords)
            {
                sqlWords += string.Format("and 記事名 like '%{0}%' ",words);
            }
            string sql = "select 種別,記事名,PDFパス from Lecture where 種別 not like 'シラバス' " + sqlWords + "union "
                + "select 種別,記事名,PDFパス from 前期量子論 where 種別 not like 'シラバス' " + sqlWords + "union "
                + "select 種別,記事名,PDFパス from シュレディンガー方程式 where 種別 not like 'シラバス' " + sqlWords + "union "
                + "select 種別,記事名,PDFパス from シュレディンガー方程式の具体的な適用 where 種別 not like 'シラバス' " + sqlWords + "union "
                + "select 種別,記事名,PDFパス from 行列力学 where 種別 not like 'シラバス' " + sqlWords + "union "
                + "select 種別,記事名,PDFパス from 量子コンピューティング基礎 where 種別 not like 'シラバス' " + sqlWords + "union "
                + "select 種別,記事名,PDFパス from Shorの素因数分解アルゴリズム where 種別 not like 'シラバス' " + sqlWords + "union "
                + "select 種別,記事名,PDFパス from 量子情報通信 where 種別 not like 'シラバス' " + sqlWords
                + "order by 記事名";

            DataTable dataTable = new DataTable();
            dataGridView1.DataSource = dataTable;

            try
            {
                using (SQLiteConnection con = new SQLiteConnection("Data Source=" + FormMain.DBPath))
                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(sql, con))
                {
                    adapter.Fill(dataTable);

                }
            }
            catch
            {
                MessageBox.Show("SQLエラー", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //PDFパスの列を非表示
            dataGridView1.Columns[2].Visible = false;
        }
    }
}
