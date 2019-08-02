using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace Paging
{
    [Preserve(AllMembers = true)]
    public class PagingViewModel : INotifyPropertyChanged
    {
        private PagingProductRepository pagingProductRepository;

        public ObservableCollection<PagingProduct> pagingProducts { get; set; }

        public PagingViewModel()
        {
            pagingProductRepository = new PagingProductRepository();
            pagingProducts = new ObservableCollection<PagingProduct>();
            GenerateSource();
        }


        private void GenerateSource()
        {
            var index = 0;
            Assembly assembly = typeof(Paging.MainPage).GetTypeInfo().Assembly;
            for (int i = 0; i < pagingProductRepository.Names.Count(); i++)
            {
                if (index == 21)
                    index = 0;

                var name = pagingProductRepository.Names1[index];
                var p = new PagingProduct()
                {
                    Name = pagingProductRepository.Names[i],
                    Weight = pagingProductRepository.Weights[i],
                    Price = pagingProductRepository.Prices[i],
                    ReviewValue = pagingProductRepository.ReviewValue[i],
                    Ratings = pagingProductRepository.Ratings[i],
                    Offer = pagingProductRepository.Offer[i],
                    Image1 = ImageSource.FromResource("ListViewSample.Rating.png", assembly),
                    Image = ImageSource.FromResource("ListViewSample.Images." + name.Replace(" ", string.Empty) + ".jpg", assembly)
                };

                index++;
                pagingProducts.Add(p);
            }
        }

        private void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
