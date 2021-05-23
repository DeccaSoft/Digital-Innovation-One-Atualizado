using System;
using System.Collections.Generic;
using DIO.Bank.conta;

namespace DIO.Bank
{
    class Program
    {
        static List<Conta> listaContas = new List<Conta>();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();
            while(opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1": ListarContas(); break;
                    case "2": InserirContas(); break;
                    case "3": Transferir(); break;
                    case "4": Sacar(); break;
                    case "5": Depositar(); break;
                    case "C": Console.Clear(); break;
                    default: throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("| Obrigado e até a próxima |");
            Console.ReadLine();
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine("|========== MENU ==========|");
            Console.WriteLine("|--------------------------|");
            Console.WriteLine("|    Digitte sua Opção:    |");
            Console.WriteLine("|--------------------------|");
            Console.WriteLine("|- 1 - Listar Contas..... -|");
            Console.WriteLine("|- 2 - Inserir nova Conta -|");
            Console.WriteLine("|- 3 - Transferirências.. -|");
            Console.WriteLine("|- 4 - Saques............ -|");
            Console.WriteLine("|- 5 - Depósitos......... -|");
            Console.WriteLine("|- C - Limpar Tela....... -|");
            Console.WriteLine("|- X - Sair.............. -|");
            Console.WriteLine("|==========================|");
            Console.WriteLine();
            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }

        private static void InserirContas()
        {
            Console.WriteLine("|========== MENU ==========|");
            Console.WriteLine("|--------------------------|");
            Console.WriteLine("|    Digitte sua Opção:    |");
            Console.WriteLine("|--------------------------|");
            Console.WriteLine("|- 1 - Pessoa Física..... -|");
            Console.WriteLine("|- 2 - Pessoa Jurídica... -|");
            Console.WriteLine("|==========================|");
            Console.WriteLine();
            int entradaTipoConta = int.Parse(Console.ReadLine());
            Console.WriteLine("| Digite o Nome do Cliente |");
            string entradaNome = Console.ReadLine();
            Console.WriteLine("| Digite o Saldo Inicial.. |");
            double entradaSaldo = double.Parse(Console.ReadLine());
            Console.WriteLine("| Digite o Crédito........ |");
            double entradaCredito = double.Parse(Console.ReadLine());
            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta, nome: entradaNome, saldo: entradaSaldo, credito: entradaCredito);
            listaContas.Add(novaConta);
            Console.WriteLine("|Sucesso: Conta Adicionada |");
            Console.WriteLine("|==========================|");
        }

        private static void ListarContas()
        {
            Console.WriteLine("|--- Listagem de Contas ---|");
            Console.WriteLine();
            if (listaContas.Count == 0)
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("| Nenhuma Conta Cadastrada |");
                Console.WriteLine("|==========================|");
                Console.WriteLine();
                Console.WriteLine();
                return;
            }
            for (int i = 0; i < listaContas.Count; i++)
            {
                Conta conta = listaContas[i];
                Console.WriteLine("#{0} - ", i);
                Console.WriteLine(conta);
                Console.WriteLine();
                Console.WriteLine("|------------------------------------------------------------------------------------------------|");
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("|==========================|");
            Console.WriteLine();
        }

        private static void Sacar()
        {
            Console.WriteLine("|--------- Saque ----------|");
            Console.WriteLine("| Digite o Número da Conta |");
            int indiceConta = int.Parse(Console.ReadLine());
            Console.WriteLine("| Qual o Valor do Saque??? |");
            double valorSacado = double.Parse(Console.ReadLine());
            listaContas[indiceConta].Sacar(valorSacado);
            Console.WriteLine("|==========================|");
            Console.WriteLine("|==========================|");
        }

        private static void Depositar()
        {
            Console.WriteLine("|------- Depositar --------|");
            Console.WriteLine("| Digite o Número da Conta |");
            int indiceConta = int.Parse(Console.ReadLine());
            Console.WriteLine("| Qual Valor é o Depósito? |");
            double valorDepositado = double.Parse(Console.ReadLine());
            listaContas[indiceConta].Depositar(valorDepositado);
            Console.WriteLine("|==========================|");
            Console.WriteLine("|==========================|");
        }


        private static void Transferir()
        {
            Console.WriteLine("|------- Transferir -------|");
            Console.WriteLine("| Digite a Conta de Origem |");
            int indiceContaOrigem = int.Parse(Console.ReadLine());
            Console.WriteLine("| Digite Conta de Destino  |");
            int indiceContaDestino = int.Parse(Console.ReadLine());
            Console.WriteLine("| Qual o Valor Transferido |");
            double valorTransferido = double.Parse(Console.ReadLine());
            listaContas[indiceContaOrigem].Transferir(valorTransferido, listaContas[indiceContaDestino]);
            Console.WriteLine("|==========================|");
            Console.WriteLine("|==========================|");
        }
    }
}
