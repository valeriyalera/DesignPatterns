using System;
using System.Collections;

namespace Mediator.Examples
{
    //  "Colleague" 
    abstract class Colleague
    {
        protected Mediator mediator;

        // Constructor
        public Colleague(Mediator mediator)
        {
            this.mediator = mediator;
        }
    }

    //  "Mediator" 
    abstract class Mediator
    {
        public abstract void Send(string message, Colleague colleague);
    }

    //  "ConcreteMediator" 
    class ConcreteMediator : Mediator
    {
        private ConcreteColleague1 colleague1;
        private ConcreteColleague2 colleague2;
        private ConcreteColleague3 colleague3; // н

        public ConcreteColleague1 Colleague1
        {
            set { colleague1 = value; }
        }

        public ConcreteColleague2 Colleague2
        {
            set { colleague2 = value; }
        }
        
        public ConcreteColleague3 Colleague3 // н
        {
            set { colleague3 = value; }
        }

        public override void Send(string message, Colleague colleague)
        {
            // Логіка відправки повідомлення (наприклад, широкомовна розсилка)
            if (colleague == colleague1)
            {
                colleague2.Notify(message);
                if (colleague3 != null) colleague3.Notify(message); // Відправляємо також до c3
            }
            else if (colleague == colleague2)
            {
                colleague1.Notify(message);
                if (colleague3 != null) colleague3.Notify(message); // Відправляємо також до c3
            }
            else if (colleague == colleague3) // *** НОВА ЛОГІКА ДЛЯ Colleague3 ***
            {
                colleague1.Notify(message);
                colleague2.Notify(message);
            }
        }
    }

    //  "ConcreteColleague1" 
    class ConcreteColleague1 : Colleague
    {
        public ConcreteColleague1(Mediator mediator) : base(mediator) { }

        public void Send(string message)
        {
            mediator.Send(message, this);
        }

        public void Notify(string message)
        {
            Console.WriteLine("Colleague1 gets message: " + message);
        }
    }

    //  "ConcreteColleague2" 
    class ConcreteColleague2 : Colleague
    {
        public ConcreteColleague2(Mediator mediator) : base(mediator) { }

        public void Send(string message)
        {
            mediator.Send(message, this);
        }

        public void Notify(string message)
        {
            Console.WriteLine("Colleague2 gets message: " + message);
        }
    }
    
    //  н "ConcreteColleague3"
    class ConcreteColleague3 : Colleague
    {
        public ConcreteColleague3(Mediator mediator) : base(mediator) { }

        public void Send(string message)
        {
            mediator.Send(message, this);
        }

        public void Notify(string message)
        {
            Console.WriteLine("Colleague3 gets message: " + message);
        }
    }

    //  Mainapp test application 
    class MainApp
    {
        static void Main()
        {
            ConcreteMediator m = new ConcreteMediator();
            ConcreteColleague1 c1 = new ConcreteColleague1(m);
            ConcreteColleague2 c2 = new ConcreteColleague2(m);
            ConcreteColleague3 c3 = new ConcreteColleague3(m); // н

            m.Colleague1 = c1;
            m.Colleague2 = c2;
            m.Colleague3 = c3; // ДОДАВАННЯ c3 ДО ПОСЕРЕДНИКА 

            Console.WriteLine("--- Повідомлення між c1 та c2 ---");
            m.Send("How are you?", c1);
            m.Send("Fine, thanks", c2);
            
            Console.WriteLine("\n--- Повідомлення від нового Colleague3 ---");
            c3.Send("Hello!"); // ВІДПРАВКА ПОВІДОМЛЕННЯ ВІД c3 

            // Wait for user
            Console.Read();
        }
    }
}