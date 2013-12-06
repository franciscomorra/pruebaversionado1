using System;
using System.Collections.Generic;

namespace Data
{

    public class SqlDataAccessArgs
    {
        public static SqlDataAccessArgs CreateWith(string name, object value)
        {
            return new SqlDataAccessArgs(name, value);
        }
        public SqlDataAccessArgs And(string name, object value)
        {
            this.args[name] = value;
            return this;
        }
public IDictionary<string, object> Arguments
        {
            get { return this.args; }
        }

        private SqlDataAccessArgs(string name, object value)
        {
            this.args[name] = value;
        }

        private IDictionary<string, object> args = new Dictionary<string, object>();
    }
}
