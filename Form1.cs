using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WInForm_Magic_Square
{
    public partial class Form1 : Form
    {      

        public Form1()
        {
            InitializeComponent();          


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.Parse(textBox1.Text) % 2 != 1) // 짝수 입력 방지
            {
                MessageBox.Show("홀수가 아닙니다.");
                return;
            }

            if (int.Parse(textBox1.Text) < 3) // 3미만 숫자 입력 방지
            {
                MessageBox.Show("3미만의 숫자입니다.");
                return;
            }


            int size = int.Parse(textBox1.Text);  // 크기를 size에 저장


            DataTable table = new DataTable(); // 데이터 테이블 생성

            //DataGridView dgv = new DataGridView();

            //table.Columns.Add("c1", typeof(string));
            //table.Columns.Add("c2", typeof(string));
            //table.Columns.Add("c3", typeof(string));


            for (int i = 1; i < size + 1; i++) // 입력 받은 수 만큼 열 생성
            {
                table.Columns.Add($"{i}", typeof(int));               
            }


            for (int i = 1; i < size + 1; i++) // 입력 받은 수 만큼의 행 생성 (마지막 행은 버림 - 값이 안드감)
            {
                table.Rows.Add();
            }

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells; // 열 크기 조정

            //table.Rows.Add("1", "2", "3", "4", "5");
            //table.Rows.Add("1", "2", "3", "4", "5");

            //dataGridView1.Columns.Add("Col6", "121");
            //dataGridView1.Rows.Add();

            dataGridView1.DataSource = table; // databinding

            int count = size * size;  // 전체 횟수 체크 변수

            for (int i = 0; i < size; i++)  // 모든 요소에 0 입력
                for (int j = 0; j < size; j++)
                {
                    table.Rows[i][j] = 0;
                }


            int row = 0;  // 최초 위치(row) - 최상단 행
            int col = size / 2; // 최초 위치(col) - 가운데 열

            
            table.Rows[row][col] = 1;  // 최상단 행의 가운데 열에 1 입력        
             

            int checkrow  = row - 1; // 다음 위치 확인 좌표
            int checkcol  = col + 1;

            int originrow = row; // 이전 위치 좌표
            int origincol = col;

            int grid_size = size - 1; // 배열이 0부터 시작하므로 size - 1

            for (int i = 2; i <= count; i++) // 칸 숫자 -1 횟수 만큼 반복 (1회는 초기 최상단 가운데열 지정되있음)
            {

               
                if ((checkrow < 0) && (checkcol <= grid_size))  // 행만 넘어갔을 때
                {
                    checkrow = grid_size;
                }
                
                if((checkrow >= 0) && (checkcol > grid_size))  // 열만 넘어갔을 때
                {
                    checkcol = 0;
                }
                
                if((checkrow < 0) && (checkcol > grid_size)) // 행, 열 둘 다 넘어갔을 때
                {
                    checkrow = originrow + 1;
                    checkcol = origincol;
                }

                if ((int)table.Rows[checkrow][checkcol] != 0)  // 숫자가 있을 때
                {
                    checkrow = originrow + 1;
                    checkcol = origincol;
                }


                table.Rows[checkrow][checkcol] = i;  // 숫자 채워넣기

                originrow = checkrow; // 이전 위치 최신화
                origincol = checkcol;

                checkrow -= 1;  // 다음 위치 탐색
                checkcol += 1;
            }


        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) //숫자 이외 입력 방지
            {
                e.Handled = true;
            }
        }

    }
}