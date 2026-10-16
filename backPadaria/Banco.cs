using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace backPadaria
{

    // classe estatica - não precisa gerar objeto para poder usar
    public static class Banco
    {
        private static string stringDeConexao = "Server= 10.91.45.57;Port=3306;Database=padaria_bd;Uid=admin;Pwd=12345678";

        public static void connectAndTest()
        {
            using (var connection = new MySqlConnection(stringDeConexao))
            {
                // tente
                try
                {

                    Console.WriteLine("Tentando conectar ao banco de dados");
                    connection.Open();

                    Console.WriteLine("Conexão bem sucedida.");

                    using (var command = new MySqlCommand("SELECT VERSION();", connection))
                    {
                        string? version = command.ExecuteScalar()?.ToString();

                        Console.WriteLine($"Versão do MariaDB {version}");
                    }



                 // capture todos os erros do banco de dados e guarde em "ex"
                }catch (MySqlException ex)
                {
                    Console.WriteLine("Erro ao conectar no banco de dados");
                    Console.WriteLine(ex.Message);
                }




            }
        }


        // Declaração do metodo: publico e estatico, retorna um numero inteiro (linhas afetadas)
        // e recebe um objeto MySqlCommand com a instrução SQL já configurada como parâmetro.
        public static int executarComando(MySqlCommand command)
        {
            /* O bloco 'using' garante que a conexão será automaticamente fechada e liberada
             da memoria ao final do bloco, mesmo que ocorrem erros no meio do processo.
                  
               Cria a conexão utilizando a variavel de ambiente
            */
            using (var conexao = new MySqlConnection(stringDeConexao))
            {
                // Vinculação: Diz ao comando SQL em qual conecão ele deve ser executado.
                command.Connection = conexao;

                try
                {
                    // Abertura da conexao: Estabelece efetivamente a comunicação com o servidor mysql.
                    conexao.Open();

                    // Execute: O ExecuteNonQuery dispara comandos de ação (INSERT, UPDATE, DELETE),
                    // Ele não retorna registros, mas sim o número inteiro de linhas que foram alteradas,
                    // e o 'return' devolve esse número para quem chamou o método.
                    return command.ExecuteNonQuery();
                }
                catch(MySqlException ex)
                {
                    Console.WriteLine($"Erro de banco de dados{ex.Message}");

                    return -1;
                }
            }
        }
    }
}
