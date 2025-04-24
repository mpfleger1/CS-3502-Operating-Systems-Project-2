using System;
using System.Collections.Generic;
using SchedulingAlgorithms; // Reference to the namespace containing the Algorithms and Process classes

namespace AlgorithmsTesting
{
    public class AlgorithmTesting
    {
        /// <summary>
        /// General test for both SRTF and MLFQ algorithms with a small set of processes.
        /// </summary>
        public static void GeneralTest()
        {
            // Initialize a small set of processes for SRTF
            var process1 = new List<Process>()
            {
                new Process { Id = 1, ArrivalTime = 0, BurstTime = 7, RemainingTime = 7 },
                new Process { Id = 2, ArrivalTime = 2, BurstTime = 4, RemainingTime = 4 },
                new Process { Id = 3, ArrivalTime = 4, BurstTime = 1, RemainingTime = 1 }
            };

            Console.WriteLine("General Test: SRTF Algorithm");
            Algorithms.srtfAlgo(process1); // Run the SRTF algorithm
            Algorithms.PerformanceMetrics(process1); // Display performance metrics for SRTF

            // Initialize a small set of processes for MLFQ
            var process2 = new List<Process>()
            {
                new Process { Id = 1, ArrivalTime = 0, BurstTime = 7, RemainingTime = 7 },
                new Process { Id = 2, ArrivalTime = 2, BurstTime = 4, RemainingTime = 4 },
                new Process { Id = 3, ArrivalTime = 4, BurstTime = 1, RemainingTime = 1 }
            };

            int[] quantum = { 2, 4, 8 }; // Define time quantum for MLFQ
            Console.WriteLine();
            Console.WriteLine("General Test: MLFQ Algorithm");
            Algorithms.mlfqAlgo(process2, quantum); // Run the MLFQ algorithm
            Algorithms.PerformanceMetrics(process2); // Display performance metrics for MLFQ
        }

        /// <summary>
        /// Large test case for both SRTF and MLFQ algorithms with 1000 processes.
        /// </summary>
        public static void LargeTestCase()
        {
            // Initialize 1000 processes for SRTF
            var processes1 = new List<Process>();
            for (int i = 0; i < 1000; i++)
            {
                processes1.Add(new Process { Id = i, ArrivalTime = i, BurstTime = i % 5, RemainingTime = i % 5 + 1 });
            }

            Console.WriteLine("Large Test Case: SRTF Algorithm");
            Algorithms.srtfAlgo(processes1); // Run the SRTF algorithm
            Algorithms.PerformanceMetrics(processes1); // Display performance metrics for SRTF

            // Initialize 1000 processes for MLFQ
            var processes2 = new List<Process>();
            for (int i = 0; i < 1000; i++)
            {
                processes2.Add(new Process { Id = i, ArrivalTime = i, BurstTime = i % 5, RemainingTime = i % 5 + 1 });
            }

            int[] quantum = { 2, 4, 8 }; // Define time quantum for MLFQ
            Console.WriteLine();
            Console.WriteLine("Large Test Case: MLFQ Algorithm");
            Algorithms.mlfqAlgo(processes2, quantum); // Run the MLFQ algorithm
            Algorithms.PerformanceMetrics(processes2); // Display performance metrics for MLFQ
        }

        /// <summary>
        /// Edge case tests for both SRTF and MLFQ algorithms.
        /// </summary>
        public static void EdgeCasesTest()
        {
            // Single process test for SRTF
            var singleProcess1 = new List<Process>()
            {
                new Process { Id = 1, ArrivalTime = 0, BurstTime = 5, RemainingTime = 5 }
            };
            Console.WriteLine("SRTF Algorithm Edge Case Test: Single Process");
            Algorithms.srtfAlgo(singleProcess1); // Run the SRTF algorithm
            Algorithms.PerformanceMetrics(singleProcess1); // Display performance metrics for SRTF

            // Single process test for MLFQ
            var singleProcess2 = new List<Process>()
            {
                new Process { Id = 1, ArrivalTime = 0, BurstTime = 5, RemainingTime = 5 }
            };

            int[] quantum = { 2, 4, 8 }; // Define time quantum for MLFQ
            Console.WriteLine();
            Console.WriteLine("MLFQ Algorithm Edge Case Test: Single Process");
            Algorithms.mlfqAlgo(singleProcess2, quantum); // Run the MLFQ algorithm
            Algorithms.PerformanceMetrics(singleProcess2); // Display performance metrics for MLFQ

            // Same arrival time test for SRTF
            var sameArrivalTimeProcess1 = new List<Process>()
            {
                new Process { Id = 1, ArrivalTime = 0, BurstTime = 5, RemainingTime = 5 },
                new Process { Id = 2, ArrivalTime = 0, BurstTime = 3, RemainingTime = 3 },
                new Process { Id = 3, ArrivalTime = 0, BurstTime = 4, RemainingTime = 4 }
            };
            Console.WriteLine();
            Console.WriteLine("SRTF Algorithm Edge Case Test: Same Arrival Time Process");
            Algorithms.srtfAlgo(sameArrivalTimeProcess1); // Run the SRTF algorithm
            Algorithms.PerformanceMetrics(sameArrivalTimeProcess1); // Display performance metrics for SRTF

            // Same arrival time test for MLFQ
            var sameArrivalTimeProcess2 = new List<Process>()
            {
                new Process { Id = 1, ArrivalTime = 0, BurstTime = 5, RemainingTime = 5 },
                new Process { Id = 2, ArrivalTime = 0, BurstTime = 3, RemainingTime = 3 },
                new Process { Id = 3, ArrivalTime = 0, BurstTime = 4, RemainingTime = 4 }
            };
            Console.WriteLine();
            Console.WriteLine("MLFQ Algorithm Edge Case Test: Same Arrival Time Process");
            Algorithms.mlfqAlgo(sameArrivalTimeProcess2, quantum); // Run the MLFQ algorithm
            Algorithms.PerformanceMetrics(sameArrivalTimeProcess2); // Display performance metrics for MLFQ
        }

        /// <summary>
        /// Main method to run all tests.
        /// </summary>
        public static void Main(string[] args)
        {
            GeneralTest(); // Run the general test
            Console.WriteLine(); // Print a new line for better readability
            LargeTestCase(); // Run the large test case
            Console.WriteLine(); // Print a new line for better readability
            EdgeCasesTest(); // Run the edge cases test
        }
    }
}