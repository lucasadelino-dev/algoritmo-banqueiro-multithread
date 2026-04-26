using System;
using System.Threading;

class Program
{
    const int NUMBER_OF_CUSTOMERS = 5;

    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Uso: dotnet run -- 10 5 7");
            return;
        }

        int[] recursos = new int[args.Length];

        for (int i = 0; i < args.Length; i++)
        {
            recursos[i] = int.Parse(args[i]);
        }

        Banco banco = new Banco(NUMBER_OF_CUSTOMERS, recursos);

        banco.MostrarEstado();

        Thread[] threads = new Thread[NUMBER_OF_CUSTOMERS];

        for (int i = 0; i < NUMBER_OF_CUSTOMERS; i++)
        {
            int id = i;

            threads[i] = new Thread(() =>
            {
                Cliente cliente = new Cliente(id, banco);
                cliente.Executar();
            });

            threads[i].Start();
        }

        foreach (Thread thread in threads)
        {
            thread.Join();
        }
    }
}