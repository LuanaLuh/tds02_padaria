using backPadaria.Model;
using backPadaria.Sevice;
using backPadaria.Sevices;
using System.ComponentModel.Design;

namespace backPadaria
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //            Console.WriteLine("Digite o nome do cliente: ");
            //            string nomeCliente = Console.ReadLine();

            //            Console.WriteLine("Digite o endereco do cliente: ");
            //            string enderecoCliente = Console.ReadLine();

            //            Console.WriteLine("Digite o cpf do cliente: ");
            //            string cpfCliente = Console.ReadLine();

            //            Console.WriteLine("Digite o telefone do cliente: ");
            //            string telefoneCliente = Console.ReadLine();

            //            Console.WriteLine("Digite os pontos do cliente: ");
            //            int pontosCliente = int.Parse(Console.ReadLine());


            //            // REFATORAÇÃO ///
            //            Cliente cliente1 = new Cliente(
            //                nome: nomeCliente, 
            //                cpf: cpfCliente, telefone: telefoneCliente,
            //                endereco: enderecoCliente, pontos: pontosCliente
            //                );




            //Cliente clienteParaDeletar = new Cliente(4);
            //   if (Cliente.Deletar(clienteParaDeletar) >= 1)
            //   {
            //       Console.WriteLine("Cliente excluido com sucesso.");
            //   }
            //   else
            //   {
            //       Console.WriteLine("Deu bom não. Cliente presente!");
            //   }


            //List<Cliente> clientes = Cliente.ListarTodos();

            //foreach (Cliente cliente in clientes)
            //{
            //    Console.WriteLine("-----------------");
            //    Console.WriteLine($"ID {cliente.Id}");
            //    Console.WriteLine($"Nome {cliente.Nome}");
            //    Console.WriteLine($"CPF {cliente.Cpf}");
            //    Console.WriteLine($"Telefone {cliente.Telefone}");
            //    Console.WriteLine($"Endereço {cliente.Endereco}");
            //    Console.WriteLine($"Pontos {cliente.Pontos}");

            //    Console.WriteLine("-----------------");
            //}



            //Cliente? cli01 = Cliente.listarPorId(2);

            //if (cli01 != null)
            //{
            //    Console.WriteLine($"ID {cli01.Id}");
            //    Console.WriteLine($"Nome {cli01.Nome}");
            //    Console.WriteLine($"CPF {cli01.Cpf}");
            //    Console.WriteLine($"Telefone {cli01.Telefone}");
            //    Console.WriteLine($"Endereço {cli01.Endereco}");
            //    Console.WriteLine($"Pontos {cli01.Pontos}");
            //}
            //else
            //{
            //    Console.WriteLine("O cliente não foi encontrado!!");
            //}

            //Funcionario? meuFuncionario = Funcionario.listarPorId(1);

            //if (meuFuncionario != null)
            //{
            //    meuFuncionario.Nome = "Liz";
            //    meuFuncionario.Cargo = "Vendedor";

            //    int resultado = Funcionario.AtualizarFuncionario(meuFuncionario);

            //    if (resultado > 0)
            //    {
            //        Console.WriteLine("Funcionario atualizado com sucesso.");
            //    }




            //Funcionario funcionario2 = new Funcionario(nome: "Sabrina", cpf: "283466470663", cargo: "Chefe");

            // Funcionario.Inserir(funcionario2);


            // Console.WriteLine(funcionario2);

            // // deletando um funcionario 



            //Funcionario funcionarioParaDeletar = new Funcionario(10);
            //if (Funcionario.Deletar(funcionarioParaDeletar) >= 1)
            //{
            //    Console.WriteLine("Funcionario excluido com sucesso.");
            //}
            //else
            //{
            //    Console.WriteLine("Deu bom não. Funcionario presente!");
            //}


            //Funcionario funcionario = Funcionario.listarPorId(1);


            //ClienteService.MenuCliente();


            // Lista de funcionario por id
            //Funcionario? func01 = Funcionario.listarPorId(8);

            // if (func01 != null)
            // {
            //     Console.WriteLine($"ID {func01.Id}");
            //     Console.WriteLine($"Nome {func01.Nome}");
            //     Console.WriteLine($"CPF {func01.Cpf}");
            //     Console.WriteLine($"Cargo {func01.Cargo}");
            // }
            // else
            // {
            //     Console.WriteLine("O funcionario não foi encontrado!!");
            // }

            //List<Funcionario> funcionario = Funcionario.ListarTodos();

            //foreach (Funcionario funcionarios in funcionario)
            //{
            //    Console.WriteLine("-----------------");
            //    Console.WriteLine($"ID {funcionarios.Id}");
            //    Console.WriteLine($"Nome {funcionarios.Nome}");
            //    Console.WriteLine($"CPF {funcionarios.Cpf}");
            //    Console.WriteLine($"Cargo {funcionarios.Cargo}");


            //    Console.WriteLine("-----------------");
            //}

            FuncionarioService.MenuFuncionario();




        }
        }
    }
