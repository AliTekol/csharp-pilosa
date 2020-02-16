using System.Collections.Generic;
using System.Text;

namespace ali.pilosa
{
    public class Index
    {
        public string name { get; set; }
        public IndexesOptions options { get; set; }
        public List<Field> fields { get; set; }
        public int shardWidth { get; set; }
        public Index(string name) 
        {
            this.name = name;
        }
        public IQuery Row(ulong rowId)
        {
            string pql = $"Row({name}={rowId})";
            return new RowQuery(pql);
        }
        public IQuery Row(string rowKey)
        {
            string pql =  $"Row({name}={rowKey})";
            return new RowQuery(pql);
        }
        public IQuery Set(ulong columnId, ulong rowId)
        {
            string pql =  $"Set({columnId},{name}={rowId})";
            return new SetQuery(pql);
        }
        public IQuery Set(string columnKey, ulong rowId)
        {
            string pql =  $"Set(\"{columnKey}\",{name}={rowId})";
            return new SetQuery(pql);
        }
        public IQuery Clear(ulong columnId, ulong rowId)
        {
            string pql =  $"Clear({columnId},{name}={rowId})";
            return new ClearQuery(pql);
        }
        public IQuery Clear(string columnKey, ulong rowId)
        {
            string pql =  $"Clear({columnKey},{name}={rowId})";
            return new ClearQuery(pql);
        }
        public IQuery ClearRow(ulong rowId)
        {
            string pql =  $"ClearRow({name}={rowId})";
            return new ClearRowQuery(pql);
        }
        public IQuery Count(IQuery row)
        {
            string pql =  $"Count({row.getPQL()})";
            return new CountQuery(pql);
        }
        public IQuery TopN()
        {
            string pql =  $"TopN({name})";
            return new TopNQuery(pql);
        }
        public IQuery TopN(int n)
        {
            string pql =  $"TopN({name},n={n})";
            return new TopNQuery(pql);
        }
        public IQuery TopN(int n, params IQuery[] rows)
        {
            var sb = new StringBuilder();   
            string seperator = ",";  
            foreach (IQuery row in rows)
            {
                sb.Append(row.getPQL());
                sb.Append(seperator);
            }
            sb.Remove(sb.Length - 1, 1);   
            string pql =  $"TopN({name},{sb},n={n})";
            return new TopNQuery(pql);
        }
        public IQuery TopN(int n, string attrName, bool attrValues)
        {
            string pql =  $"TopN({name},n={n},{attrName},{attrValues})";
            return new TopNQuery(pql);
        }
        public IQuery Union(params IQuery[] rows)
        {
            var sb = new StringBuilder();   
            string seperator = ",";  
            foreach (IQuery row in rows)
            {
                sb.Append(row.getPQL());
                sb.Append(seperator);
            }
            sb.Remove(sb.Length - 1, 1);  
            string pql =  $"Union({sb})";
            return new UnionQuery(pql);
        }
        public IQuery Intersect(params IQuery[] rows)
        { 
            var sb = new StringBuilder();   
            string seperator = ",";  
            foreach (IQuery row in rows)
            {
                sb.Append(row.getPQL());
                sb.Append(seperator);
            }
            sb.Remove(sb.Length - 1, 1);   
            string pql =  $"Intersect({sb})";
            return new IntersectQuery(pql);         
        }
        public IQuery Difference(params IQuery[] rows)
        {
            var sb = new StringBuilder();   
            string seperator = ",";  
            foreach (IQuery row in rows)
            {
                sb.Append(row.getPQL());
                sb.Append(seperator);
            }
            sb.Remove(sb.Length - 1, 1);   
            string pql =  $"Difference({sb})";
            return new DifferenceQuery(pql);
        }
        public IQuery Not(IQuery row)
        {
            string pql =  $"Not({row.getPQL()})";
            return new NotQuery(pql);
        }
        public IQuery Rows()
        {
            string pql =  $"Rows({name})";
            return new RowsQuery(pql);
        }
        public IQuery Rows(ulong columnId)
        {
            string pql =  $"Rows({columnId})";
            return new RowsQuery(pql);
        }
        public IQuery Rows(string columnKey)
        {
            string pql =  $"Rows({columnKey})";
            return new RowsQuery(pql);
        }
        public IQuery Min()
        {
            string pql =  $"Min(field=\"{name}\")";
            return new MinQuery(pql);
        }
        public IQuery Min(IQuery row)
        {
            string pql =  $"Min({row},field=\"{name}\")";
            return new MinQuery(pql);
        }
        public IQuery Max()
        {
            string pql =  $"Max(field=\"{name}\")";
            return new MaxQuery(pql);
        }
        public IQuery Max(IQuery row)
        {
            string pql =  $"Max({row},field=\"{name}\")";
            return new MaxQuery(pql);
        }
        public IQuery GroupBy(params IQuery[] rows)
        {
            var sb = new StringBuilder();   
            string seperator = ",";  
            foreach (IQuery row in rows)
            {
                sb.Append(row.getPQL());
                sb.Append(seperator);
            }
            sb.Remove(sb.Length - 1, 1);   
            string pql =  $"GroupBy({sb})";
            return new GroupByQuery(pql);
        }
        public IQuery GroupBy(ulong limit, params IQuery[] rows)
        {
            var sb = new StringBuilder();   
            string seperator = ",";  
            foreach (IQuery row in rows)
            {
                sb.Append(row.getPQL());
                sb.Append(seperator);
            }
            sb.Remove(sb.Length - 1, 1);   
            string pql =  $"GroupBy({sb},limit={limit})";
            return new GroupByQuery(pql);
        }
        public IQuery GroupBy(string filter, ulong limit, params IQuery[] rows)
        {
            var sb = new StringBuilder();   
            string seperator = ",";  
            foreach (IQuery row in rows)
            {
                sb.Append(row.getPQL());
                sb.Append(seperator);
            }
            sb.Remove(sb.Length - 1, 1);   
            string pql =  $"GroupBy({sb},limit={limit},filter={filter})";
            return new GroupByQuery(pql);
        }
        public IQuery Sum()
        {
            string pql =  $"Sum(field=\"{name}\")";
            return new SumQuery(pql);
        }
        public IQuery Sum(IQuery row)
        {
            string pql =  $"Sum({row.getPQL()},field=\"{name}\")";
            return new SumQuery(pql);
        }
        public IQuery Shift(IQuery row, int n)
        {
            string pql =  $"Shift({row.getPQL()},n={n})";
            return new ShiftQuery(pql);
        }
        public IQuery Xor(params IQuery[] rows)
        {
            var sb = new StringBuilder();   
            string seperator = ",";  
            foreach (IQuery row in rows)
            {
                sb.Append(row.getPQL());
                sb.Append(seperator);
            }
            sb.Remove(sb.Length - 1, 1);   
            string pql =  $"Xor({sb})";
            return new XorQuery(pql);
        }
        public IQuery Store(IQuery row, ulong rowId)
        {
            string pql =  $"Store({row.getPQL()},{name}={rowId})";
            return new StoreQuery(pql);
        }
        public IQuery Store(IQuery row, string rowKey)
        {
            string pql =  $"Store({row.getPQL()},{name}={rowKey})";
            return new StoreQuery(pql);
        }
    }
}