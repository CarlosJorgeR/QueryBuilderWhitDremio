using System;
using System.Collections.Generic;
using System.Text;

namespace QueryBuilder.Client.Models
{
    public class Entity
    {
        public string RealName { get; set; }
        public string Alias { get; set; }
        public List<Entity_Attribute> atributes { get; set; }
    }
    public class Entity_Attribute
    {
        public string Name { get; set; }
        public BasicTypes Type { get; set; }
        public bool IsNumeric => IsType(BasicTypes.NUMERIC_TYPE);
        public bool IsText => IsType(BasicTypes.TEXT_TYPE);
        public bool IsDate => IsType(BasicTypes.DATE_TYPE);
        private bool IsType(BasicTypes basicType) => !((Type & basicType) == 0);
        public IEnumerable<OperatorType> Listoperators
        {
            get
            {
                if (IsNumeric)
                {
                    return new List<OperatorType> { OperatorType.Equal,
                                                    OperatorType.Diff,
                                                    OperatorType.GreaterThan,
                                                    OperatorType.GreaterThanEqual,
                                                    OperatorType.SmallerThan,
                                                    OperatorType.SmallerThanEqual,
                                                    OperatorType.Between};
                }
                else if (IsText)
                {
                    return new List<OperatorType> {
                                                    OperatorType.Contains,
                                                    OperatorType.StartWith,
                                                    OperatorType.EndWith,
                                                    OperatorType.Equal,
                                                    OperatorType.Diff};
                }
                else
                {
                    return new List<OperatorType> { OperatorType.Equal,
                                                    OperatorType.Diff,
                                                    OperatorType.GreaterThan,
                                                    OperatorType.GreaterThanEqual,
                                                    OperatorType.SmallerThan,
                                                    OperatorType.SmallerThanEqual,
                                                    OperatorType.Between};
                }
            }
        }

        public Entity_Attribute(string name, string type)
        {
            Name = name;
            Type= Enum.Parse<BasicTypes>(type);
        }
    }
}
