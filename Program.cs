using System.Linq;
using System.Text.Json;
class MojaKlasa
{
    static void Main(string[] args)
    {
        List<Employee> employees=new List<Employee>();
        foreach( string s in File.ReadAllLines("employees.csv").Skip(1)){
            employees.Add(Employee.FromCsv(s));
        }

        List<Territories> territories=new List<Territories>();
        foreach( string s in File.ReadAllLines("territories.csv").Skip(1)){
            territories.Add(Territories.FromCsv(s));
        }

        List<Region> regions=new List<Region>();
        foreach( string s in File.ReadAllLines("regions.csv").Skip(1)){
            regions.Add(Region.FromCsv(s));
        }

        List<EmployeeTerritories> employeeTerritories=new List<EmployeeTerritories>();
        foreach( string s in File.ReadAllLines("employee_territories.csv").Skip(1)){
            employeeTerritories.Add(EmployeeTerritories.FromCsv(s));
        }

        List<Order> orders=new List<Order>();
        foreach( string s in File.ReadAllLines("orders.csv").Skip(1)){
            orders.Add(Order.FromCsv(s));
        }

        List<OrderDetail> ordersDetails=new List<OrderDetail>();
        foreach( string s in File.ReadAllLines("orders_details.csv").Skip(1)){
            ordersDetails.Add(OrderDetail.FromCsv(s));
        }
        


        var pierwszeQuery=from p in employees select new{nazwisko=p.lastname};
        foreach(var x in pierwszeQuery){
            Console.WriteLine(x);
        }

        var drogieQuery=from p in employees
        join et in employeeTerritories on p.employeeid equals et.employeeId
        join t in territories on et.territoryId equals t.territoryId
        join r in regions on t.regionId equals r.regionId
        select new{nazwisko=p.lastname, nazwaRegionu=r.regionDescription,nazwaTerytorium=t.territoryDescription};

        foreach(var x in drogieQuery){
            Console.WriteLine(x);
        }

        var trzecieQuery="?";

        var czwarteQuery=from r in regions
        join t in territories on r.regionId equals t.regionId
        join et in employeeTerritories on t.territoryId equals et.territoryId
        join e in employees on et.employeeId equals e.employeeid
        group r by r.regionDescription into z
        select new{nazwaRegionu=z.Key,supracownikow=z.Count()};
       
       foreach(var x in czwarteQuery){
        Console.WriteLine(x);
       }
    }
}

class Region{
    public string ?regionId{get;set;}
    public string ?regionDescription{get;set;}

    public static Region FromCsv(string csvline){
        string[] fields=csvline.Split(",");
        Region r=new Region();
        r.regionId=fields[0];
        r.regionDescription=fields[1];
        return r;
    }
    public override string  ToString(){
        return "Region: "+regionId+" Region Descripiton: "+regionDescription;
    }
}
class Territories{
    public string ?territoryId{get;set;}
    public string ?territoryDescription{get;set;}
    public string ?regionId{get;set;}
    public static Territories FromCsv(string csvline){
        string[] fields=csvline.Split(",");
        Territories t=new Territories();
        t.territoryId=fields[0];
        t.territoryDescription=fields[1];
        t.regionId=fields[2];
        return t;
    }
    public override string ToString(){
        return "TerritoryId: "+territoryId+" territoryDescription: "+territoryDescription+" RegionId "+regionId;
    }
}
class EmployeeTerritories{
    public string ?employeeId{get;set;}
    public string ?territoryId{get;set;}
    
    public static EmployeeTerritories FromCsv(string csvline){
        string[] fields=csvline.Split(",");
        EmployeeTerritories e=new EmployeeTerritories();
        e.employeeId=fields[0];
        e.territoryId=fields[1];
        return e;
    }
    public override string ToString(){
        return "employeeId: "+employeeId+" territoryId: "+territoryId;
    }
}
class Employee{
    public string ?employeeid{get;set;}
    public string ?lastname{get;set;}
    public string ?firstname{get;set;}
    public string ?title{get;set;}
    public string ?titleofcourtesy{get;set;}
    public string ?birthdate{get;set;}
    public string ?hiredate{get;set;}
    public string ?address{get;set;}
    public string ?city{get;set;}
    public string ?region{get;set;}
    public string ?postalcode{get;set;}
    public string ?country{get;set;}
    public string ?homephone{get;set;}
    public string ?extension{get;set;}
    public string ?photo{get;set;}
    public string ?notes{get;set;}
    public string ?reportsto{get;set;}
    public string ?photopath{get;set;}
    public static Employee FromCsv(string csvline){
        string[]fields=csvline.Split(",");
        Employee e=new Employee();
        e.employeeid=fields[0];
        e.lastname=fields[1];
        e.firstname=fields[2];
        e.title=fields[3];
        e.titleofcourtesy=fields[4];
        e.birthdate=fields[5];
        e.hiredate=fields[6];
        e.address=fields[7];
        e.city=fields[8];
        e.region=fields[9];
        e.postalcode=fields[10];
        e.country=fields[11];
        e.homephone=fields[12];
        e.extension=fields[13];
        e.photo=fields[14];
        e.notes=fields[15];
        e.reportsto=fields[16];
        e.photopath=fields[17];
        return e;
    }
    public override string ToString(){
        return "EmployeId: "+employeeid+" firstname: "+firstname+" lastName: "+lastname;
    }

}
public class Order{
    public string ?orderid{get;set;}
    public string ?customerid{get;set;}
    public string ?employeeid{get;set;}
    public string ?orderdate{get;set;}
    public string ?requireddate{get;set;}
    public string ?shippeddate{get;set;}
    public string ?shipvia{get;set;}
    public string ?freight{get;set;}
    public string ?shipname{get;set;}
    public string ?shipaddress{get;set;}
    public string ?shipcity{get;set;}
    public string ?shipregion{get;set;}
    public string ?shippostalcode{get;set;}
    public string ?shipcountry{get;set;}
        public static Order FromCsv(string csvline){
        string[]fields=csvline.Split(",");
        Order o=new Order();
        o.orderid=fields[0];
        o.customerid=fields[1];
        o.employeeid=fields[2];
        o.orderdate=fields[3];
        o.requireddate=fields[4];
        o.shippeddate=fields[5];
        o.shipvia=fields[6];
        o.freight=fields[7];
        o.shipname=fields[8];
        o.shipaddress=fields[9];
        o.shipcity=fields[10];
        o.shipregion=fields[11];
        o.shippostalcode=fields[12];
        o.shipcountry=fields[13];
        return o;
    }

}

public class OrderDetail{
    public string ?orderid{get;set;}
    public string ?productid{get;set;}
    public string ?unitprice{get;set;}
    public string ?quantity{get;set;}
    public string ?discount{get;set;}
    public static OrderDetail FromCsv(string csvline){
        string[]fields=csvline.Split(",");
        OrderDetail od=new OrderDetail();
        od.orderid=fields[0];
        od.productid=fields[1];
        od.unitprice=fields[2];
        od.quantity=fields[3];
        od.discount=fields[4];
        return od;
    }
}

