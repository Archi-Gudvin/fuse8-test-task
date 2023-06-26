try
{
    //количество наборов
    int NumberOfSets = Convert.ToInt32(Console.ReadLine());

    if (NumberOfSets > Math.Pow(10, 4) || NumberOfSets < 1)
    {
        Console.WriteLine("Превышен лимит числа");
    }


    //общие суммы к оплате наборам
    List<int> AmountToBePaid = new List<int>(NumberOfSets);

    for (int i = 0; i <= NumberOfSets - 1; i++)
    {
        //количество купленных товаров
        int NumberOfGoods = Convert.ToInt32(Console.ReadLine());

        if (NumberOfGoods > 2 * Math.Pow(10, 5) || NumberOfGoods < 1)
        {
            Console.WriteLine("Превышен лимит числа");
        }

        //цены купленных товаров
        List<int> PricesOfGoods = new List<int>();

        string[] prices = Console.ReadLine().Split(' ');

        //заполняем массив цен 
        for (int p = 0; p < NumberOfGoods; p++)
        {
            PricesOfGoods.Add(Convert.ToInt32(prices[p]));
        }

        if (PricesOfGoods.Count > Math.Pow(10, 4) || PricesOfGoods.Count < 1)
        {
            Console.WriteLine("Превышен лимит числа");
        }

        PricesOfGoods.Sort();

        //опеределяем цены за один товар их количество повторов
        var selectPrice = from p in PricesOfGoods
                          group p by p into g
                          select new { p = g.Key, Count = g.Count() };

        foreach (var price in selectPrice)
        {
            int amount = price.Count / 3;

            AmountToBePaid.Add(price.p * (price.Count - amount));
        }
    }

    Console.WriteLine();

    foreach (var item in AmountToBePaid)
    {
        Console.WriteLine(item);
    }

    Console.ReadLine();
}
catch (Exception ex) { Console.WriteLine(ex.Message); }


