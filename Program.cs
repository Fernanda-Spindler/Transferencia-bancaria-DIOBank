using System;
using System.Collections.Generic;

namespace DIO.Bank
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "6")
                {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    
                    default:
                        throw new ArgumentOutOfRangeException();
                }
               
                opcaoUsuario = ObterOpcaoUsuario();

                
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();
        }
        
        private static void Transferir()
        {
            if (listContas.Count <= 1)
            {
                Console.WriteLine("Não é possível fazer a transferência, pois não há contas suficientes cadastradas.");
                return;
            }

            Console.Write("Digite o número da conta de origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Digite o número da conta de destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser transferido: ");
            double valorTransferencia = int.Parse(Console.ReadLine());

            listContas[indiceContaOrigem].Transferir(valorTransferencia, listContas[indiceContaDestino]);
        }

        private static void Sacar()
        {
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser sacado: ");
            double valorSaque = int.Parse(Console.ReadLine());

            listContas[indiceConta].Sacar(valorSaque);
        }

        private static void Depositar()
        {
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser depositado: ");
            double valorDeposito = int.Parse(Console.ReadLine());

            listContas[indiceConta].Depositar(valorDeposito);
        }

        private static void InserirConta()
        {
            Console.WriteLine("Inserir nova conta");

            Console.Write("Digite 1 para conta Física ou 2 para Jurídica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());
                while (entradaTipoConta != 1 && entradaTipoConta !=2){
                
                Console.WriteLine("Digite uma opção válida: 1 ou 2");
                entradaTipoConta = int.Parse(Console.ReadLine());

                }
                       

            Console.Write("Digite 1 para Conta Corrente ou 2 para Poupança: ");
            int entradaTipoConta2 = int.Parse(Console.ReadLine());
                while (entradaTipoConta2 != 1 && entradaTipoConta2 !=2){
                
                entradaTipoConta2 = 1;
                Console.WriteLine("Digite uma opção válida: 1 ou 2");
                entradaTipoConta2 = int.Parse(Console.ReadLine());
            
                }


            Console.Write("Digite o nome do cliente: ");
            string entradaNome = Console.ReadLine();

            Console.Write("Digite o saldo inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.Write("Digite o limite da conta: ");
            double entradaLimiteConta = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta (tipoConta: (TipoConta)entradaTipoConta,
                                         tipoConta2: (TipoConta2)entradaTipoConta2,
                                         Saldo: entradaSaldo,
                                         LimiteConta: entradaLimiteConta,
                                         Nome: entradaNome);                         
            
            listContas.Add(novaConta);         
        }

        private static void ListarContas()
        {
            Console.WriteLine("Listar Contas");      

            if (listContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada.");
                return;
            }
            for (int i = 0; i < listContas.Count; i++)
            {
                Conta conta = listContas[i];
                Console.Write("#{0} - ", i);
                Console.WriteLine(conta);
            }
        }
        
        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Bank a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1 - Listar contas");
            Console.WriteLine("2 - Inserir nova conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("6 - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
