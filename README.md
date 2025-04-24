# 🧠 CPU Scheduling Algorithms: SRTF & MLFQ

This project implements two CPU scheduling algorithms in C#:

- **Shortest Remaining Time First (SRTF)**
- **Multi-Level Feedback Queue (MLFQ)**

Both algorithms are tested and evaluated using various scenarios including general tests, large-scale simulations, and edge cases to determine which is best for OwlTech Systems (fictional). 

---

## 📁 Project Structure

Requirements
.NET SDK (any recent version compatible with C# 7.0+)

Console environment

---

## 🚀 How to Run

1. Clone the repository or download the files.
2. Open the project in Visual Studio or any C#-compatible IDE.
3. Build and run the project.

The `Main` method in `AlgorithmTesting.cs` will automatically execute:
- General test
- Large-scale simulation with 1000 processes
- Edge case tests

---

## 📊 Performance Metrics

Each algorithm run displays the following metrics:

- **Average Waiting Time**
- **Average Turnaround Time**
- **Throughput** (processes per second)
- **CPU Utilization** (%)

These metrics are calculated and printed to the console for easy comparison.

---

## 🛠️ Requirements

- [.NET SDK](https://dotnet.microsoft.com/en-us/download) (any recent version)
- A console-compatible C# environment (e.g., Visual Studio, Rider, VS Code with C# extension)

---

## 🤖 Example Output

```bash
General Test: SRTF Algorithm
Performance Metrics:
Total Processes: 3
Average Waiting Time: 2.33
Average Turnaround Time: 5.00
Throughput: 0.27 processes/second
CPU Utilization: 100.00%
