using System;
using System.Text;

internal class Sapper
{
    private static void Main(string[] args)
    {
        // Init
        const string HOVER_CMD = "hover";
        const string CUT_CMD = "cut";
        const string EXPLODE = "BOOM";
        const string RED_WIRE = "red";
        const string DISARMED = "disarmed";
        const string CAPACITOR = "*";
        const string BLANK = "-";
        const string MISSED = "missed";
        const int PANEL_WIDTH = 16;

        StringBuilder result = new StringBuilder();

        int mask;
        int leftCircuitFiguresCount = 0;
        int rightCircuitFiguresCount = 0;
        bool exploded = false;
        bool? cutTheRedWire = null;
        string currentCommand = string.Empty;

        int currentX;
        int currentY;

        int currentRow = -1;
        int upperRow = -1;
        int lowerRow = -1;

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

        // Counting the figures
        for (int currentLine = 1; currentLine < PANEL_WIDTH - 1; currentLine++)
        {
            // Selecting current line and assigning upper and lower lines as well
            switch (currentLine)
            {
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

                default:
                    break;
            }

            // Counting
            for (int i = 1; i < 15; i++)
            {
                mask = 1 << i;

                if ((currentRow & mask) == 0 &&
                    (upperRow & mask) > 0 &&
                (lowerRow & mask) > 0)
                {
                    mask = mask << 1;

                    if ((currentRow & mask) > 0 &&
                        (upperRow & mask) > 0 &&
                        (lowerRow & mask) > 0)
                    {
                        mask = mask >> 2;

                        if ((currentRow & mask) > 0 &&
                        (upperRow & mask) > 0 &&
                        (lowerRow & mask) > 0)
                        {
                            if (i > 7)
                            {
                                leftCircuitFiguresCount++;
                            }
                            else
                            {
                                rightCircuitFiguresCount++;
                            }

                            i += 2;
                        }
                    }
                }
            }
        }

        // Reading commands
        while (true)
        {
            currentCommand = Console.ReadLine();

            if (currentCommand == CUT_CMD)
            {
                currentCommand = Console.ReadLine();

                if (currentCommand == RED_WIRE)
                {
                    cutTheRedWire = true;

                    if (leftCircuitFiguresCount != 0)
                    {
                        exploded = true;
                    }
                }
                else
                {
                    cutTheRedWire = false;

                    if (rightCircuitFiguresCount != 0)
                    {
                        exploded = true;
                    }
                }

                break;
            }
            else // hover or operate
            {
                // Read the requested position
                currentY = int.Parse(Console.ReadLine());
                currentX = PANEL_WIDTH - (int.Parse(Console.ReadLine()) + 1); // convert to bit position
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

                if (currentCommand == HOVER_CMD) // displays the current position
                {
                    if ((currentRow & mask) > 0)
                    {
                        result.AppendLine(CAPACITOR);
                    }
                    else
                    {
                        result.AppendLine(BLANK);
                    }
                }
                else // operates at the current position
                {
                    if ((currentRow & mask) > 0) // there is a capacitor so BOOM :)
                    {
                        exploded = true;
                        break;
                    }

                    // If there is no figure -> do nothing
                    if (!((upperRow & mask) > 0 &&
                        (lowerRow & mask) > 0 &&
                        (upperRow & (mask << 1)) > 0 &&
                        (upperRow & (mask >> 1)) > 0 &&
                        (lowerRow & (mask >> 1)) > 0 &&
                        (lowerRow & (mask << 1)) > 0
                        ))
                    {
                        continue;
                    }
                    // Kill all capacitors -> breaks the figure
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

                    // Record the change
                    if (currentX > 7)
                    {
                        leftCircuitFiguresCount--;
                    }
                    else
                    {
                        rightCircuitFiguresCount--;
                    }

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

        if (exploded)
        {
            if (cutTheRedWire.HasValue) // One of the wires was cut
            {
                if (cutTheRedWire == true)
                {
                    result.AppendLine(leftCircuitFiguresCount.ToString());
                }
                else
                {
                    result.AppendLine(rightCircuitFiguresCount.ToString());
                }
            }
            else // A capacitor was hit
            {
                result.AppendLine(MISSED);
                result.AppendLine((leftCircuitFiguresCount + rightCircuitFiguresCount).ToString());
            }

            result.AppendLine(EXPLODE); // Tell mama she was right :)
        }
        else // The warhead is dead -> Bira time :)
        {
            result.AppendLine((leftCircuitFiguresCount + rightCircuitFiguresCount).ToString());
            result.AppendLine(DISARMED);
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