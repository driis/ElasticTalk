<Query Kind="Program">
  <NuGetReference>AutoFixture</NuGetReference>
  <NuGetReference>NEST</NuGetReference>
  <Namespace>Nest</Namespace>
  <Namespace>Ploeh.AutoFixture</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>


void Main()
{
	var config = new Nest.ConnectionSettings(new Uri("http://172.16.130.30:9200"), "employees");
	var client = new Nest.ElasticClient(config);
	
	var employee = new Employee { Id = 9, Name = "Bruce Lee", Age = 57 };
	client.Index(employee);
	
	var response = client.Get<Employee>(employee.Id);
	response.Source.Dump();
	
	var searchResponse = client.Search<Employee>(sd => sd.Query(
		q => q.Match(
			mq => mq.OnField(m => m.Name).Query("lee"))
		)
	);
		
	searchResponse.Documents.Dump();
}

[ElasticType]
public class Employee
{
	public long Id { get;set;}
	public string Name { get;set;}
	public int Age { get;set;}
}
