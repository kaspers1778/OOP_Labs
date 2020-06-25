using System;
using System.Linq;
using System.Collections.Generic;
namespace OOP_LAB_4
{
    class Program
    {
        static List<Client> Clients = new List<Client>()
    {
        new Client(1,"John Andersson","London","2809825659"),
        new Client(2,"Vasiliy Ivanov","Vena","4589562045"),
        new Client(3,"Arseniy Markow","Krakow","7856235453"),
        new Client(4,"Oleg Petrov","Kyiv","380985648216"),
        new Client(5,"Ann Black","New York","356498562")
    };

        static List<Car> Cars = new List<Car>()
    {
        new Car(1,"Renault Dokker","Hatchback",10846,2013),
        new Car(2,"Honda Accord X","Sedan",54580,2018),
        new Car(3,"Volkswagen Caddy","Hatchback",17927,2010),
        new Car(4,"Audi A8","Sedan",128721,2017),
        new Car(5,"Opel Astra J","Hatchback",15841,2012),
        new Car(6,"Mercedes-Benz Citan","Minibus",24692,2013)
    };

        static List<Transaction> Transactions = new List<Transaction>()
        {
            new Transaction(1,4,"01.06.20","26.06.20",500),
            new Transaction(2,2,"01.05.19","12.05.19",200)
        };

        static void Main(string[] args)
        {
            Console.WriteLine("List of cars");
            var q1 = from car in Cars
                     select car;
            foreach (var car in q1)
                Console.WriteLine(car);
            Console.WriteLine("\n");

            Console.WriteLine("List of clients");
            var q2 = from client in Clients
                     select client;
            foreach (var client in q2)
                Console.WriteLine(client);
            Console.WriteLine("\n");

            Console.WriteLine("List of transactions");
            var q3 = from transaction in Transactions
                     select transaction;
            foreach (var client in q3)
                Console.WriteLine(client);
            Console.WriteLine("\n");

            Console.WriteLine("All marks of cars");
            var q4 = from car in Cars
                     select car.mark;
            foreach (var car in q4)
                Console.WriteLine(car);
            Console.WriteLine("\n");

            Console.WriteLine("List of available cars");
            var q5_5 = from transaction in Transactions
                       select transaction.carId;
            var q5 = from car in Cars
                     where !q5_5.Contains(car.id)
                     select car;
            foreach (var car in q5)
                Console.WriteLine(car);
            Console.WriteLine("\n");

            Console.WriteLine("List of hatchbacks");
            var q6 = from car in Cars
                    where car.type == "Hatchback"
                    select car;
            foreach (var car in q6)
                Console.WriteLine(car);
            Console.WriteLine("\n");

            Console.WriteLine("List of sedans");
            var q7 = from car in Cars
                     where car.type == "Sedan"
                     select car;
            foreach (var car in q7)
                Console.WriteLine(car);
            Console.WriteLine("\n");

            Console.WriteLine("List of other types");
            var q8 = from car in Cars
                     where car.type != "Sedan" && car.type != "Hatchback"
                     select car;
            foreach (var car in q8)
                Console.WriteLine(car);
            Console.WriteLine("\n");

            Console.WriteLine("Cards sorted by price for hour");
            var q9 = from car in Cars
                     orderby car.priceForDay
                     select car;
            foreach (var car in q9)
                Console.WriteLine(car);
            Console.WriteLine("\n");

            Console.WriteLine("Clients that renting cars");
            var q10_5 = (from transaction in Transactions
                        select transaction.clientId).Distinct();
            var q10 = from client in Clients
                      where q10_5.Contains(client.id)
                      select client;
            foreach (var client in q10)
                Console.WriteLine(client);
            Console.WriteLine("\n");

            Console.WriteLine("The chepiest one from available");
            var f11 = (from car in q5 select car).First();
            Console.WriteLine(f11);
            Console.WriteLine("\n");

            Console.WriteLine("The average price for a day");
            var q12 = from car in Cars
                      select car.priceForDay;
            Console.WriteLine(q12.Average());
            Console.WriteLine("\n");

            Console.WriteLine("When rented cars will be available");
            var q13 = from car in Cars
                     from transation in Transactions
                     where car.id == transation.carId
                     select new { Car = car.mark, id = transation.carId, transation.finishDay };
            foreach (var x in q13)
                Console.WriteLine(x);
            Console.WriteLine("\n");

            Console.WriteLine("Amount of cars");
            var f14 = (from car in Cars select car).Count();
            Console.WriteLine(f14);
            Console.WriteLine("\n");

            Console.WriteLine("Clients sorted by Name");
            var q15 = Clients.Where((client) =>
            {
                return true;
            }).OrderBy(client => client.fullName);
            foreach(var x in q15)
                Console.WriteLine(x);
            Console.WriteLine("\n");
        }
    }

    public class Car
    {
        public int id;
        public string mark;
        public string type;
        public int carPrice;
        public int yearOfProdaction;
        public int priceForDay;
    
        public Car(int id,string m,string t,int cp,int yp)
        {
            this.id = id;
            this.mark = m;
            this.type = t;
            this.carPrice = cp;
            this.yearOfProdaction = yp;

            this.priceForDay = (carPrice / 100) / (DateTime.Now.Year - this.yearOfProdaction);
        }

        public override string ToString()
        {
            return "(Mark: " + this.mark + "; Type: " + this.type +
            "; Car price: " + this.carPrice + "; Year of production: "+ this.yearOfProdaction + "; Price for day:" + this.priceForDay + ")";
        }
    }

    public class Client
    {
        public int id;
        public string fullName;
        public string adress;
        public string phone;

        public Client(int id,string fn,string a,string p)
        {
            this.id = id;
            this.fullName = fn;
            this.adress = a;
            this.phone = p;
        }

        public override string ToString()
        {
            return "(Fullname: " + this.fullName + "; Adress: " + this.adress +
            "; Phone number: " + this.phone + ")";
        }
    }

   public class Transaction
    {
        public int clientId;
        public int carId;
        public string startDay;
        public string finishDay;
        public int deposit;

        public Transaction(int clientid,int carid,string sd,string fd,int d)
        {
            this.clientId = clientid;
            this.carId = carid;
            this.startDay = sd;
            this.finishDay = fd;
            this.deposit = d;
        }

        public override string ToString()
        {
            return "(Client: " + this.clientId + "; Car: " + this.carId +
            "; Start Day: " + this.startDay + "; Finish day:"+ this.finishDay + "; Deposit: "+ this.deposit + ")";
        }
    }
}
