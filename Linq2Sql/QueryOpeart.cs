using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

/*******************************************************
 * 
 * 作者：Justin.Jia
 * 文件名称：QueryOpeart
 * 创建日期：2017/1/14 22:12:11
 * 说明：详见代码内容
 * 运行环境：.NET 4.0
 * 版本号：1.0.0
 * 
 * 历史记录：
 * 创建文件 Justin.Jia 2017/1/14 22:12:11
 * 
*******************************************************/

namespace Linq2Sql
{
    public class QueryProvider : IQueryProvider
    {
        public void AnalysisExpression(Expression exp)
        {
            switch (exp.NodeType)
            {
                case ExpressionType.Call:
                    {
                        MethodCallExpression mce = exp as MethodCallExpression;
                        Console.WriteLine("The Method Is {0}", mce.Method.Name);
                        for (int i = 0; i < mce.Arguments.Count; i++)
                        {
                            AnalysisExpression(mce.Arguments[i]);
                        }
                    }
                    break;
                case ExpressionType.Quote:
                    {
                        UnaryExpression ue = exp as UnaryExpression;
                        AnalysisExpression(ue.Operand);
                    }
                    break;
                case ExpressionType.Lambda:
                    {
                        LambdaExpression le = exp as LambdaExpression;
                        AnalysisExpression(le.Body);
                    }
                    break;
                case ExpressionType.Equal:
                    {
                        BinaryExpression be = exp as BinaryExpression;
                        Console.WriteLine("The Method Is {0}", exp.NodeType.ToString());
                        AnalysisExpression(be.Left);
                        AnalysisExpression(be.Right);
                    }
                    break;
                case ExpressionType.Constant:
                    {
                        ConstantExpression ce = exp as ConstantExpression;
                        Console.WriteLine("The Value Type Is {0}", ce.Value.ToString());
                    }
                    break;
                case ExpressionType.Parameter:
                    {
                        ParameterExpression pe = exp as ParameterExpression;
                        Console.WriteLine("The Parameter Is {0}", pe.Name);
                    }
                    break;
                default:
                    {
                        Console.Write("UnKnow");
                    }
                    break;
            }
        }


        public IQueryable CreateQuery(Expression expression)
        {
            Type elementType = expression.Type;
            try
            {
                return (IQueryable)Activator.CreateInstance(typeof(Query<>).MakeGenericType(elementType), new object[] { this, expression });
            }
            catch (TargetInvocationException tie)
            {
                throw tie.InnerException;
            }
            //return new Query<str>(this, expression);
        }

        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            AnalysisExpression(expression);
            return new Query<TElement>(this,expression);
        }

        public object Execute(Expression expression)
        {
            return new Order() { OrderName="时光网" };
        }

        public TResult Execute<TResult>(Expression expression)
        {
            return (TResult)this.Execute(expression);
        }
    }

    public class Query<T> : IQueryable<T>
    {
        QueryProvider provider;

        Expression expression;

        public Query(QueryProvider _provider)
        {
            if (_provider == null)
            {
                throw new ArgumentNullException("provider");
            }
            this.provider = _provider;
            this.expression = Expression.Constant(this);
        }

        public Query(QueryProvider _provider, Expression _expression)
        {
            this.provider = _provider;
            this.expression = _expression;
        }

        public Type ElementType
        {
            get
            {
                return typeof(T); 
            }
        }

        public Expression Expression
        {
            get
            {
               return this.expression;
            }
        }

        public IQueryProvider Provider
        {
            get
            {
                return this.provider;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)this.provider.Execute(this.expression)).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)this.provider.Execute(this.expression)).GetEnumerator();
        }
    }

    public class QueryOrder<T>:IQueryable<T> where T:Order
    {
        QueryProvider provider;

        Expression expression;

        public QueryOrder(QueryProvider _provider)
        {
            if (_provider == null)
            {
                throw new ArgumentNullException("provider");
            }
            this.provider = _provider;
            this.expression = Expression.Constant(this);
        }

        public QueryOrder(QueryProvider _provider, Expression _expression)
        {
            this.provider = _provider;
            this.expression = _expression;
        }
        public Type ElementType
        {
            get
            {
                return typeof(Order);
            }
        }

        public Expression Expression
        {
            get
            {
                return this.expression;
            }
        }

        public IQueryProvider Provider
        {
            get
            {
                return provider;
            }
        }

        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)this.provider.Execute(this.expression)).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return ((IEnumerable<T>)this.provider.Execute(this.expression)).GetEnumerator();
        }
    }
}
