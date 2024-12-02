using System;

namespace MultipleInheritanceExample
{
    // Первый интерфейс сравнения по тарифному плану
    public interface ICompareByPlan
    {
        int Compare(MobileService other);
    }

    // Второй интерфейс сравнения по использованию услуг
    public interface ICompareByUsageSMS
    {
        int Compare(MobileService other);
    }

    public class MobileService : ICompareByPlan, ICompareByUsageSMS
    {
        private string TariffPlan;
        private double LocalCallMinutes;
        private double LongDistanceCallMinutes;
        private double SmsPayment;
        private double InternetUsage;

        public MobileService(string tariffPlan, double localCallMinutes, double longDistanceCallMinutes, double smsPayment, double internetUsage)
        {
            TariffPlan = tariffPlan;
            LocalCallMinutes = localCallMinutes;
            LongDistanceCallMinutes = longDistanceCallMinutes;
            SmsPayment = smsPayment;
            InternetUsage = internetUsage;
        }

        // Метод сравнения по названию тарифа
        int ICompareByPlan.Compare(MobileService other)
        {
            int result = string.Compare(this.TariffPlan, other.TariffPlan, StringComparison.Ordinal);

            if (result > 0)
            {
                Console.WriteLine($"Тариф \"{this.TariffPlan}\" преобладает над тарифом \"{other.TariffPlan}\" по первой букве в Unicode на {result} позиций.");
            }
            else if (result < 0)
            {
                Console.WriteLine($"Тариф \"{this.TariffPlan}\" имеет меньшее место, чем тариф \"{other.TariffPlan}\" по первой букве в Unicode на {result} позиций.");
            }
            else
            {
                Console.WriteLine($"Позиции главных букв в Unicode одинаковые.");
            }

            return result;
        }

        // Метод сравнения по использованию услуг
        int ICompareByUsageSMS.Compare(MobileService other)
        {
            double SMSUsage = this.SmsPayment;
            double OtherSMSUsage = other.SmsPayment;

            int result = SMSUsage.CompareTo(OtherSMSUsage);

            if (result > 0)
            {
                Console.WriteLine($"Тариф - \"{this.TariffPlan}\" имеет {SMSUsage} смс больше, чем \"{other.TariffPlan}\" - {OtherSMSUsage}.");
            }
            else if (result < 0)
            {
                Console.WriteLine($"Тариф - \"{this.TariffPlan}\" имеет {SMSUsage} смс меньше, чем \"{other.TariffPlan}\" - {OtherSMSUsage}.");
            }
            else
            {
                Console.WriteLine($"Тарифы смс равны.");
            }

            return result;
        }

        public override string ToString()
        {
            return $"Тариф: {TariffPlan}, Местные звонки: {LocalCallMinutes} мин, Межгород: {LongDistanceCallMinutes} мин, SMS: {SmsPayment} кол-во, Интернет: {InternetUsage} ГБ";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MobileService tarif1 = new MobileService("Эконом", 100, 50, 200, 5);
            MobileService tarif2 = new MobileService("Премиум", 200, 100, 150, 10);
            MobileService tarif3 = new MobileService("Эконом", 80, 30, 250, 2);

            ICompareByPlan comparerByPlan = tarif1;
            Console.WriteLine($"Сравнение tarif1 и tarif2 по тарифу:");
            comparerByPlan.Compare(tarif2);

            // Сравнение по использованию услуг
            ICompareByUsageSMS comparerByUsage = tarif1;
            Console.WriteLine($"\nСравнение tarif1 и tarif3 по использованию:");
            comparerByUsage.Compare(tarif3);

            Console.WriteLine("\nВсе услуги:");
            Console.WriteLine(tarif1);
            Console.WriteLine(tarif2);
            Console.WriteLine(tarif3);
        }
    }
}
