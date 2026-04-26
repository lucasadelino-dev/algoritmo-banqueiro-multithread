using System;

public class Banco
{
    private int numeroClientes;
    private int numeroRecursos;

    private int[] available;
    private int[,] maximum;
    private int[,] allocation;
    private int[,] need;

    private object trava = new object();

    public Banco(int numeroClientes, int[] recursosDisponiveis)
    {
        this.numeroClientes = numeroClientes;
        this.numeroRecursos = recursosDisponiveis.Length;

        available = new int[numeroRecursos];
        maximum = new int[numeroClientes, numeroRecursos];
        allocation = new int[numeroClientes, numeroRecursos];
        need = new int[numeroClientes, numeroRecursos];

        Array.Copy(recursosDisponiveis, available, numeroRecursos);

        InicializarMaximum();
        InicializarNeed();
    }

    private void InicializarMaximum()
    {
        Random random = new Random();

        for (int i = 0; i < numeroClientes; i++)
        {
            for (int j = 0; j < numeroRecursos; j++)
            {
                maximum[i, j] = random.Next(1, available[j] + 1);
            }
        }
    }

    private void InicializarNeed()
    {
        for (int i = 0; i < numeroClientes; i++)
        {
            for (int j = 0; j < numeroRecursos; j++)
            {
                need[i, j] = maximum[i, j];
            }
        }
    }

    public void MostrarEstado()
    {
        Console.WriteLine("Recursos disponíveis:");

        for (int i = 0; i < numeroRecursos; i++)
        {
            Console.Write(available[i] + " ");
        }

        Console.WriteLine();
    }

    public int ReleaseResources(int cliente, int[] release)
    {
        lock (trava)
        {
            for (int i = 0; i < numeroRecursos; i++)
            {
                if (release[i] > allocation[cliente, i])
                {
                    return -1;
                }
            }

            for (int i = 0; i < numeroRecursos; i++)
            {
                allocation[cliente, i] -= release[i];
                available[i] += release[i];
                need[cliente, i] += release[i];
            }

            Console.WriteLine($"Cliente {cliente} liberou recursos.");

            return 0;
        }
    }

    private bool IsSafe()
    {
        int[] work = new int[numeroRecursos];
        bool[] finish = new bool[numeroClientes];

        for (int i = 0; i < numeroRecursos; i++)
        {
            work[i] = available[i];
        }

        bool encontrou;

        do
        {
            encontrou = false;

            for (int i = 0; i < numeroClientes; i++)
            {
                if (!finish[i])
                {
                    bool podeExecutar = true;

                    for (int j = 0; j < numeroRecursos; j++)
                    {
                        if (need[i, j] > work[j])
                        {
                            podeExecutar = false;
                            break;
                        }
                    }

                    if (podeExecutar)
                    {
                        for (int j = 0; j < numeroRecursos; j++)
                        {
                            work[j] += allocation[i, j];
                        }

                        finish[i] = true;
                        encontrou = true;
                    }
                }
            }

        } while (encontrou);

        for (int i = 0; i < numeroClientes; i++)
        {
            if (!finish[i])
            {
                return false;
            }
        }

        return true;
    }

    public int RequestResources(int cliente, int[] request)
    {
        lock (trava)
        {
            for (int i = 0; i < numeroRecursos; i++)
            {
                if (request[i] > need[cliente, i])
                {
                    return -1;
                }
    
                if (request[i] > available[i])
                {
                    return -1;
                }
            }
    
            for (int i = 0; i < numeroRecursos; i++)
            {
                available[i] -= request[i];
                allocation[cliente, i] += request[i];
                need[cliente, i] -= request[i];
            }
    
            if (IsSafe())
            {
                Console.WriteLine($"Cliente {cliente} recebeu recursos.");
                return 0;
            }
    
            for (int i = 0; i < numeroRecursos; i++)
            {
                available[i] += request[i];
                allocation[cliente, i] -= request[i];
                need[cliente, i] += request[i];
            }
    
            Console.WriteLine($"Cliente {cliente} teve pedido negado.");
    
            return -1;
        }
    }
}