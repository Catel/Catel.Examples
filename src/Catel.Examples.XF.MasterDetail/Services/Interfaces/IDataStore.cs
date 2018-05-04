﻿namespace Catel.Examples.Xamarin.Forms.MasterDetail.Services.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IDataStore<T>
    {
        Task<bool> AddItemAsync(T item);
        Task<bool> UpdateItemAsync(T item);
        Task<bool> DeleteItemAsync(T item);
        Task<T> GetItemAsync(string id);
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);
        Task InitializeAsync();
        Task<bool> PullLatestAsync();
        Task<bool> SyncAsync();
    }
}