/*
 * 3. You are given a cable TV company. 
 * The company needs to lay cable to a new 
 * neighborhood (for every house). 
 * If it is constrained to bury the cable only 
 * along certain paths, then there would be a graph 
 * representing which points are connected by those paths. 
 * But the cost of some of the paths is more
 * expensive because they are longer.
 * If every house is a node and every path 
 * from house to house is an edge, 
 * find a way to minimize the cost for cables.
 */
namespace _03.TV_Company
{
    using System;

    class TvCompanyDemo
    {
        static void Main()
        {
            var graph = new Graph<string>();


            graph.AddConnection("Studentski", "Durvenica", 20, true);
            graph.AddConnection("Studentski", "Mladost 1", 60, true);
            graph.AddConnection("Durvenica", "Mladost 1", 20, true);
            graph.AddConnection("Mladost 1", "Dianabad", 100, true);
            graph.AddConnection("Studentski", "Dianabad", 40, true);


            Console.WriteLine(graph);


            var result = graph.PrimeMinimumSpanningTree("Studentski");

            Console.WriteLine(" --- Minimum spanning Tree from Studentski: ");
            foreach (var edge in result)
            {
                Console.WriteLine(edge);
            }


        }
    }
}
