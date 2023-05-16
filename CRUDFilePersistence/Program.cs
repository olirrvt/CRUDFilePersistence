namespace CRUDFilePersistence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Caminho do Arquivo
            string caminhoArquivo = "C:/Users/Taylor/Desktop/CRUDFilePersistence/dados.dat";

            // Lista com a classe Pessoa
            List<Pessoa> listaPessoa = new List<Pessoa>();
            Persistencia.popularArquivoLista(caminhoArquivo, listaPessoa);

            int opcao;
            bool continuar = true;

            while (continuar)
            {
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("UFN - UNIVERSIDADE FRANSCISCANA");
                Console.ResetColor();
                Console.WriteLine("Seja muito bem vindo(a)!");

                Console.WriteLine(" ");
                Console.WriteLine("Escolha uma das opções para continuar");
                Console.WriteLine(" ");

                Console.WriteLine("1- Cadastrar pessoa");
                Console.WriteLine("2- Listar pessoa");
                Console.WriteLine("3- Apagar pessoa");
                Console.WriteLine("4- Pesquisar pessoa");
                Console.WriteLine("5- Sair");

                Console.WriteLine(" ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Console.Clear();
                        // Classe CRUD com método para cadastrar 
                        Crud.cadastrar(listaPessoa, caminhoArquivo);
                    break;

                    case 2:
                        Console.Clear();
                        // Classe CRUD com método para listar
                        Crud.listar(listaPessoa);
                    break;

                    case 3:
                        Console.Clear();
                        Console.WriteLine("Apagar");
                        Crud.apagar(listaPessoa, caminhoArquivo);
                    break;

                    case 4:
                        Console.Clear();
                        Console.WriteLine("Pesquisar");
                        //Crud.pesquisar(listaPessoa);
                    break;

                    case 5:
                        Console.Clear();
                        Console.WriteLine("Saindo");
                        continuar = false;
                    break;

                    default: 
                        Console.WriteLine(" ");
                        Console.WriteLine("Comandos inválidos, digite outra opção!");
                    break;
                }
            }
        }
    }
}

//Menu:

//1 - Cadastrar pessoa
//2- Listar Pessoa
//3- Apagar pessoa

//* Elementos necessários:

//	1 - Classe Pessoa(nome, email, dataNascimento(string))
//        - método para gerar o email da pessoa automaticamente:
//			"sobrenome@ufn.edu.br"


//    2 - Lista de Pessoas
//		- Ordenação (Sort)

//	3 - Arquivo
//        - Texto puro->CSV ou seja, separada por ";"
//		- StremReader (Classe leitora)
// 		-StreamWriter(Classe escritora)

//* Fluxo do Programa


//    Cadastrar->Nome e DataNascimento -> Constrói Objeto com email gerado -> Joga na lista 
//	-> Atualiza o arquivo

//	Listar -> Mostrar na lista

//	Pesquisar -> Percorrer a lista a procura de alguma pessoa

//	Excluir -> Pesquisar -> Retirar da lista -> Atualizar arquivo