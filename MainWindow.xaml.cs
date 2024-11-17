using System;
using System.Windows;

namespace MagicCalculator
{
    public partial class MainWindow : Window
    {
        // Variable zur Speicherung des aktuellen Eingabewerts
        private string _currentInput = "";
        private string _operator = "";
        private double _firstOperand = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        // Event-Handler für die Zahlentasten
        private void btn_num_1_Click(object sender, RoutedEventArgs e) => AddToInput("1");
        private void btn_num_2_Click(object sender, RoutedEventArgs e) => AddToInput("2");
        private void btn_num_3_Click(object sender, RoutedEventArgs e) => AddToInput("3");
        private void btn_num_4_Click(object sender, RoutedEventArgs e) => AddToInput("4");
        private void btn_num_5_Click(object sender, RoutedEventArgs e) => AddToInput("5");
        private void btn_num_6_Click(object sender, RoutedEventArgs e) => AddToInput("6");
        private void btn_num_7_Click(object sender, RoutedEventArgs e) => AddToInput("7");
        private void btn_num_8_Click(object sender, RoutedEventArgs e) => AddToInput("8");
        private void btn_num_9_Click(object sender, RoutedEventArgs e) => AddToInput("9");
        private void btn_num_0_Click(object sender, RoutedEventArgs e) => AddToInput("0");

        // Event-Handler für den Komma-Button
        private void btn_comma_Click(object sender, RoutedEventArgs e) => AddToInput(".");

        // Hinzufügen von Zeichen (Zahlen oder Operatoren) zum aktuellen Eingabewert
        private void AddToInput(string value)
        {
            _currentInput += value;
            txtCalculation.Text = _currentInput;
        }

        // Event-Handler für die Operatoren
        private void btn_plus_Click(object sender, RoutedEventArgs e) => SetOperator("+");
        private void btn_sub_Click(object sender, RoutedEventArgs e) => SetOperator("-");
        private void btn_mul_Click(object sender, RoutedEventArgs e) => SetOperator("x");
        private void btn_div_Click(object sender, RoutedEventArgs e) => SetOperator("/");

        // Setzen des Operators und Speichern des ersten Operanden
        private void SetOperator(string op)
        {
            _operator = op;
            _firstOperand = double.Parse(_currentInput);
            _currentInput = "";
        }

        // Event-Handler für den Gleichheits-Button
        private void btn_equal_Click(object sender, RoutedEventArgs e)
        {
            double secondOperand = double.Parse(_currentInput);
            double result = 0;

            switch (_operator)
            {
                case "+":
                    result = _firstOperand + secondOperand;
                    break;
                case "-":
                    result = _firstOperand - secondOperand;
                    break;
                case "x":
                    result = _firstOperand * secondOperand;
                    break;
                case "/":
                    result = _firstOperand / secondOperand;
                    break;
            }

            _currentInput = result.ToString();
            txtCalculation.Text = _currentInput;
            _operator = "";
            _firstOperand = 0;
        }

        // Event-Handler für den DEL-Button (Löschen)
        private void btn_del_Click(object sender, RoutedEventArgs e)
        {
            if (_currentInput.Length > 0)
            {
                _currentInput = _currentInput.Substring(0, _currentInput.Length - 1);
                txtCalculation.Text = _currentInput;
            }
        }

        // Event-Handler für den Vorzeichen-Button (+/-)
        private void btn_vorzeichen_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(_currentInput) && _currentInput != "0")
            {
                if (_currentInput.StartsWith("-"))
                {
                    _currentInput = _currentInput.Substring(1);
                }
                else
                {
                    _currentInput = "-" + _currentInput;
                }
                txtCalculation.Text = _currentInput;
            }
        }

        // Event-Handler für den TextChanged-Event der TextBox (optional)
        private void txtCalculation_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            // Optional: Weitere Validierungen oder Updates der UI
        }
    }
}
