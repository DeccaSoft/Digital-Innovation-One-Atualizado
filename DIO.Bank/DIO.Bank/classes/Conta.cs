using System;

namespace DIO.Bank.conta
{
    public class Conta
    {
        private TipoConta TipoConta {get; set;}
        private double Saldo {get; set;}
        private double Credito {get; set;}
        private string Nome{ get; set;}

        public Conta(TipoConta tipoConta, string nome, double saldo, double credito )
        {
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        }

        public bool Sacar(double valorSaque)
        {
            if((this.Saldo - valorSaque) < (this.Credito * -1))
            {
                Console.WriteLine("|==========================|");
                Console.WriteLine("|  Saldo Insuficiente !!!  |");
                Console.WriteLine("|==========================|");
                return false;
            }
            this.Saldo -= valorSaque;
            Console.WriteLine("|---------------------------------------------------|");
            Console.WriteLine("Olá {0}, seu Saldo Atual é {1}", this.Nome, this.Saldo);
            Console.WriteLine("|---------------------------------------------------|");
            Console.WriteLine();
            return true;
        }

        public void Depositar(double valorDeposito)
        {
            this.Saldo += valorDeposito;
            Console.WriteLine("|---------------------------------------------------|");
            Console.WriteLine("Olá {0}, seu Saldo Atual é {1}", this.Nome, this.Saldo);
            Console.WriteLine("|---------------------------------------------------|");
            Console.WriteLine();
        }

        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if (this.Sacar(valorTransferencia))
            {
                contaDestino.Depositar(valorTransferencia);
            }
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "TipoConta " + this.TipoConta + " | ";
            retorno += "Nome " + this.Nome + " | ";
            retorno += "Saldo " + this.Saldo + " | ";
            retorno += "Cédito " + this.Credito;
            return retorno;
        }
    }

}