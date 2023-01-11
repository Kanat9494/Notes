using Microsoft.Maui.Controls.Handlers.Items;

public class CollectionViewHandlerEx : CollectionViewHandler
{
    protected override ReorderableItemsViewAdapter<ReorderableItemsView, IGroupableItemsViewSource> CreateAdapter()
    {
        return new CollectionViewAdapter(VirtualView);
    }
}
