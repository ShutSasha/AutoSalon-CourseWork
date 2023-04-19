using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Utils
{
    internal class MenuText
    {
        public static string chooseOneFunction = "\nВиберіть, одну з функцій нижче:\n\n" + "1. Додати автомобіль, клієнта, мотоцикл тощо до автосалону.\n" + "2. Редагування інформації щодо автомобілей.\n" + "3. Додавання клієнта.\n" + "4. Редагування клієнта.\n" + "5. Автоматизація підбору варіантів для покупця.\n" +
                "6. Показати базу автомобілів, клієнтів тощо\n" +
            "7. Пошук автомобіля за маркою, рік тощо.\n" +
            "8. Видалити машину з списку.\n" +
            "9. Додати клієнта.\n" +
            "-1. Вихід";

        public static string exitOrContinueForChanges = "\n\nВибиріть одну з функцій нижче:\n" +
            "\n1. Вийти до головного меню" +
            "\n2. Вихід з програми";

        public const string exitOrContinueOutputText = "\n\nВибиріть одну з функцій нижче:\n" +
            "\n1. Вийти до головного меню" +
            "\n2. Вихід з програми";

    }
}
