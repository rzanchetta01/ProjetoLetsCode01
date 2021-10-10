using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ProjetoLesCode01
{
    class Program
    {
        //tudo que fosse fazer tem que atraves de um unico menu --> 
        static void Main(string[] args)
        {

            Dictionary<int, ILojas> estabelecimentos = new();//Lista que armazena os estabelecimentos         
            Dictionary<int, Pessoa> pessoas = new();
            LojasIncial(estabelecimentos, pessoas);//Cria lojas default, inclusive a empresa aerea
            StartMenu(estabelecimentos, pessoas);//Menu iniciar do sistema


        }
        public static void LojasIncial(Dictionary<int, ILojas> estabelecimentos, Dictionary<int, Pessoa> pessoas)
        {
            ILojas ps = new LojaComum("Carro do perigo", "na entrada do shopping");
            ILojas fs = new FastFood("FoodFast", "na praça de alimentação");
            ILojas sf = new SelfService("ServiceSelf", "na praça de alimentação");

            Pessoa p = new Pessoa("r", 1000, true);

            ps.AddProduto("Air jordan duvidosos", 99, 11);
            ps.AddProduto("Disco vinil", 500, 33);
            ps.AddProduto("Gema do poder que o thanos queria", 99999.99, 666);

            fs.AddProduto("a", 25, 10);
            fs.AddProduto("Hamburguer quase bom", 15, 11);
            fs.AddProduto("HAmburguer da promoção do dia", 5, 12);
            fs.AddProduto("Refri free refil", 0, 13);

            sf.AddProduto("Arroz e feijão", 20, 11);
            sf.AddProduto("Carne", 20, 12);
            sf.AddProduto("Frango", 20, 13);
            sf.AddProduto("Bebibas genericas", 6, 14);

            estabelecimentos.Add(estabelecimentos.Count + 1, fs);
            estabelecimentos.Add(estabelecimentos.Count + 1, sf);
            estabelecimentos.Add(estabelecimentos.Count + 1, ps);
            pessoas.Add(pessoas.Count + 1,p);

        }

        public static void StartMenu(Dictionary<int, ILojas> estabelecimentos, Dictionary<int, Pessoa> pessoas)//Mostra o menu inicial do sistema
        {
            //Menu inicial
            Console.WriteLine("\nBem vindo ao sistema do shopping ");
            Console.WriteLine("1 para Registrar loja");
            Console.WriteLine("2 para Registrar pessoa");
            Console.WriteLine("3 para alterar um produto de uma loja existente");
            Console.WriteLine("4 para Simular um cliente");
            Console.WriteLine("9 para Sair");

            int option;//variavel que descide a movimentação do menu pelo codigo
            Int32.TryParse(Console.ReadLine(), out option);

            switch (option)
            {
                case 1:

                    AddLoja(estabelecimentos, pessoas);//Cria estabelecimentos novos
                    break;

                case 2:

                    AddCliente(estabelecimentos, pessoas);//Registra clientes novos
                    break;

                case 3:

                    AlteraDadosLoja(estabelecimentos, pessoas);//Altera o catalogo/cardapio da loja es questão
                    break;

                case 4:
                    Console.WriteLine("");

                    FazerCompra(estabelecimentos, pessoas);
                    Thread.Sleep(1000);
                    StartMenu(estabelecimentos, pessoas);//Caso digite um numero fora do menu, reinicia o processo
                    break;

                case 9:
                    Console.WriteLine("O segurança chega até você e pergunta:");
                    Console.Write("Segurança - ");
                    var x = SelectCliente(pessoas);

                    if (x.IsPassageiro)
                    {
                        BoaViagem(x);
                    }
                    else
                    {
                        Console.WriteLine("\nAchei que tivesse passagem");
                    }

                    Console.WriteLine("\nTchau Tchau");
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Numero incorreto");
                    Thread.Sleep(1000);
                    StartMenu(estabelecimentos, pessoas);//Caso digite um numero fora do menu, reinicia o processo
                    break;
            }
        }

        public static void AddLoja(Dictionary<int, ILojas> estabelecimentos, Dictionary<int, Pessoa> pessoas)//Função para adcionar estabelecimentos
        {

            string tipoLoja;
            string nomeLoja;
            string posShop;
            bool option;

            Console.WriteLine("\nQual o tipo de loja?");
            Console.WriteLine("Para voltar digite 0");
            Console.WriteLine("Temos disponivel para registro : FastFood, LojaComum e SelfService");
            tipoLoja = Console.ReadLine().ToUpper();//Le o tipo de loja e deixa tudo em caixa alta para evitar problemas

            if (tipoLoja == "FASTFOOD")//Criação de um futuro fastfood
            {

                Console.WriteLine("Criando um FastFood");
                nomeLoja = AuxAddLojaNome(estabelecimentos);
                posShop = AuxAddLojaPos(estabelecimentos);
                FastFood ff = new FastFood(nomeLoja, posShop);
                estabelecimentos.Add(estabelecimentos.Count + 1, ff);
                AddProduto(ff);

            }
            else if (tipoLoja == "LOJACOMUM")//criação de uma futura loja comum
            {

                Console.WriteLine("Criando uma LojaComum");
                nomeLoja = AuxAddLojaNome(estabelecimentos);
                posShop = AuxAddLojaPos(estabelecimentos);
                LojaComum lc = new LojaComum(nomeLoja, posShop);
                estabelecimentos.Add(estabelecimentos.Count + 1, lc);
                AddProduto(lc);

            }
            else if (tipoLoja == "SELFSERVICE")//Criação de um selfservice
            {

                Console.WriteLine("Criando um SelfService");
                nomeLoja = AuxAddLojaNome(estabelecimentos);
                posShop = AuxAddLojaPos(estabelecimentos);
                SelfService sf = new SelfService(nomeLoja, posShop);
                estabelecimentos.Add(estabelecimentos.Count + 1, sf);
                AddProduto(sf);

            }
            else if (tipoLoja == "0")//caso queira voltar ao menu incial
            {

                StartMenu(estabelecimentos, pessoas);

            }
            else
            {
                Console.WriteLine("Tipo de loja não encontrado, tente novamente");
                Thread.Sleep(1000);
                AddLoja(estabelecimentos, pessoas);//Repete o processo de digitar, caso digite algum tipo de loja errado
            }

            option = RepitirProcesso("\nDesejeita registrar outra loja?");//Descide se quer adicionar uma nova loja

            if (option)
            {
                Thread.Sleep(1000);
                AddLoja(estabelecimentos, pessoas);
            }
            else
            {
                Thread.Sleep(1000);
                StartMenu(estabelecimentos, pessoas);
            }

        }

        public static String AuxAddLojaNome(Dictionary<int, ILojas> estabelecimentos)//Função auxiliar do AddLoja
        {
            string nomeLoja;

            Console.Write("\nQual o nome da loja que você vai registrar? ");
            nomeLoja = Console.ReadLine();

            foreach (var e in estabelecimentos)//Verificação para saber se ja não existe uma loja com o nome que quer criar
            {
                if (e.Value.NomeLoja.ToUpper() == nomeLoja.ToUpper())
                {
                    Console.WriteLine("\nJa existe uma loja com esse nome tente novamente");
                    Thread.Sleep(1000);
                    AuxAddLojaNome(estabelecimentos);
                }
            }

            return nomeLoja;
        }

        public static String AuxAddLojaPos(Dictionary<int, ILojas> estabelecimentos)//Função auxiliar do AddLoja
        {

            int option;

            Console.Write("\nQual será o local onde a loja sera montada? ");
            Console.WriteLine("Temos\n1: Praça de Alimentação\n2:Corredores do shopping");
            Int32.TryParse(Console.ReadLine(), out option);

            if (option == 1)
            {
                return "Praça de alimentação";
            }
            else if (option == 2)
            {
                return "Corredores do shopping";
            }
            else //valida erros novamente
            {
                Console.WriteLine("Opção inválida, tente novamente");
                Thread.Sleep(500);
                return AuxAddLojaPos(estabelecimentos);
            }

        }

        public static bool RepitirProcesso(string msg)//Função para repitir todas as tomadas de descisão de sim ou não
        {
            string option;

            Console.WriteLine($"\n{msg} \nsim ou não");
            option = Console.ReadLine();
            Console.WriteLine("");
            if (option.ToUpper() == "SIM")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void AddCliente(Dictionary<int, ILojas> estabelecimentos, Dictionary<int, Pessoa> pessoas)//Registra novos clientes
        {
            Console.Write("\nQual o seu nome: ");
            string nome = Console.ReadLine();
            double saldoInicial;
            bool isPassageiro;
            Console.Write("\nQual o seu saldo para futuras compras? ");
            double.TryParse(Console.ReadLine(), out saldoInicial);

            isPassageiro = RepitirProcesso("\nVocê é um passageiro?");


            Pessoa p = new Pessoa(nome, saldoInicial, isPassageiro);
            pessoas.Add(pessoas.Count + 1,p);

            if (isPassageiro)
            {
                Console.WriteLine("Qual a sua bagagem\nDigite 0 para sair");
                Console.Write("Bagagem: ");
                String bag = Console.ReadLine();
                while (bag != "0")
                {
                    p.RegistrarBagagemInicial(bag);
                    Console.Write("Bagagem: ");
                    bag = Console.ReadLine();
                }

                Console.Write("\nNão esqueça de comprar sua passagem para conseguir ir embora\n");
            }

            Thread.Sleep(200);
            Console.WriteLine("Você foi registrado em nosso sistema");

            StartMenu(estabelecimentos, pessoas);
        }

        public static void AlteraDadosLoja(Dictionary<int, ILojas> estabelecimentos, Dictionary<int, Pessoa> pessoas)//Altera o catalogo/produto das lojas
        {
            Console.WriteLine("Qual loja deseja alterar os dados?");

            ILojas a = SelectEstabelecimento(estabelecimentos);

            Console.WriteLine("1 : Adicionar produto\n2 : Remover um produto");
            Int32.TryParse(Console.ReadLine(), out int escolha);
            if(escolha == 1)
            {
                AddProduto(a);
                Console.WriteLine("Produto adicionado com sucesso");
                Thread.Sleep(1000);
                StartMenu(estabelecimentos, pessoas);
            }
            else if(escolha == 2)
            {
                a.MostrarProduto();
                Console.WriteLine("\nQual produto deseja remover:");
                Int32.TryParse(Console.ReadLine(), out int auxRemover);

                if(a.Produtos.ContainsKey(auxRemover))
                {
                    a.Produtos.Remove(auxRemover);
                    Console.WriteLine("Produto removido com sucesso");
                    Thread.Sleep(1000);
                    StartMenu(estabelecimentos, pessoas);
                }
            }
            else
            {
                Console.WriteLine("\n Escolha inválida, tente novamente");
                AlteraDadosLoja(estabelecimentos, pessoas);
            }
        }

        public static Pessoa SelectCliente(Dictionary<int, Pessoa> pessoas)
        {
            Console.WriteLine("Quem você é?\n");

            foreach (var e in pessoas)
            {
                Console.WriteLine($"{e.Key} : {e.Value.NomePessoa}");
            }

            Console.WriteLine("");

            Int32.TryParse(Console.ReadLine(), out int selectPessoa);    
            
            if(pessoas.ContainsKey(selectPessoa))
            {
                return pessoas.Values.ElementAt(selectPessoa - 1);
            }
            else
            {
                Console.WriteLine("Cliente não econtrado, tente novamente");
                return SelectCliente(pessoas);
            }                      
        }

        public static ILojas SelectEstabelecimento(Dictionary<int, ILojas> estabelecimentos)
        {
            foreach (var e in estabelecimentos)
            {
                Console.WriteLine($"Loja {e.Key} : {e.Value.NomeLoja}");
            }

            Console.WriteLine("");

            Int32.TryParse(Console.ReadLine(), out int kLoja);

            if(estabelecimentos.ContainsKey(kLoja))
            {
                return estabelecimentos.Values.ElementAt(kLoja - 1);
            }
            else
            {
                Console.WriteLine("Loja não econtrada, tente novamente");
                Thread.Sleep(1000);
                return SelectEstabelecimento(estabelecimentos);
            }        
        }

        public static void FazerCompra(Dictionary<int, ILojas> estabelecimentos, Dictionary<int, Pessoa> pessoas)
        {
            Pessoa cliente = SelectCliente(pessoas);
            if (cliente.IsPassageiro)
            {
                if (RepitirProcesso("Deseja comprar sua passagem?"))
                {
                    cliente.ComprarPassagem(340, TAP());
                    Thread.Sleep(700);

                    if (!RepitirProcesso("quer continuar suas compras?"))
                    {
                        StartMenu(estabelecimentos, pessoas);
                    }
                }
            }


            ILojas loja = SelectEstabelecimento(estabelecimentos);

            double totalCompra = 0;
            totalCompra = loja.FazerVenda(0);

            cliente.ComprarProduto(totalCompra);
        }

        public static Voos TAP()
        {
            return new Voos("Passagens aereas", "na entrada do shopping");
        }

        public static void BoaViagem(Pessoa pessoa)
        {
            if (pessoa.HasPassagem)
            {
                Console.WriteLine("Qual o seu voo?");
                Console.Write("Para: ");
                String voo = "para " + Console.ReadLine();

                Random randNum = new Random();

                Console.WriteLine($"O seu voo {voo}, parte daqui {randNum.Next(2, 3)} horas");
                Console.WriteLine("Boa sorte esperando ");
            }
        }

        public static void AddProduto(ILojas estabelecimento)
        {
            Console.WriteLine("Quantos pratos deseja adicionar");
            Int32.TryParse(Console.ReadLine(), out int nProduto);

            for (int i = 1; i <= nProduto; i++)
            {
                Console.WriteLine($"Produto nº{i}");

                Console.Write("Nome: ");
                string nomePrato = Console.ReadLine();

                Console.Write("\nPreco: ");
                double.TryParse(Console.ReadLine(), out double precoPrato);

                Console.Write("\nId do produto: ");
                Int32.TryParse(Console.ReadLine(), out int idProduto);

                while (estabelecimento.Produtos.Keys.Contains(idProduto))
                {
                    Console.WriteLine("Ja existe um produto com essa id, tente novamente");
                    Console.Write("\nId do produto: ");
                    Int32.TryParse(Console.ReadLine(), out idProduto);
                }

                estabelecimento.AddProduto(nomePrato, precoPrato, idProduto);
            }
        }
    }
}

