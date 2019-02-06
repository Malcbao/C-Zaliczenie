using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kolkoikrzyzyk
{
    public partial class Form1 : Form
    {
        public enum EBoxState
        {
            None, Krz, Kol
        }
        class GameBox
        {
            public EBoxState MyState;
            PictureBox MyBox;
            Form1 MyForm;

            public GameBox(PictureBox MyNewBox, Form1 MyNewForm)
            {
                MyState = EBoxState.None;
                MyBox = MyNewBox;
                MyBox.MouseClick += MyOnClick_MouseClick;
                MyForm = MyNewForm;
            }


            void MyOnClick_MouseClick(object sender, MouseEventArgs e)
            {
                if (MyBox == null || MyForm == null || !MyForm.GameIsOn)
                    return;

                if (e.Button == MouseButtons.Left)
                {
                    if (MyState == EBoxState.None)
                    {
                        if (MyForm.ActualState == EBoxState.Krz)
                        {
                            MyState = EBoxState.Krz;
                            MyBox.Image = kolkoikrzyzyk.Properties.Resources.krzyzyk;
                        }
                        else
                        {
                            MyState = EBoxState.Kol;
                            MyBox.Image = kolkoikrzyzyk.Properties.Resources.kolko;
                        }
                        if(MyForm.CheckForWinner(MyState))
                        {
                            MyForm.EndGame(MyState);
                            return;
                        }
                        else if(MyForm.clicks == 16)
                        {
                            MyForm.EndGame(EBoxState.None);
                            return;
                        }
                        MyForm.ChangePlayer();
                    }
                }
            }

            public void Reset()
            {
                MyState = EBoxState.None;
                if(MyBox != null)
                MyBox.Image = kolkoikrzyzyk.Properties.Resources.white64;
            }

        }

   
        public EBoxState ActualState;

        private void ChangePlayer()
        {
            if (ActualState == EBoxState.Krz)
                ChangePlayer(EBoxState.Kol);
            else
                ChangePlayer(EBoxState.Krz);
        }

        private void ChangePlayer(EBoxState NewState)
        {
            ActualState = NewState;
            if (ActualState == EBoxState.Krz)
                pictureBox10.Image = kolkoikrzyzyk.Properties.Resources.krzyzyk;
            else
                pictureBox10.Image = kolkoikrzyzyk.Properties.Resources.kolko;
        }


        public Form1()
        {
            InitializeComponent();
        }

        List<GameBox> Playground = new List<GameBox>();
        byte clicks;
       public bool GameIsOn;

        private void Form1_Load(object sender, EventArgs e)
        {
            Playground.Add(new GameBox(pictureBox1, this));
            Playground.Add(new GameBox(pictureBox2, this));
            Playground.Add(new GameBox(pictureBox3, this));
            Playground.Add(new GameBox(pictureBox17, this));
            Playground.Add(new GameBox(pictureBox4, this));
            Playground.Add(new GameBox(pictureBox5, this));
            Playground.Add(new GameBox(pictureBox6, this));
            Playground.Add(new GameBox(pictureBox16, this));
            Playground.Add(new GameBox(pictureBox7, this));
            Playground.Add(new GameBox(pictureBox8, this));
            Playground.Add(new GameBox(pictureBox9, this));
            Playground.Add(new GameBox(pictureBox15, this));
            Playground.Add(new GameBox(pictureBox11, this));
            Playground.Add(new GameBox(pictureBox12, this));
            Playground.Add(new GameBox(pictureBox13, this));
            Playground.Add(new GameBox(pictureBox14, this));
            RestartGame();
        }

        private void RestartGame()
        {
            GameIsOn = true;
            clicks = 0;
            foreach(GameBox gb in Playground)
            {
                gb.Reset();
            }
            label1.Visible = false;
            ChangePlayer(EBoxState.Krz);
        }

        bool CheckForWinner(EBoxState Type)
        {
            clicks++;
            int iof = 0;
            for(int i = 0; i < 4; i++)
            {
                if (Playground[i + iof].MyState == Type && Playground[i + 1 + iof].MyState == Type && Playground[i + 2 + iof].MyState == Type && Playground[i + 3 + iof].MyState == Type)
                return true;
                iof += 4;
            }
            iof = 0;
            for (int i = 0; i < 4; i++)
            {
                if (Playground[i + iof].MyState == Type && Playground[i + 4 + iof].MyState == Type && Playground[i + 8 + iof].MyState == Type && Playground[i + 12 + iof].MyState == Type)
                    return true;
                iof += 1;
            }

            if (Playground[0].MyState == Type && Playground[5].MyState == Type && Playground[10].MyState == Type && Playground[15].MyState == Type)
                return true;

            if (Playground[3].MyState == Type && Playground[6].MyState == Type && Playground[9].MyState == Type && Playground[12].MyState == Type)
                return true;

            return false;

        }

        void EndGame(EBoxState Winner)
        {
            GameIsOn = false;
            label1.Visible = true;
            String WinnerText = "";
            if (Winner == EBoxState.None)
            {
                WinnerText = "Draw";
            }
            if (Winner == EBoxState.Krz)
            {
                WinnerText = "Player 1 Wins!";
            }
            if (Winner == EBoxState.Kol)
            {
                WinnerText = "Player 2 Wins!";
            }
            label1.Text = WinnerText;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            RestartGame();
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
