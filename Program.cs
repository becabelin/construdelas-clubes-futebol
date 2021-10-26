using System;
using System.Collections.Generic;
using System.Threading;

namespace Clubes_Futebol
{
    public class Program
    {
        static List<Clube> clubesCadastrados = new List<Clube>();
        public static void Main(string[] args)
        {

            /** Flávio Augusto da Silva criou um estádio de futebol, ele precisa armezenar o resultado
            *   dos jogos no telão do campo de futebol.
            *   faça um programa que cadastre alguns clubes (Nome) de futebol
            *   depois crie um menu para possibilitar a criação de um jogo, selecionando
            *   dois times diferentes e colocando o valor do resultado do jogo, exemplo
            *   Flamengo (x) vs (y) Corinthians
            *   mostre um relatório com a lista de resultados das combinações entre os times.
            **/

            List<Jogo> jogos = new List<Jogo>(); //cria uma lista de jogos

            Console.WriteLine("\nBem-vindo ao Estádio Flávio Augusto da Silva!");
            while (true)
            {
                Console.Clear(); //aqui é o menu principal, onde o usuário escolhe o que quer fazer
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("1 - Cadastrar clube");
                Console.WriteLine("2 - Cadastrar Jogo");
                Console.WriteLine("3 - Listar jogos cadastrados");
                Console.WriteLine("0 - Sair do programa");

                try
                {
                    int opcao = Convert.ToInt16("0" + Console.ReadLine()); //usuário digita o número que quer

                    switch (opcao)
                    {
                        case 1:
                            clubesCadastrados.Add(cadastroClube()); //ele vai para a parte de cadastrar um clube
                            break;
                        case 2:
                            jogos.Add(cadastrarJogo()); //ele vai cadastrar um jogo
                            break;
                        case 3:
                            listarJogos(jogos); //lista todos os jogos que já foram cadastrados
                            break;
                        case 0:
                            return; //caso ele clique em 0, volta para o menu
                        default:
                            Console.Clear(); //se ele digitar um número que não está no menu, dá erro
                            Console.WriteLine("Opção inválida");
                            Thread.Sleep(5000); // 5 segundos
                            break;
                    }
                }
                catch (Exception err)
                {
                    Console.Clear();
                    Console.WriteLine(err.Message);
                    Thread.Sleep(5000); // 5 segundos
                    continue;
                }
                static void listarJogos(List<Jogo> jogos)
                {
                    Console.Clear();
                    if (jogos.Count == 0) //se o número de jogos cadastrados for igual a 0
                        Console.WriteLine("Nenhum jogo cadastrado");
                    else
                    {
                        foreach (var jogo in jogos) //para cada jogo em jogos, fazer:
                        {
                            Console.WriteLine($"{jogo.Time1.Nome} ({jogo.ResultadoTime1}) vs ({jogo.ResultadoTime2}) {jogo.Time2.Nome}");
                            Console.WriteLine("-------------------------------"); //aparece o time e a pontuação
                            Console.WriteLine(jogo.Vencedor());
                        }
                    }

                    Thread.Sleep(5000); // 5 segundos
                }
                static Jogo cadastrarJogo() //aqui dá para cadastrar um jogo
                {
                    var jogo = new Jogo();
                    Console.Clear();
                    Console.WriteLine("Para cadastrar o primeiro time do jogo, selecione um clube abaixo:");
                    if (!mostrarClubes()) throw new Exception("Não existe clubes cadastrados"); //se ele não tiver cadastrado nenhum clube, aparece isso
                    int idClube1 = Convert.ToInt16("0" + Console.ReadLine());
                    jogo.Time1 = clubesCadastrados.Find(c => c.Id == idClube1);
                    if (jogo.Time1 == null) throw new Exception("ID do Clube digitado não existe"); //se errar o ID do clube

                    Console.Clear();
                    Console.WriteLine("Para cadastrar o segundo time do jogo, selecione um clube abaixo:");
                    if (!mostrarClubes()) throw new Exception("Não existe clubes cadastrados");
                    int idClube2 = Convert.ToInt16("0" + Console.ReadLine());
                    jogo.Time2 = clubesCadastrados.Find(c => c.Id == idClube2);
                    if (jogo.Time2 == null) throw new Exception("ID do Clube digitado não existe");

                    Console.WriteLine($"Digite o resultado do {jogo.Time1.Nome}:");
                    jogo.ResultadoTime1 = Convert.ToInt16("0" + Console.ReadLine());

                    Console.WriteLine($"Digite o resultado do {jogo.Time2.Nome}:");
                    jogo.ResultadoTime2 = Convert.ToInt16("0" + Console.ReadLine());

                    Console.Clear();
                    Console.WriteLine($"Jogo foi cadastrado com sucesso !"); //depois de cadastrar os dois times
                    Thread.Sleep(1000); // 1 segundo
                    return jogo;
                }

                static bool mostrarClubes()
                {
                    if (clubesCadastrados.Count == 0)
                    {
                        Console.WriteLine("Nenhum clube cadastrado cadastrado"); //se ele não tiver cadastrado nenhum clube
                        return false;
                    }
                    else
                    {
                        foreach (var clube in clubesCadastrados)
                        {
                            Console.WriteLine($" {clube.Id} - {clube.Nome}"); //ele mostra o nome do clube e o ID
                        }
                    }

                    return true;
                }

                static Clube cadastroClube() //aqui ele pode cadastrar um clube
                {
                    Console.Clear();
                    Console.WriteLine("Digite o nome do clube");
                    var clube = new Clube();
                    clube.Id = clubesCadastrados.Count + 1;
                    clube.Nome = Console.ReadLine();

                    Console.Clear();
                    Console.WriteLine($"Clube {clube.Nome} foi cadastrado com sucesso !");
                    Thread.Sleep(1000); // 1 segundo
                    return clube;
                }
            }
        }
    }
}