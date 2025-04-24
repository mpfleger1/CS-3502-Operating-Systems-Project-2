using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace SchedulingAlgorithms
{
    /// <summary>
    /// This class represents a process with its attributes
    /// such as ProcessID, ArrivalTime, BurstTime, CompletionTime, TurnaroundTime, WaitingTime, and RemainingTime.
    /// </summary>
    public class Process
    {
        public int Id { get; set; }
        public int ArrivalTime { get; set; }
        public int BurstTime { get; set; }
        public int RemainingTime { get; set; }
        public int CompletionTime { get; set; }
        public int WaitingTime { get; set; }
        public int TurnaroundTime { get; set; }
    }

    public class Algorithms
    {
        /// <summary>
        /// Shortest Remaining Time First (SRTF) Scheduling Algorithm.
        /// This algorithm selects the process with the shortest remaining time to execute next.
        /// </summary>
        /// <param name="processes">List of processes to be scheduled</param>
        public static void srtfAlgo(List<Process> processes)
        {
            int time = 0; // Current time in the scheduling simulation
            int completed = 0; // Number of processes that have completed execution
            int n = processes.Count; // Total number of processes

            // Continue until all processes are completed
            while (completed != n)
            {
                Process shortest = null; // Variable to store the process with the shortest remaining time

                // Iterate through all processes to find the shortest remaining time process
                foreach (var process in processes)
                {
                    // Check if the process has arrived and still has remaining time
                    if (process.ArrivalTime <= time && process.RemainingTime > 0)
                    {
                        // Update the shortest process if it's null or the current process has a shorter remaining time
                        if (shortest == null || process.RemainingTime < shortest.RemainingTime)
                        {
                            shortest = process;
                        }
                    }
                }

                // If no process is ready to execute, increment the time and continue
                if (shortest == null)
                {
                    time++;
                    continue;
                }

                // Execute the shortest process for one unit of time
                shortest.RemainingTime--;

                // If the process has completed execution
                if (shortest.RemainingTime == 0)
                {
                    // Calculate completion time, turnaround time, and waiting time
                    shortest.CompletionTime = time + 1; // Completion time is the current time + 1
                    shortest.TurnaroundTime = shortest.CompletionTime - shortest.ArrivalTime; // Turnaround time
                    shortest.WaitingTime = shortest.TurnaroundTime - shortest.BurstTime; // Waiting time
                    completed++; // Increment the count of completed processes
                }

                // Increment the current time
                time++;
            }
        }

public static void mlfqAlgo(List<Process> processes, int[] quantum)
{
    int time = 0;
    var readyQueues = new Queue<Process>[quantum.Length];

    for (int i = 0; i < quantum.Length; i++)
    {
        readyQueues[i] = new Queue<Process>();
    }

    var pendingProcesses = new List<Process>(processes.OrderBy(p => p.ArrivalTime));

    while (pendingProcesses.Count > 0 || readyQueues.Any(q => q.Count > 0))
    {
        // Add newly arrived processes to the first queue
        for (int i = 0; i < pendingProcesses.Count;)
        {
            if (pendingProcesses[i].ArrivalTime <= time)
            {
                pendingProcesses[i].RemainingTime = pendingProcesses[i].BurstTime;
                readyQueues[0].Enqueue(pendingProcesses[i]);
                pendingProcesses.RemoveAt(i);
            }
            else i++;
        }

        bool didExecute = false;

        for (int i = 0; i < quantum.Length; i++)
        {
            if (readyQueues[i].Count == 0)
                continue;

            var process = readyQueues[i].Dequeue();

            // Execute the process
            int execTime = Math.Min(quantum[i], process.RemainingTime);
            time += execTime;
            process.RemainingTime -= execTime;

            // Check for newly arrived processes during execution
            for (int j = 0; j < pendingProcesses.Count;)
            {
                if (pendingProcesses[j].ArrivalTime <= time)
                {
                    pendingProcesses[j].RemainingTime = pendingProcesses[j].BurstTime;
                    readyQueues[0].Enqueue(pendingProcesses[j]);
                    pendingProcesses.RemoveAt(j);
                }
                else j++;
            }

            if (process.RemainingTime == 0)
            {
                process.CompletionTime = time;
                process.TurnaroundTime = process.CompletionTime - process.ArrivalTime;
                process.WaitingTime = process.TurnaroundTime - process.BurstTime;
            }
            else
            {
                // Demote to lower queue or stay in last queue
                if (i + 1 < quantum.Length)
                    readyQueues[i + 1].Enqueue(process);
                else
                    readyQueues[i].Enqueue(process);
            }

            didExecute = true;
            break; // Only execute one process per cycle
        }

        // If no process was executed, advance time
        if (!didExecute)
        {
            time++;
        }
    }
}


        public static void PerformanceMetrics(List<Process> processes)
        {
            int totalTime = processes.Max(p => p.CompletionTime);

            int totalProcesses = processes.Count; // Total number of processes
            // Waiting time
            double avgWaitingTime = processes.Average(p => p.WaitingTime);
            // Turnaround time
            double avgTurnaroundTime = processes.Average(p => p.TurnaroundTime);
            //Throughput/second
            double throughput = (double)totalProcesses / totalTime;
            // Cpu utilization
            double totalBurstTime = processes.Sum(p => p.BurstTime);
            double cpuUtil = (totalBurstTime / totalTime) * 100;
            

            
    

            // Display the performance metrics
            Console.WriteLine("Performance Metrics:");
            Console.WriteLine($"Total Processes: {totalProcesses}");
            Console.WriteLine($"Average Waiting Time: {avgWaitingTime:F2}");
            Console.WriteLine($"Average Turnaround Time: {avgTurnaroundTime:F2}");
            Console.WriteLine($"Throughput: {throughput:F2} processes/second");
            Console.WriteLine($"CPU Utilization: {cpuUtil:F2}%");
        }
    }
}