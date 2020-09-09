using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Media;

namespace Handle
{
    public interface IAdd
    {
        /// <summary>
        /// Значение возвращаемое окном
        /// </summary>
        bool IShowDialog { get; }

        /// <summary>
        /// Строка с полным именем клиента
        /// </summary>
        string fullNameString { get; }

        /// <summary>
        /// Строка с датой рождения/создания
        /// </summary>
        string dateString { get; }

        /// <summary>
        /// Строка с именем названием клиента
        /// </summary>
        //string nameString { get; }

        /// <summary>
        /// Заголовок окна
        /// </summary>
        string ITitle { get; set; }

        /// <summary>
        /// Текст пометки об имени
        /// </summary>
        string nameText { get; set; }

        /// <summary>
        /// Текст пометки о дате
        /// </summary>
        string dateText { get; set; }

        /// <summary>
        /// Текст пометки о фамилии
        /// </summary>
        string lastNameText { get; set; }

        /// <summary>
        /// Включена ли третья строка
        /// </summary>
        bool third_string_on { get; set; }

        /// <summary>
        /// Цвет текстбокса ввода даты рождения/создания
        /// </summary>
        Brush CreateBoxCol { get; set; }

    }
}
