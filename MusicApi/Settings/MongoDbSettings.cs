namespace MusicApi.Settings
{
	public class MongoDbSettings
	{
		public string? Host { get; set; }
		public int Port { get; set; }

		public string ConnectionString
		{
			get
			{
				return "mongodb://jesus9:1A0B3Z9ROeP7eIKt@ac-phifvra-shard-00-00.9zt7hrm.mongodb.net:27017,ac-phifvra-shard-00-01.9zt7hrm.mongodb.net:27017,ac-phifvra-shard-00-02.9zt7hrm.mongodb.net:27017/?ssl=true&replicaSet=atlas-uaeggq-shard-0&authSource=admin&retryWrites=true&w=majority";
			}
		}
	}
}