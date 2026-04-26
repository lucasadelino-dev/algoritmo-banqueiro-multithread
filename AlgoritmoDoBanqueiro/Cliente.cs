using System;
using System.Threading;

public class Cliente
{
    private int id;
    private Banco banco;
    private Random random;

    public Cliente(int id, Banco banco)
    {
        this.id = id;
        this.banco = banco;
        random = new Random(Guid.NewGuid().GetHashCode());
    }

    public void Executar()
    {
        while (true)
        {
            Thread.Sleep(random.Next(1000, 3000));

            int[] request = GerarValoresAleatorios();
            banco.RequestResources(id, request);

            Thread.Sleep(random.Next(1000, 3000));

            int[] release = GerarValoresAleatorios();
            banco.ReleaseResources(id, release);
        }
    }

    private int[] GerarValoresAleatorios()
    {
        int quantidade = banco.NumeroRecursos();
        int[] valores = new int[quantidade];

        for (int i = 0; i < quantidade; i++)
        {
            valores[i] = random.Next(0, 3);
        }

        return valores;
    }
}