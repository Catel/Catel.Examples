using Catel.Examples.Xamarin.Forms.MasterDetail.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(MockDataStore))]

namespace Catel.Examples.Xamarin.Forms.MasterDetail.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Catel.Examples.Xamarin.Forms.MasterDetail.Models;
    using Catel.Examples.Xamarin.Forms.MasterDetail.Services.Interfaces;

    public class MockDataStore : IDataStore<Item>
    {
        private bool isInitialized;

        private List<Item> items;

        public async Task<bool> AddItemAsync(Item item)
        {
            await InitializeAsync();

            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            await InitializeAsync();

            var _item = items.FirstOrDefault(arg => arg.Id == item.Id);

            items.Remove(_item);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(Item item)
        {
            await InitializeAsync();
            var _item = items.FirstOrDefault(arg => arg.Id == item.Id);
            items.Remove(_item);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            await InitializeAsync();

            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            await InitializeAsync();

            Thread.Sleep(2000);

            return await Task.FromResult(items);
        }

        public Task<bool> PullLatestAsync()
        {
            return Task.FromResult(true);
        }

        public Task<bool> SyncAsync()
        {
            return Task.FromResult(true);
        }
        
        private readonly object _syncObj = new object();

        public async Task InitializeAsync()
        {
        	lock(_syncObj)
        	{
	            if (isInitialized)
	                return;
	
	            items = new List<Item>
	            {
	                new Item
	                {
	                    Id = Guid.NewGuid().ToString(),
	                    Text = "Buy some cat food",
	                    Description = "The cats are hungry"
	                },
	                new Item
	                {
	                    Id = Guid.NewGuid().ToString(),
	                    Text = "Learn F#",
	                    Description = "Seems like a functional idea"
	                },
	                new Item {Id = Guid.NewGuid().ToString(), Text = "Learn to play guitar", Description = "Noted"},
	                new Item
	                {
	                    Id = Guid.NewGuid().ToString(),
	                    Text = "Buy some new candles",
	                    Description = "Pine and cranberry for that winter feel"
	                },
	                new Item
	                {
	                    Id = Guid.NewGuid().ToString(),
	                    Text = "Complete holiday shopping",
	                    Description = "Keep it a secret!"
	                },
	                new Item {Id = Guid.NewGuid().ToString(), Text = "Finish a todo list", Description = "Done"}
	            };
	
	            isInitialized = true;
        	}
        }
    }
}