# Algoritmo do Banqueiro com Multithreading

Trabalho acadêmico da disciplina de Sistemas Operacionais (PUC Betim), com implementação do Algoritmo do Banqueiro em C# usando múltiplas threads e exclusão mútua.

## Identificação

- Curso: Sistemas de Informação (3º período)
- Ano: 2026
- Professor: Lucas Braganca
- Alunos:
  - Bernardo Maia Lomas
  - Lucas Gabriel Adelino Araujo

## Objetivo

Simular um banco que gerencia requisições e liberações  de recursos por clientes concorrentes, aceitando pedidos apenas quando o estado do sistema permanece seguro.

## O que foi implementado

- 5 clientes executando concorrentemente em threads.
- Vetores/matrizes classicos do algoritmo: `available`, `maximum`, `allocation` e `need`.
- Operações de requisição e liberação de recursos.
- Verificação de seguranca (estado seguro/inseguro) antes de conceder requisições.
- Uso de `lock` (mutex) para evitar condições de corrida no acesso aos dados compartilhados.

## Como compilar e executar

Pre-requisito: .NET SDK 9.0.

No terminal, na raiz do projeto:

```bash
dotnet run --project AlgoritmoDoBanqueiro -- 10 5 7
```

Os valores após `--` representam a quantidade inicial de cada tipo de recurso (exemplo com 3 tipos).

## Resultado

O programa demonstra, na prática, os conceitos de concorrência, sincronização e prevenção de deadlock, aplicando o Algoritmo do Banqueiro para manter o sistema em estado seguro durante a execução.

## Referência

SILBERSCHATZ, Abraham; GALVIN, Peter B.; GAGNE, Greg. Fundamentos de Sistemas Operacionais. 9. ed. Rio de Janeiro: LTC, 2015.
