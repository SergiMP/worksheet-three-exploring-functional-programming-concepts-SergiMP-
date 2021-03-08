# Worksheet Three

## Exploring functional programming concepts

1. `Action` Print  
	Write a program that reads a collection of strings from the console and then prints them onto the console. 
	Each name should be printed on a new line.  
	Use `Action<T>`.
	
	```
	Input: 
		One Two Three
	Output: 
		One
		Two
		Three
	```
2. Knights of Honour  
	Write a program that reads a collection of names as strings from the console and then appends `"Sir"` in front of every name and prints it back onto the console.   
	Use `Action<T>`.
	
	```
	Input: 
		Fred Betty John
		Joan
	Output:
		Sir Fred
		Sir Betty
		Sir John
		Sir Joan
	```
3. Custom `Min` Function  
	Write a simple program that reads from the console a set of numbers and prints back onto the console the smallest number from the collection.   
	Use `Func<T, T>`.
	
	```
	Input:
		12 4 3 2 1 7 13
	Output:
		1
	```

4. Find `Evens` or `Odds`  
	You are given a lower and an upper bound for a range of integer numbers. Then a command specifies if you need to list all the *even* or *odd* numbers in the given range.  
	Use `Predicate<T>`.
	
	```
	Input:
		1 10
		odd
	Output:
		1 3 5 7 9
	Input:
		20 30
		even
	Output:
		20 22 24 26 28 30
	```
5. Applied arithmetic  
	Write a program that executes some mathematical operations on a given collection. 
	On the first line you are given a list of numbers. 
	On the next lines you are passed different commands that you need to apply to all numbers in the list: 
	+ `"add" -> add 1 to each number`; 
	+ `"multiply" -> multiply each number by 2`; 
	+ `"subtract" -> subtract 1 from each number`; 
	+ `"print" -> print the collection`.  
	
	The input will end with and `"end"` command, after which you need to print the result.   
	Use functions.
	
	```
	Input:
		1 2 3 4 5
		add
		add
		print
		end
	Output:
		3 4 5 6 7
	Input:
		5 10
		multiply
		subtract
		print
		end
	Output:
		9 19
	```
6. Reverse and exclude  
	Write a program that reverses a collection and removes elements that are divisible by a given integer `n`.  
	Use predicates/functions.
	
	```
	Input:
		1 2 3 4 5 6
		2
	Output:
		5 3 1
	Input:
		20 10 40 30 60 50
		3
	Output:
		50 40 10 20
	```
	
7. Predicate for names  
	Write a program that filters a list of names according to their length. 
	On the first line you will be given integer `n` representing name length. 
	On the second line you will be given some names as strings separated by space. 
	Write a function that prints only the names whose length is **less than or equal** to `n`.
	
	```
	Input:
		4
		Kurnelia Qnaki Geo Muk Ivan
	Output:
		Geo
		Muk
		Ivan
	Input:
		4
		Karaman Asen Kiril Yordan
	Output:
		Asen
	```

8. Custom Comparator  
	Write a custom comparator that sorts all even numbers before all odd ones in ascending order. 
	Pass it to an `Array.sort()` function and print the result.
	
	```
	Input:
		1 2 3 4 5 6
	Output:
		2 4 6 1 3 5
	Input:
		-3 2
	Output:
		2 -3
	```
9. List of Predicates  
	Find all numbers in the range `1..N` that are divisible by the numbers of a given sequence.  
	Use predicates/functions.
	
	```
	Input:
		10
		1 1 1 2
	Output:
		0 2 4 6 8 10
	Input:
		100
		2 5 10 20
	Output:
		0 20 40 60 80 100
	```
10. Predicates Galore!  
	Fred's parents are on a vacation for the holidays and he is planning an epic party at home. 
	Unfortunately, his organisational skills are next to non-existent so you are given the task to help him with the reservations.
	
	On the first line you get a list with all the people that are coming. 
	On the next lines, until you get the `"Party!"` command, 
	you may be asked to double or remove all the people that apply to given criteria. 
	There are three different criteria are: 
	1. Everyone that has a name starting with a given string; 
	2. Everyone that has a name ending with a given string; 
	3. Everyone that has a name with a given length.  
	
	See the examples below:


	```
	Input:
		Peter Mark Steve
		Remove StartsWith P
		Double Length 5
		Party!
	Output:
		Mark, Mark, Steve are going to the party!
	Input:
		Peter
		Double StartsWith Pete
		Double EndsWith eter
		Party!
	Output:
		Peter, Peter, Peter, Peter are going to the party!
	```
	