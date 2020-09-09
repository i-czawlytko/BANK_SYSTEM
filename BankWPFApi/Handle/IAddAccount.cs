using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Handle
{
    public interface IAddAccount
    {
        /// <summary>
        /// Значение возвращаемое окном
        /// </summary>
        bool IShowDialog { get; }

        /// <summary>
        /// Строка с суммой
        /// </summary>
        string amountString { get; }

        /// <summary>
        /// Строка с процентами
        /// </summary>
        string percentString { get; }

        /// <summary>
        /// Заголовок
        /// </summary>
        string ITitle { get; set; }

        /// <summary>
        /// Капитализация (да/нет)
        /// </summary>
        bool Capitalization { get;}

        Brush AccAmountCol { get; set; }

        Brush AccPercentCol { get; set; }

        /// <summary>
        /// Показать чек-бок с капитализацией
        /// </summary>
        void ShowCheckBox();

        /// <summary>
        /// Скрыть чек-бокс с капитализацией
        /// </summary>
        void HideCheckBox();
    }
}
