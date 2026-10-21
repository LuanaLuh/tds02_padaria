using backPadaria.Model;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace backPadaria.Sevices
{
    public static class ClienteService
    {
        public static void MenuCliente()
        {
            bool sair = false;

            while (!sair)
            {
                Console.WriteLine("==== GESTÃO DE CLIENTES====");

                Console.WriteLine("1 - Cadastrar Cliente");
                Console.WriteLine("2 - Listar Todos os Clientes");
                Console.WriteLine("3 - Buscar Cliente por ID");
                Console.WriteLine("4 - Atualizar Cliente");
                Console.WriteLine("5 - Excluir Cliente");
                Console.WriteLine("6 - Visualizar pontuação");
                Console.WriteLine("0 - Sair do Programa");

                Console.WriteLine("==========================");
                Console.WriteLine("Digite uma opção: ");

                string opcao = Console.ReadLine();


                Console.Clear();


                try
                {
                    switch (opcao)
                    {
                        case "1": // Cadastrar

                            cadastrarClienteMenu();

                            break;


                        case "2": //Listar
                            listarClientesMenu();

                            break;

                        case "3":

                            listarPorId();

                            break;

                        case "4":

                            AtualizarCliente();

                            break;
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"[Erro de validação: {ex.Message}");


                }

            }



        }// Fim do menu


        private  static void cadastrarClienteMenu()
        {
            Console.WriteLine("----- CADASTRAR CLIENTE -----");

            Console.WriteLine("Digite o nome do cliente: ");
            string nomeCliente = Console.ReadLine();

            Console.WriteLine("Digite o endereco do cliente: ");
            string enderecoCliente = Console.ReadLine();

            Console.WriteLine("Digite o cpf do cliente: ");
            string cpfCliente = Console.ReadLine();

            Console.WriteLine("Digite o telefone do cliente: ");
            string telefoneCliente = Console.ReadLine();

            Console.WriteLine("Digite os pontos do cliente: ");
            int pontosCliente = int.Parse(Console.ReadLine());

            Cliente novoCliente = new Cliente(
             nome: nomeCliente,
             cpf: cpfCliente,
             telefone: telefoneCliente,
             endereco: enderecoCliente,
             pontos: pontosCliente);


            int resultadoInsert = Cliente.Inserir(novoCliente);

            Console.Clear();

            if (resultadoInsert > 0) Console.WriteLine("Cliente cadastrado com sucesso!!");


        }

        private static void listarClientesMenu()
        {
            Console.Write("----- LISTA DE CLIENTES ----- ");

            List<Cliente> lista = Cliente.ListarTodos();

            if(lista.Count == 0)
            {
                Console.WriteLine("Menhum cliente cadastrado no sistema.");

            }
            else
            {
                foreach(var cliente in lista)
                {
                    Console.WriteLine($"ID: {cliente.Id} | Nome: {cliente.Nome} CPF: {cliente.Cpf} Pontos: {cliente.Pontos}");


                }
            }
            Console.WriteLine("\n Pressione uma tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }
         
        private static void listarPorId()
        {
            Console.WriteLine("----- LISTA DE CLIENTES POR ID -----");

            Console.WriteLine($"Digite o id desejado:");


            int idCliente = 0;

            int.TryParse( Console.ReadLine(), out idCliente);

            Cliente cliente = Cliente.listarPorId(idCliente);

            Console.WriteLine($"ID:{cliente.Id} | Nome: {cliente.Nome} | CPF: {cliente.Cpf} | Telefone: {cliente.Telefone} | Endereço: {cliente.Endereco} | Pontos: {cliente.Pontos}");


            Console.WriteLine("\n Pressione uma tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }

        private static void AtualizarCliente()
        {
            Console.WriteLine("----- ATUALIZAR CLIENTE -----");

            Console.WriteLine("Digite o id do cliente que deseja atualizar:  " );

            int idCliente = 0;
            int.TryParse(Console.ReadLine(), out idCliente);
            Cliente cliente = Cliente.listarPorId(idCliente);

            if ( cliente != null)
            {
                Console.WriteLine("--- Informações atuais ----");
                Console.WriteLine($"ID: {cliente.Id} | Nome: {cliente.Nome} | CPF: {cliente.Cpf} | Telefone: {cliente.Telefone} | Endereço: {cliente.Endereco} | Pontos: {cliente.Pontos}");


                Console.WriteLine("Caso não deseje alterar o dado, pressione o enter");

                Console.WriteLine("Digite o novo nome do cliente: ");
                string nomeCliente = Console.ReadLine();

                Console.WriteLine("Digite o novo telefone: ");
                string telefoneCliente = Console.ReadLine();


                Console.WriteLine("Digite o novo endereço: ");
                string enderecoCliente = Console.ReadLine();


                Console.WriteLine("Digite a nova pontuação: ");
                int pontosCliente;

                int.TryParse(Console.ReadLine(), out pontosCliente);





            }









        }
    }
 



    }

