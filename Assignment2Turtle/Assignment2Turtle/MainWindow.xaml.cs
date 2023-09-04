using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
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

namespace Assignment2Turtle
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        int treeDepth = 0;
        int arrXCounter = 0;
        int arrYCounter = 0;
        int depthLimit = 10;

        string numericString;
        int command;

        int [,] turtle = new int [51,51];

        int timer = 0;
        int timerTick = 5;

        int penPos = 0;


        public MainWindow()
        {
            InitializeComponent();

            for (int i = 0; i < 50; i++)
            {
                turtle[i, i] = 0;
            }

        }
        void Timer()
        {
            while (command != 9)
            {

                if (arrXCounter < 50)
                {
                    arrXCounter++;
                }
                else
                {
                    arrXCounter = 0;
                    if (arrYCounter < 50)
                    {
                        arrYCounter += 1;
                    }
                    else
                    {
                        arrYCounter = 0;
                    }

                }

                Debug.WriteLine("arr X" + arrXCounter);
                Debug.WriteLine("arr Y" + arrYCounter);

                switch (command)
                {
                    case 1:
                        turtle[arrXCounter, arrYCounter] = 0;
                        penPos = 0;
                        Debug.WriteLine("PEN: " + penPos);
                        break;

                    case 2:
                        turtle[arrXCounter, arrYCounter] = 1;
                        penPos = 1;
                        Debug.WriteLine("PEN: " + penPos);
                        break;
                    case 3:
                        turtle[arrXCounter - 1, arrYCounter - 1] = 1;
                        Debug.WriteLine("arr X" + arrXCounter);
                        Debug.WriteLine("arr Y" + arrYCounter);
                        break;
                    case 4:
                        turtle[arrXCounter + 1, arrYCounter + 1] = 1;
                        Debug.WriteLine("arr X" + arrXCounter);
                        Debug.WriteLine("arr Y" + arrYCounter);
                        break;
                    case 5:
                        break;
                    case 6:

                        for(int i = 0; i <= 50; i++)
                        {
                            turtle[i, i] = 0;
                        }
                        break;
                    case 9:
                        System.Windows.Application.Current.Shutdown();
                        break;
                    default:
                        
                        break;
                }
                
                Thread.Sleep(timerTick);
            }
        }

        /*private void StartAnimation(object sender, EventArgs e)
        {
            animationCounter += 1;
            if (animationCounter % 60 == 0)
            {
                DrawBinaryTree(
                         canvas1,
                         treeDepth,
                         new Point(canvas1.Width / 2, 0.83 * canvas1.Height),
                         0.2 * canvas1.Width,
                         -Math.PI / 2
                );
                string str = "Binary Tree - Depth = " +
                treeDepth.ToString();
                tbLabel.Text = str;
                treeDepth += 1;
                if (treeDepth > depthLimit)
                {
                    tbLabel.Text = "Binary Tree - Depth = 10. Finished";
                    CompositionTarget.Rendering -= StartAnimation;
                }
            }
        }

         private double lengthScale = 0.75;
    private double deltaTheta = Math.PI / 5;
    private void DrawBinaryTree(Canvas canvas, int depth, Point pt,
                                    double length, double theta)
    {
        double x1 = pt.X + length * Math.Cos(theta);
        double y1 = pt.Y + length * Math.Sin(theta);
        Line line = new Line();
        line.Stroke = Brushes.Blue;
        line.X1 = pt.X;
        line.Y1 = pt.Y;
        line.X2 = x1;
        line.Y2 = y1;
        canvas.Children.Add(line);
        if (depth > 1)
        {
            DrawBinaryTree(canvas, depth - 1,
                             new Point(x1, y1),
                              length * lengthScale, theta + deltaTheta);
            DrawBinaryTree(canvas, depth - 1,
                              new Point(x1, y1),
                              length * lengthScale, theta - deltaTheta);
        }
        else
            return;
    }

         */
        private void StartAnimation(object sender, EventArgs e)
        {
            for (int i = 0;i <= 50;i++)
            {
                for (int j = 0;j <= 50;j++)
                {
                    if (turtle[i,j] == 1)
                    {
                        DrawBinaryTree(canvas1,
                                    treeDepth,
                                    new Point(canvas1.Width * i, canvas1.Height * j), 0.2 * canvas1.Width);
                    }
                }
            }
        }

        private double lengthScale = 0.75;
        private double deltaTheta = Math.PI / 5;
        private void DrawBinaryTree(Canvas canvas, int depth, Point pt,
                                        double length)
        {
            double x1 = pt.X + length;
            double y1 = pt.Y + length;
            Line line = new Line();
            line.Stroke = Brushes.Blue;
            line.X1 = pt.X;
            line.Y1 = pt.Y;
            line.X2 = x1;
            line.Y2 = y1;
            canvas.Children.Add(line);
            
        }




        private void Button_Click(object sender, RoutedEventArgs e)
        {
            canvas1.Children.Clear();
            command = 0;
            numericString = null;
            foreach (var c in tbLabel.Text)
            {
                if ((c >= '0' && c <= '9'))
                {
                    numericString = string.Concat(numericString, c.ToString());
                }
                else
                {
                    break;
                }
            }
            if (int.TryParse(numericString, out int j))
            {
                command = j;
            }

            Thread timerThread = new Thread(new ThreadStart(Timer));
            timerThread.Start();
            CompositionTarget.Rendering += StartAnimation;
        }

    }
}
