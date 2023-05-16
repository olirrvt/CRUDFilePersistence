using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDFilePersistence
{
    internal class Crud
    {
        public static void cadastrar(List<Pessoa> listaPessoas, string caminhoArquivo)
        {
            string nome;
            string dataNascimento;
            Pessoa pessoa;

            Console.Write("Digite o nome: ");
            nome = Console.ReadLine();
            nome = ToTitleCase(nome);

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
            bool parar = false;
            string opcao;

            do
            {
                Console.Clear();
                Console.WriteLine("Lista das pessoas registradas");
                Console.WriteLine(" ");

                foreach (var item in lista)
                {
                    Console.WriteLine("----------------------------------------------------");
                    Console.WriteLine($"Nome: {item.Nome} | Email: {item.Email}");
                }

                Console.WriteLine(" ");
                Console.WriteLine("Digite '1' se quiser voltar para o menu");
                Console.WriteLine(" ");

                opcao = Console.ReadLine();
                parar = opcao == "1" ? true : false;

            } while (!parar);
        }

        public static void apagar(List<Pessoa> lista, string caminhoArquivo)
        {
            string nome;
            string opcao;
            bool removeu = false;
            bool parar = false;

            do
            {
                do
                {
                    removeu = false;

                    Console.Write("Digite o nome a ser excluído: ");
                    nome = Console.ReadLine();
                    nome = ToTitleCase(nome);

                    if(nome.ToLower() == "voltar")
                    {
                        Console.Clear();
                        parar = true;
                        break;
                    }

                    foreach (var item in lista)
                    {
                        if (nome == item.Nome)
                        {
                            lista.Remove(item);
                            removeu = true;
                            break;
                        }
                    }

                    if (removeu)
                    {
                        Persistencia.gravarListaArquivo(lista, caminhoArquivo);
                        Console.WriteLine("Registro excluída com sucesso!");
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Registro não encontrado, digite outro!");
                        Console.WriteLine("Se você deseja voltar, digite 'voltar'");
                        Console.WriteLine(" ");
                    }

                } while(!removeu);

                if (!parar)
                {
                    Console.Clear(); 
                    Console.WriteLine("Deseja apagar mais um usuário?");
                    Console.WriteLine(" ");

                    opcao = Console.ReadLine().ToLower();

                    parar = opcao == "sim" ? true : false;
                }

            } while (!parar);
        }

        static string ToTitleCase(string text)
        {
            CultureInfo cultureInfo = CultureInfo.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            return textInfo.ToTitleCase(text.ToLower());
        }
    }
}
