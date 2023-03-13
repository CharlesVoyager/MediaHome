using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MediaHome
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            Thickness thicknessFocus = new Thickness();
            thicknessFocus.Bottom = 3;
            thicknessFocus.Left = 3;
            thicknessFocus.Right = 3;
            thicknessFocus.Top = 3;
            mainMenu.brdNetflix.BorderThickness = thicknessFocus;
        }

        private void MainWindow_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            var keyEnum = (Key)e.Key;


            if (keyEnum == Key.Right)
            {
                //System.Diagnostics.Trace.WriteLine("[XYZ] left right is clicked.");
                processRightKey();
            }
            else if (keyEnum == Key.Left)
            {
                //System.Diagnostics.Trace.WriteLine("[XYZ] left key is clicked.");
                processLeftKey();
            }
        }


        private void processRightKey()
        {
            Thickness thicknessFocus = new Thickness();
            thicknessFocus.Bottom = 3;
            thicknessFocus.Left = 3;
            thicknessFocus.Right = 3;
            thicknessFocus.Top = 3;

            Thickness thicknessZero = new Thickness();
            thicknessZero.Bottom = 0;
            thicknessZero.Left = 0;
            thicknessZero.Right = 0;
            thicknessZero.Top = 0;

            if (mainMenu.brdNetflix.BorderThickness.Left > 0)
            {
                mainMenu.brdNetflix.BorderThickness = thicknessZero;
                mainMenu.brdDisneyPlus.BorderThickness = thicknessFocus;
                mainMenu.brdYiutube.BorderThickness = thicknessZero;
            }
            else if (mainMenu.brdDisneyPlus.BorderThickness.Left > 0)
            {
                mainMenu.brdDisneyPlus.BorderThickness = thicknessZero;
                mainMenu.brdYiutube.BorderThickness = thicknessFocus;
            }
            else if (mainMenu.brdYiutube.BorderThickness.Left > 0)
            {
                return;
            }
        }

        private void processLeftKey()
        {
            Thickness thicknessFocus = new Thickness();
            thicknessFocus.Bottom = 3;
            thicknessFocus.Left = 3;
            thicknessFocus.Right = 3;
            thicknessFocus.Top = 3;

            Thickness thicknessZero = new Thickness();
            thicknessZero.Bottom = 0;
            thicknessZero.Left = 0;
            thicknessZero.Right = 0;
            thicknessZero.Top = 0;

            if (mainMenu.brdNetflix.BorderThickness.Left > 0)
            {
                return;
            }
            else if (mainMenu.brdDisneyPlus.BorderThickness.Left > 0)
            {
                mainMenu.brdNetflix.BorderThickness = thicknessFocus;
                mainMenu.brdDisneyPlus.BorderThickness = thicknessZero;
            }
            else if (mainMenu.brdYiutube.BorderThickness.Left > 0)
            {

                mainMenu.brdDisneyPlus.BorderThickness = thicknessFocus;
                mainMenu.brdYiutube.BorderThickness = thicknessZero;
            }
        }

    }
}
