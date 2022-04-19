using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WizardWorldDesktop.Extensions; 

public static class ObservableCollectionExtensions {
    public static void AddRange<T>(this ObservableCollection<T> collection, List<T> addedCollection) {
        foreach (var element in addedCollection) {
            collection.Add(element);
        }
    }
}