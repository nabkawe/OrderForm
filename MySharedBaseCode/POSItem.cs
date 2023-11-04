using LiteDB;
using System;
using System.ComponentModel;
using System.Net.NetworkInformation;

namespace sharedCode
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
        public POSDepartments()
        {

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

    public class PhoneLog : INotifyPropertyChanged
    {
        public PhoneLog() { }
        [BsonId]
        public int Id { get; set; }
        public DateTime CallDateTime { get; set; }

        private string _phoneNumber;
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                _phoneNumber = value;
                OnPropertyChanged(nameof(PhoneNumber));
            }
        }

        private string _customerName;
        public string CustomerName
        {
            get { return _customerName; }
            set
            {
                _customerName = value;
                OnPropertyChanged(nameof(CustomerName));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public string DisplayText
        {
            get { return $"{CustomerName} |  {PhoneNumber}  | {CallDateTime.ToString("hh:mm:sstt ddd")}"; }
        }
        public static PhoneLog NewPhoneLog(string phoneNumber)
        {
            PhoneLog phoneLog = new PhoneLog();
            phoneLog.PhoneNumber = phoneNumber;
            phoneLog.CallDateTime = DateTime.Now.AddTicks(-(DateTime.Now.Ticks % TimeSpan.TicksPerSecond));
            return phoneLog;
        }
    }


}

