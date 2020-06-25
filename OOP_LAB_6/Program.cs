using Microsoft.Data.SqlClient;
using System;

namespace OOP_LAB_6
{
    class Program
    {
        static void Main(string[] args)
        {
            // InsertData();
            string cn = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = RieltorsAgencyDB;Integrated Security = True;";

            using (var connection = new SqlConnection(cn))
            {
                connection.Open();
                Console.WriteLine("1.All available esates: ");
                string AllEstaes = "SELECT * FROM Estastes";
                var selectEstates = new SqlCommand(AllEstaes, connection);
                var sel = selectEstates.ExecuteReader();
                while (sel.Read())
                {
                    Console.WriteLine("ID:{0}; Type: {1}; Purpose: {2}; Registered number: {3}; Adress: {4}; " +
                        "Price: {5}$", sel[0],sel[1],sel[2],sel[3],sel[4],sel[5]); 
                }
                sel.Close();

                Console.WriteLine();
                Console.WriteLine("2.Brocers staff: ");
                string AllBrocers = "SELECT * FROM Brocers";
                var selectBrokers = new SqlCommand(AllBrocers, connection);
                var sel2 = selectBrokers.ExecuteReader();
                while (sel2.Read())
                {
                    Console.WriteLine("ID:{0}; FirstName: {1}; SecondName: {2}; AgencyId: {3}; ", sel2[0], sel2[1], sel2[2], sel2[3]);
                }
                sel2.Close();

                Console.WriteLine();
                Console.WriteLine("3.All Clients: ");
                string AllClients = "SELECT * FROM Clients";
                var selectClients = new SqlCommand(AllClients, connection);
                var sel3 = selectClients.ExecuteReader();
                while (sel3.Read())
                {
                    Console.WriteLine("ID: {0}; FirstName: {1}; SecondName: {2}; Phone Number: {3}; Registration number: {4}; ", sel3[0], sel3[1], sel3[2], sel3[3],sel3[4]);
                }
                sel3.Close();

                Console.WriteLine();
                Console.WriteLine("4.All sellings: ");
                string AllSales = "SELECT * FROM Estastes WHERE Purpose = 'Sell'";
                var selectSales = new SqlCommand(AllSales, connection);
                var sel4 = selectSales.ExecuteReader();
                while (sel4.Read())
                {
                    Console.WriteLine("ID:{0}; Type: {1}; Purpose: {2}; Registered number: {3}; Adress: {4}; " +
                        "Price: {5}", sel4[0], sel4[1], sel4[2], sel4[3], sel4[4], sel4[5]);
                }
                sel4.Close();
                

                Console.WriteLine();
                Console.WriteLine("5.The chipiest place to live: ");
                string chipRoom = "SELECT TOP 1 * FROM Estastes WHERE Purpose = 'Rent' ORDER BY Price DESC"; 
                var selectChipRoom = new SqlCommand(chipRoom, connection);
                var sel5 = selectChipRoom.ExecuteReader();
                while (sel5.Read())
                {
                    Console.WriteLine("The chipiest place to live is {0} which {1}s at the {2} for {3}$ ", sel5[1], sel5[2], sel5[4], sel5[5]);
                }
                sel5.Close();

                Console.WriteLine();
                Console.WriteLine("6.Which dealer sales each estimate: ");
                string whoSale = "SELECT Brocers.FirstName,Brocers.SecondName,Estastes.Address,Estastes.Type FROM (Contracts INNER JOIN Brocers ON Contracts.BrockerId = Brocers.BrockerId) INNER JOIN Estastes ON Contracts.EstateId = Estastes.EstateId ";  

                var selectWhoSale = new SqlCommand(whoSale, connection);
                var sel6 = selectWhoSale.ExecuteReader();
                while (sel6.Read())
                {
                    Console.WriteLine("{0} {1} Sales {3} at {2}", sel6[0], sel6[1], sel6[2],sel6[3]);
                }
                sel6.Close();


                Console.WriteLine();
                Console.WriteLine("7.The avaliable estimates: ");
                string avaEst = "SELECT * FROM Contracts RIGHT JOIN Estastes ON Contracts.EstateId = Estastes.EstateId WHERE ContractId is NULL";
                var selectAvaEst = new SqlCommand(avaEst, connection);
                var sel7 = selectAvaEst.ExecuteReader();
                while (sel7.Read())
                {
                    Console.WriteLine("{0} to {1} at {2} for {3}",  sel7[7], sel7[8],sel7[10],sel7[11]);
                }
                sel7.Close();

                Console.WriteLine();
                Console.WriteLine("8.Where lives clients: ");
                string whereClients = "SELECT Clients.FirstName,Clients.SecondName,Estastes.Address,Estastes.Type FROM (Contracts INNER JOIN Clients ON Contracts.CLientId = Clients.ClientId) INNER JOIN Estastes ON Contracts.EstateId = Estastes.EstateId WHERE Estastes.Purpose = 'Rent' OR Estastes.Purpose = 'Buy'";
                var selectWhereClients = new SqlCommand(whereClients, connection);
                var sel8 = selectWhereClients.ExecuteReader();
                while (sel8.Read())
                {
                    Console.WriteLine("{0} {1} lives in new {2} at {3}", sel8[0], sel8[1], sel8[3], sel8[2]);
                }
                sel8.Close();

                Console.WriteLine();
                Console.WriteLine("9.How to contact a brocer: ");
                string contactBrocer = "SELECT Brocers.FirstName ,Brocers.SecondName, Agencys.Name,Agencys.Phone FROM Brocers FULL OUTER JOIN Agencys ON Brocers.AgencyId = Agencys.AgencyId";
                var selectContactsBrocer = new SqlCommand(contactBrocer, connection);
                var sel9 = selectContactsBrocer.ExecuteReader();
                while (sel9.Read())
                {
                    Console.WriteLine("{0} {1} contact by {2}-phone number of <{3}> company", sel9[0], sel9[1], sel9[3], sel9[2]);
                }
                sel9.Close();

                Console.WriteLine();
                Console.WriteLine("10.Clients who want to sell property: ");
                string wantToSell = "SELECT Clients.FirstName,Clients.SecondName,Estastes.Type,Estastes.Address,Estastes.Price FROM (Contracts FULL OUTER JOIN Clients ON Clients.ClientId = Contracts.ClientId) left JOIN Estastes ON Estastes.EstateId = Contracts.EstateId WHERE Estastes.Purpose = 'Sell'";
                var selectSellingClients = new SqlCommand(wantToSell, connection);
                var sel10 = selectSellingClients.ExecuteReader();
                while (sel10.Read())
                {
                    Console.WriteLine("{0} {1} wanted to sell {2} at {3} for {4}$", sel10[0], sel10[1], sel10[2], sel10[3],sel10[4]);
                }
                sel10.Close();
                connection.Close();

            }
        }
        public static void InsertData()
        {
            string cn = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = RieltorsAgencyDB;Integrated Security = True;";

            using (var connection = new SqlConnection(cn))
            {
           
                connection.Open();
                string addAgency =
                "INSERT INTO Agencys(Name,Adress,Phone,DirectorName) SELECT 'BERI_KBARTIRY','Kiev,Yangelia 22','+380982824166','Mikyla Nikoliaev'" ;

                string addBrokers =
                "INSERT INTO Brocers(FirstName,SecondName,AgencyId) SELECT 'John','Black', '1'" +
                "INSERT INTO Brocers(FirstName,SecondName,AgencyId) SELECT 'Dean','White', '1'" +
                "INSERT INTO Brocers(FirstName,SecondName,AgencyId) SELECT 'Leam','Johnson', '1'" +
                "INSERT INTO Brocers(FirstName,SecondName,AgencyId) SELECT 'John','Sena', '1'" +
                "INSERT INTO Brocers(FirstName,SecondName,AgencyId) SELECT 'Andy','Marshal', '1'" +
                "INSERT INTO Brocers(FirstName,SecondName,AgencyId) SELECT 'Vasya','Petrov', '1'" +
                "INSERT INTO Brocers(FirstName,SecondName,AgencyId) SELECT 'Andrei','Belov', '1'" +
                "INSERT INTO Brocers(FirstName,SecondName,AgencyId) SELECT 'Anna','Clark', '1'" +
                "INSERT INTO Brocers(FirstName,SecondName,AgencyId) SELECT 'Jin','Marbles', '1'" +
                "INSERT INTO Brocers(FirstName,SecondName,AgencyId) SELECT 'Bob','Sponge', '1'" +
                "INSERT INTO Brocers(FirstName,SecondName,AgencyId) SELECT 'Patric','Stars', '1'";

                string addClients =
                "INSERT INTO Clients(FirstName,SecondName,PhoneNumber,RegistrationNumber) SELECT 'John','Snow', '452135','0156'" +
                "INSERT INTO Clients(FirstName,SecondName,PhoneNumber,RegistrationNumber) SELECT 'Robbert','Barateon', '789456','5468'" +
                "INSERT INTO Clients(FirstName,SecondName,PhoneNumber,RegistrationNumber) SELECT 'Aria','Stark', '12586','2354'" +
                "INSERT INTO Clients(FirstName,SecondName,PhoneNumber,RegistrationNumber) SELECT 'Ben','Ten', '654862','0629'" +
                "INSERT INTO Clients(FirstName,SecondName,PhoneNumber,RegistrationNumber) SELECT 'Aang','Avatar', '123548','5486'" +
                "INSERT INTO Clients(FirstName,SecondName,PhoneNumber,RegistrationNumber) SELECT 'Toph','Suong', '745892','7469'" +
                "INSERT INTO Clients(FirstName,SecondName,PhoneNumber,RegistrationNumber) SELECT 'Katara','Water', '12354','9865'" +
                "INSERT INTO Clients(FirstName,SecondName,PhoneNumber,RegistrationNumber) SELECT 'Soka','Water', '412532','1234'" +
                "INSERT INTO Clients(FirstName,SecondName,PhoneNumber,RegistrationNumber) SELECT 'Din','Winchester', '788945','05649'" +
                "INSERT INTO Clients(FirstName,SecondName,PhoneNumber,RegistrationNumber) SELECT 'Gerald','Rivia', '412584','65482'" +
                "INSERT INTO Clients(FirstName,SecondName,PhoneNumber,RegistrationNumber) SELECT 'Yenifer','Vengerberg', '354854','9784'";

                string addEstates =
                "INSERT INTO Estastes(Type,Purpose,RegistrationNumber,Address,Price) SELECT 'Flat','Sell', '2006','Vinnitsa,Pyrogova 107A','20000'" +
                "INSERT INTO Estastes(Type,Purpose,RegistrationNumber,Address,Price) SELECT 'House','Sell', '0620','Salnik','5000'" +
                "INSERT INTO Estastes(Type,Purpose,RegistrationNumber,Address,Price) SELECT 'House','Buy', '1778','Mariupol,Lenina 50B','25000'" +
                "INSERT INTO Estastes(Type,Purpose,RegistrationNumber,Address,Price) SELECT 'Room','Rent', '2000','Kyev,Yangelia 22','30'" +
                "INSERT INTO Estastes(Type,Purpose,RegistrationNumber,Address,Price) SELECT 'Flat','Buy', '1554','Kiev,Starokievskaya 1','350'" +
                "INSERT INTO Estastes(Type,Purpose,RegistrationNumber,Address,Price) SELECT 'Area','Sell', '5432','Berdiansk','200500'" +
                "INSERT INTO Estastes(Type,Purpose,RegistrationNumber,Address,Price) SELECT 'Room','Rent', '7894','Krim,Belyaus','200'" +
                "INSERT INTO Estastes(Type,Purpose,RegistrationNumber,Address,Price) SELECT 'Area','Buy', '7845','Miropilya','34500'" +
                "INSERT INTO Estastes(Type,Purpose,RegistrationNumber,Address,Price) SELECT 'Flat','Buy', '1445','Vinitsua,Aivazovskogo 5','65000'" +
                "INSERT INTO Estastes(Type,Purpose,RegistrationNumber,Address,Price) SELECT 'House','Sell', '4125','Sopyn','78000'";

                string addContracts =
                "INSERT INTO Contracts(RegistrationNumber,Date,BrockerId,ClientId,EstateId) SELECT '11','01.01.20', '1','1','1'" +
                "INSERT INTO Contracts(RegistrationNumber,Date,BrockerId,ClientId,EstateId) SELECT '22','02.02.20', '2','2','2'" +
                "INSERT INTO Contracts(RegistrationNumber,Date,BrockerId,ClientId,EstateId) SELECT '33','03.03.20', '2','3','3'" +
                "INSERT INTO Contracts(RegistrationNumber,Date,BrockerId,ClientId,EstateId) SELECT '44','04.04.20', '4','5','4'" +
                "INSERT INTO Contracts(RegistrationNumber,Date,BrockerId,ClientId,EstateId) SELECT '55','05.05.20', '5','4','5'" +
                "INSERT INTO Contracts(RegistrationNumber,Date,BrockerId,ClientId,EstateId) SELECT '66','06.06.20', '5','6','6'" +
                "INSERT INTO Contracts(RegistrationNumber,Date,BrockerId,ClientId,EstateId) SELECT '71','05.11.20', '7','7','7'" +
                "INSERT INTO Contracts(RegistrationNumber,Date,BrockerId,ClientId,EstateId) SELECT '35','12.06.20', '8','8','8'" +
                "INSERT INTO Contracts(RegistrationNumber,Date,BrockerId,ClientId,EstateId) SELECT '87','30.02.20', '9','9','9'" +
                "INSERT INTO Contracts(RegistrationNumber,Date,BrockerId,ClientId,EstateId) SELECT '99','09.09.19', '10','10','10'";




                var insertAgency = new SqlCommand(addAgency, connection);
                var insertBrokers = new SqlCommand(addBrokers, connection);
                var insertClients = new SqlCommand(addClients, connection);
                var insertEstates = new SqlCommand(addEstates, connection);
                var insertContracts = new SqlCommand(addContracts, connection);
                insertAgency.ExecuteNonQuery();
                insertBrokers.ExecuteNonQuery();
                insertClients.ExecuteNonQuery();
                insertEstates.ExecuteNonQuery();
                insertContracts.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
