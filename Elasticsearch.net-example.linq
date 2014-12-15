<Query Kind="Program">
  <NuGetReference>AutoFixture</NuGetReference>
  <NuGetReference>NEST</NuGetReference>
  <Namespace>Elasticsearch.Net</Namespace>
  <Namespace>Ploeh.AutoFixture</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	var config = new Elasticsearch.Net.Connection.ConnectionConfiguration(new Uri("http://172.16.130.30:9200"));
	var client = new Elasticsearch.Net.ElasticsearchClient(config);
	
	var indexResponse = client.Index("employees", "employee", "6", new {
		name = "John Doe",
		age = 39
	});
	// indexResponse.Dump();
	
	var result = client.Search(new {
		query =new {
			match =new {
				name = "John"
			}
		}
	});
	
	//result.Dump();
	dynamic hitsObject = result.Response["hits"];
	object hits = hitsObject.hits;
	hits.Dump();
}
