using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using sharedCode;

namespace OrderForm
{
    

    public class POSDepartments
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string DefaultPrinter { get; set; }

        public POSDepartments(string name, string defaultPrinter)
        {
            Name = name;
            DefaultPrinter = defaultPrinter;
        }
        public POSDepartments(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            if (Name != null)
            {
                return Name.ToString();
            }
            else return "Null";
        }
    }
    public class Contacts
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public string comments { get; set; }
        public Contacts() { }
        public Contacts(string name, string number, string comments)
        {
            Name = name;
            Number = number;
            this.comments = comments;
        }
    }
}

