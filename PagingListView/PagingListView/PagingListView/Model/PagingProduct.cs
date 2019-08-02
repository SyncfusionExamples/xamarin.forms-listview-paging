using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace Paging
{
    [Preserve(AllMembers = true)]

    public class PagingProduct : INotifyPropertyChanged
    {
        public string Name { get; set; }

        public string Ratings { get; set; }

        public ImageSource Image { get; set; }

        public ImageSource Image1 { get; set; }

        public string Weight { get; set; }

        public double Price { get; set; }

        public string Offer { get; set; }

        public double ReviewValue { get; set; }

        private void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
