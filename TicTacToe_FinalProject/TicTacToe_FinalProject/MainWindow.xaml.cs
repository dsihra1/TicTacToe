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

namespace TicTacToe_FinalProject
{

    // This is not my Code. I followed a WPF tutorial to create a Tic Tac Toe Game 
    //https://www.youtube.com/watch?v=mnTyiUAHuVk 

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CharacterType[] EndResults;

        private bool PlayerMove;

        private bool End;

        public MainWindow()
        {
            InitializeComponent();


            NewGame();
        }

        private void NewGame()
        {
            EndResults = new CharacterType[9]; 

            for (var i = 0; i < EndResults.Length; i++)
            {
                EndResults[i] = CharacterType.none;
            }
            PlayerMove = true;

            Container.Children.Cast<Button>().ToList().ForEach(button => 
            {
                button.Content = string.Empty;
                button.Background = Brushes.White;
                button.Foreground = Brushes.Red;
            });

            End = false; 

        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            if (End)
            {
                NewGame();
                return; 
            }

            var button = (Button)sender;

            var column = Grid.GetColumn(button);
            var row = Grid.GetRow(button);

            var index = column + (row * 3);

            if (EndResults[index] != CharacterType.none)
                return;

            if (PlayerMove)
                EndResults[index] = CharacterType.O;
            else
                EndResults[index] = CharacterType.X;

            button.Content = PlayerMove ? "X" : "O";

            if (!PlayerMove)
                button.Foreground = Brushes.Blue; 

            if (PlayerMove)
                PlayerMove = false;
            else
                PlayerMove = true;


            CheckWinner();
            
                

        }

        private void CheckWinner()
        {

           // var chk = (EndResults[0] & EndResults[1] & EndResults[2]) == EndResults[0];

            //Row
            if (EndResults[0] != CharacterType.none && (EndResults[0] & EndResults[1] & EndResults[2]) == EndResults[0])
            {
                End = true;

                btn.Background = Brushes.Black;
                btnOneZero.Background = Brushes.Black;
                btnTwoZero.Background = Brushes.Black; 
            }


            if (EndResults[3] != CharacterType.none && (EndResults[3] & EndResults[4] & EndResults[5]) == EndResults[3])
            {
                End = true;

                btnZeroOne.Background = Brushes.Black;
                btnOnes.Background = Brushes.Black;
                btnTwoOne.Background = Brushes.Black; 

                
            }

            if (EndResults[6] != CharacterType.none && (EndResults[6] & EndResults[7] & EndResults[8]) == EndResults[6])
            {
                End = true;

                btnZeroTwo.Background = Brushes.Black;
                btnOneTwo.Background = Brushes.Black;
                btnTwos.Background = Brushes.Black;


            }

            //Column 

            if (EndResults[0] != CharacterType.none && (EndResults[0] & EndResults[3] & EndResults[6]) == EndResults[0])
            {
                End = true;

                btn.Background = Brushes.Black;
                btnZeroOne.Background = Brushes.Black;
                btnZeroTwo.Background = Brushes.Black;
            }

            if (EndResults[1] != CharacterType.none && (EndResults[1] & EndResults[4] & EndResults[7]) == EndResults[1])
            {
                End = true;

                btnOneTwo.Background = Brushes.Black;
                btnOnes.Background = Brushes.Black;
                btnOneZero.Background = Brushes.Black;
            }

            if (EndResults[2] != CharacterType.none && (EndResults[2] & EndResults[5] & EndResults[8]) == EndResults[2])
            {
                End = true;

                btnTwoZero.Background = Brushes.Black;
                btnTwoOne.Background = Brushes.Black;
                btnTwos.Background = Brushes.Black;
            }


            //Cross 
            if (EndResults[0] != CharacterType.none && (EndResults[0] & EndResults[4] & EndResults[8]) == EndResults[0])
            {
                End = true;

                btn.Background = Brushes.Black;
                btnOnes.Background = Brushes.Black;
                btnTwos.Background = Brushes.Black;
            }

            if (EndResults[2] != CharacterType.none && (EndResults[2] & EndResults[4] & EndResults[6]) == EndResults[2])
            {
                End = true;

                btnTwoZero.Background = Brushes.Black;
                btnOnes.Background = Brushes.Black;
                btnZeroTwo.Background = Brushes.Black;
            }

           
            if (!EndResults.Any(result => result == CharacterType.none))
            {
                End = true;

                Container.Children.Cast<Button>().ToList().ForEach(button =>
                {
                    
                    button.Background = Brushes.DarkGray;
                    
                });
            }

        }
    }
}
