using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

class ObservableCollectionDemo
{
    static void Main()
    {
        var items = new ObservableCollection<string>();
        items.CollectionChanged += items_CollectionChanged;

        items.Add("new item");
        items.Add("another item");
        items.Add("one more item");
        items[1] = "new value";
        items.RemoveAt(0);
    }

    static void items_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        Console.WriteLine(e.Action);
    }
}