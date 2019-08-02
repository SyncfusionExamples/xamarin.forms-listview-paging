using Syncfusion.SfDataGrid.XForms.DataPager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace Paging
{
    [Preserve(AllMembers = true)]
    public class SfListViewPagingBehavior : Behavior<ContentPage>
    {
        #region Fields

        private Syncfusion.ListView.XForms.SfListView listView;
        private PagingViewModel PagingViewModel;
        private SfDataPager dataPager;

        #endregion

        #region Methods
        protected override void OnAttachedTo(ContentPage bindable)
        {
            listView = bindable.FindByName<Syncfusion.ListView.XForms.SfListView>("listView");
            dataPager = bindable.FindByName<SfDataPager>("dataPager");
            PagingViewModel = new PagingViewModel();
            listView.BindingContext = PagingViewModel;
            dataPager.PageCount = 5;
            dataPager.OnDemandLoading += DataPager_OnDemandLoading;
            base.OnAttachedTo(bindable);
        }

        private void DataPager_OnDemandLoading(object sender, OnDemandLoadingEventArgs e)
        {
            var source = PagingViewModel.pagingProducts.Skip(e.StartIndex).Take(e.PageSize);
            listView.ItemsSource = source.AsEnumerable();
        }

        protected override void OnDetachingFrom(ContentPage bindable)
        {
            listView = null;
            PagingViewModel = null;
            dataPager = null;
            base.OnDetachingFrom(bindable);
        }

        #endregion
    }
}
