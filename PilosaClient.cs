using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ali.pilosa
{
    public class PilosaClient
    {
        static readonly HttpClientHandler handler = new HttpClientHandler();
        static readonly HttpClient httpClient = new HttpClient();
        private string pilosaAddress;
        public PilosaClient(string address = "http://127.0.0.1:10101")
        {
            this.pilosaAddress = address;
        }
        public async Task<object> query(string indexName, IQuery query)
        {
            using (HttpClient httpClient = new HttpClient(handler, false))
            {
                var requestAddress = $"{pilosaAddress}/index/{indexName}/query";
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), requestAddress))
                {
                    request.Content = new StringContent(query.getPQL());
                    //Console.WriteLine(query.getPQL());
                    var response = await httpClient.SendAsync(request);
                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        switch (query.getType())
                        {
                            case IQuery.ROW:                           
                                return new RowParse(result);
                                
                            case IQuery.SET:
                                return new SetParse(result);
                                
                            case IQuery.CLEAR:
                                return new ClearParse(result);

                            case IQuery.COUNT:
                                return new CountParse(result);

                            case IQuery.TOPN:
                                return new TopNParse(result);

                            case IQuery.UNION:
                                return new UnionParse(result);

                            case IQuery.INTERSECT:
                                return new IntersectParse(result);

                            case IQuery.DIFFERENCE:
                                return new DifferenceParse(result);

                            case IQuery.MIN:
                                return new MinParse(result);

                            case IQuery.MAX:
                                return new MaxParse(result);

                            case IQuery.STORE:
                                return new StoreParse(result);

                            case IQuery.ROWS:
                                return new RowsParse(result);

                            case IQuery.GROUPBY:
                                return new GroupByParse(result);

                            case IQuery.XOR:
                                return new XorParse(result);

                            case IQuery.NOT:
                                return new NotParse(result);

                            case IQuery.SUM:
                                return new SumParse(result);

                            case IQuery.CLEAR_ROW:
                                return new ClearRowParse(result);
                            
                            case IQuery.SHIFT:
                                return new ShiftParse(result);
                        }
                    }
                    throw new Exception($"Fail {response.StatusCode}");
                }
            }
        }
        public async Task<object> createIndex(string indexName, bool hasKeys)
        {
            Dictionary<string, object> opt = new Dictionary<string, object>();
            Dictionary<string, object> key = new Dictionary<string, object>();
            opt["options"] = key;
            key["keys"] = false;
            string json = JsonConvert.SerializeObject(opt);
            using (HttpClient httpClient = new HttpClient(handler, false))
            {
                var requestAddress = $"{pilosaAddress}/index/{indexName}";
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), requestAddress))
                {
                    request.Content = new StringContent(json);
                    var response = await httpClient.SendAsync(request);
                    Console.WriteLine(await response.Content.ReadAsStringAsync());
                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject(result);
                    }
                    throw new Exception($"Fail {response.StatusCode}");
                }
            }
        }
        public async Task<object> createField(string indexName, string fieldName, string type, int min, int max)
        {
            Dictionary<string, object> param1 = new Dictionary<string, object>();
            Dictionary<string, object> param2 = new Dictionary<string, object>();
            param1["options"] = param2;
            param2["type"] = type;
            param2["min"] = min;
            param2["max"] = max;
            string json = JsonConvert.SerializeObject(param1);
            using (HttpClient httpClient = new HttpClient(handler, false))
            {
                var requestAddress = $"{pilosaAddress}/index/{indexName}/field/{fieldName}";
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), requestAddress))
                {
                    request.Content = new StringContent(json);
                    var response = await httpClient.SendAsync(request);
                    Console.WriteLine(await response.Content.ReadAsStringAsync());
                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject(result);
                    }
                    throw new Exception($"Fail {response.StatusCode}");
                }
            }
        }
        public async Task<object> removeField(string indexName, string fieldName)
        {
            using (HttpClient httpClient = new HttpClient(handler, false))
            {
                var requestAddress = $"{pilosaAddress}/index/{indexName}/field/{fieldName}";
                using (var request = new HttpRequestMessage(new HttpMethod("DELETE"), requestAddress))
                {
                    var response = await httpClient.SendAsync(request);
                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject(result);
                    }
                    throw new Exception($"Fail {response.StatusCode}");
                }
            }
        }
        public async Task<List<Index>> listAllIndexSchemas()
        {
            using (httpClient)
            {
                var requestAddress = $"{pilosaAddress}/schema";
                using (var request = new HttpRequestMessage(new HttpMethod("GET"), requestAddress))
                {
                    var response = await httpClient.SendAsync(request);
                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var rootObject = JsonConvert.DeserializeObject<ali.pilosa.SchemaRootObject>(result);
                        Console.WriteLine("indexes:");
                        foreach (var indexes in rootObject.indexes)
                        {
                            Console.WriteLine("");
                            Console.WriteLine("name: {0}", indexes.name);
                            Console.WriteLine("keys: {0}", indexes.options.keys);
                            Console.WriteLine("trackExistence: {0}", indexes.options.trackExistence);
                            Console.WriteLine("shardWidth: {0}", indexes.shardWidth);
                            Console.WriteLine("");
                            if (indexes.fields != null)
                            {
                                foreach (var fields in indexes.fields)
                                {
                                    Console.WriteLine("");
                                    Console.WriteLine("fields:");
                                    Console.WriteLine("");
                                    Console.WriteLine("name: {0}", fields.name);
                                    Console.WriteLine("type: {0}", fields.options.type);
                                    Console.WriteLine("timeQuantum: {0}", fields.options.timeQuantum);
                                    Console.WriteLine("cacheType: {0}", fields.options.cacheType);
                                    Console.WriteLine("cacheSize: {0}", fields.options.cacheSize);
                                    Console.WriteLine("keys: {0}", fields.options.keys);
                                    Console.WriteLine("noStandardView: {0}", fields.options.noStandardView);
                                    Console.WriteLine("");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Fields: {0}", (indexes.fields == null ? "Null" : indexes.fields.ToString()));
                                continue;
                            }
                        }
                        return new List<Index>();
                    }
                    throw new Exception($"Fail {response.StatusCode}");
                }
            }
        }
        public async Task<object> getVersion()
        {
            using (HttpClient httpClient = new HttpClient(handler, false))
            {
                var requestAddress = $"{pilosaAddress}/version";
                using (var request = new HttpRequestMessage(new HttpMethod("GET"), requestAddress))
                {
                    var response = await httpClient.SendAsync(request);
                    Console.WriteLine(await response.Content.ReadAsStringAsync());
                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject(result);
                    }
                    throw new Exception($"Fail {response.StatusCode}");
                }
            }
        }
        public async Task<object> getStatus()
        {
            using (HttpClient httpClient = new HttpClient(handler, false))
            {
                var requestAddress = $"{pilosaAddress}/status";
                using (var request = new HttpRequestMessage(new HttpMethod("GET"), requestAddress))
                {
                    var response = await httpClient.SendAsync(request);
                    Console.WriteLine(await response.Content.ReadAsStringAsync());
                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject(result);
                    }
                    throw new Exception($"Fail {response.StatusCode}");
                }
            }
        }
        public async Task<object> recalculateCaches()
        {
            using (HttpClient httpClient = new HttpClient(handler, false))
            {
                var requestAddress = $"{pilosaAddress}/recalculate-caches";
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), requestAddress))
                {
                    var response = await httpClient.SendAsync(request);
                    Console.WriteLine(await response.Content.ReadAsStringAsync());
                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject(result);
                    }
                    throw new Exception($"Fail {response.StatusCode}");
                }
            }
        }
    }
}