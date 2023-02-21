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

namespace myWPFCalc
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
        char operand = ' ';

        private string CalcuateIt(float numOne, float numTwo, char operand)
        {
            float answer = 0;
            string strReturn = "";
            if (operand == '+')
            {
                answer = numOne + numTwo;
            }
            else if (operand == '-')
            {
                answer = numOne - numTwo;
            }
            else if (operand == '*')
            {
                answer = numOne * numTwo;
            }
            else if(operand == '/')
            {
                if (numTwo == 0) {
                    return "Error";
                        }
                else
                {
                    answer = numOne / numTwo;
                }
            }
            else
            {
                return null;
            }
            strReturn = answer.ToString("0.00");
            return strReturn;
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            lblInputOutput.Content= string.Empty;
        }

        private void btnNumClick(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            string number =(string)btn.Content;
            lblInputOutput.Content= lblInputOutput.Content+number;

        }

        private void btnEquation(object sender, RoutedEventArgs e)
        {
            Button btn =(Button)sender;
            string symbol = (string)btn.Content;
            string equation =(string)lblInputOutput.Content;                    
            char lastCharacter = equation.Last();
            if (char.IsDigit(lastCharacter))
            {
                lblInputOutput.Content= equation + symbol;
            }
            else
            {
                lblInputOutput.Content = equation.Replace(lastCharacter, char.Parse(symbol));
            }
            operand = char.Parse(symbol);
        }

        private void btnDecimal(object sender, RoutedEventArgs e)
        {
            string equation = (string)lblInputOutput.Content;

            if (!equation.Contains('.'))
            {
                if (equation == "")
                {
                    lblInputOutput.Content = "0.";
                }
                else
                {
                    lblInputOutput.Content = lblInputOutput.Content + ".";
                }
            }
            else
            {
                int operationLocation = equation.IndexOf(operand);

                if (operand != ' ' && operationLocation != equation.Length)
                {
                    char equationLast = equation.Last();
                    if (equationLast == operand)
                    {
                        lblInputOutput.Content = equation + "0.";
                    }
                    else
                    {
                        lblInputOutput.Content = equation + ".";
                    }
                }

            }
        }

        private void btnSquare(object sender, RoutedEventArgs e)
        {
            float answer = 0;
            string strReturn = "";
            string equation = (string)lblInputOutput.Content;

                float numOne = float.Parse(equation.Substring(0));
                answer = (float)Math.Pow(numOne,2);
                strReturn = answer.ToString("0.00");
                lblInputOutput.Content = strReturn;
            
            
        }

        private void btnEqualsClick(object sender, RoutedEventArgs e)
        {
            string equation = (string)lblInputOutput.Content;
            int operationLocation = equation.IndexOf(operand);
            //this doesn't work with multiple operations only 1 at a time
            float numOne = float.Parse(equation.Substring(0,operationLocation));
            float numTwo = float.Parse(equation.Substring(operationLocation+1));
            lblInputOutput.Content= CalcuateIt(numOne,numTwo,operand);
        }


    }
}
