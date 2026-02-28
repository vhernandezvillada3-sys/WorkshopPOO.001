using WorkshopPOO_01.Backend;

namespace WorkshopPOO_01.Frontend
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Crear las 5 horas
                Time t1 = new Time(23, 58, 34, 666);
                Time t2 = new Time(12, 0, 0, 0);
                Time t3 = new Time(5, 30, 0, 0);
                Time t4 = new Time(0, 0, 0, 1);
                Time t5 = new Time(15, 45, 23, 456);

                Time[] times = { t1, t2, t3, t4, t5 };

                Console.WriteLine("HORAS CREADAS:");
                foreach (Time t in times)
                {
                    Console.WriteLine($"Time: {t}");
                }

                Console.WriteLine("\n" + new string('=', 50) + "\n");
                Console.WriteLine("SUMANDO t3 A CADA HORA:");

                foreach (Time t in times)
                {
                    Time resultado = t.Add(t3);
                    Console.WriteLine($"{t} + {t3} = {resultado}");
                }

                Console.WriteLine("\n" + new string('=', 50) + "\n");
                Console.WriteLine("¿PASA AL OTRO DÍA? (con t4):");

                foreach (Time t in times)
                {
                    bool pasaOtroDia = t.IsOtherDay(t4);
                    Console.WriteLine($"{t} + {t4} = {(pasaOtroDia ? "Sí" : "No")} pasa al otro día");
                }

                Console.WriteLine("\n" + new string('=', 50) + "\n");
                Console.WriteLine("PRESIONE CUALQUIER TECLA PARA SALIR...");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.ReadKey();
            }
        }
    }
}