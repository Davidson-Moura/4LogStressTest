using _4LogStressTest;

while (true)
{
    try
    {
        Thread.Sleep(2000);

        for (int i = 0; i < 5; i++)
            try
            {
                SLService.CreateDoc();
            }catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        try
        {
            PackingListService.CreatePk();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.ToString());
    }
}

Console.ReadKey();