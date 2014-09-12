namespace TSUsingSourceDFS
{
    public class DFSTS
    {
        public static void Main()
        {
            var matrix = new int[,]
                             {
                                 { 0, 1, 0, 0, 1, 0 },
                                 { 0, 0, 1, 1, 0, 0 },
                                 { 0, 0, 0, 1, 0, 0 },
                                 { 0, 0, 0, 0, 1, 1 },
                                 { 0, 0, 0, 0, 0, 1 },
                                 { 0, 0, 0, 0, 0, 0 },
                             };

            var graph = new Graph(matrix);
            graph.TestDfs();
            graph.ShowSort();
        }
    }
}
