using SevenWinBackend.Common;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWinBackend.Domain.Common
{
    /// <summary>
    /// SQL构建器
    /// </summary>
    public class SqlBuilder
    {
        /// <summary>
        /// SQL查询
        /// </summary>
        public class Query
        {
            /// <summary>
            /// SQL语句
            /// </summary>
            public readonly string Sql;
            private readonly Dictionary<string, object> Parameters;

            internal Query(string sql, Dictionary<string, object> parameters)
            {
                Sql = sql;
                this.Parameters = parameters ?? throw new ArgumentNullException(nameof(parameters));
            }

            /// <summary>
            /// 获取动态参数对象
            /// </summary>
            public ExpandoObject DynamicParameters
            {
                get
                {
                    var obj = new ExpandoObject();
                    foreach (var item in this.Parameters)
                    {
                        DynamicHelper.SetPropertyValue(obj, item.Key, item.Value);
                    }
                    return obj;
                }
            }
        }

        private StringBuilder StringBuilder { get; set; } = new StringBuilder();
        private Dictionary<string, object> Parameters { get; set; } = new Dictionary<string, object>();
        /// <summary>
        /// 在末尾添加SQL语句
        /// </summary>
        public SqlBuilder AppendToEnd(string sql)
        {
            this.StringBuilder.Append(" " + sql + " ");
            return this;
        }

        /// <summary>
        /// 在开头添加SQL语句
        /// </summary>
        public SqlBuilder InsertToStart(string sql)
        {
            this.StringBuilder.Insert(0, " " + sql + "");
            return this;
        }
        /// <summary>
        /// 增加参数
        /// </summary>
        public SqlBuilder AddParameter(string name, object value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }
            if (value.GetType().IsEnum)
            {
                this.Parameters.Add(name, (int)value);
            }
            else
            {
                this.Parameters.Add(name, value);
            }
            return this;
        }
        /// <summary>
        /// 设置读取几条数据
        /// </summary>
        public SqlBuilder SetLimit(int limit)
        {
            if (limit <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(limit));
            }
            this.AppendToEnd("limit @p_limit");
            this.AddParameter("p_limit", limit);
            return this;
        }

        /// <summary>
        /// 设置跳过几条数据
        /// </summary>
        public SqlBuilder SetOffset(int offset)
        {
            if (offset < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(offset));
            }
            this.AppendToEnd("OFFSET @p_offset");
            this.AddParameter("p_offset", offset);
            return this;
        }
        /// <summary>
        /// 设置分页
        /// </summary>
        public SqlBuilder SetPaging(int currentPage = 1, int pageSize = 10)
        {
            if (currentPage <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(currentPage));
            }
            if (pageSize <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(pageSize));
            }
            this.SetLimit(pageSize).SetOffset((currentPage - 1) * pageSize);
            return this;
        }

        /// <summary>
        /// 获取查询
        /// </summary>
        /// <returns></returns>
        public Query GetQuery()
        {
            Dictionary<string, object> newList = new Dictionary<string, object>();
            foreach (var item in this.Parameters)
            {
                newList.Add(item.Key, item.Value);
            }
            return new Query(this.ToString(), newList);
        }

        /// <summary>
        /// 获取SQL字符串
        /// </summary>
        public override string ToString()
        {
            //return this.StringBuilder.ToString().Trim().Trim(';') + ";";
            return this.StringBuilder.ToString().Trim().Trim(';');
        }

        /// <summary>
        /// 克隆对象
        /// </summary>
        public object Clone()
        {
            SqlBuilder builder = new SqlBuilder();
            builder.StringBuilder.Append(this.StringBuilder.ToString());
            foreach (var item in this.Parameters)
            {
                builder.Parameters.Add(item.Key, item.Value);
            }
            return builder;
        }
    }
}
