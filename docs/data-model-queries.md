# Data Model and Queries

## Indexes and Fields

Index and Field are the main data models of Pilosa. You can check [Pilosa documentation](https://www.pilosa.com/docs) for more details about the data model.

First create an object of PilosaClient class
```C#
var client = new PilosaClient();
```
While the async methods running in the main client class, the await prefix should be added to the beginning of the call. Else, you may get the Exception.

Then you can create desired indexes with the key status (true or false)
```C#
var createdIndex = await client.createIndex("myindex", false);
```
You can pass the main options of Fields to the create method
```C#
var createdField = await client.createField("myindex", "myfield", "type", -1000, 5000);
```
## Queries

For creating queries for them. First you need to create the following method assigned with the field name:
```C#
var index = new ali.pilosa.Index("stargazer");
```
To get the query method results, you need to add the following code at the end of your code:
```C#
var query = await client.query("repository", count); //This will run the results with the required field name (Assumed that the count query will be executed at the example.)
```
For example, `Row` query is wanted to get to work. You can write something like this:
```C#
var row = index.Row(1);  // corresponds to PQL: Row(stargazer=1)
```
`Union` query is can be used with n elements created on Index object.
```C#
var union = index.Union(index.Row(1), index.Row(2), index.Row(3)); // corresponds to PQL: Union(Row(stargazer=1),Row(stargazer=2),Row(stargazer=3))
```

If you want to see the query that executed, just remove the comment slashes at the line of 26 in the PilosaClient.

Check [Pilosa documentation](https://www.pilosa.com/docs) for PQL details. Here is a list of methods corresponding to PQL calls:

* `IQuery Row(ulong rowId)`
* `IQuery Row(string rowKey)`
* `IQuery Set(ulong columnId, ulong rowId)`
* `IQuery Set(string columnKey, ulong rowId)`
* `IQuery Clear(ulong columnId, ulong rowId)`
* `IQuery Clear(string columnKey, ulong rowId)`
* `IQuery ClearRow(ulong rowId)`
* `IQuery Count(IQuery row)`
* `IQuery TopN()`
* `IQuery TopN(int n)`
* `IQuery TopN(int n, params IQuery[] rows)`
* `IQuery TopN(int n, string attrName, bool attrValues)`
* `IQuery Union(params IQuery[] rows)`
* `IQuery Intersect(params IQuery[] rows)`
* `IQuery Difference(params IQuery[] rows)`
* `IQuery Not(IQuery row)`
* `IQuery Rows()`
* `IQuery Rows(ulong columnId)`
* `IQuery Rows(string columnKey)`
* `IQuery Min()`
* `IQuery Min(IQuery row)`
* `IQuery Max()`
* `IQuery Max(IQuery row)`
* `IQuery GroupBy(params IQuery[] rows)`
* `IQuery GroupBy(ulong limit, params IQuery[] rows)`
* `IQuery GroupBy(string filter, ulong limit, params IQuery[] rows)`
* `IQuery Sum()`
* `IQuery Sum(IQuery row)`
* `IQuery Shift(IQuery row, int n)`
* `IQuery Xor(params IQuery[] rows)`
* `IQuery Store(IQuery row, ulong rowId)`
* `IQuery Store(IQuery row, string rowKey)`