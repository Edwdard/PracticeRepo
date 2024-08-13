using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MathsOperators__UWP_
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //calculate.Content = "True";
            try
            {
                if ((bool)addition.IsChecked)
                {
                    addValues();
                }
                else if ((bool)subtraction.IsChecked)
                {
                    subtractValue();

                }
                else if ((bool)multiplication.IsChecked)
                {
                    multiplyValues();

                }
                else if ((bool)division.IsChecked)
                {
                    divideValues();
                }
                else if ((bool)remainder.IsChecked)
                {
                    remainderValues();
                }

                else
                {
                    throw new InvalidOperationException("No operator selected");
                }



        }
            catch (FormatException fEx)
            {
                result.Text = fEx.Message;
            }
            catch (OverflowException oEx)
            {
                result.Text = oEx.Message;

            }
            catch (InvalidOperationException ioEx)
            {
                result.Text = ioEx.Message;
            }
            catch (Exception ex)
                { result.Text = ex.Message; }


        }

        private void addValues ()
        {
            int lhs = int.Parse(lhsOperand.Text);
            int rhs = int.Parse(rhsOperand.Text);
            int outcome = 0;
            outcome = lhs + rhs;
            expression.Text = $"{lhs}+{rhs}";
            result.Text=outcome.ToString();

        }

        private void subtractValue()
        {
            int lhs = int.Parse(lhsOperand.Text);
            int rhs = int.Parse(rhsOperand.Text);
            int outcome = 0;
                outcome = lhs - rhs;
            expression.Text = $"{lhs}-{rhs}";
                result.Text = outcome.ToString();
        }

        private void multiplyValues()
        {
            int lhs = int.Parse(lhsOperand.Text);
            int rhs = int.Parse(rhsOperand.Text);
            int outcome = 0;

            outcome = checked(lhs * rhs);
            expression.Text = $"{lhs} * {rhs}";
            result.Text = outcome.ToString();
        }

        private void divideValues()
        {
            int lhs = int.Parse(lhsOperand.Text);
            int rhs = int.Parse(rhsOperand.Text);
            int outcome = 0;

            outcome = lhs / rhs;
            expression.Text = $"{lhs} / {rhs}";
            result.Text = outcome.ToString();
        }

        private void remainderValues()
        {
            int lhs = int.Parse(lhsOperand.Text);
            int rhs = int.Parse(rhsOperand.Text);
            int outcome = 0;

            outcome = lhs % rhs;
            expression.Text = $"{lhs} % {rhs}";
            result.Text = outcome.ToString();
        }

    }
}
