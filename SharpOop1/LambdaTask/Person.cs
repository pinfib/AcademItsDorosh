namespace Academits.Dorosh.LambdaTask
{
    public class Person
    {
        //private string _name;

        public string Name { get; set; }

        private int _age;

        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                if (value > 0)
                {
                    _age = value;
                }
            }
        }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public override string ToString()
        {
            return $"{Name} ({Age})";
        }
    }
}
