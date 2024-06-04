using System;
using System.Collections.Generic;
public class LaundryService
{
    public Random random = new Random();
    private static LaundryService _instance;
    public string CustomerName { get; set; }
    public string CustomerAddress { get; set; }
    public int ItemsToClean { get; set; }

    // Конструктор теперь является приватным, чтобы предотвратить создание экземпляра вне класса
    private LaundryService(string name, string address)
    {
        CustomerName = name;
        CustomerAddress = address;
    }

    // Метод для получения экземпляра класса
    public static LaundryService GetInstance(string name, string address)
    {
        if (_instance == null)
        {
            _instance = new LaundryService(name, address);
        }
        return _instance;
    }

    

    public int CalculateTotalCost()
    {       
        if(ItemsToClean <= 10)
        return ItemsToClean*10;
        else return ItemsToClean * 7+10;
    }

    public string PlaceOrder()
    {
        switch (random.Next(0, 4))
        {
            case 4:
                return("В системе возникла ошибка. Попробуйте еще раз.");
            case 3:
                return ("Извените, все машинки сейчас заняты, попробуйте позже.");
            case 2:
                return ("Извените, сейчас идет тех обслуживание машинок, попробуйте позже.");
            default:
                return ("Заказ успешно размещен.");
        }
    }
}
