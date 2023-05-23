using System.Windows.Input;
namespace Epr3.Helpers.BindableProperties
{
    public class CustomListView : ListView
    {
        public static BindableProperty ItemTappedCommandProperty = BindableProperty.Create(
            nameof(ItemTappedCommand),
            typeof(ICommand),
            typeof(CustomListView)
            );
        public ICommand ItemTappedCommand
        {
            get
            {
                return (ICommand)GetValue(ItemTappedCommandProperty);
            }
            set
            {
                SetValue(ItemTappedCommandProperty, value);
            }
        }
        public CustomListView()
        {
            ItemTapped += OnItemTapped;
        }
        private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null)
            {
                ItemTappedCommand?.Execute(e.Item);
                SelectedItem = null;
            }
        }
    }
}