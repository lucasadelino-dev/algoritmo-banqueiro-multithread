# Algoritmo do Banqueiro com Multithreading

Trabalho acadêmico da disciplina de Sistemas Operacionais (PUC Betim), com implementação do Algoritmo do Banqueiro em C# usando múltiplas threads e exclusão mútua.

## Identificação

- Curso: Sistemas de Informação (3o período)
- Ano: 2026
- Professor: Lucas Braganca
- Alunos:
  - Bernardo Maia Lomas
  - Lucas Gabriel Adelino Araujo

## Objetivo

Simular um banco que gerencia requisicoes e liberacoes de recursos por clientes concorrentes, aceitando pedidos apenas quando o estado do sistema permanece seguro.

## O que foi implementado

- 5 clientes executando concorrentemente em threads.
- Vetores/matrizes classicos do algoritmo: `available`, `maximum`, `allocation` e `need`.
- Operacoes de requisicao e liberacao de recursos.
- Verificacao de seguranca (estado seguro/inseguro) antes de conceder requisicoes.
- Uso de `lock` (mutex) para evitar condicoes de corrida no acesso aos dados compartilhados.

## Como compilar e executar

Pre-requisito: .NET SDK 9.0.

No terminal, na raiz do projeto:

```bash
dotnet run --project AlgoritmoDoBanqueiro -- 10 5 7
```

Os valores apos `--` representam a quantidade inicial de cada tipo de recurso (exemplo com 3 tipos).

## Resultado

O programa demonstra, na pratica, os conceitos de concorrencia, sincronizacao e prevencao de deadlock, aplicando o Algoritmo do Banqueiro para manter o sistema em estado seguro durante a execucao.

## Referencia

SILBERSCHATZ, Abraham; GALVIN, Peter B.; GAGNE, Greg. Fundamentos de Sistemas Operacionais. 9. ed. Rio de Janeiro: LTC, 2015.
