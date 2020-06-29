using System;
using System.Collections.Generic;
using System.Text;

namespace QueryBuilder.Client.Models
{
    public class BasedQueryEntity
    {
        public List<string> Outputs { get; set; }
        public string TableName { get; set; }
        public string Alias { get; set; }

        public List<AbstractPredicate> predicates { get; set; }

    }
    public abstract class AbstractPredicate
    {
        public string Operator { get; set; }
        public string fieldName { get; set; }
        public string BasicType { get; set; }

        protected AbstractPredicate(OperatorType Operator, string fieldName, BasicTypes BasicType)
        {
            this.Operator = Operator.ToString();
            this.fieldName = fieldName;
            this.BasicType = BasicType.ToString();
        }
        public abstract string GetExpression();
        public string GetValue(string expression)
        {
            var dataType = Enum.Parse<BasicTypes>(this.BasicType);
            ///<summary>
            /// Cuando implementen el DataType
            ///</summary>
            if (!((dataType & BasicTypes.TEXT_TYPE) == 0)|| !((dataType & BasicTypes.DATE_TYPE) == 0))
                return $"'{expression}'";
            //else if (!((dataType & BasicTypes.NUMERIC_TYPE) == 0))
            //    return expression;
            //else
            //    return $"TO_DATE('{expression}', 'YYYY-MM-DD HH24:MI:SS')";
            else
                return expression;
        }
    }
    public class BasicPredicate:AbstractPredicate
    {
        public string Value { get; set; }
        public BasicPredicate(string fieldName, OperatorTypeBin Operator, BasicTypes BasicType, string Value):base((OperatorType)Operator,fieldName,BasicType)
        {
            this.Value = Value;
        }
        public override string GetExpression()
        {
            // TODO: Throws unsupported operations for field types.
            switch (Enum.Parse<OperatorType>(Operator))
            {
                case OperatorType.Contains:
                    return $"{this.fieldName} LIKE '%{this.Value}%'";
                case OperatorType.StartWith:
                    return $"{this.fieldName} LIKE '{this.Value}%'";
                case OperatorType.EndWith:
                    return $"{this.fieldName} LIKE '%{this.Value}'";
                case OperatorType.Equal:
                    return $"{this.fieldName} = {this.GetValue(this.Value)}";
                case OperatorType.Diff:
                    return $"{this.fieldName} != {this.GetValue(this.Value)}";
                case OperatorType.GreaterThan:
                    return $"{this.fieldName} > {this.GetValue(this.Value)}";
                case OperatorType.GreaterThanEqual:
                    return $"{this.fieldName} >= {this.GetValue(this.Value)}";
                case OperatorType.SmallerThan:
                    return $"{this.fieldName} < {this.GetValue(this.Value)}";
                case OperatorType.SmallerThanEqual:
                    return $"{this.fieldName} <= {this.GetValue(this.Value)}";
                default: return default;
            }
        }
    }
    public class BetweenPredicate : AbstractPredicate
    {
        public string Higher { get; set; }
        public string Lower { get; set; }
        public BetweenPredicate(string fieldName,string higher, string lower, BasicTypes BasicType) :base(OperatorType.Between,fieldName,BasicType)
        {
            Higher = higher;
            Lower = lower;
        }
        public override string GetExpression()
        {
            return $"{fieldName} Between {GetValue(Lower)} AND {GetValue(Higher)}";
        }


    }



}
