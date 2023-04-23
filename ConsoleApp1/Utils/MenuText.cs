using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Utils
{
    internal class MenuText
    {
        public static string chooseOneFunction = "\nВиберіть, одну з функцій нижче:\n\n" + "1. Додати автомобіль, клієнта, мотоцикл тощо до автосалону.\n" + "2. Редагування інформацію щодо автомобілів, клієнтів, мотоциклів тощо.\n" + "3. Автоматизація підбору варіантів для покупця.\n" +
                "4. Показати базу автомобілів, клієнтів тощо\n" +
            "5. Пошук автомобіля за маркою, рік тощо.\n" +
            "6. Видалити транспорт, клієнта тощо з списку.\n" +
            "7. Зробити замовлення.\n" +
            "-1. Вихід";

        public static string exitOrContinueForChanges = "\n\nВибиріть одну з функцій нижче:\n" +
            "\n1. Вийти до головного меню" +
            "\n2. Вихід з програми"; 

    }
}
