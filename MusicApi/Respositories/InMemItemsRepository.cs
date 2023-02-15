using MusicApi.Models;

namespace MusicApi.Repositories
{


	public class InMemItemsRepository : IItemsRepository
	{
		private readonly List<Item>? items = new(){
			new Item
			{
				Id = Guid.NewGuid(), Name = "potion", Price = 10, CreatedDate = DateTimeOffset.UtcNow
			},
			new Item {
				Id = Guid.NewGuid(), Name = "iron sword", Price = 20, CreatedDate = DateTimeOffset.UtcNow
			},
			new Item{
				Id = Guid.NewGuid(), Name = "bronze shield", Price = 16, CreatedDate = DateTimeOffset.UtcNow
			},
			new Item{
				Id = Guid.NewGuid(), Name = "potion", Price = 10, CreatedDate = DateTimeOffset.UtcNow
			},
			new Item{
				Id = Guid.NewGuid(), Name = "potion", Price = 10, CreatedDate = DateTimeOffset.UtcNow
			},
			new Item{
				Id = Guid.NewGuid(), Name = "potion", Price = 10, CreatedDate = DateTimeOffset.UtcNow
			},
			new Item{
				Id = Guid.NewGuid(), Name = "potion", Price = 10, CreatedDate = DateTimeOffset.UtcNow
			},
		};

		public IEnumerable<Item> GetItemsAsync()
		{
			return items;
		}

		public Item GetItemAsync(Guid id)
		{
			return items.Where(item => item.Id! == id).SingleOrDefault();
		}

		public void CreateItemAsync(Item item)
		{
			items.Add(item);
		}

		public void UpdateItemAsync(Item item)
		{
			var index = items.FindIndex(current => current.Id == item.Id);

			items[index] = item;
		}

		public void DeleteItemAsync(Guid id)
		{
			var index = items.FindIndex(current => current.Id == id);
			items.RemoveAt(index);
		}
	}
}