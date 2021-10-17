using System;

namespace DIO.Bank
{
    public class Conta
    {
        private TipoConta tipoConta { get; set; }
        private TipoConta2 tipoConta2 { get; set; }
        private double Saldo { get; set; }
        private double LimiteConta { get; set; }
        private string Nome { get; set; }

        public Conta(TipoConta tipoConta, TipoConta2 tipoConta2, double Saldo, double LimiteConta, string Nome)
        {
            this.tipoConta = tipoConta;
            this.tipoConta2 = tipoConta2;
            this.Saldo = Saldo;
            this.LimiteConta = LimiteConta;
            this.Nome = Nome; 
        }

        public bool Sacar(double valorSaque)
        {
            // Validação de saldo suficiente
            if (this.Saldo - valorSaque < (this.LimiteConta * -1)){
                Console.WriteLine("Saldo Insuficiente!");
                return false;
            }

            this.Saldo -= valorSaque;
            
            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);

            return true;
        }

        public void Depositar(double valorDeposito)
        {
            this.Saldo += valorDeposito;

            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
        }
        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if (this.Sacar(valorTransferencia)){
                contaDestino.Depositar(valorTransferencia);
            }            
        }
                
        public override string ToString()
        {
            string retorno = "";
            retorno += "TipoConta " + this.tipoConta + " | ";
            retorno += "" + this.tipoConta2 + " | ";
            retorno += "Nome " + this.Nome + " | ";
            retorno += "Saldo " + this.Saldo + " | ";
            retorno += "Limite da conta " + this.LimiteConta;
            return retorno;
        }
        
    }
}