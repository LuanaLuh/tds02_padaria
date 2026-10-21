using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace backPadaria.Model
{
    internal class Funcionario
    {
        private int id;
        private string nome;
        private string cpf;
        private string cargo;

        public int Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Cpf { get => cpf; set => cpf = value; }
        public string Cargo { get => cargo; set => cargo = value; }


        public Funcionario(string nome, string cpf, string cargo)
        {
            if (string.IsNullOrWhiteSpace(nome)) throw new Exception("O nome do cliente não pode ser vazio.");
            this.Nome = nome;
            this.Cpf = cpf;
            this.Cargo = cargo;
        }
        public Funcionario(int id, string nome, string cpf, string cargo)
        {
            this.Id = id;
            this.Nome = nome;
            this.Cpf = cpf;
            this.Cargo = cargo;
        }

  
        public static int DeletarFuncionario(Funcionario funcionario)
        {

            string sql = "DELETE FROM `Funcionario` WHERE `Id` = @id";

            using (var cmd = new MySqlCommand(sql))
            {
                cmd.Parameters.AddWithValue("@id", funcionario.id);

                return Banco.executarComando(cmd);
            }
        }

        public static int InserirFuncionario(Funcionario funcionario)
        {
            string sql = "INSERT INTO `Funcionario`(`Nome`, `CPF`, `cargo`)  VALUES (@Nome, @CPF, @Cargo) ";

            using (var cmd = new MySqlCommand(sql))
            {
                cmd.Parameters.AddWithValue("@Nome", funcionario.Nome);
                cmd.Parameters.AddWithValue("@CPF", funcionario.Cpf);
                cmd.Parameters.AddWithValue("@Cargo", funcionario.Cargo);

                return Banco.executarComando(cmd);
            }
        }
         public static int AtualizarFuncionario(Funcionario funcionario)
        {
            string sql = "UPDATE `Funcionario` SET `Nome` = @Nome, `Cargo` = @Cargo WHERE `Id` = @Id";

            using (var cmd = new MySqlCommand(sql))
            {
               
                cmd.Parameters.AddWithValue("@Nome", funcionario.Nome);
                cmd.Parameters.AddWithValue("@Cargo", funcionario.Cargo);
                cmd.Parameters.AddWithValue("@Id", funcionario.Id);

                return Banco.executarComando(cmd);
            }
        }

        public static Funcionario listarPorId(int id)
        {

            string sql = "SELECT * FROM `Funcionario` WHERE `id`= @Id";

            using (var cmd = new MySqlCommand(sql))
            {
                cmd.Parameters.AddWithValue("@Id", id);

                MySqlDataReader reader = Banco.executarComRetornoDeDados(cmd);

                Funcionario funcionario = null;

                while (reader.Read())
                {
                    
 
                    string nome = validarCampo(reader["Nome"]);
                    string cpf = validarCampo(reader["CPF"]);
                    string cargo = validarCampo(reader["Cargo"]);
                  
                    funcionario = new Funcionario( id, nome, cpf, cargo);

                }
                return funcionario;
            }
        }

        public static List<Funcionario> ListarTodos()
        {
            string sql = "SELECT * FROM `Funcionario`";
            List<Funcionario> listaFuncionarios = new();

            using (var cmd = new MySqlCommand(sql))
            {

                using (MySqlDataReader reader = Banco.executarComRetornoDeDados(cmd))
                {

                    while (reader.Read())
                    {

                        int id = reader.GetInt32("id");
                        string nome = validarCampo(reader["Nome"]);
                        string cpf = validarCampo(reader["CPF"]);
                        string cargo = validarCampo(reader["Cargo"]);


                        Funcionario funcionario = new Funcionario(id, nome, cpf, cargo);


                        listaFuncionarios.Add(funcionario);

                    }
                    return listaFuncionarios;
                }


            }
        }

        private static string validarCampo(object campo)
        {
            if (campo == DBNull.Value || campo == null)
            {
                return "";
            }
            else
            {
                return campo.ToString();
            }
        }
    }
 }
