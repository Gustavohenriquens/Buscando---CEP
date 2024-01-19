using Refit;

namespace ExemploRefit
{
    class Program
    {
           static async Task Main(string[] args)   
            {
                try
                {
                    var cepClient = RestService.For<ICepApiService>("http://viacep.com.br"); //Cria uma instância de cliente para interagir com a API usando a interface.

                    Console.WriteLine("Informe seu CEP:");
                    string cepInformado = Console.ReadLine().ToString();
                    Console.WriteLine("Consultando informações do CEP:" + cepInformado);

                    var address = await cepClient.GetAddressAsync(cepInformado);//Faz uma chamada assíncrona para a API usando o cliente Refit.

                    Console.WriteLine($"\nLogradouro:{address.Logradouro},\nBairro:{address.Bairro}, \nLocalidade:{address.Localidade}");
                    //Exibe na tela informações do endereço obtidas da chamada à API.
                    Console.ReadKey();
                    
                } catch(Exception e)
                {
                    Console.WriteLine("Erro na consulta de cep : " + e.Message);
                }

            }


        


    }
}
