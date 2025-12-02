using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    class Program
    {
        // === "Product" (Продукт) ===
        class Pizza
        {
            string dough;
            string sauce;
            string topping;

            public Pizza() { }
            public void SetDough(string d) { dough = d; }
            public void SetSauce(string s) { sauce = s; }
            public void SetTopping(string t) { topping = t; }

            public void Info()
            {
                Console.WriteLine("Dough: {0}\nSause: {1}\nTopping: {2}",
                    dough, sauce, topping);
            }
        }

        //  "Abstract Builder"
        abstract class PizzaBuilder
        {
            protected Pizza pizza;

            public PizzaBuilder() { }
            public Pizza GetPizza() { return pizza; }
            public void CreateNewPizza() { pizza = new Pizza(); }

            public abstract void BuildDough();
            public abstract void BuildSauce();
            public abstract void BuildTopping();
        }

        //  "Concrete Builder 1" (Гавайська)
        class HawaiianPizzaBuilder : PizzaBuilder
        {
            public override void BuildDough() { pizza.SetDough("cross"); }
            public override void BuildSauce() { pizza.SetSauce("mild"); }
            public override void BuildTopping()
            {
                pizza.SetTopping("ham+pineapple");
            }
        }

        // "Concrete Builder 2" (Гостра)
        class SpicyPizzaBuilder : PizzaBuilder
        {
            public override void BuildDough() { pizza.SetDough("pan baked"); }
            public override void BuildSauce() { pizza.SetSauce("hot"); }
            public override void BuildTopping()
            {
                pizza.SetTopping("pepparoni+salami");
            }
        }
        
        //  "Concrete Builder 3" (Маргарита н)
        class MargaritaPizzaBuilder : PizzaBuilder
        {
            public override void BuildDough() 
            { 
                pizza.SetDough("thin classic"); 
            }
            public override void BuildSauce() 
            { 
                pizza.SetSauce("tomato");
            }
            public override void BuildTopping() 
            {
                pizza.SetTopping("mozzarella+basil"); 
            }
        }

        //  "Director" 
        class Waiter
        {
            private PizzaBuilder pizzaBuilder;

            public void SetPizzaBuilder(PizzaBuilder pb) { pizzaBuilder = pb; }
            public Pizza GetPizza() { return pizzaBuilder.GetPizza(); }

            // Метод конструювання: послідовність кроків
            public void ConstructPizza()
            {
                pizzaBuilder.CreateNewPizza();
                pizzaBuilder.BuildDough();
                pizzaBuilder.BuildSauce();
                pizzaBuilder.BuildTopping();
            }
        }

        // (Main) 
        class BuilderExample
        {
            public static void Main(String[] args)
            {
                Waiter waiter = new Waiter();
                PizzaBuilder hawaiianPizzaBuilder = new HawaiianPizzaBuilder();
                PizzaBuilder spicyPizzaBuilder = new SpicyPizzaBuilder();
                PizzaBuilder margaritaPizzaBuilder = new MargaritaPizzaBuilder(); // Створення Margarita Builder
                Pizza pizza;

                // 1. Готуємо Гавайську
                waiter.SetPizzaBuilder(hawaiianPizzaBuilder);
                waiter.ConstructPizza();
                pizza = waiter.GetPizza();
                Console.WriteLine("--- Hawaiian Pizza ---");
                pizza.Info();

                // 2. Готуємо Гостру
                waiter.SetPizzaBuilder(spicyPizzaBuilder);
                waiter.ConstructPizza();
                pizza = waiter.GetPizza();
                Console.WriteLine("\n--- Spicy Pizza ---");
                pizza.Info();
                
                // 3. Готуємо Маргариту
                waiter.SetPizzaBuilder(margaritaPizzaBuilder); // Встановлюємо новий будівельник
                waiter.ConstructPizza();
                pizza = waiter.GetPizza();
                Console.WriteLine("\n--- Margarita Pizza ---");
                pizza.Info();

                Console.ReadKey();
            }
        }
    }
}
