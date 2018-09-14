using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms.Extended;

namespace InfiniteScrollDemo
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private const int PageSize = 8;
        private bool _isBusy;
        readonly Service _service = new Service();
        public InfiniteScrollCollection<string> Items { get; }

        public MainViewModel()
        {
            Items = new InfiniteScrollCollection<string>
            {
                OnLoadMore = async () =>
                {
                    IsBusy = true;

                    // Ler a proxima pagina
                    var page = Items.Count / PageSize;

                    //Busca os itens
                    var items = await _service.GetPessoasAsync(page, PageSize);

                    IsBusy = false;

                    // Itens que serão adicionados
                    return items;
                }
            };

            Download();
        }

        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                _isBusy = value;
                OnPropertyChanged();
            }
        }

        private async Task Download()
        {
            var items = await _service.GetPessoasAsync(pageIndex: 0, pageSize: PageSize);

            Items.AddRange(items);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        
    }
}