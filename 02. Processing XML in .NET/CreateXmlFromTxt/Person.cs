namespace CreateXmlFromTxt
{
    public class Person
    {
        public Person(string name, string address, string phone)
        {
            this.Name = name;
            this.Address = address;
            this.Phone = phone;
        }

        public string Name { get; private set; }
        public string Address { get; private set; }
        public string Phone { get; private set; }
    }
}
