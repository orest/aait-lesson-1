using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyStats.Models
{
    public class Family
    {
        public Family()
        {
            Children = new List<Person>();
        }
        public int FamilyId { get; set; }
        public string Nickname { get; set; }
        public Adult Father { get; set; }
        public Adult Mother { get; set; }

        public List<Person> Children { get; set; }

        public int AvgAge
        {
            get
            {
                var age = Father.Age + Mother.Age;

                foreach (var child in Children)
                {
                    age += child.Age;
                }

                return age / (2 + Children.Count);
            }
        }

        public Person OldestChild
        {
            get
            {
                if (this.Children.Count == 0)
                {
                    return null;
                }

                Person oldestChild = Children[0];

                foreach (var child in Children)
                {
                    if (child.Age > oldestChild.Age)
                    {
                        oldestChild = child;
                    }
                }
                return oldestChild;
            }
        }

        public override string ToString()
        {
            var separator = "    ";
            var builder = new StringBuilder();
            builder.AppendLine($"Family {Nickname}({FamilyId})");
            builder.AppendLine($"{separator}Parent");
            builder.AppendLine($"{separator}{separator}{Father.Name} - {DateTime.Now.Year - Father.DateOfBirth.Year}, {Father.Job}, {Father.LicenseNumber}");
            builder.AppendLine($"{separator}{separator}{Mother.Name} - {DateTime.Now.Year - Mother.DateOfBirth.Year}, {Mother.Job}, {Mother.LicenseNumber}");
            builder.AppendLine($"{separator}Kids");

            foreach (var child in Children)
            {
                builder.AppendLine($"{separator}{separator}{child.Name} - {DateTime.Now.Year - child.DateOfBirth.Year} ");
            }

            return builder.ToString();
        }
    }
}
