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

namespace chess_wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        Point startPoint;
        Thickness startMargin;
        Boolean figureClicked = false;
        Board chessBoard = new Board(new MyPoint(100, 50));
        List<Image> piecesList = new List<Image>();

        //private void List_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        //{
        //    // Store the mouse position
        //    startPoint = e.GetPosition(null);
        //    startMargin = Pawn1.Margin;
        //    figureClicked = true;
        //}

        //private void List_MouseMove(object sender, MouseEventArgs e)
        //{
        //    Uri imguri = new Uri("/Resources/w_pawn.png", UriKind.Relative);
        //    BitmapImage ni = new BitmapImage(imguri);
        //    Image img = new Image();
        //    img.Source = ni;
        //    img.Margin = new Thickness(100, 100, 0, 0);
        //}

        private void Window_MouseMove_1(object sender, MouseEventArgs e)
        {
            // Get the current mouse position
            Point mousePos = e.GetPosition(null);
            Vector diff = startPoint - mousePos;

            if (figureClicked == true) 
            {
                Thickness newMargin = new Thickness(startMargin.Left - diff.X, startMargin.Top - diff.Y, startMargin.Right + diff.X, startMargin.Bottom + diff.Y);
                Pawn1.Margin = newMargin;
                TextLabel.Content = diff.ToString();
                MarginLabel.Content = newMargin.ToString();
                StartLabel.Content = startMargin.ToString();

            }
        }

        private void Window_MouseUp_1(object sender, MouseButtonEventArgs e)
        {
            Point pos = e.GetPosition(null);
            MyPoint point = new MyPoint(Convert.ToInt32(pos.X), Convert.ToInt32(pos.Y));
            MyPoint chessPos = chessBoard.getPositionXY(point);

            chessPieces piece;

            mouseUpInPx.Content = point.ToString();
            mouseUpPos.Content = chessPos;
            piece = chessBoard.whatPieceAtPos(chessPos);
            mouseUpPiece.Content = piece;

            figureClicked = false;
        }

        private void Window_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            Point pos = e.GetPosition(null);
            MyPoint point = new MyPoint(Convert.ToInt32(pos.X), Convert.ToInt32(pos.Y));
            MyPoint chessPos = chessBoard.getPositionXY(point);

            mouseDownInPx.Content = point.ToString();
            mouseDownPos.Content = chessPos;
            mouseDownPiece.Content = chessBoard.whatPieceAtPos(chessPos);
        }

    }
}
