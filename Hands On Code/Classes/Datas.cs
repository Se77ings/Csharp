using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datas
{
    public class Datas
    {

        public void LidandoComDatas()
        {
            var data1 = new DateTime(2025, 01, 03, 14, 05, 00);
            var data2 = DateTime.Parse("2022/10/01 19:20:00");
            var data3 = DateTime.Now;
            //Console.WriteLine(data1);
            //Console.WriteLine(data2);
            //Console.WriteLine(data3.ToString("MMM / yyyy"));

            var dateTimeOffset = new DateTimeOffset(DateTime.Now, new TimeSpan(-3, 0, 0));
            Console.WriteLine(dateTimeOffset.LocalDateTime);
            Console.WriteLine(dateTimeOffset.UtcDateTime);


            Console.Write(data1 - data2);
        }

        public void SubtraindoDatas()
        {
            var hoje = DateTime.Now;
            var inicioAno = DateTime.Parse("2025,01,01");

            var diff = hoje - inicioAno;
            Console.WriteLine("Total dias -> "+diff.TotalDays);
            Console.WriteLine("Total Horas -> "+diff.TotalHours);
            Console.WriteLine("Dia da semana: "+ hoje.DayOfWeek);
            Console.WriteLine(hoje.Subtract(inicioAno));




        }
    }
}
