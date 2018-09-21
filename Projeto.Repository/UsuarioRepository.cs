using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using Projeto.Entities;
using Dapper;

namespace Projeto.Repository
{
    public class UsuarioRepository
    {
        //atributo para armazenar a connectionstring
        private string connectionString = ConfigurationManager.ConnectionStrings["aula"].ConnectionString;

        //método para inserir um usuario no banco de dados
        public void Insert(Usuario u)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                //comando SQL que será executado no banco de dados
                string query = "insert into Usuario(Nome, Email, Senha, DataCriacao) "
                             + "values(@Nome, @Email, @Senha, GetDate())";

                con.Execute(query, u); //executando..
            }
        }

        //método para atualizar um usuario no banco de dados
        public void Update(Usuario u)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                //comando SQL que será executado no banco de dados
                string query = "update Usuario set Nome = @Nome, Email = @Email, Senha = @Senha "
                             + "where IdUsuario = @IdUsuario";

                con.Execute(query, u); //executando..
            }
        }

        //método para excluir um usuario no banco de dados
        public void Delete(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                //comando SQL que será executado no banco de dados
                string query = "delete from Usuario where IdUsuario = @IdUsuario";

                con.Execute(query, new { IdUsuario = id });

            }
        }

        //método para consultar todos os usuarios no banco de dados
        public List<Usuario> FindAll()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                //comando SQL que será executado no banco de dados
                string query = "select * from Usuario";

                return con.Query<Usuario>(query)
                            .ToList();
            }
        }

        //método para retornar 1 usuario pelo id no banco de dados
        public Usuario FindById(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                //comando SQL que será executado no banco de dados
                string query = "select * from Usuario where IdUsuario = @IdUsuario";

                return con.Query<Usuario>(query, new { IdUsuario = id }).FirstOrDefault();
            }
        }

        //método para retornar 1 usuario pelo email e senha
        public Usuario Find(string email, string senha)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "select * from Usuario where Email = @Email and Senha = @Senha";

                return con.Query<Usuario>(query, new { Email = email, Senha = senha }).FirstOrDefault();
            }

        }

        //método booleano para verificar se um email ja esta cadastrado na tabela
        public bool HasEmail(string email)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "select count(Email) from Usuario where Email = @Email";

                return con.Query<int>(query,
                        new { Email = email })
                        .FirstOrDefault() > 0;
            }
        }

    }

}