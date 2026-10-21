using backPadaria.Model;
using MySqlConnector;
using MySqlConnector.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace backPadaria.Sevice
{
    public static class FuncionarioService
    {
        public static void MenuFuncionario()
        {

            bool sair = false;


            while (!sair)
            {
                Console.WriteLine("==== GESTÃO DE FUNCIONARIOS====");

                Console.WriteLine("1 - Cadastrar Funcionarios");
                Console.WriteLine("2 - Listar Todos os Funcionarios");
                Console.WriteLine("3 - Buscar Funcionario por ID");
                Console.WriteLine("4 - Atualizar Funcionario");
                Console.WriteLine("5 - Excluir Funcionario");
                Console.WriteLine("0 - Sair do Programa");

                Console.WriteLine("==========================");
                Console.WriteLine("Digite uma opção: ");

                string opcao = Console.ReadLine();


                Console.Clear();

                try
                {
                    switch (opcao)
                    {
                        case "1":
                            cadastrarFuncionarioMenu();

                            break;


                        case "2":
                            listarFuncionariosMenu();

                            break;

                        case "3":

                            listarPorId();

                            break;


                        case "4":

                            AtualizarFuncionario();

                            break;


                        case "5":
                            ExcluirFuncionario();

                            break;

                        case "0":

                            return;

                            break;

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[Erro de validação: {ex.Message}");

                }
            }
        }



        private static void cadastrarFuncionarioMenu()
        {
            Console.WriteLine("----- CADASTRAR FUNCIONARIO -----");

            Console.WriteLine("Digite o nome do funcionario: ");
            string nomeFuncionario = Console.ReadLine();

            Console.WriteLine("Digite o cpf do funcionario: ");
            string cpfFuncionario = Console.ReadLine();

            Console.WriteLine("Digite o cargo do funcionario: ");
            string cargoFuncionario = Console.ReadLine();



            Funcionario novoFuncionario = new Funcionario(
             nome: nomeFuncionario,
             cpf: cpfFuncionario,
             cargo: cargoFuncionario);


            int resultadoInsert = Funcionario.InserirFuncionario(novoFuncionario);

            Console.Clear();

            if (resultadoInsert > 0) Console.WriteLine("Funcionario cadastrado com sucesso!!");
        }

        private static void listarFuncionariosMenu()
        {
            Console.Write("----- LISTA DE FUNCIONARIOS ----- ");

            List<Funcionario> lista = Funcionario.ListarTodos();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhum funcionario cadastrado no sistema.");

            }
            else
            {
                foreach (var funcionario in lista)
                {
                    Console.WriteLine($"ID: {funcionario.Id} | Nome: {funcionario.Nome} CPF: {funcionario.Cpf} Cargo: {funcionario.Cargo}");


                }
            }
            Console.WriteLine("\n Pressione uma tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }

        private static void listarPorId()
        {
            Console.WriteLine("----- LISTA DE FUNCIONARIOS POR ID -----");

            Console.WriteLine($"Digite o id desejado:");


            int idFuncionario = 0;

            int.TryParse(Console.ReadLine(), out idFuncionario);

            Funcionario funcionario = Funcionario.listarPorId(idFuncionario);

            Console.WriteLine($"ID:{funcionario.Id} | Nome: {funcionario.Nome} | CPF: {funcionario.Cpf} | Cargo: {funcionario.Cargo} ");


            Console.WriteLine("\n Pressione uma tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }

        private static void AtualizarFuncionario()
        {
            Console.WriteLine("----- ATUALIZAR FUNCIONARIO -----");

            Console.WriteLine("Digite o id do funcionario que deseja atualizar:  ");

            int idFuncionario = 0;
            int.TryParse(Console.ReadLine(), out idFuncionario);
            Funcionario funcionario = Funcionario.listarPorId(idFuncionario);

            if (funcionario != null)
            {
                Console.WriteLine("--- Informações atuais ----");
                Console.WriteLine($"ID: {funcionario.Id} | Nome: {funcionario.Nome}  | Cargo: {funcionario.Cargo} ");


                Console.WriteLine("Caso não deseje alterar o dado, pressione o enter");

                Console.WriteLine("Digite o novo nome do funcionario: ");
                string nomeFuncionario = Console.ReadLine();

                Console.WriteLine("Digite o novo cargo do funcionario: ");
                string cargoFuncionario = Console.ReadLine();


            }
        }
        private static int ExcluirFuncionario()
        {

            Console.WriteLine("------ EXCLUIR FUNCIONARIO ------");
            Console.WriteLine("Digite o id do cliente que deseja atualizar:  ");

            int idFuncionario = 0;
            int.TryParse(Console.ReadLine(), out idFuncionario);
            Funcionario? funcionario= Funcionario.listarPorId(idFuncionario);


            string sql = "DELETE FROM `Funcionario` WHERE `Id` = @id";


            Console.WriteLine("Funcionario excluido com sucesso!! ");
                using (var cmd = new MySqlCommand(sql))
                {
                    cmd.Parameters.AddWithValue("@id", idFuncionario);

                    return Banco.executarComando(cmd);
                }
            }
        }

    }


    

    