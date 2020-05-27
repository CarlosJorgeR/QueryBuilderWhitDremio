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

        public Entity_Attribute(string name, string type)
        {
            Name = name;
            Type= Enum.Parse<BasicTypes>(type);
        }
    }
}
