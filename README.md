# C# Client for Pilosa

<a href="https://github.com/pilosa"><img src="https://img.shields.io/badge/pilosa-1.4-blue.svg"></a>

<img src="https://www.pilosa.com/img/ee.svg" style="float: right" align="right" height="301">

C# client for Pilosa high performance distributed index.

## Requirements

* NET Core 3.1 and higher

## Usage

### Quick overview

Assuming [Pilosa](https://github.com/pilosa/pilosa) server is running at `localhost:10101` (the default):

```C#
// Create the default client
var client = new PilosaClient();

// Retrieve the schema
var schema = await client.listAllIndexSchemas();

// Create an Index object with key status
var myindex = await client.createIndex("myindex", false);

// Create a Field object of created Index with type, min and max values
var myfield = await client.createField("myindex", "myfield", "type", -1000, 5000);

//Assign the Field name will be used in the queries
var index = new ali.pilosa.Index("stargazer");

// Send a Set query
var set = index.Set(10, 2);

// Send a Row query
var row = index.Row(1);

// Send a Clear query
var clear = index.Clear(10, 1);

// Send a Count query
var count = index.Count(index.Row(1));

// Send an Intersect query
var intersect = index.Intersect(index.Row(1), index.Row(2), index.Row(3));

//Send a Union query
var union = index.Union(index.Row(1), index.Row(2), index.Row(3));

// Send a Difference query
var difference = index.Difference(index.Row(1), index.Row(2));

// Send a Min query
var min = index.Min();

// Send a Max query
var max = index.Max();

// Send a Store query
var store = index.Store(index.Row(1), 2);

// Send a Shift query
var shift = index.Shift(index.Row(1), 2);

// Send a ClearRow query
var clearrow = index.ClearRow(1);

// Send a Sum query
var sum = index.Sum();

// Send a Not query
var not = index.Not(index.Row(1));

//Send an Xor Query
var xor = index.Xor(index.Row(1), index.Row(2));

//Send Rows Query
var rows = index.Rows();

//Send GroupBy Query
var groupby = index.GroupBy(index.Rows("language"));

//Send TopN Query
var topn = index.TopN();

// Get the desired query result with the given Index name
var query = await client.query("repository", union);
```
## Documentation

### Data Model and Queries

See: [Data Model and Queries](docs/data-model-queries.md)
