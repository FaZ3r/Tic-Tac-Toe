namespace Ics_si_Zero
{
    public partial class IcsSiZero : Form
    {
        public IcsSiZero()
        {
            InitializeComponent();
            buttonRes.Visible = false;

        }
        Button[,] matButton = new Button[3,3];
        int nr = 0;
        struct tabla
        {
          public Button[,] matButton = new Button[3, 3];
            public tabla()
            {

            }
        };
        tabla[,] celula=new tabla[3,3];
        private void disable()
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++) 
                    matButton[i, j].Enabled = false;
           // buttonRes.Visible = true;
        }
        private void buttonJoc_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (labelPlayer.Text == "Turn X")
            {
                btn.ForeColor = Color.Blue;
                btn.Text = "X";
                labelPlayer.Text = "Turn 0";
                btn.Enabled = false;
            }
            else
                 if(labelPlayer.Text == "Turn 0")
                 {
                     btn.ForeColor = Color.Red;
                     btn.Text = "0";
                     labelPlayer.Text = "Turn X";
                     btn.Enabled = false;
                }
            nr++;
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if(matButton[i, j] == btn)
                    {
                        if (matButton[i, 0].Text == matButton[i, 1].Text && matButton[i, 0].Text == matButton[i, 2].Text)
                        {
                            if (labelPlayer.Text == "Turn 0")
                            {
                                MessageBox.Show("Player X has won!");
                                disable();
                                
                            }
                                
                            else
                            {
                                MessageBox.Show("Player 0 has won!");
                                disable();
                               
                            }
                            return;
                        }
                        if (matButton[0,j].Text == matButton[1, j].Text && matButton[0, j].Text == matButton[2, j].Text)
                        {
                            if (labelPlayer.Text == "Turn 0")
                            {
                                MessageBox.Show("Player X has won!");
                                disable();
                            }
                                
                            else
                            {
                                MessageBox.Show("Player 0 has won!");
                                disable();
                            }
                            return;
                        }
                        if(i==j)
                        if(matButton[0,0].Text==matButton[1,1].Text&&matButton[0,0].Text==matButton[2,2].Text)
                        {
                            if (labelPlayer.Text == "Turn 0")
                                {
                                    MessageBox.Show("Player X has won!");
                                    disable();
                                }
                            else
                                {
                                    MessageBox.Show("Player 0 has won!");
                                    disable();
                                }
                                
                            return;
                        }
                        if(i+j==2)
                        if(matButton[0,2].Text==matButton[1,1].Text && matButton[0,2].Text==matButton[2,0].Text)
                        {
                            if (labelPlayer.Text == "Turn 0")
                                {
                                    MessageBox.Show("Player X has won!");
                                    disable();
                                }
                            else
                                {
                                    MessageBox.Show("Player 0 has won!");
                                    disable();
                                }
                                
                            return;
                        }
                    }
            if (nr == 9)
            { 
                MessageBox.Show("Egalitate");
                disable();
                return;
            }


        }
        void Viz(int n,int m)
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    celula[n,m].matButton[i, j].Visible = true;
        }
        private void build(int n,int m)
        {
            int x = this.Width / 3;
            int y = 100;
               for(int i=0;i<3;i++)
                 for(int j=0;j<3;j++)
                 {
                    celula[n,m].matButton[i, j] = new Button();
                    celula[n,m].matButton[i, j].Size = new Size(30, 30);
                    celula[n,m].matButton[i, j].Location = new Point(x+j*75,y+i*75);
                    celula[n,m].matButton[i, j].Text = "";
                    celula[n,m].matButton[i, j].BackColor = Color.LightGray;
                    celula[n,m].matButton[i, j].Font = new Font("Arial", 12);
                    this.Controls.Add(celula[n,m].matButton[i, j]);
                    celula[n,m].matButton[i, j].Visible = false;
                    celula[n,m].matButton[i, j].Click += new EventHandler(buttonJoc_Click);
                 }
          


        }
        private void IcsSiZero_Load(object sender, EventArgs e)
        {

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                 celula[i,j] = new tabla();
                 build(i,j);
            }
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    Viz(i,j);
           labelPlayer.Text = "Turn X";
           buttonStart.Visible = false;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
           for (int i = 0; i < 3; i++)
              for (int j = 0; j < 3; j++)
                  matButton[i, j].Visible = true;
            labelPlayer.Text = "Turn X";
            buttonStart.Visible = false;
            
       }


        private void buttonRes_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    matButton[i, j].Text = " ";
                    matButton[i, j].Enabled = true; 
                }
            nr = 0;
            labelPlayer.Text = "Turn X";
            buttonRes.Visible = false;
        }
        private void buttonExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}