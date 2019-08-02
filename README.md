# Paging in Xamarin.Forms Listview

The SfListView allows displaying paging using the [SfDataPager](http://help.syncfusion.com/cr/cref_files/xamarin/Syncfusion.SfDataGrid.XForms~Syncfusion.SfDataGrid.XForms.DataPager_namespace.html) control. It can be performed through loading data dynamically into ItemsSource of the SfListView using OnDemandLoading event for the current page by setting the [SfDataPager.UseOnDemandPaging](http://help.syncfusion.com/cr/cref_files/xamarin/Syncfusion.SfDataGrid.XForms~Syncfusion.SfDataGrid.XForms.DataPager.SfDataPager~UseOnDemandPaging.html) to `True`. By using the [SfDataPager.PageSize](http://help.syncfusion.com/cr/cref_files/xamarin/Syncfusion.SfDataGrid.XForms~Syncfusion.SfDataGrid.XForms.DataPager.SfDataPager~PageSize.html) property, you can define the number of list items to be displayed in each page.

```
<ContentPage xmlns:syncfusion="clr-namespace:Syncfusion.ListView.XForms;assembly=Syncfusion.SfListView.XForms"
             xmlns:sfPager="clr-namespace:Syncfusion.SfDataGrid.XForms.DataPager;assembly=Syncfusion.SfDataGrid.XForms">

    <ContentPage.Behaviors>
        <local:SfListViewPagingBehavior/>
    </ContentPage.Behaviors>

    <ContentPage.Resources>
        <ResourceDictionary>
            <local:CurrencyFormatConverter x:Key="currencyFormatConverter"/>
        </ResourceDictionary>
    </ContentPage.Resources>

    <ContentPage.Content>
        <StackLayout>

            <syncfusion:SfListView x:Name="listView" >
                <syncfusion:SfListView.LayoutManager>
                    <syncfusion:GridLayout SpanCount = "2">
                </syncfusion:SfListView.LayoutManager>
                <syncfusion:SfListView.ItemTemplate>
                    <DataTemplate>
                        <Grid>
                            <Image Source="{Binding Image}" />    
                            <Label Text="{Binding Name}" />
                            <Label Text="{Binding Weight}" />
                        </Grid>
                    </DataTemplate>
                </syncfusion:SfListView.ItemTemplate>
            </syncfusion:SfListView>

            <sfPager:SfDataPager x:Name="dataPager" UseOnDemandPaging="True" DisplayMode = "PreviousNextNumeric" NumericButtonCount = "4" PageSize = "6">

        </StackLayout>
    </ContentPage.Content>
</ContentPage>
```

```
public class SfListViewPagingBehavior : Behavior<ContentPage>
{

    private Syncfusion.ListView.XForms.SfListView listView;
    private PagingViewModel PagingViewModel;
    private SfDataPager dataPager;

    protected override void OnAttachedTo(ContentPage bindable)
    {
        listView = bindable.FindByName<Syncfusion.ListView.XForms.SfListView>("listView");
        dataPager = bindable.FindByName<SfDataPager>("dataPager");
        PagingViewModel = new PagingViewModel();
        listView.BindingContext = PagingViewModel;
        dataPager.Source = PagingViewModel.pagingProducts;
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
}
```
To know more about MVVM in ListView, please refer our documentation [here](https://help.syncfusion.com/xamarin/sflistview/mvvm)
