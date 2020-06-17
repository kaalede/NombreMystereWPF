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

namespace NombreMystereWPF
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int randomed;
        int nombreEssais;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            NewGame();
        }

        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {
            int pickedNum = PickANumber();
            if(pickedNum > 0)
            {
                if (pickedNum != randomed)
                {
                    pickedNum = TryAgain(pickedNum);

                }
                else
                {
                    YouWin();
                }
            }


        }

        private void BtnNewGame_Click(object sender, RoutedEventArgs e)
        {
            NewGame();
        }

         void NewGame()
        {
            randomed = GenerateARandomNumber();
            textBlockInfo.Text = string.Empty;
            textBoxInput.Text = string.Empty;
            nombreEssais = 0;
            UpdateTry();

        }

        void UpdateTry()
        {
            textBlockEssai.Text = "Nombre d'essais : " + nombreEssais;
        }

         void YouWin()
        {
            textBlockInfo.Text = "Bravo ! Tu as gagné.";
        }

         int PickANumber()
        {
            string picked = textBoxInput.Text;

            // Vérification de la saisie avec TryParse
            int pickedNum;
            bool isNumeric = int.TryParse(picked, out pickedNum);

            if (isNumeric == false)
            {
                textBlockInfo.Text = "Il ne s'agit pas d'un nombre. Essaie encore.";
            }
            else
            {
                textBlockInfo.Text = string.Empty;
            }

            return pickedNum;
        }

        int GenerateARandomNumber()
        {
            return new Random().Next(1, 21);
        }

        int TryAgain(int pickedNum)
        {
            if(pickedNum > randomed)
            {
                textBlockInfo.Text = "C'est moins.";
            }
            else
            {
                textBlockInfo.Text = "C'est plus.";
            }

            nombreEssais = nombreEssais + 1;
            UpdateTry();

            return pickedNum;
        }
    }
}
