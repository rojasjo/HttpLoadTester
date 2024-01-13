# HTTP Load Tester

This is my solution to the [coding challenge #42](https://codingchallenges.fyi/challenges/challenge-load-tester/).
I've developed the solution in C# until step 5, and therefore, the command line application offers the following features:

- Send GET requests to the given URL
- Setup the number of requests to send
- Configure the number of users (threads)
- View the details of every single request
- View the result summary, including:
  - Number of total successful and failed requests
  - Total time of the test execution
  - Requests per second
  - Total request time
  - Time to first byte
  - Time to last byte

## CLI

The following is an example of a test that can be executed using the CLI:

```bash
./HttpLoadTester -u https://localhost:7102/api/v1/account/show -n 100 -c 5

```

The results are displayed as shown below:

```bash
Starting load tests
Progress: 100%
Results:
  Total Requests (2XX).......................: 100
  Failed Requests (5XX)......................: 0
  Total Time (s)..............................: 2.870733
  Request/second.............................: 34.83430886815319
Total Request Time (s) (Min, Max, Mean).....: 0.1028048, 0.2575234, 0.13826380100000002
Time to first byte (s) (Min, Max, Mean)....................: 0.1027517, 0.2574729, 0.138197584
Time to last byte (s) (Min, Max, Mean).....................: 7E-06, 0.0005965, 6.621700000000003E-05
```

Feel free to explore the capabilities of this tool and customize it as needed. If you encounter any issues or have suggestions for improvement, don't hesitate to contribute or open an issue.

Happy testing!