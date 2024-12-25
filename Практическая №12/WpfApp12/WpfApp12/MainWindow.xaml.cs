using System.Text;
using System.Windows;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp12
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent(); // Инициализация компонентов окна
        }

        private void CheckArrays_Click(object sender, RoutedEventArgs e)
        {
            // Получаем строки из текстовых полей
            string firstArrayInput = firstArrayTextBox.Text; // Ввод первого массива
            string secondArrayInput = secondArrayTextBox.Text; // Ввод второго массива

            // Проверяем на пустые строки
            if (string.IsNullOrWhiteSpace(firstArrayInput) || string.IsNullOrWhiteSpace(secondArrayInput))
            {
                MessageBox.Show("Оба массива должны быть заполнены.", "Ошибка"); // Сообщение об ошибке при пустом вводе
                return; // Выход из метода при ошибке
            }

            try
            {
                // Преобразуем строки в массивы чисел
                int[] firstArray = firstArrayInput.Split(',').Select(int.Parse).ToArray(); // Преобразование строки в массив целых чисел
                int[] secondArray = secondArrayInput.Split(',').Select(int.Parse).ToArray(); // Преобразование строки в массив целых чисел

                // Проверяем соответствие длины массивов
                if (firstArray.Length != secondArray.Length)
                {
                    MessageBox.Show("Массивы должны быть одинаковой длины.", "Ошибка"); // Сообщение об ошибке при разной длине массивов
                    return; // Выход из метода при ошибке
                }

                int count = 0; // Счетчик для количества элементов первого массива, превышающих соответствующие элементы второго

                // Сравниваем элементы массивов
                for (int i = 0; i < firstArray.Length; i++)
                {
                    if (firstArray[i] > secondArray[i]) // Если элемент первого массива больше соответствующего элемента второго
                    {
                        count++; // Увеличиваем счетчик
                    }
                }

                // Выводим результат в ListBox
                resultsListBox.Items.Clear(); // Очистка предыдущих результатов
                resultsListBox.Items.Add($"Количество элементов первого массива, превышающих соответствующие элементы второго: {count}"); // Вывод результата
            }
            catch (FormatException)
            {
                MessageBox.Show("Пожалуйста, введите корректные числовые значения.", "Ошибка"); // Сообщение об ошибке при некорректном формате ввода
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown(); // Закрытие приложения при нажатии кнопки "Выход"
        }

        private void AboutButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Разработчик: Кошеренков Максим Сергеевич\nНомер работы: 12\nЗадание: Проверить количество элементов первого массива, превышающих соответствующие элементы второго.", "О программе");
            // Вывод информации о разработчике и задании при нажатии кнопки "О программе"
        }
    }
}