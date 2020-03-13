using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyStats.Models
{
    public class MyTester
    {
        private readonly List<Family> _data;

        public MyTester(List<Family> data)
        {
            _data = data;
        }

        public List<Family> GetFamilyWithMostKids()
        {
            List<Family> response = new List<Family>();
            var maxNumberOfKids = 0;
            foreach (var family in _data)
            {
                if (family.Children.Count > maxNumberOfKids)
                {
                    maxNumberOfKids = family.Children.Count;
                }
            }

            foreach (var family in _data)
            {
                if (family.Children.Count == maxNumberOfKids)
                {
                    response.Add(family);
                }
            }
            return response;
        }

        public List<Family> GetFamilyWithNoKids()
        {
            List<Family> response = new List<Family>();
            foreach (var family in _data)
            {
                if (family.Children.Count == 0)
                {
                    response.Add(family);
                }
            }

            return response;
        }


        public List<Family> GetFamilyWithOldestChild()
        {
            List<Family> response = new List<Family>();

            int oldestChildAge = 0;
            foreach (var family in _data)
            {
                if (family.OldestChild != null && family.OldestChild.Age > oldestChildAge)
                {
                    oldestChildAge = family.OldestChild.Age;
                }
            }

            foreach (var family in _data)
            {
                if (family.OldestChild != null && family.OldestChild.Age == oldestChildAge)
                {
                    response.Add(family);
                }
            }

            return response;
        }

        public List<Family> GetFamilyByName(string nameToFind)
        {
            List<Family> response = new List<Family>();
            foreach (var family in _data)
            {
                if (family.Father.Name.Equals(nameToFind, StringComparison.CurrentCultureIgnoreCase)
                    || family.Mother.Name.Equals(nameToFind, StringComparison.CurrentCultureIgnoreCase))
                {
                    response.Add(family);
                }
                else
                {
                    foreach (var familyChild in family.Children)
                    {
                        if (familyChild.Name.Equals(nameToFind, StringComparison.CurrentCultureIgnoreCase))
                        {
                            response.Add(family);
                            break;
                        }
                    }
                }
            }

            return response;
        }
    }
}
