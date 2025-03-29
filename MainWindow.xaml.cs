using System;
using System.Windows;
using System.Windows.Controls;
using System.Text;

namespace password_generation
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Random random = new Random();
        private const string LowercaseChars = "abcdefghijklmnopqrstuvwxyz";
        private const string UppercaseChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string NumberChars = "0123456789";
        private const string SymbolChars = "!@#$%^&*()-_=+[]{}|;:,.<>?";

        public MainWindow()
        {
            InitializeComponent();
            // По умолчанию устанавливаем длину пароля 16
            LengthTextBox.Text = "16";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // Получаем размер пароля из текстового поля
            if (!int.TryParse(LengthTextBox.Text, out int passwordLength) || passwordLength <= 0)
            {
                MessageBox.Show("Пожалуйста, введите корректную длину пароля (положительное число).", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            
            // Собираем символы для пароля в зависимости от выбранной сложности
            StringBuilder charPool = new StringBuilder();
            
            if (LowercaseCheckBox.IsChecked == true)
                charPool.Append(LowercaseChars);
                
            if (UppercaseCheckBox.IsChecked == true)
                charPool.Append(UppercaseChars);
                
            if (NumbersCheckBox.IsChecked == true)
                charPool.Append(NumberChars);
                
            if (SymbolsCheckBox.IsChecked == true)
                charPool.Append(SymbolChars);
                
            // Проверяем, что хотя бы один набор символов выбран
            if (charPool.Length == 0)
            {
                MessageBox.Show("Пожалуйста, выберите хотя бы один тип символов для пароля.", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            
            string availableChars = charPool.ToString();
            
            // Создаем массив символов с указанной длиной
            char[] passwordChars = new char[passwordLength];

            // Заполняем массив случайными символами
            for (int i = 0; i < passwordChars.Length; i++)
            {
                int charIndex = random.Next(0, availableChars.Length);
                passwordChars[i] = availableChars[charIndex];
            }

            // Конвертируем массив символов в строку и выводим в текстовое поле
            PasswordTextBox.Text = new string(passwordChars);
        }
    }
}