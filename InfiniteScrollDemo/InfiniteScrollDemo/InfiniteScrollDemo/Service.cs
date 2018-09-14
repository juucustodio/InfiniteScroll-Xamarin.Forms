using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfiniteScrollDemo
{
    public class Service
    {

        private readonly List<string> _pessoas = new List<string>
        {
            "Adriano", "José", "Maria","Oscar", "João", "Eduarda", "Daniel",
            "Suzana", "Paulo", "Pedro","Davi", "Felipe", "Fernanda", "Regina", "Nicole",
            "Jesus", "Samira", "Samuel", "Elis", "Mayara", "Leticia", "Luiz", "Luciano",
            "Neto", "Rodrigo", "Silvia", "Joel", "Vitória", "Fernando", "Samanta", "Karen",
            "Marcio", "Cleusa", "Clara", "Luciana", "Cleber", "Jairo", "Jair", "Douglas", "Hamilton",
        };

        public async Task<List<string>> GetPessoasAsync(int pageIndex, int pageSize)
        {
            //Delay para simular o tempo de uma requisição
            await Task.Delay(3000);
            return _pessoas.Skip(pageIndex * pageSize).Take(pageSize).ToList();
        }
    }
}
