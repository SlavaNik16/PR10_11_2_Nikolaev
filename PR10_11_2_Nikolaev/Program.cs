using System;
using System.Collections;
using System.Linq;

namespace PR10_11_2_Nikolaev
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            ArrayList fio = new ArrayList();
            fio.AddRange(new string[] {"Аидов Иван", "Андреев Петр", "Иванов Ирина","Николай Виктор"});
            ArrayList job = new ArrayList();
            job.AddRange(new string[] { "пекарник", "пондитор", "тестомес","пекарник" });
            ArrayList salary = new ArrayList();
            salary.AddRange(new uint[] { 25000,15783, 47342,12434});
            ArrayList exp = new ArrayList();
            exp.AddRange(new int[] { 9, 3,6,1});
            ArrayList kod = new ArrayList();
            kod.AddRange(new string[] { "AU111", "AU222", "AU333","AU444"});

            string output = "\tКод\tФИО\t\tДолжность\tОклад\t\tСтаж(г.)";
            Console.WriteLine($"Текущее содержимое списка сотрудников: \n\r");
            Console.WriteLine(output); ;
            for (int i =0; i < fio.Count; i++)
            {
                Console.WriteLine($"\t{kod[i]}\t{fio[i]}\t{job[i]}\t{salary[i]:C2}\t{exp[i]}"); ;
            }
            Console.Write("Обратный порядок: \n\r");
            Console.WriteLine(output); 
            for (int i = fio.Count - 1; i >= 0; i--)
            {
                Console.WriteLine($"\t{kod[i]}\t{fio[i]}\t{job[i]}\t{salary[i]:C2}\t{exp[i]}"); ;
            }
            Console.WriteLine("Выберите действие: \n\r1)Добавить пользователя\n\r2)Удалиить пользователя\n\r3)Найти по должности");
           
            var allsal = 0m;
            foreach (var c in kod)
            {
                var index = kod.IndexOf(c);
                allsal += decimal.Parse(salary[index].ToString());
            }
            var avg = allsal / salary.Count;
            Console.Write($"Найти человека у которого оклад выше {avg:C2} и со стажем < 5: ");
            int s = 0;
            foreach (var c in kod)
            {
                if (decimal.Parse(salary[s].ToString()) > avg && decimal.Parse(exp[s].ToString()) < 5)
                {
                    Console.WriteLine($"\t{kod[s]}\t{fio[s]}\t{job[s]}\t{salary[s]:C2}\t{exp[s]}"); ;
                }
                s++;
            }

            Console.Write("Добавление пользователя!\n\r");
            int kods = 5;
            Console.Write("FIO: ");
            fio.Add(Console.ReadLine());
            Console.Write($"Должность: ");
            job.Add(Console.ReadLine().ToLower());
            Console.Write($"Оклад: ");
            salary.Add(int.TryParse(Console.ReadLine(), out int num2) ? num2 : 0);
            Console.Write($"Стаж: ");
            exp.Add(int.TryParse(Console.ReadLine(),out int num) ? num : 0);
            kod.Add($"AU{kods * 111}");
            kods++;
            Console.WriteLine(output); ;
            for (int i = 0; i < kod.Count; i++)
            {
                Console.WriteLine($"\t{kod[i]}\t{fio[i]}\t{job[i]}\t{salary[i]:C2}\t{exp[i]}"); ;
            }
           
            Console.Write("\nВведите должность: ");
            string dol = Console.ReadLine().ToLower();
            int q = 0;
            foreach(var c in job)
            {
                if (dol.Equals(c))
                {
                    Console.WriteLine($"\t{kod[q]}\t{fio[q]}\t{job[q]}\t{salary[q]:C2}\t{exp[q]}"); ;
                }
                q++;
            }
            Console.Write("\nВвeдите код сотрудника, которого вы хотите уволить: ");
            string k = Console.ReadLine();
            int count = kod.Count;
            foreach (var c in kod)
            {
                if (k.Equals(c))
                {
                    int ud = kod.IndexOf(k);
                    Console.WriteLine($"Вы удалили сотрудника в списке: {fio[ud]} {kod[ud]}");
                    kod.RemoveAt(ud);
                    fio.RemoveAt(ud);
                    salary.RemoveAt(ud);
                    job.RemoveAt(ud);
                    exp.RemoveAt(ud);
                    break;
                }   
            }
            if (count == kod.Count)
            {
                Console.Write("Такого сотрудника не существует: \n\r");
            }

            Console.WriteLine(output); ;
            for (int i = 0; i < kod.Count; i++)
            {
                Console.WriteLine($"\t{kod[i]}\t{fio[i]}\t{job[i]}\t{salary[i]:C2}\t{exp[i]}"); ;
            }
        }
    }
}
