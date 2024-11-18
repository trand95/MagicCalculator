using System;
using System.Windows;

namespace MagicCalculator
{
    public partial class MainWindow : Window
    {
        // Variable zur Speicherung des aktuellen Eingabewerts
        private string _currentInput = "";
        private string _operator = "";
        private string _history = "";
        private double _operand1 = 0.0;
        private double _operand2 = 0.0;
        private double _result = 0.0;
        private int _operatorCounter = 0;
        private bool _commaIsSet = false;
        private bool _isEqual = false;


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
        private void btn_comma_Click(object sender, RoutedEventArgs e) => AddToInput(",");

        // Hinzufügen von Zeichen (Zahlen oder Operatoren) zum aktuellen Eingabewert
        private void AddToInput(string value)
        {

            if (_isEqual == true)
            {
                txtCalculation.Text = "";
                
                _currentInput = "";
                txtHistory.Text = "";
                _isEqual = false;
            }

            _operatorCounter = 0;

            if (!_currentInput.Contains(","))
            {
                _currentInput += value;

            }

            else
            {
                if (value == ",") return;
                _currentInput += value;
            }


            txtCalculation.Text = _currentInput;









        }

        // Event-Handler für die Operatoren
        private void btn_plus_Click(object sender, RoutedEventArgs e) => SetOperator("+");
        private void btn_sub_Click(object sender, RoutedEventArgs e) => SetOperator("-");
        private void btn_mul_Click(object sender, RoutedEventArgs e) => SetOperator("x");
        private void btn_div_Click(object sender, RoutedEventArgs e) => SetOperator("/");

        private void ReplaceLastChar(string input, string newOperator)
        {
            if (string.IsNullOrEmpty(input))
            {
                txtHistory.Text = input;
                return;
            }


            txtHistory.Text = input.Substring(0, input.Length - 1) + newOperator;
            return;
        }
        // Setzen des Operators und Speichern des ersten Operanden
        private void SetOperator(string op)
        {


            _operator = op;
            _operatorCounter++;




            switch (_operator)
            {
                case "+":

                    if (_operatorCounter > 1)
                    {
                        ReplaceLastChar(txtHistory.Text, _operator);

                    }
                    else
                    {
                        txtHistory.Text += " " + txtCalculation.Text + " +";
                    }
                    break;
                case "-":

                    if (_operatorCounter > 1)
                    {
                        ReplaceLastChar(txtHistory.Text, _operator);

                    }
                    else
                    {
                        txtHistory.Text += " " + txtCalculation.Text + " -";
                    }
                    break;
                case "/":

                    if (_operatorCounter > 1)
                    {
                        ReplaceLastChar(txtHistory.Text, _operator);

                    }
                    else
                    {
                        txtHistory.Text += " " + txtCalculation.Text + " /";
                    }
                    break;
                case "x":

                    if (_operatorCounter > 1)
                    {
                        ReplaceLastChar(txtHistory.Text, _operator);

                    }
                    else
                    {
                        txtHistory.Text += " " + txtCalculation.Text + " x";
                    }
                    break;
            }

            if (_operand1 == 0.0)
            {
                if (double.TryParse(_currentInput, out double parsedValue))
                {
                    _operand1 = parsedValue;
                }
                _currentInput = "";
            }

            else if (_operand2 == 0.0)
            {
                if (double.TryParse(_currentInput, out double parsedValue))
                {
                    _operand2 = parsedValue;
                }
                _currentInput = "";

                switch (_operator)
                {
                    case "+":

                        if (_operatorCounter > 1)
                        {
                            ReplaceLastChar(txtHistory.Text, _operator);

                        }
                        else
                        {
                            // txtHistory.Text += " " + txtCalculation.Text + " +";
                        }
                        _result = _operand1 + _operand2;

                        txtCalculation.Text = _result.ToString();
                        _operand1 = _result;
                        _operand2 = 0.0;
                        break;
                    case "-":

                        if (_operatorCounter > 1)
                        {
                            ReplaceLastChar(txtHistory.Text, _operator);

                        }
                        else
                        {
                            //txtHistory.Text += " " + txtCalculation.Text + " -";
                        }
                        _result = _operand1 - _operand2;

                        txtCalculation.Text = _result.ToString();
                        _operand1 = _result;
                        _operand2 = 0.0;
                        break;
                    case "/":

                        if (_operatorCounter > 1)
                        {
                            ReplaceLastChar(txtHistory.Text, _operator);

                        }
                        else
                        {
                            // txtHistory.Text += " " + txtCalculation.Text + " /";
                        }
                        _result = _operand1 / _operand2;

                        txtCalculation.Text = _result.ToString();
                        _operand1 = _result;
                        _operand2 = 0.0;
                        break;
                    case "x":

                        if (_operatorCounter > 1)
                        {
                            ReplaceLastChar(txtHistory.Text, _operator);

                        }
                        else
                        {
                            //txtHistory.Text += " " + txtCalculation.Text + " x";
                        }
                        _result = _operand1 * _operand2;

                        txtCalculation.Text = _result.ToString();
                        _operand1 = _result;
                        _operand2 = 0.0;
                        break;
                }
            }


            /*

            _operator = op;
            
            
            if (_operator != op)
            {
                _operator = op;
                _operatorIsChanged = true;
            }


            if (_operand1 == 0.0)
            {
                _operand1 = double.Parse(_currentInput);

                switch (_operator)
                {
                    case "+":
                        txtHistory.Text += " " + txtCalculation.Text + " +";
                        if (_operatorIsChanged == true)
                        {
                            ReplaceLastChar(txtHistory.Text, _operator);
                            _operatorIsChanged = false;
                        }
                        break;
                    case "-":
                        txtHistory.Text += " " + txtCalculation.Text + " -";
                        if (_operatorIsChanged == true)
                        {
                            ReplaceLastChar(txtHistory.Text, _operator);
                            _operatorIsChanged = false;
                        }
                        break;
                    case "/":
                        txtHistory.Text += " " + txtCalculation.Text + " /";
                        if (_operatorIsChanged == true)
                        {
                            ReplaceLastChar(txtHistory.Text, _operator);
                            _operatorIsChanged = false;
                        }
                        break;
                    case "*":
                        txtHistory.Text += " " + txtCalculation.Text + " *";
                        if (_operatorIsChanged == true)
                        {
                            ReplaceLastChar(txtHistory.Text, _operator);
                            _operatorIsChanged = false;
                        }
                        break;
                }
            }



            else if (_operand2 == 0.0)
            {
                if (_currentInput != "")
                {
                    _operand2 = double.Parse(_currentInput);
                    _currentInput = "";

                    switch (_operator)
                    {
                        case "+":
                            _result = _operand1 + _operand2;
                            txtHistory.Text += " " + txtCalculation.Text + " +";
                            txtCalculation.Text = _result.ToString();
                            _operand1 = _result;
                            _operand2 = 0.0;
                            if (_operatorIsChanged == true)
                            {
                                ReplaceLastChar(txtHistory.Text, _operator);
                                _operatorIsChanged = false;
                            }
                            break;
                        case "-":
                            _result = _operand1 - _operand2;
                            txtHistory.Text += " " + txtCalculation.Text + " -";
                            txtCalculation.Text = _result.ToString();
                            _operand1 = _result;
                            _operand2 = 0.0;
                            if (_operatorIsChanged == true)
                            {
                                ReplaceLastChar(txtHistory.Text, _operator);
                                _operatorIsChanged = false;
                            }
                            break;
                        case "/":
                            _result = _operand1 / _operand2;
                            txtHistory.Text += " " + txtCalculation.Text + " /";
                            txtCalculation.Text = _result.ToString();
                            _operand1 = _result;
                            _operand2 = 0.0;
                            if (_operatorIsChanged == true)
                            {
                                ReplaceLastChar(txtHistory.Text, _operator);
                                _operatorIsChanged = false;
                            }
                            break;
                        case "*":
                            _result = _operand1 * _operand2;
                            txtHistory.Text += " " + txtCalculation.Text + " *";
                            txtCalculation.Text = _result.ToString();
                            _operand1 = _result;
                            _operand2 = 0.0;
                            if (_operatorIsChanged == true)
                            {
                                ReplaceLastChar(txtHistory.Text, _operator);
                                _operatorIsChanged = false;
                            }
                            break;
                    }
                }





            }






            */



        }



        // Event-Handler für den Gleichheits-Button
        private void btn_equal_Click(object sender, RoutedEventArgs e)
        {

            if (double.TryParse(_currentInput, out double parsedValue))
            {
                _operand2 = parsedValue;
            }
            _currentInput = "";


            switch (_operator)
            {
                case "+":
                    _result = _operand1 + _operand2;
                    _operand1 = _result;

                    break;
                case "-":
                    _result = _operand1 - _operand2;
                    _operand1 = _result;

                    break;
                case "x":
                    _result = _operand1 * _operand2;
                    _operand1 = _result;

                    break;
                case "/":
                    if (_operand2 == 0)
                    {
                        txtCalculation.Text = "Fehler: Division durch 0";
                        _operator = "";
                        _currentInput = "";
                        _operand1 = 0.0;
                        _operand2 = 0.0;
                        return;
                    }
                    _result = _operand1 / _operand2;
                    _operand1 = _result;


                    break;
            }

            _currentInput = _result.ToString();
            txtCalculation.Text = _currentInput;
            txtHistory.Text += " " + _operand2;
            _operator = "";
            _operand1 = 0.0;
            _operand2 = 0.0;
            _isEqual = true;

        }

        // Event-Handler für den DEL-Button (Löschen)
        private void btn_del_Click(object sender, RoutedEventArgs e)
        {
            txtCalculation.Text = "";
            _currentInput = "";
            txtHistory.Text = "";



        }

        // Event-Handler für den Vorzeichen-Button (+/-)
        private void btn_vorzeichen_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(_currentInput, out double parsedValue))
            {
                parsedValue = -parsedValue;
                _currentInput = parsedValue.ToString();
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
