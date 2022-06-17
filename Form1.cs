using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


// 그리드 -> DataGridView 실패 (size를 입력 받아도 행,열 추가 x)
// 페널 -> TableLayoutPanel 실패 (입력으로 행, 열 추가 x)

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
            if (int.Parse(textBox1.Text) % 2 != 1) // 짝수 입력 방지 && 3이상의 수 입력
            {
                MessageBox.Show("홀수가 아닙니다.");
                return;
            }

            if (int.Parse(textBox1.Text) < 3) // 3미만 숫자 입력 방지
            {
                MessageBox.Show("3미만의 숫자입니다.");
                return;
            }


            int size = int.Parse(textBox1.Text);



            //DataGridView dgv = new DataGridView();

            DataTable table = new DataTable(); // 데이터 테이블 생성
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



            dataGridView1.AutoSizeColumnsMode =DataGridViewAutoSizeColumnsMode.AllCells; // 열 크기 조정

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



            int x = 0;  // 최초 위치(x) - 최상단 행
            int y = size / 2; // 최초 위치(y) - 가운데 열

            
            table.Rows[x][y] = 1;  // 최상단 행의 가운데 열에 1 입력        
             

            int check_x  = x - 1; // 다음 위치 확인 좌표
            int check_y  = y + 1;

            int org_x = x; // 이전 위치 좌표
            int org_y = y;

            int grid_size = size - 1; // 그리드 내에서 사이즈

            for (int i = 2; i <= count; i++) // 칸 숫자 -1 횟수 만큼 반복
            {

                if((check_x < 0) || (check_y > grid_size)) // 행 또는 열이 넘어갔을 때
                {
                    if (check_x < 0 && check_y < grid_size)  // 행만 넘어갔을 때
                    {
                        check_x = grid_size;
                    }
                    if(check_y > grid_size && check_x < grid_size)  // 열만 넘어갔을 때
                    {
                        check_y = 0;
                    }
                    if((check_x < 0) && (check_y > grid_size)) // 행, 열 둘 다 넘어갔을 때
                    {

                    }                        
                }
                

                if()  // 숫자가 있을 때
                {

                }
            }







            int check; 
            table.Rows[2][2] = 55;
            

            check = (int)table.Rows[2][2];

            if ((int)table.Rows[2][2] == check)
            {
                table.Rows[1][1] = 10;
            }



            //int[,] arr = new int[size, size];  // 입력 받은size 크기 만큼의 2차원 배열 생성
            





            //next_x = next_x - 1;
            //next_y = next_y + 1;


        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) //숫자 이외 입력 방지
            {
                e.Handled = true;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}