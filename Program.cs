// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");

var n = new NeuroTest();
n.computeWeights();

var t1 = @"
|   |
|X  |
|   |
";

Console.WriteLine("\n ---- Testing ---\n");
n.test(2,t1);

n.test(5, @"
|  X|
|   |
|   |
");

n.test(0, @"
|   |
|   |
|XX |
");

n.test(4, @"
| XX|
|   |
|X  |
");

n.test(6, @"
| X |
|  X|
| X |
");

n.test(2, @"
|XX |
|X  |
| X |
");

n.test(2, @"
|XXX|
|   |
|XXX|
");

n.test(2, @"
| XX|
|   |
|XXX|
");

n.test(2, @"
| X |
|   |
| X |
");

n.test(6, @"
| XX|
|   |
| XX|
");

n.summary();

