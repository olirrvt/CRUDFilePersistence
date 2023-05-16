using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDFilePersistence
{
    internal class Crud
    {

        public static bool validaEntrada(string nome)
        {
            string[]vetor = nome.Split(',');

            if (nome.Length == 0)
            { 
                return false;
            }

            return true;
        }
        public static void cadastrar(List<Pessoa> listaPessoas, string caminhoArquivo)
        {
            string nome;
            string dataNascimento;
            Pessoa pessoa;

            do
            {
                Console.Write("Digite o nome: ");
                nome = Console.ReadLine();

            } while(!validaEntrada(nome));


            Console.Write("Data Nascimento: ");
            dataNascimento = Console.ReadLine();

            pessoa = new Pessoa(nome, dataNascimento);

            if (!listaPessoas.Contains(pessoa))
            {
                listaPessoas.Add(pessoa);
                Console.WriteLine("Usuário Cadastradao com sucesso!");
            }
            else
            {
                Console.WriteLine("Pessoa com este email já na base de dados");
            }

            Persistencia.atualizarPessoaArquivo(pessoa, caminhoArquivo);
        }
        public static void listar(List<Pessoa> lista)
        {
            foreach (var item in lista)
            {
                Console.WriteLine(item.Nome);
            }
        }
    }
}
