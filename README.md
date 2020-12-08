# 1456. Maximum Number of Vowels in a Substring of Given Length

## Problem : 

Given a string s and an integer k.

Return the maximum number of vowel letters in any substring of s with length k.

Vowel letters in English are (a, e, i, o, u).

## Solution: 

### Approach 1: Sliding Window (Using Queue)

We will maintain a sliding window of size K and iterate over the input string S. 
Input guarantees that k < or equal to length of string S. 

We will maintain a queue of size K, we will keep on enqueing characters from the string array until the queue size is equal to K.
We will maintain two integer variables first to maintain count of vowels in the current window which we will reset everytime we change the window, and second to maintain the max count from all possible windows of size k. 
While enquing characters in queue we will verify if the enqueued character is a vowel, if it is a vowel we will increment the count of vowels found so far i.e. in the current window. When queue reaches size K, we will have the number of vowels found in this window, if the vowel count of this window is greater than previous global maximum we will update the global max vowel count. 
We will return the global max vowel count once we go through all the windows.

Following code written in C# solves the problem in O(n)
```
public int MaxVowels(string s, int k) {
        //Current Vowel count maintains the number of vowels in the current sliding window length k (Local Maxima)
        int currentVowelCount = 0;
        //Max Vowel maintains the max number of vowels found so far (Global Maxima)
        int maxVowelCount = 0;
        HashSet<char> vowels = new HashSet<char>(){'a','e','i','o','u'};
        Queue<char> q = new Queue<char>();        
        for(int i=0;i<s.Length;i++)
        {
            q.Enqueue(s[i]);            
            if(vowels.Contains(s[i]))
                currentVowelCount++;
            
            if(q.Count == k)
            {
                char removedChar = q.Dequeue();
                maxVowelCount = Math.Max(currentVowelCount,maxVowelCount);
                if(vowels.Contains(removedChar))
                    currentVowelCount--;
            }
        }       
        return maxVowelCount;
    }
```

## Time Complexity: 
This algorithm iterates over the string S once, hence the time complexity is linear i.e O(N) where n is length or size of the string S. 

## Space Complexity: 
We use a Queue to maintain a window of length K so the space complexity of this algorithm is O(K) 
