using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Bookmaster.AppData
{
    public static class FeedbackService
    {
        //1)Тип сообщения ошибка
        //Ошибка для пользователя
        
        public static void Error(string message)
        {
            MessageBox.Show(message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        //Системная ошибка
        public static void Error(Exception exception)
        {
            MessageBox.Show(exception.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        //2)Предупреждение 
        public static void Warning(string message)
        {
            MessageBox.Show(message, "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
        //3)Информация 
        public static void Information(string message)
        {
            MessageBox.Show(message, "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        //4)Тип сообщения Вопрос 
        public static MessageBoxResult Question(string message)
        {
            return MessageBox.Show(message, "Вопрос", MessageBoxButton.YesNo, MessageBoxImage.Question);
        }
    }
}
