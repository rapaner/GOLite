using System;
using System.Linq;

namespace GOLite.Common
{
    public static class ClassExtensions
    {
        /// <summary>
        /// Получить сообщение об исключении
        /// </summary>
        /// <param name="ex">Исключение</param>
        public static string GetExceptionMessage(this Exception ex)
        {
            string mes = string.Empty;
            Exception exc = ex;
            mes += exc.Message;
            while (exc.InnerException != null)
            {
                exc = exc.InnerException;
                mes += $"\n{exc.Message}";
            }

            return mes;
        }

        /// <summary>
        /// Получить дату из строки
        /// </summary>
        /// <param name="dateString">Строка даты</param>
        public static DateTime GetDateFromString(this string dateString)
        {
            var dateParts = dateString
                .Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray();
            return new DateTime(dateParts[2], dateParts[1], dateParts[0]);
        }

        /// <summary>
        /// Получить строку из даты для БД
        /// </summary>
        /// <param name="date">Дата</param>
        public static string GetStringFromDateForDB(this DateTime date)
        {
            return date.ToString("dd.MM.yyyy");
        }
    }
}