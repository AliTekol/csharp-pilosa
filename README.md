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
```
## Documentation

### Data Model and Queries

See: [Data Model and Queries](docs/data-model-queries.md)
