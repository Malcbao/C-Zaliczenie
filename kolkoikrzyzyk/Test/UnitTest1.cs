using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using kolkoikrzyzyk;
using System.Windows.Forms;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]

        public void TestMethod1(PictureBox Box, Form1 Form) { }

        [TestMethod]

        public void MouseTest(Object a, MouseEventArgs m, Form1 Form, PictureBox Box, Form1.EBoxState k)
        {
            PictureBox Mybox = Box;

            Form1 Myform = Form;

            Form1.EBoxState Mystate = k;

            if (Mybox == null || Myform == null || !Myform.GameIsOn) { Console.WriteLine("return true"); }

            else { Console.WriteLine("return false"); }

            if (m.Button == MouseButtons.Left)
            {
                if (Mystate == 0)
                {
                    if (Myform.ActualState == Form1.EBoxState.Krz)



                    { Console.WriteLine("rysuje krzyzyk"); }

                    else { Console.WriteLine("rysuje kolko"); }


                }
                else { Console.WriteLine("blad"); }

            }

        }
        [TestMethod]
        public void ResetTest(PictureBox b)
        {
            PictureBox Mybox = b;

            if (Mybox == null) { Console.WriteLine("blad, gra sie nie resetuje"); }
        }
        
        

    }
        

        
    
}
