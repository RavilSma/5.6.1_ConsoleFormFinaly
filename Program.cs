using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace _5._6._1_ConsoleFormFinaly
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var infoAboutUser = GetUserForm();
            Console.WriteLine(Environment.NewLine + "Итак, давай посмотрим, что мы о вас выяснили:");
            Console.WriteLine($"Вас зовут {CapitalizationName(infoAboutUser.name)} {CapitalizationName(infoAboutUser.familyName)}. Вам {infoAboutUser.age} лет.");

            if (infoAboutUser.petsName.Length == 1) Console.WriteLine($"Кличка вашего единственного и самого любимого питомца: {CapitalizationName(infoAboutUser.petsName[0]) + "."}");
            else if (infoAboutUser.petsName.Length > 1)
            {
                string strPetsName = string.Empty;
                for (int i = 0; i < infoAboutUser.petsName.Length; i++) strPetsName += CapitalizationName(infoAboutUser.petsName[i]) + ", ";
                Console.WriteLine($"Клички ваших любимых питомцев: {strPetsName.Remove(strPetsName.Length - 2) + "."}");
            }

            if (infoAboutUser.favColors.Length == 1) Console.WriteLine($"Твой единственный самый любимый цвет: {infoAboutUser.favColors[0] + "."}");
            else if (infoAboutUser.favColors.Length > 1)
            {
                string strFavColors = string.Empty;
                for (int i = 0; i < infoAboutUser.favColors.Length; i++) strFavColors += infoAboutUser.favColors[i] + ", ";
                Console.WriteLine($"Ваши любимые цвета: {strFavColors.Remove(strFavColors.Length - 2) + "."}");
            }
        }

        static bool IsCorrectName(string str)
        {
            if (str.Any(s => !char.IsLetter(s)) || str == "") return false;
            else return true;
        }
        static bool IsCorrectNumber(string str, out byte num)
        {
            if (byte.TryParse(str, out num) == false | num == 0) return false;
            else return true;
        }
        static bool IsCorrectBoolAnswer(string str)
        {
            if (str == "да" || str == "нет") return true;
            else return false;
        }
        static string[] GetArrayPetsName()
        {
            Console.Write("Замечательно! А сколько у вас питомцев? Введите целое число: ");
            string stringNumPets = Console.ReadLine();
            byte numPets = 0;
            while (!IsCorrectNumber(stringNumPets, out numPets))
            {
                Console.Write("Пожалуйста, повторно введите кол-во своих питомцев: ");
                stringNumPets = Console.ReadLine();
            }
            string[] tempPetsName = new string[numPets];
            for (int i = 0; i < numPets; i++)
            {
                Console.Write($"Как зовут вашего {i + 1}-го питомца: ");
                string petName = Console.ReadLine();
                while (!IsCorrectName(petName))
                {
                    Console.Write($"Пожалуйста, повторно введите кличку вашего {i + 1}-го питомца (без цифр и знаков пунктуации): ");
                    petName = Console.ReadLine();
                }
                tempPetsName[i] = petName;
            }
            return tempPetsName;
        }
        static string[] GetArrayFavColors()
        {
            Console.Write("А сколько у вас любимых цветов ? Пожалуйста, укажите количество: ");
            string stringNumFavColors = Console.ReadLine();
            byte numFavColors = 0;
            while (!IsCorrectNumber(stringNumFavColors, out numFavColors))
            {
                Console.Write("Пожалуйста, повторно введите кол-во своих любимых цветов: ");
                stringNumFavColors = Console.ReadLine();
            }
            string[] tempFavColors = new string[numFavColors];
            for (int i = 0; i < numFavColors; i++)
            {
                Console.Write($"Ваш {i + 1}-ый любимый цвет: ");
                string favColor = Console.ReadLine();
                while (!IsCorrectName(favColor))
                {
                    Console.Write($"Пожалуйста, повторно введите ваш {i + 1}-ый любимый цвет (без цифр и знаков пунктуации): ");
                    favColor = Console.ReadLine();
                }
                tempFavColors[i] = favColor;
            }
            return tempFavColors;
        }
        static (string name, string familyName, byte age, string[] petsName, string[] favColors) GetUserForm()
        {
            Console.Write("Введите ваше имя: ");
            string name = Console.ReadLine();
            while (!IsCorrectName(name))
            {
                Console.Write("Пожалуйста, повторно введите ваше корректное имя (без цифр и знаков пунктуации): ");
                name = Console.ReadLine();
            }

            Console.Write("Введите вашу фамилию: ");
            string familyName = Console.ReadLine();
            while (!IsCorrectName(familyName))
            {
                Console.Write("Пожалуйста, повторно введите вашу корректную фамилию (без цифр и знаков пунктуации): ");
                familyName = Console.ReadLine();
            }

            Console.Write("Введите ваш возраст (полные года): ");
            string stringAge = Console.ReadLine();
            byte age = 0;
            while (!IsCorrectNumber(stringAge, out age) | age > 130)
            {
                Console.Write("Пожалуйста, повторно введите ваш корректный возраст: ");
                stringAge = Console.ReadLine();
            }

            Console.Write("Есть ли у вас питомец (питомцы)? Ответьте да/нет: ");
            string hasPet = Console.ReadLine().Replace(" ", "").ToLower();
            while (!IsCorrectBoolAnswer(hasPet))
            {
                Console.Write("Пожалуйста, повторно введите ответ (да/нет): ");
                hasPet = Console.ReadLine().Replace(" ", "").ToLower();
            }
            string[] petsName = new string[0];
            if (hasPet == "да") petsName = GetArrayPetsName();

            Console.Write("Есть ли у вас любимый цвет (цвета)? Ответьте да/нет: ");
            string hasFavColors = Console.ReadLine().Replace(" ", "").ToLower();
            while (!IsCorrectBoolAnswer(hasFavColors))
            {
                Console.Write("Пожалуйста, повторно введите ответ (да/нет): ");
                hasFavColors = Console.ReadLine().Replace(" ", "").ToLower();
            }
            string[] favColors = new string[0];
            if (hasFavColors == "да") favColors = GetArrayFavColors();

            return (name, familyName, age, petsName, favColors);
        }
        static string CapitalizationName(string name)
        {
            string correctName = string.Empty;
            for (int i = 0; i < name.Length; i++)
            {
                if (i == 0) correctName += char.ToUpper(name[i]);
                else correctName += char.ToLower(name[i]);
            }
            return correctName;
        }
    }
}
