using System;
using System.Text;

internal class GameOfPage
{
    private static void Main(string[] args)
    {
        // Init
        const string WHAT_CMD = "what is";
        const string BUY_CMD = "buy";
        const string PAGE = "page";
        const string COOKIE = "cookie";
        const string PAY = "paypal";
        const string EMPTY = "smile";
        const string BROKEN = "broken cookie";
        const string CRUMB = "cookie crumb";
        const int TRAY_WIDTH = 16;
        const decimal COOKIE_COST = 1.79M;

        StringBuilder result = new StringBuilder();

        int mask;
        int soldCookiesCount = 0;
        string currentCommand = string.Empty;

        int currentX;
        int currentY;

        int currentRow = -1;
        int upperRow = -1;
        int lowerRow = -1;

        bool isCookie = false;

        // Input
        int n0 = Convert.ToInt32(Console.ReadLine(), 2);
        int n1 = Convert.ToInt32(Console.ReadLine(), 2);
        int n2 = Convert.ToInt32(Console.ReadLine(), 2);
        int n3 = Convert.ToInt32(Console.ReadLine(), 2);
        int n4 = Convert.ToInt32(Console.ReadLine(), 2);
        int n5 = Convert.ToInt32(Console.ReadLine(), 2);
        int n6 = Convert.ToInt32(Console.ReadLine(), 2);
        int n7 = Convert.ToInt32(Console.ReadLine(), 2);
        int n8 = Convert.ToInt32(Console.ReadLine(), 2);
        int n9 = Convert.ToInt32(Console.ReadLine(), 2);
        int n10 = Convert.ToInt32(Console.ReadLine(), 2);
        int n11 = Convert.ToInt32(Console.ReadLine(), 2);
        int n12 = Convert.ToInt32(Console.ReadLine(), 2);
        int n13 = Convert.ToInt32(Console.ReadLine(), 2);
        int n14 = Convert.ToInt32(Console.ReadLine(), 2);
        int n15 = Convert.ToInt32(Console.ReadLine(), 2);

        // Reading commands
        while (true)
        {
            currentCommand = Console.ReadLine();

            if (currentCommand == PAY)
            {
                decimal check = COOKIE_COST * soldCookiesCount;
                result.AppendLine(check.ToString());
                
                break;
            }
            else
            {
                // Read the requested position
                currentY = int.Parse(Console.ReadLine());
                currentX = TRAY_WIDTH - (int.Parse(Console.ReadLine()) + 1); // convert to bit position
                mask = 1 << currentX;

                switch (currentY) // assigning current row as well as upper and lower row
                {
                    case 0:
                        currentRow = n0;
                        upperRow = 0;
                        lowerRow = n1;
                        break;

                    case 1:
                        currentRow = n1;
                        upperRow = n0;
                        lowerRow = n2;
                        break;

                    case 2:
                        currentRow = n2;
                        upperRow = n1;
                        lowerRow = n3;
                        break;

                    case 3:
                        currentRow = n3;
                        upperRow = n2;
                        lowerRow = n4;
                        break;

                    case 4:
                        currentRow = n4;
                        upperRow = n3;
                        lowerRow = n5;
                        break;

                    case 5:
                        currentRow = n5;
                        upperRow = n4;
                        lowerRow = n6;
                        break;

                    case 6:
                        currentRow = n6;
                        upperRow = n5;
                        lowerRow = n7;
                        break;

                    case 7:
                        currentRow = n7;
                        upperRow = n6;
                        lowerRow = n8;
                        break;

                    case 8:
                        currentRow = n8;
                        upperRow = n7;
                        lowerRow = n9;
                        break;

                    case 9:
                        currentRow = n9;
                        upperRow = n8;
                        lowerRow = n10;
                        break;

                    case 10:
                        currentRow = n10;
                        upperRow = n9;
                        lowerRow = n11;
                        break;

                    case 11:
                        currentRow = n11;
                        upperRow = n10;
                        lowerRow = n12;
                        break;

                    case 12:
                        currentRow = n12;
                        upperRow = n11;
                        lowerRow = n13;
                        break;

                    case 13:
                        currentRow = n13;
                        upperRow = n12;
                        lowerRow = n14;
                        break;

                    case 14:
                        currentRow = n14;
                        upperRow = n13;
                        lowerRow = n15;
                        break;

                    case 15:
                        currentRow = n15;
                        upperRow = n14;
                        lowerRow = 0;
                        break;

                    default:
                        break;
                }

                isCookie = ((currentRow & mask) > 0 &&
                    (currentRow & (mask << 1)) > 0 &&
                    (currentRow & (mask >> 1)) > 0 &&
                    (lowerRow & mask) > 0 &&
                    (lowerRow & (mask << 1)) > 0 &&
                    (lowerRow & (mask >> 1)) > 0 &&
                    (upperRow & mask) > 0 &&
                    (upperRow & (mask << 1)) > 0 &&
                    (upperRow & (mask >> 1)) > 0);

                if (currentCommand == WHAT_CMD) // displays the current position
                {
                    if ((currentRow & mask) > 0)
                    {
                        if (isCookie)
                        {
                            result.AppendLine(COOKIE);
                        }
                        else
                        {
                            if ((currentRow & (mask << 1)) == 0 &&
                            (currentRow & (mask >> 1)) == 0 &&
                            (upperRow & mask) == 0 &&
                            (upperRow & (mask << 1)) == 0 &&
                            (upperRow & (mask >> 1)) == 0 &&
                            (lowerRow & mask) == 0 &&
                            (lowerRow & (mask << 1)) == 0 &&
                            (lowerRow & (mask >> 1)) == 0)
                            {
                                result.AppendLine(CRUMB);
                            }
                            else
                            {
                                result.AppendLine(BROKEN);
                            }
                        }
                    }
                    else
                    {
                        result.AppendLine(EMPTY);
                    }
                }
                else // try to buy the cookie
                {
                    if (!isCookie)
                    {
                        result.AppendLine(PAGE);
                        continue;
                    }

                    // Remove the cookie from the tray
                    currentRow ^= mask;
                    upperRow ^= mask;
                    lowerRow ^= mask;

                    mask = mask << 1;

                    currentRow ^= mask;
                    upperRow ^= mask;
                    lowerRow ^= mask;

                    mask = mask >> 2;

                    currentRow ^= mask;
                    upperRow ^= mask;
                    lowerRow ^= mask;

                    soldCookiesCount++;

                    // Update the real rows with the temp values
                    switch (currentY)
                    {
                        case 0:
                            n0 = currentRow;
                            n1 = lowerRow;
                            break;

                        case 1:
                            n1 = currentRow;
                            n0 = upperRow;
                            n2 = lowerRow;
                            break;

                        case 2:
                            n2 = currentRow;
                            n1 = upperRow;
                            n3 = lowerRow;
                            break;

                        case 3:
                            n3 = currentRow;
                            n2 = upperRow;
                            n4 = lowerRow;
                            break;

                        case 4:
                            n4 = currentRow;
                            n3 = upperRow;
                            n5 = lowerRow;
                            break;

                        case 5:
                            n5 = currentRow;
                            n4 = upperRow;
                            n6 = lowerRow;
                            break;

                        case 6:
                            n6 = currentRow;
                            n5 = upperRow;
                            n7 = lowerRow;
                            break;

                        case 7:
                            n7 = currentRow;
                            n6 = upperRow;
                            n8 = lowerRow;
                            break;

                        case 8:
                            n8 = currentRow;
                            n7 = upperRow;
                            n9 = lowerRow;
                            break;

                        case 9:
                            n9 = currentRow;
                            n8 = upperRow;
                            n10 = lowerRow;
                            break;

                        case 10:
                            n10 = currentRow;
                            n9 = upperRow;
                            n11 = lowerRow;
                            break;

                        case 11:
                            n11 = currentRow;
                            n10 = upperRow;
                            n12 = lowerRow;
                            break;

                        case 12:
                            n12 = currentRow;
                            n11 = upperRow;
                            n13 = lowerRow;
                            break;

                        case 13:
                            n13 = currentRow;
                            n12 = upperRow;
                            n14 = lowerRow;
                            break;

                        case 14:
                            n14 = currentRow;
                            n13 = upperRow;
                            n15 = lowerRow;
                            break;

                        case 15:
                            n15 = currentRow;
                            n14 = upperRow;
                            break;

                        default:
                            break;
                    }
                    //PrintLines(n0, n1, n2, n3, n4, n5, n6, n7, n8, n9, n10, n11, n12, n13, n14, n15);
                }
            }
        }

        Console.Write(result);
    }

    //private static void PrintLines(int n0, int n1, int n2, int n3, int n4, int n5, int n6, int n7, int n8, int n9, int n10, int n11, int n12, int n13, int n14, int n15)
    //{
    //    Console.WriteLine();
    //    Console.WriteLine(Convert.ToString(n0, 2).PadLeft(16, '0'));
    //    Console.WriteLine(Convert.ToString(n1, 2).PadLeft(16, '0'));
    //    Console.WriteLine(Convert.ToString(n2, 2).PadLeft(16, '0'));
    //    Console.WriteLine(Convert.ToString(n3, 2).PadLeft(16, '0'));
    //    Console.WriteLine(Convert.ToString(n4, 2).PadLeft(16, '0'));
    //    Console.WriteLine(Convert.ToString(n5, 2).PadLeft(16, '0'));
    //    Console.WriteLine(Convert.ToString(n6, 2).PadLeft(16, '0'));
    //    Console.WriteLine(Convert.ToString(n7, 2).PadLeft(16, '0'));
    //    Console.WriteLine(Convert.ToString(n8, 2).PadLeft(16, '0'));
    //    Console.WriteLine(Convert.ToString(n9, 2).PadLeft(16, '0'));
    //    Console.WriteLine(Convert.ToString(n10, 2).PadLeft(16, '0'));
    //    Console.WriteLine(Convert.ToString(n11, 2).PadLeft(16, '0'));
    //    Console.WriteLine(Convert.ToString(n12, 2).PadLeft(16, '0'));
    //    Console.WriteLine(Convert.ToString(n13, 2).PadLeft(16, '0'));
    //    Console.WriteLine(Convert.ToString(n14, 2).PadLeft(16, '0'));
    //    Console.WriteLine(Convert.ToString(n15, 2).PadLeft(16, '0'));
    //    Console.WriteLine();
    //}
}